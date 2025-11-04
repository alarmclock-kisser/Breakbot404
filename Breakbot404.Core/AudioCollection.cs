using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Drawing;

namespace Breakbot404.Core
{
    public class AudioCollection
    {
        // Fields
        public string WorkingDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "_BreakBot404");
        public string ImportDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        public readonly BindingList<AudioObj> Audios = [];
        public readonly ConcurrentDictionary<Guid, CancellationToken> PlaybackCancellationTokens = [];

        public int BeatScanMinimumBpm { get; set; } = 70;
        public int BeatScanMaximumBpm { get; set; } = 210;

        public float TargetLufs { get; set; } = -14.0f;
        public int MinDurationMs { get; set; } = 50;
        public int MaxDurationMs { get; set; } = 650;
        public int SilenceWindowMs { get; set; } = 180;
        public double TruncateStartSeconds { get; set; } = 0.0;
        public double TruncateEndSeconds { get; set; } = 0.0;
        public bool KeepOriginal { get; set; } = false;



        // Objects
        public readonly AudioExporter Exporter;
        public readonly AudioRecorder Recorder;
        public readonly BeatScanner Scanner;
        public readonly SampleCutter Cutter;


        // Lambda
        public string ExportPath => Path.Combine(this.WorkingDirectory, "Breakbot404_Exports");
        public string RecordPath => Path.Combine(this.WorkingDirectory, "Breakbot404_Records");
        public int Count => this.Audios.Count;
        public IEnumerable<Guid> Ids => this.Audios.Select(a => a.Id);
        public IEnumerable<Guid> Playing => this.Audios.Where(a => a.Playing).Select(a => a.Id);
        public bool IsRecording => this.Recorder.IsRecording;


        // Enums
        public AudioObj? this[Guid id] => this.Audios.FirstOrDefault(a => a.Id == id);
        public AudioObj? this[string name] => this.Audios.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));


        // Ctor
        public AudioCollection(string? workingDir = null, string? importDir = null, int wavRecordingBits = 32)
        {
            if (!string.IsNullOrEmpty(workingDir))
            {
                this.WorkingDirectory = workingDir;
            }
            if (!string.IsNullOrEmpty(importDir))
            {
                this.ImportDirectory = importDir;
            }

            Directory.CreateDirectory(this.WorkingDirectory);
            Directory.CreateDirectory(this.ExportPath);
            Directory.CreateDirectory(this.RecordPath);

            this.Exporter = new AudioExporter(this.ExportPath);
            this.Recorder = new AudioRecorder(this.RecordPath, wavRecordingBits);
            this.Scanner = new BeatScanner();
            this.Cutter = new SampleCutter();
        }


        // IO Methods
        public async Task<AudioObj?> LoadAsync(string filePath)
        {
            var audio = await AudioObj.FromFileAsync(filePath);
            if (audio != null)
            {
                this.Audios.Add(audio);
            }

            return audio;
        }

        public async Task<IEnumerable<AudioObj?>> LoadManyAsync(IEnumerable<string> filePaths)
        {
            var tasks = filePaths.Select(AudioObj.FromFileAsync);
            var audios = await Task.WhenAll(tasks).ConfigureAwait(false);
            var loadedAudios = audios.Where(a => a != null).ToList()!;
            foreach (var audio in loadedAudios)
            {
                if (audio != null)
                {
                    this.Audios.Add(audio);
                }
            }

            return loadedAudios;
        }

        public async Task<IEnumerable<AudioObj?>> LoadDirectoryAsync(string directoryPath)
        {
            string[] supportedExtensions = [".mp3", ".wav", ".flac"];
            var files = Directory.GetFiles(directoryPath).Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()))
                .ToList();
            return await this.LoadManyAsync(files).ConfigureAwait(false);
        }

        public async Task<AudioObj?> RemoveAsync(Guid id, bool dispose = true)
        {
            var audio = this[id];
            if (audio != null)
            {
                this.Audios.Remove(audio);
                if (dispose)
                {
                    await Task.Run(audio.Dispose).ConfigureAwait(false);
                }
            }

            if (!dispose)
            {
                return audio;
            }

            return null;
        }

        public async Task Clear()
        {
            foreach (var audio in this.Audios)
            {
                await Task.Run(audio.Dispose).ConfigureAwait(false);
            }

            this.Audios.Clear();
        }



        // Playback Methods
        public async Task PlayManyAsync(IEnumerable<Guid> ids)
        {
            var tasks = ids.Select(id => this[id]?.PlayAsync(CancellationToken.None) ?? Task.CompletedTask);
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        public async Task PlayAllAsync()
        {
            var playTasks = this.Audios.Where(a => !a.Playing).Select(a => a.PlayAsync(CancellationToken.None));
            await Task.WhenAll(playTasks).ConfigureAwait(false);
        }

        public async Task StopManyAsync(IEnumerable<Guid> ids)
        {
            var tasks = ids.Select(id => this[id]?.StopAsync() ?? Task.CompletedTask);
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        public async Task StopAllAsync()
        {
            var stopTasks = this.Audios.Where(a => a.Playing).Select(a => a.StopAsync());
            await Task.WhenAll(stopTasks).ConfigureAwait(false);
        }


        // Export Methods
        public async Task<string?> ExportAsync(Guid id, string format = ".wav", int bits = 24)
        {
            format = this.Exporter.AvailableExportFormats.ContainsKey(format) ? format : ".wav";
            bits = this.Exporter.AvailableExportFormats[format].Contains(bits) ? bits : this.Exporter.AvailableExportFormats[format].Last();
            var audio = this[id];
            if (audio != null)
            {
                if (format == ".mp3")
                {
                    return await this.Exporter.ExportMp3Async(audio, bits).ConfigureAwait(false);
                }
                else
                {
                    return await this.Exporter.ExportWavAsync(audio, bits).ConfigureAwait(false);
                }
            }
            return null;
        }
        public async Task<IEnumerable<string>> ExportManyAsync(IEnumerable<Guid> ids, string format = ".wav", int bits = 24)
        {
            format = this.Exporter.AvailableExportFormats.ContainsKey(format) ? format : ".wav";
            bits = this.Exporter.AvailableExportFormats[format].Contains(bits) ? bits : this.Exporter.AvailableExportFormats[format].Last();

            var tasks = ids.Select(id =>
            {
                var audio = this[id];
                if (audio != null)
                {
                    if (format == ".mp3")
                    {
                        return this.Exporter.ExportMp3Async(audio, bits);
                    }
                    else
                    {
                        return this.Exporter.ExportWavAsync(audio, bits);
                    }
                }

                return Task.FromResult<string?>(null);
            });

            var results = await Task.WhenAll(tasks).ConfigureAwait(false);
            return results.Where(r => r != null).Select(r => r ?? string.Empty);
        }

        public async Task<IEnumerable<string>> ExportAllAsync(string format = ".wav", int bits = 24)
        {
            var ids = this.Audios.Select(a => a.Id);
            return await this.ExportManyAsync(ids, format, bits).ConfigureAwait(false);
        }


        // Scanner Methods
        public async Task<float?> ScanBpmAsync(Guid id, int windowSize = 16384, int lookingRange = 4, bool set = false)
        {
            var audio = this[id];
            if (audio == null)
            {
                return null;
            }

            float bpm = (float) await this.Scanner.ScanBpmAsync(audio, windowSize, lookingRange, this.BeatScanMinimumBpm, this.BeatScanMaximumBpm);

            if (set)
            {
                audio.Bpm = bpm;
            }

            return bpm;
        }


        // Recorder Methods
        public async Task<string?> StartRecordingAsync(string? fileName = null)
        {
            await this.Recorder.StartRecording(this.RecordPath, fileName);
            return this.Recorder.RecordedFile;
        }

        public async Task<double?> StopRecordingAsync(bool normalize = false)
        {
            double recordedSeconds = this.Recorder.RecordingTime?.TotalSeconds ?? 0.0;
            await Task.Run(() => this.Recorder.StopRecording(normalize));
            return recordedSeconds;
        }


        // Truncate Method
        public async Task<AudioObj?> TruncateAudioAsync(Guid id, TimeSpan? start = null, TimeSpan? end = null, bool? createNew = null)
        {
            var audio = this[id];
            if (audio == null)
            {
                return null;
            }

            var cutAudio = await this.Cutter.TruncateAudioAsync(audio, start?.TotalSeconds ?? this.TruncateEndSeconds, end?.TotalSeconds ?? this.TruncateStartSeconds, createNew ?? this.KeepOriginal);
            if (cutAudio != null && (createNew ?? this.KeepOriginal))
            {
                this.Audios.Add(cutAudio);
            }

            return cutAudio;
        }

        // AutoCutting Methods
        public async Task<IEnumerable<AudioObj?>> AutoCutAudioAsync(Guid id, float? targetLufs = null, int? minDurationMs = null, int? maxDurationMs = null, int? silenceWindowMs = null, int maxWorkers = 4, bool add = false, IProgress<double>? progress = null)
        {
            targetLufs ??= this.TargetLufs;
            minDurationMs ??= this.MinDurationMs;
            maxDurationMs ??= this.MaxDurationMs;
            silenceWindowMs ??= this.SilenceWindowMs;

            var audio = this[id];
            List<AudioObj> samples = [];
            if (audio != null)
            {
                samples = (await this.Cutter.AutoCutSamplesAsync(audio, targetLufs.Value, minDurationMs.Value, maxDurationMs.Value, silenceWindowMs.Value, maxWorkers, progress)).ToList() ?? [];
            }

            if (add)
            {
                foreach (var sample in samples)
                {
                    this.Audios.Add(sample);
                }
            }

            return samples;
        }

		// Draw Methods
        




		// Private Methods



	}
}
