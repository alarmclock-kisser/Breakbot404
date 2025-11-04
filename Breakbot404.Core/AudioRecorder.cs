using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Breakbot404.Core;

public class AudioRecorder
{
    // Fields
    public string RecordsPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "_BreakBot404", "Breakbot404_Records");
    public bool IsRecording { get; private set; } = false;
    public string? RecordedFile { get; private set; } = null;
    public DateTime? RecordingStartTime { get; private set; } = null;

    public double MaxDetectionAttention { get; set; } = 4;
    private float peakThreshold = 0.95f;
    private bool normalizeOnStop = false;
    public readonly int WavRecordBits = 24;

    public string? LastErrorMessage { get; private set; } = null;




    // Lambda
    public string CaptureDeviceName => this._capture?.WaveFormat.ToString() ?? "N/A";
    public string MMDeviceName => this._mmDevice?.FriendlyName ?? "N/A";
    public float PeakThreshold
    {
        get => this.peakThreshold;
        set
        {
            value = Math.Clamp(value, 0.0f, 1.0f);

            if (this.peakThreshold != value)
            {
                // Reset hits
                this._peakHits.Clear();
                Console.WriteLine($"Peak set to {value}.");
            }

            this.peakThreshold = value;
        }
    }
    public TimeSpan? RecordingTime => this.RecordingStartTime != null ? DateTime.UtcNow - this.RecordingStartTime : null;

    public float EstimatedBpm => this.GetPeaksPerMinute();




    // Objects
    private WasapiLoopbackCapture? _capture;
    private MMDevice? _mmDevice;
    private WaveFileWriter? _writer;
    private readonly object _peakLock = new();
    private readonly List<DateTime> _peakHits = [];
    private AudioExporter exporter;



    // Ctor
    public AudioRecorder(string? recordsPath = null, int wavRecordBits = 32)
    {
        if (!string.IsNullOrEmpty(recordsPath))
        {
            this.RecordsPath = recordsPath;
        }

        if (!Directory.Exists(this.RecordsPath))
        {
            Directory.CreateDirectory(this.RecordsPath);
        }

        this.exporter = new AudioExporter(this.RecordsPath);
        this.WavRecordBits = this.exporter.AvailableExportFormats[".wav"].Contains(wavRecordBits) ? wavRecordBits : 24;
    }






    public float GetPeakVolume(MMDevice? useDevice = null)
    {
        try
        {
            // Nimm übergebenes Gerät oder Standardgerät
            MMDevice? device = useDevice ?? this.GetDefaultPlaybackDevice();
            if (device == null)
            {
                Console.WriteLine("No device selected.");
                return 0.0f;
            }

            // Mit LoopbackCapture initialisieren (wie in StartRecording)
            using var capture = new WasapiLoopbackCapture(device);

            // Kurze Initialisierung, aber kein echtes Recording starten
            var format = capture.WaveFormat;

            float value = device.AudioMeterInformation.MasterPeakValue;

            this.CheckPeakHit(value);

            // Pegel über AudioMeterInformation abrufen
            return value;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting loudness / volume: {ex.Message}");
            return 0.0f;
        }
    }

    private void CheckPeakHit(float value)
    {
        if (value >= this.PeakThreshold)
        {
            lock (this._peakLock)
            {
                // Add hit if last hit is older than 200ms
                if (this._peakHits.Count == 0 || (DateTime.UtcNow - this._peakHits.Last()).TotalMilliseconds > 200)
                {
                    this._peakHits.Add(DateTime.UtcNow);
                }

                // Alte Einträge (älter als 60s) entfernen
                this._peakHits.RemoveAll(t => (DateTime.UtcNow - t).TotalSeconds > this.MaxDetectionAttention);
            }
        }
    }

    public float GetPeaksPerMinute()
    {
        lock (this._peakLock)
        {
            if (this._peakHits.Count < 2)
            {
                return 0.0f;
            }

            // Zeitspanne zwischen erstem und letztem Hit in Sekunden
            double spanSeconds = (this._peakHits.Last() - this._peakHits.First()).TotalSeconds;
            if (spanSeconds <= 0.0)
            {
                return 0.0f;
            }

            // Rate auf Minuten hochgerechnet
            double rate = (this._peakHits.Count - 1) / spanSeconds * 60.0;
            return (float) rate;
        }
    }


    public async Task StartRecording(string? fileDirectory = null, string? initialTrackName = null, MMDevice? mmDevice = null)
    {
        if (this.IsRecording)
        {
            Console.WriteLine("Recording is already running.");
            return;
        }

        if (string.IsNullOrEmpty(fileDirectory))
        {
            fileDirectory = this.RecordsPath;
        }

        if (!Directory.Exists(fileDirectory))
        {
            Directory.CreateDirectory(fileDirectory);
        }

        string filePath = initialTrackName != null
            ? Path.Combine(fileDirectory, $"{initialTrackName}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.wav")
            : Path.Combine(fileDirectory, $"Breakbot404_Record_{DateTime.UtcNow:yyyyMMdd_HHmmss}.wav");

        this.RecordingStartTime = DateTime.UtcNow;

        this.RecordedFile = Path.GetFullPath(filePath);

        try
        {
            MMDevice? captureDevice = null;
            if (mmDevice != null)
            {
                captureDevice = mmDevice;
            }

            // Nutze das gefundene Gerät oder das Standardgerät als Fallback
            this._capture = captureDevice != null ? new WasapiLoopbackCapture(captureDevice) : new WasapiLoopbackCapture();

            this._writer = new WaveFileWriter(filePath, this._capture.WaveFormat);

            this._capture.DataAvailable += this.OnDataAvailable;
            this._capture.RecordingStopped += async (s, e) => await Task.Run(() => this.OnRecordingStopped(s, e));

            this._capture.StartRecording();
            this.IsRecording = true;
            this._mmDevice = captureDevice ?? this.GetDefaultPlaybackDevice();
            Console.WriteLine($"Recording started on device: {captureDevice?.FriendlyName ?? "Default"}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting recording: {ex.Message}");
            this.LastErrorMessage = ex.Message;
            this.IsRecording = false;
            await this.Cleanup();
        }
    }

    public void StopRecording(bool normalizeOutput = false)
    {
        if (!this.IsRecording)
        {
            Console.WriteLine("Keine Aufnahme aktiv.");
            return;
        }

        this.IsRecording = false;

        // Optional: Normalisieren
        this.normalizeOnStop = normalizeOutput;

        Console.WriteLine("Aufnahme wird gestoppt...");
        this._capture?.StopRecording();
    }

    public MMDevice? GetActivePlaybackDevice()
    {
        var enumerator = new MMDeviceEnumerator();
        var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.All);

        MMDevice? activeDevice = null;
        float maxPeak = 0.0f;

        foreach (var device in devices)
        {
            float peak = device.AudioMeterInformation.MasterPeakValue;
            if (peak > maxPeak)
            {
                maxPeak = peak;
                activeDevice = device;
            }
        }

        this._mmDevice = activeDevice;
        return activeDevice;
    }

    public MMDevice? GetDefaultPlaybackDevice()
    {
        var enumerator = new MMDeviceEnumerator();
        return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
    }

    public MMDevice[] GetCaptureDevices()
    {
        var enumerator = new MMDeviceEnumerator();
        return enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.All).ToArray();
    }

    public void SetCaptureDevice(MMDevice? device)
    {
        if (device == null)
        {
            Console.WriteLine("Ungültiges Gerät.");
            return;
        }
        if (this._capture != null && this.IsRecording)
        {
            Console.WriteLine("Aufnahme läuft bereits. Stoppe die Aufnahme, bevor du das Gerät änderst.");
            return;
        }
        try
        {
            this._capture?.Dispose();
            this._capture = new WasapiLoopbackCapture(device);
            Console.WriteLine($"Gerät auf {device.FriendlyName} gesetzt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Setzen des Geräts: {ex.Message}");
        }
    }

    private void OnDataAvailable(object? sender, WaveInEventArgs e)
    {
        this._writer?.Write(e.Buffer, 0, e.BytesRecorded);
    }

    private async void OnRecordingStopped(object? sender, StoppedEventArgs e)
    {
        Console.WriteLine("Aufnahme gestoppt.");

        if (e.Exception != null)
        {
            Console.WriteLine($"Fehler während der Aufnahme: {e.Exception.Message}");
        }

        // Finalize and cleanup
        this._writer?.Flush();


        await this.Cleanup();
    }

    private async Task Cleanup()
    {
        this._writer?.Dispose();
        this._writer = null;
        this._capture?.Dispose();
        this._capture = null;
        this.IsRecording = false;

        if (this.normalizeOnStop && this.RecordedFile != null && File.Exists(this.RecordedFile))
        {
            try
            {
                Console.WriteLine("Normalisiere Aufnahme...");
                var obj = await AudioObj.FromFileAsync(this.RecordedFile);
                if (obj?.Data.LongLength > 0)
                {
                    await obj.NormalizeAsync();
                    await this.exporter.ExportWavAsync(obj, 32);
                }
                Console.WriteLine("Normalisierung abgeschlossen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler bei der Normalisierung: {ex.Message}");
            }
            finally
            {
                this.normalizeOnStop = false;
            }
        }

        this.normalizeOnStop = false;
    }
}