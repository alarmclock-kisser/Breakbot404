using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakbot404.Core
{
    public class SampleCutter
    {
        // Fields (wie in der Quelldatei definiert)
        public float MaxPeakAmplitude { get; set; } = 0.999f;
        public double MeasurementBlockDurationSeconds { get; set; } = 0.4;
        public double AbsoluteGatingThresholdDb { get; set; } = -70.0;
        public double RelativeGatingThresholdDb { get; set; } = 10.0;


        // References
        private readonly AudioCollection? Collection;


        // Lambda
        private double DbToRmsFactor(float dB) => Math.Pow(10.0, dB / 20.0);


        // Ctor
        public SampleCutter(AudioCollection? audioCollection = null)
        {
            this.Collection = audioCollection;
        }



        // Methods
        public async Task<IEnumerable<AudioObj>> AutoCutSamplesAsync(AudioObj original, float targetLufs = -12.4f, int minDurationMs = 75, int maxDurationMs = 750, int silenceWindowMs = 180, int maxWorkers = 4, IProgress<double>? progress = null)
        {
            maxWorkers = Math.Clamp(maxWorkers, 1, Environment.ProcessorCount);
            // Ergebnisse in Reihenfolge
            List<(long Index, AudioObj Audio)> cutSamples = [];

            // Progress-Helfer
            static double Clamp01(double v) => v < 0 ? 0 : (v > 1 ? 1 : v);
            void Report(double percent) => progress?.Report(Math.Max(0.0, Math.Min(100.0, percent)));

            // Phasen-Gewichte
            const double Phase1Weight = 40.0; // RMS-Profil
            const double Phase2Weight = 20.0; // Segmenterkennung
            const double Phase3Weight = 40.0; // Schneiden + Normalisieren

            Report(0.0);

            if (original.Data.Length == 0 || original.SampleRate == 0)
            {
                LogCollection.Log("Original audio data is empty or SampleRate is 0.");
                Report(100.0);
                return [];
            }

            // Konvertierung der Zeitparameter in Samples
            long msToSamples(int ms) => (long) ((double) ms / 1000.0 * original.SampleRate * original.Channels);

            long minLengthSamples = msToSamples(minDurationMs);
            long maxLengthSamples = msToSamples(maxDurationMs);

            // Definiere den Schwellenwert für Stille (z.B. -40 dBFS)
            const float silenceDetectionDb = -40.0f;
            double silenceThresholdRms = this.DbToRmsFactor(silenceDetectionDb);
            long totalSamples = original.Data.Length;

            // Fenstergröße für die RMS-Erkennung
            long rmsWindowSamples = msToSamples(50);
            if (rmsWindowSamples == 0)
            {
                rmsWindowSamples = original.Channels;
            }

            // Erstellen Sie ein RMS-Profil: Array von RMS-Werten für jedes 50ms-Fenster.
            int numRmsBlocks = (int) Math.Ceiling((double) totalSamples / rmsWindowSamples);
            bool[] isSilent = new bool[numRmsBlocks];

            // --- PHASE 1: RMS-Profil (PARALLEL) ---
            int doneRms = 0;
            int rmsReportStep = Math.Max(1, numRmsBlocks / 100); // ~1% Schritte

            await Task.Run(() =>
            {
                Parallel.For(0, numRmsBlocks, new ParallelOptions { MaxDegreeOfParallelism = maxWorkers }, blockIndex =>
                {
                    long start = blockIndex * rmsWindowSamples;
                    long end = Math.Min(start + rmsWindowSamples, totalSamples);

                    double sumOfSquares = 0;
                    for (long i = start; i < end; i++)
                    {
                        sumOfSquares += original.Data[i] * original.Data[i];
                    }

                    if (end - start > 0)
                    {
                        double rms = Math.Sqrt(sumOfSquares / (end - start));
                        // Markiere, ob der Block unter dem Schwellenwert liegt
                        isSilent[blockIndex] = rms < silenceThresholdRms;
                    }
                    else
                    {
                        isSilent[blockIndex] = true; // Ende des Arrays
                    }

                    int d = System.Threading.Interlocked.Increment(ref doneRms);
                    if (d % rmsReportStep == 0 || d == numRmsBlocks)
                    {
                        double inPhase = Clamp01(d / (double) Math.Max(1, numRmsBlocks));
                        Report(inPhase * Phase1Weight);
                    }
                });
            });

            // --- PHASE 2: SEGMENTERKENNUNG (sequentiell mit Fortschritt) ---
            long silenceWindowBlocks = msToSamples(silenceWindowMs) / rmsWindowSamples;
            long currentSegmentStartBlock = 0;
            long currentSegmentStartSample = 0;

            List<(long Start, long End)> segments = [];
            int doneScan = 0;
            int scanReportStep = Math.Max(1, numRmsBlocks / 100);

            for (int i = 0; i < numRmsBlocks; i++)
            {
                bool isSegmentEnd = false;

                // Überprüfen, ob eine Stille von ausreichender Dauer beginnt
                // Suche nach einer kontinuierlichen Kette von 'silenceWindowBlocks' stillen Blöcken
                if (!isSilent[i])
                {
                    // Wenn wir sprechen, zurücksetzen
                    currentSegmentStartBlock = i;
                    currentSegmentStartSample = currentSegmentStartBlock * rmsWindowSamples;
                }
                else
                {
                    // Wenn Stille erkannt wird
                    if (i - currentSegmentStartBlock >= silenceWindowBlocks)
                    {
                        isSegmentEnd = true;
                    }
                }

                // Zusätzliche Prüfung: Maximale Dauer erreicht?
                if (i * rmsWindowSamples - currentSegmentStartSample > maxLengthSamples)
                {
                    isSegmentEnd = true;
                }

                // Segment abschließen?
                if (isSegmentEnd)
                {
                    long segmentEndSample = i * rmsWindowSamples;
                    long segmentLength = segmentEndSample - currentSegmentStartSample;

                    if (segmentLength >= minLengthSamples)
                    {
                        segments.Add((currentSegmentStartSample, segmentEndSample));
                    }

                    // Setze den Segment-Start auf das Ende des aktuellen Blocks, um die Stille zu überspringen
                    currentSegmentStartBlock = i;
                    currentSegmentStartSample = currentSegmentStartBlock * rmsWindowSamples;
                }

                // Fortschritt Phase 2
                doneScan++;
                if (doneScan % scanReportStep == 0 || doneScan == numRmsBlocks)
                {
                    double inPhase = Clamp01(doneScan / (double) Math.Max(1, numRmsBlocks));
                    Report(Phase1Weight + inPhase * Phase2Weight);
                }
            }

            // Letztes Segment prüfen (von der letzten Startposition bis zum Ende)
            if (totalSamples - currentSegmentStartSample >= minLengthSamples)
            {
                segments.Add((currentSegmentStartSample, totalSamples));
            }

            // --- PHASE 3: SCHNEIDEN & NORMALISIEREN (pro Segment mit Fortschritt) ---
            int totalSegments = segments.Count;
            int doneSegments = 0;
            for (int si = 0; si < totalSegments; si++)
            {
                var (startSample, endSample) = segments[si];

                AudioObj? newCut = this.CreateCutAudioObj(original, startSample, endSample, si);
                if (newCut != null)
                {
                    await this.NormalizeLufsAsync(newCut, targetLufs, maxWorkers);
                    cutSamples.Add((startSample, newCut));
                }

                doneSegments++;
                double inPhase = totalSegments > 0 ? Clamp01(doneSegments / (double) totalSegments) : 1.0;
                Report(Phase1Weight + Phase2Weight + inPhase * Phase3Weight);
            }

            // Ausgabe sortiert
            var ordered = cutSamples.OrderBy(kv => kv.Index).Select(kv => kv.Audio);
            if (this.Collection != null)
            {
                foreach (var audio in ordered)
                {
                    this.Collection.Audios.Add(audio);
                }
            }

            Report(100.0);
            return ordered;
        }

        public async Task<AudioObj> TruncateAudioAsync(AudioObj original, double startSeconds = 0, double endSeconds = 0, bool createNew = false)
        {
            long startSample = (long) (startSeconds * original.SampleRate * original.Channels);
            long endSample = endSeconds > 0 ? (long) (endSeconds * original.SampleRate * original.Channels) : original.Data.Length;

            // Clamp
            startSample = Math.Clamp(startSample, 0, original.Data.Length);
            endSample = Math.Clamp(endSample, 0, original.Data.Length);
            AudioObj? truncated = this.CreateCutAudioObj(original, startSample, endSample, 0);
            if (truncated != null)
            {
                if (createNew)
                {
                    if (this.Collection != null)
                    {
                        this.Collection.Audios.Add(truncated);
                    }

                    return truncated;
                }

                // Original ersetzen
                original.Data = truncated.Data;
                original.Length = truncated.Length;
                original.Duration = truncated.Duration;
                return original;
            }

            return original;
        }

        public async Task<AudioObj> NormalizeLufsAsync(AudioObj original, float targetLufs = -16, int maxWorkers = 2)
        {
            maxWorkers = Math.Clamp(maxWorkers, 1, Environment.ProcessorCount);
            long totalSamples = original.Length * original.Channels;

            if (totalSamples == 0 || original.Data.Length == 0)
            {
                return original;
            }

            try
            {
                LogCollection.Log($"--- Starting LUFS Normalization (Target: {targetLufs} LUFS) ---");

                // --- SCHRITT 1: SEQUENTIELLE MESSUNG (Loudness-Bestimmung) ---
                Task<float> measurementTask = Task.Run(async () =>
                {
                    // Dieser Task muss sequentiell ausgeführt werden, da die Messung das gesamte File betrachtet.
                    return await this.CalculateIntegratedLufsAsync(original, maxWorkers);
                });

                float measuredLufs = await measurementTask;

                LogCollection.Log($"   -> Measured LUFS (RMS-Gated): {measuredLufs:F2}");

                // --- SCHRITT 2: GAIN BERECHNUNG ---

                float requiredGainDb = targetLufs - measuredLufs;
                double requiredGainFactor = Math.Pow(10.0, requiredGainDb / 20.0);

                LogCollection.Log($"   -> Required Gain: {requiredGainDb:F2} dB (Factor: {requiredGainFactor:F4})");

                // --- SCHRITT 3: PARALLELE GAIN-ANWENDUNG ---
                await this.ApplyGainParallel(original, requiredGainFactor, maxWorkers);

                // Objekt-Update
                original.Volume = (float) requiredGainFactor * original.Volume;

                LogCollection.Log("--- Normalization Complete ---");
            }
            catch (Exception ex)
            {
                // LogCollection.Log(ex); 
                LogCollection.Log($"An error occurred: {ex.Message}");
            }

            return original;
        }

        public Task<float> CalculateIntegratedLufsAsync(AudioObj audio, int maxWorkers)
        {
            // 1. Die gesamte CPU-gebundene Berechnung wird in Task.Run ausgelagert.
            return Task.Run(() => this.CalculateIntegratedLufsParallel(audio, maxWorkers));
        }



        // Private Methods
        private AudioObj? CreateCutAudioObj(AudioObj original, long startIndex, long endIndex, int sampleIndex)
        {
            long lengthSamples = endIndex - startIndex;
            if (lengthSamples <= 0)
            {
                return null;
            }

            // Erstellen des neuen Daten-Arrays
            float[] data = new float[lengthSamples];

            // Kopiere die Daten (paralleles Kopieren ist hier unnötig, da es ein kurzer Block ist)
            Array.Copy(original.Data, startIndex, data, 0, lengthSamples);

            // Erzeuge das neue AudioObj
            return new AudioObj
            {
                Name = $"{original.Name}_{sampleIndex:D3}", // Fortlaufende Nummerierung
                FilePath = original.FilePath, // Behält den Originalpfad
                Data = data,
                SampleRate = original.SampleRate,
                Channels = original.Channels,
                BitDepth = original.BitDepth,
                Length = lengthSamples / original.Channels, // Nur Samples pro Kanal
                Duration = TimeSpan.FromSeconds((double) lengthSamples / original.Channels / original.SampleRate),

                // Übernimm Metadaten
                Volume = original.Volume
                // ... weitere Metadaten ...
            };
        }

        private float CalculateIntegratedLufsParallel(AudioObj audio, int maxWorkers)
        {
            // 1. Definiere Blockgröße und Hilfsvariablen
            int sampleRate = audio.SampleRate;
            long totalSamples = audio.Data.Length;

            // Blockgröße in Samples: 400 ms * SampleRate
            long blockSizeSamples = (long) (this.MeasurementBlockDurationSeconds * sampleRate);
            if (blockSizeSamples <= 0)
            {
                return 0.0f;
            }

            // Gesamtanzahl der Blöcke
            int maxBlocks = (int) Math.Ceiling((double) totalSamples / blockSizeSamples);

            // Array für die Ergebnisse: thread-safe durch den Block-Index
            double[] blockLoudnessArray = new double[maxBlocks];


            // --- 2. Erzeuge Momentary Loudness für alle Blöcke (PARALLEL) ---

            // Wir parallelisieren über die Blöcke (beste Granularität).
            Parallel.For(0, maxBlocks, new ParallelOptions { MaxDegreeOfParallelism = maxWorkers }, blockIndex =>
            {
                long start = blockIndex * blockSizeSamples;
                long end = Math.Min(start + blockSizeSamples, totalSamples);

                // Berechne RMS für den aktuellen Block
                double sumOfSquares = 0;
                for (long i = start; i < end; i++)
                {
                    // **Wichtig:** Kein K-Weighting-Filter, nur RMS (wie im Originalcode).
                    sumOfSquares += audio.Data[i] * audio.Data[i];
                }

                if (end - start > 0)
                {
                    double rms = Math.Sqrt(sumOfSquares / (end - start));

                    // Konvertiere RMS (linear) in dBFS (Loudness)
                    double loudnessDb = 20.0 * Math.Log10(rms);

                    // Schreibe das Ergebnis thread-sicher in das Array
                    blockLoudnessArray[blockIndex] = loudnessDb;
                }
                // Block bleibt 0.0, falls leer (wird später im Gating entfernt)
            });

            // Konvertiere das Array in eine Liste für die sequentielle Gating-Logik
            List<double> blockLoudnessList = blockLoudnessArray.ToList();

            if (blockLoudnessList.Count <= 0)
            {
                return 0.0f;
            }

            // Absolute Gating
            var gatedLoudness = blockLoudnessList
                .Where(loudness => loudness > this.AbsoluteGatingThresholdDb)
                .ToList();

            if (gatedLoudness.Count <= 0)
            {
                return (float) this.AbsoluteGatingThresholdDb;
            }

            // Relative Gating (Muss sequentiell und iterativ bleiben)
            List<double> finalBlocks = [.. gatedLoudness];
            bool blocksRemoved = true;

            while (blocksRemoved)
            {
                blocksRemoved = false;
                double currentAverage = finalBlocks.Average();
                double relativeThreshold = currentAverage - this.RelativeGatingThresholdDb;

                var blocksToRemove = finalBlocks.Where(loudness => loudness < relativeThreshold).ToList();

                if (blocksToRemove.Count != 0)
                {
                    finalBlocks.RemoveAll(blocksToRemove.Contains);
                    blocksRemoved = true;
                }
            }

            // 5. Endresultat: Durchschnitt der verbleibenden Blöcke
            return (float) finalBlocks.Average();
        }

        private async Task ApplyGainParallel(AudioObj audio, double gainFactor, int maxWorkers = 2)
        {
            long totalSamples = audio.Data.Length;
            int chunkSize = audio.ChunkSize > 0 ? audio.ChunkSize : 4096;
            long maxChunks = (long) Math.Ceiling((double) totalSamples / chunkSize);

            await Task.Run(() =>
            {
                Parallel.For(0, maxChunks, new ParallelOptions { MaxDegreeOfParallelism = maxWorkers }, chunkIndex =>
                {
                    // Definiere den Bereich für den aktuellen Work-Group/Chunk
                    long start = chunkIndex * chunkSize;
                    long end = Math.Min(start + chunkSize, totalSamples);

                    for (long i = start; i < end; i++)
                    {
                        // 1. Gain anwenden
                        float newSample = (float) (audio.Data[i] * gainFactor);

                        // 2. Clipping verhindern (True Peak Limit)
                        audio.Data[i] = Math.Clamp(newSample, -this.MaxPeakAmplitude, this.MaxPeakAmplitude);
                    }
                });
            });
        }
    }
}