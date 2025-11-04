using Breakbot404.Core;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Breakbot404.Forms
{
    internal class WindowMainViewModel
    {
        // References
        private readonly Form WindowMain;

        public readonly AudioCollection AudioC = new(null, null, 24);
        public AudioObj? SelectedTrack { get; private set; } = null;


        // Objects
        internal readonly System.Windows.Forms.Timer WaveformTimer;
        internal readonly ConcurrentDictionary<Guid, CancellationToken> PlaybackCancellationTokens = [];

        // Rendering guard
        private int isRendering = 0;
		private volatile bool isEditingTimestamp = false;

		// Properties
        private DateTime LastGarbageCollected = DateTime.MinValue;
		private float DefaultHueIncrement = 1.125f; // Standardwert
		private float StoredHueValue = 0.0f;


		// Cached Controls
		private ListBox? ListBox_audios = null;
        private PictureBox? PictureBox_waveform = null;
        private HScrollBar? HScrollBar_offset = null;
		private Button? Button_playback = null;
        private Button? Button_pause = null;
        private TextBox? TextBox_timestamp = null;
        private TextBox? TextBox_recordingTime = null;
        private Button? Button_waveColor = null;
        private Button? Button_backColor = null;


		// Fields
		public int FrameRate { get; private set; } = 60;
        public int SamplesPerPixel { get; private set; } = 128;
        public bool DrawEachChannel { get; set; } = false;
        public int CaretWidth { get; set; } = 2;
        public bool SmoothenWaveform { get; set; } = false;
        public Color WaveColor { get; private set; } = Color.Black;
        public Color BackColor { get; private set; } = Color.White;
        public Color CaretColor { get; private set; } = Color.Red;
        public float Volume { get; set; } = 1.0f;
        public bool NormalizeAfterRecording { get; set; } = false;
        public float HueAdjustment { get; set; } = 0.0f;
        public bool HueEffect { get; set; } = false;
        public bool StrobeEffect { get; set; } = false;
		public bool SeekEnabled { get; set; } = true;


		// Ctor
		public WindowMainViewModel(Form windowMain, int frameRate = 60, int garbadgeCollectionDelay = 0)
        {
            this.WindowMain = windowMain;

            // Set provided framerate
            this.FrameRate = Math.Max(1, frameRate);

            // Use Forms.Timer so ticks run on UI thread and avoid frequent cross-thread Invokes
            this.WaveformTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 / Math.Max(1, this.FrameRate)
            };
            this.WaveformTimer.Tick += async (s, e) => await this.WaveformTimer_Tick(garbadgeCollectionDelay);
            this.WaveformTimer.Start();
        }


        // Internal Methods (for Form (WindowMain))
        internal void Bind_ListBox_Log(ListBox listBox, CheckBox? checkBox_autoScroll = null, bool doubleClickToCopy = true, int maxLogEntries = 512)
        {
            LogCollection.MaxLogCount = maxLogEntries;

            // Bind the ListBox to the log entries
            listBox.DataSource = null;
            listBox.DataSource = LogCollection.Logs;

            // Optionally bind the auto-scroll CheckBox
            if (checkBox_autoScroll != null)
            {
                checkBox_autoScroll.CheckedChanged += (s, e) =>
                {
                    if (checkBox_autoScroll.Checked)
                    {
                        listBox.SelectedIndex = listBox.Items.Count - 1;
                    }
                };
                LogCollection.Logs.ListChanged += (s, e) =>
                               {
                                   if (checkBox_autoScroll.Checked)
                                   {
                                       listBox.Invoke(() =>
                        {
                    listBox.SelectedIndex = listBox.Items.Count - 1;
                });
                                   }
                               };
            }

            // Optionally enable double-click to copy log entry
            if (doubleClickToCopy)
            {
                listBox.DoubleClick += (s, e) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        string logEntry = listBox.SelectedItem.ToString() ?? string.Empty;
                        Clipboard.SetText(logEntry);
                        LogCollection.Log("Log entry copied to clipboard.");
                    }
                };
            }
        }

        internal void Bind_Elements_View(ListBox listBox_audios, PictureBox? pictureBox_waveform = null, NumericUpDown? numeric_frameRate = null, NumericUpDown? numeric_samplesPerPixel = null, HScrollBar? hScrollBar_offset = null, Button? button_waveColor = null, Button? button_backColor = null, CheckBox? checkBox_drawEachChannel = null, CheckBox? checkBox_smoothWaveform = null, CheckBox? checkBox_seek = null, TextBox? textBox_info = null)
        {
            this.HScrollBar_offset = hScrollBar_offset;
            this.PictureBox_waveform = pictureBox_waveform;
            this.ListBox_audios = listBox_audios;
            this.Button_waveColor = button_waveColor;
            this.Button_backColor = button_backColor;

			listBox_audios.DrawMode = DrawMode.OwnerDrawFixed;
            listBox_audios.DrawItem += this.ListBox_audios_DrawItem;
            listBox_audios.DataSource = null;
            listBox_audios.DataSource = this.AudioC.Audios;
            listBox_audios.DisplayMember = "Name";
            listBox_audios.ValueMember = "Id";
            listBox_audios.SelectedIndexChanged += (s, e) =>
            {
                var selectedId = (listBox_audios.SelectedValue as Guid?) ?? Guid.Empty;
                this.SelectedTrack = this.AudioC[selectedId];

                if (textBox_info != null)
                {
                    textBox_info.Text = this.SelectedTrack?.GetInfoString(true) ?? string.Empty;
                }

                if (this.HScrollBar_offset != null)
                {
                    this.AdjustOffsetHScrollBarValues();
                }

                if (this.Button_playback != null)
                {
                    this.Button_playback.Text = this.SelectedTrack?.Playing == true ? "■" : "▶";
                }
                if (this.Button_pause != null)
                {
                    this.Button_pause.ForeColor = this.SelectedTrack?.Paused == true ? Color.Black : Color.Gray;
                }
            };

            if (pictureBox_waveform != null)
            {
                pictureBox_waveform.MouseWheel += async (s, e) =>
                {
                    // If CTRL down, zoom (samplesPerPixel)
                    if (Control.ModifierKeys.HasFlag(Keys.Control))
                    {
                        int delta = e.Delta > 0 ? -Math.Max(this.SamplesPerPixel / 2, 1) : Math.Max(this.SamplesPerPixel / 2, 1);
                        int newSamplesPerPixel = Math.Clamp(this.SamplesPerPixel + delta, 1, (int) (numeric_samplesPerPixel?.Maximum ?? 8192));
                        this.SamplesPerPixel = newSamplesPerPixel;
                        if (numeric_samplesPerPixel != null)
                        {
                            numeric_samplesPerPixel.Value = Math.Clamp(newSamplesPerPixel, numeric_samplesPerPixel.Minimum, numeric_samplesPerPixel.Maximum);
                        }

                        this.AdjustOffsetHScrollBarValues();
						return;
                    }

                    // Otherwise, scroll horizontally (proportional to samplesPerPixel (change by1/4 of visible samples))
                    if (this.HScrollBar_offset != null && this.SelectedTrack != null)
					{
                        if (this.SelectedTrack.Playing == false)
                        {
							int visibleSamples = pictureBox_waveform.Width * this.SamplesPerPixel;
							int deltaPixels = (e.Delta > 0 ? -1 : 1) * (visibleSamples / (4 * this.SamplesPerPixel));
							int newOffset = Math.Clamp(this.HScrollBar_offset.Value + deltaPixels, this.HScrollBar_offset.Minimum, this.HScrollBar_offset.Maximum);
							this.HScrollBar_offset.Value = newOffset;
                            if (this.SeekEnabled)
                            {
                                this.SelectedTrack.SetPosition(newOffset * this.SamplesPerPixel);
							}
						}
                    }
                };
            }

            if (hScrollBar_offset != null)
            {
                hScrollBar_offset.Scroll += (s, e) =>
                {
                    if (this.SelectedTrack != null && this.SeekEnabled)
                    {
                        if (this.SelectedTrack.Playing == false)
                        {
                            this.SelectedTrack.SetPosition(hScrollBar_offset.Value * this.SamplesPerPixel);
                        }
                    }
                };
			}

            if (numeric_frameRate != null)
            {
                this.FrameRate = (int) numeric_frameRate.Value;
                numeric_frameRate.ValueChanged += (s, e) =>
                {
                    this.FrameRate = (int) Math.Clamp(numeric_frameRate.Value, numeric_frameRate.Minimum, numeric_frameRate.Maximum);
                    // Update Forms.Timer interval
                    this.WaveformTimer.Interval = 1000 / Math.Max(1, this.FrameRate);
                };
            }

            if (numeric_samplesPerPixel != null)
            {
                this.SamplesPerPixel = (int) numeric_samplesPerPixel.Value;
                numeric_samplesPerPixel.ValueChanged += (s, e) =>
                 {
                     this.SamplesPerPixel = (int) Math.Clamp(numeric_samplesPerPixel.Value, numeric_samplesPerPixel.Minimum, numeric_samplesPerPixel.Maximum);
                 };
            }

            if (button_waveColor != null)
            {
                this.WaveColor = button_waveColor.BackColor;
                button_waveColor.Click += (s, e) =>
                {
                    using ColorDialog colorDialog = new();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.WaveColor = colorDialog.Color;
                        button_waveColor.BackColor = this.WaveColor;
                        button_waveColor.ForeColor = this.WaveColor.GetBrightness() < 0.6f ? Color.White : Color.Black;
                    }
                };
            }

            if (button_backColor != null)
            {
                this.BackColor = button_backColor.BackColor;
                button_backColor.MouseDown += (s, e) =>
                {
                    // If Right AND NOT left click, toggle to negative color
                    if (Control.MouseButtons.HasFlag(MouseButtons.Right) && !Control.MouseButtons.HasFlag(MouseButtons.Left))
                    {
                        this.BackColor = GetNegativeColor(this.BackColor);
                    }
                    else
                    {
                        using ColorDialog colorDialog = new();
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.BackColor = colorDialog.Color;
                        }
                    }

					button_backColor.BackColor = this.BackColor;
					button_backColor.ForeColor = this.BackColor.GetBrightness() < 0.6f ? Color.White : Color.Black;
				};
            }

            if (checkBox_drawEachChannel != null)
            {
                this.DrawEachChannel = checkBox_drawEachChannel.Checked;
                checkBox_drawEachChannel.CheckedChanged += (s, e) =>
                {
                    this.DrawEachChannel = checkBox_drawEachChannel.Checked;
                };
            }

            if (checkBox_smoothWaveform != null)
            {
                this.SmoothenWaveform = checkBox_smoothWaveform.Checked;
                checkBox_smoothWaveform.CheckedChanged += (s, e) =>
                {
                    this.SmoothenWaveform = checkBox_smoothWaveform.Checked;
                };
			}

            if (checkBox_seek != null)
            {
                this.SeekEnabled = checkBox_seek.Checked;
                checkBox_seek.CheckedChanged += (s, e) =>
                {
                    this.SeekEnabled = checkBox_seek.Checked;
                };
			}
		}

        internal void Bind_Elements_Playback(Button? button_playback = null, Button? button_pause = null, TextBox? textBox_timestamp = null, Button? button_recording = null, TextBox? textBox_recordingTime = null, VScrollBar? vScrollBar_volume = null, Label? label_volume = null)
        {
            // Action onPlaybackStopped
            var onPlaybackStopped = new Action(() =>
            {
                if (button_playback != null)
                {
                    this.WindowMain.Invoke(() => { button_playback.Text = "▶"; });
                }
                if (button_pause != null)
                {
                    this.WindowMain.Invoke(() => { button_pause.ForeColor = Color.Gray; });
                }
            });

            // Playback button
            this.Button_playback = button_playback;
            if (button_playback != null)
            {
                button_playback.Click += async (s, ev) =>
                {
                    if (this.SelectedTrack == null)
                    {
                        MessageBox.Show(this.WindowMain, "No track selected to play.", "Play Track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!this.SelectedTrack.Playing && !this.SelectedTrack.Paused)
                    {
                        this.PlaybackCancellationTokens.AddOrUpdate(this.SelectedTrack.Id, new CancellationToken(), (key, oldValue) => new CancellationToken());
                        button_playback.Text = "■";
                        await this.SelectedTrack.PlayAsync(this.PlaybackCancellationTokens.GetValueOrDefault(this.SelectedTrack.Id), onPlaybackStopped, this.Volume);
                    }
                    else
                    {
                        // If CTRL down, stop all
                        if (Control.ModifierKeys.HasFlag(Keys.Control))
                        {
                            await this.AudioC.StopAllAsync();
                            this.PlaybackCancellationTokens.Clear();
                            LogCollection.Log("All tracks stopped.");
                        }
                        else
                        {
                            await this.SelectedTrack.StopAsync();
                            this.PlaybackCancellationTokens.TryRemove(this.SelectedTrack.Id, out _);
                        }

                        button_playback.Text = "▶";
                    }
                };
            }

            // Pause button
            this.Button_pause = button_pause;
            if (button_pause != null)
            {
                button_pause.Click += async (s, ev) =>
                {
                    if (this.SelectedTrack == null)
                    {
                        MessageBox.Show(this.WindowMain, "No track selected to pause.", "Pause Track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    await this.SelectedTrack.PauseAsync();

                    if (!this.SelectedTrack.Paused)
                    {
                        button_pause.ForeColor = Color.Gray;
                    }
                    else
                    {
                        button_pause.ForeColor = Color.Black;
					}
                };
            }

			// Timestamp TextBox
			this.TextBox_timestamp = textBox_timestamp;
			if (textBox_timestamp != null)
			{
				// Beim Enter: nur editieren erlauben, falls Track vorhanden und nicht spielt
				textBox_timestamp.Enter += (s, ev) =>
				{
					if (this.SelectedTrack == null || this.SelectedTrack.Playing || this.SeekEnabled == false)
					{
						textBox_timestamp.ReadOnly = true;
						return;
					}

                    this.isEditingTimestamp = true;
					textBox_timestamp.ReadOnly = false;
					// Optional: setze aktuellen Wert als Startpunkt für Editing
					textBox_timestamp.Text = this.SelectedTrack.CurrentTime.ToString(@"h\:mm\:ss\.fff");
				};

				// Beim Verlassen: parse und springe, dann wieder Timer-Updates erlauben
                textBox_timestamp.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter)
                    {
                        // Verlasse das TextBox (triggert Leave-Event)
                        this.WindowMain.ActiveControl = null;
                        ev.Handled = true;
                        ev.SuppressKeyPress = true;
                    }
                };

				textBox_timestamp.Leave += (s, ev) =>
				{
					if (this.SelectedTrack == null)
					{
                        this.isEditingTimestamp = false;
						textBox_timestamp.ReadOnly = true;
						return;
					}

					// Versuche Parsen der eingegebenen Zeit
					if (TimeSpan.TryParse(textBox_timestamp.Text, out TimeSpan newTime))
					{
						// Clamp
						if (newTime < TimeSpan.Zero)
                        {
                            newTime = TimeSpan.Zero;
                        }

                        if (newTime > this.SelectedTrack.Duration)
                        {
                            newTime = this.SelectedTrack.Duration;
                        }

                        // Springe zur Position (Seek erwartet Sekunden)
                        this.SelectedTrack.Seek(newTime.TotalSeconds);
                        if (this.HScrollBar_offset != null)
                        {
                            this.HScrollBar_offset.Value = (int) Math.Floor(this.SelectedTrack.Position / (double) this.SamplesPerPixel);
						}
						LogCollection.Log($"Set {this.SelectedTrack.Name} position to {newTime.ToString(@"h\:mm\:ss\.fff")}");
					}
					else
					{
						// Revert zu aktueller Zeit wenn parse fehl schlägt
						textBox_timestamp.Text = this.SelectedTrack.CurrentTime.ToString(@"h\:mm\:ss\.fff");
					}

                    this.isEditingTimestamp = false;
					textBox_timestamp.ReadOnly = true;
				};

				// Kurzzeitmodus: bei MouseDown kurzzeitig Dauer anzeigen (keine Konflikte mit Editing-Flag)
				textBox_timestamp.MouseDown += (s, ev) =>
				{
					if (this.SelectedTrack == null)
                    {
                        return;
                    }
                    // Wenn bereits editing, ignoriere den Mode-Switch
                    if (this.isEditingTimestamp)
                    {
                        return;
                    }

                    textBox_timestamp.Tag = "mode";
					textBox_timestamp.Text = this.SelectedTrack.Duration.ToString(@"h\:mm\:ss\.fff");
					textBox_timestamp.ForeColor = Color.DarkGray;
				};
				textBox_timestamp.MouseUp += (s, ev) =>
				{
					if (this.SelectedTrack == null)
                    {
                        return;
                    }

                    if (this.isEditingTimestamp)
                    {
                        return;
                    }

                    textBox_timestamp.Text = this.SelectedTrack.CurrentTime.ToString(@"h\:mm\:ss\.fff");
					textBox_timestamp.ForeColor = Color.Black;
					textBox_timestamp.Tag = null;
				};
			}

			// Recording button
			if (button_recording != null)
            {
                button_recording.Click += async (s, ev) =>
                {
                    if (!this.AudioC.IsRecording)
                    {
                        button_recording.ForeColor = Color.Red;
                        await this.AudioC.StartRecordingAsync();
                        if (this.AudioC.IsRecording)
                        {
                            LogCollection.Log("Recording started.");
                        }
                        else
                        {
                            button_recording.ForeColor = Color.Black;
                            LogCollection.Log("Failed to start recording.");
                            LogCollection.Log(this.AudioC.Recorder.LastErrorMessage ?? string.Empty);
                        }
                    }
                    else
                    {
                        // Require CTRL down to stop
                        if (!Control.ModifierKeys.HasFlag(Keys.Control))
                        {
                            LogCollection.Log("To stop recording, hold down the CTRL key while clicking the Record button.");
                            return;
                        }

                        button_recording.ForeColor = Color.Black;
                        await this.AudioC.StopRecordingAsync(this.NormalizeAfterRecording);
                        LogCollection.Log("Recording stopped.");
                    }
                };
            }

            // Recording Time TextBox
            this.TextBox_recordingTime = textBox_recordingTime;

            // Volume scrollBar event
            if (vScrollBar_volume != null)
            {
                vScrollBar_volume.Scroll += (s, ev) =>
                {
                    float scaledVolume = (vScrollBar_volume.Maximum - vScrollBar_volume.Value) / (float) vScrollBar_volume.Maximum;
                    if (this.SelectedTrack != null)
                    {
                        this.SelectedTrack.SetVolume(scaledVolume);
					}

                    this.Volume = scaledVolume;
                    if (label_volume != null)
                    {
                        label_volume.Text = $"{((float) (scaledVolume * 100)):F1}%";
					}
				};
            }
        }

        internal void Bind_Elements_IO(Button? button_import = null, Button? button_export = null, Button? button_remove = null, ComboBox? comboBox_format = null, ComboBox? comboBox_bits = null, Button? button_browse = null, Label? label_workingDir = null)
        {
            // Import button
            if (button_import != null)
            {
                button_import.Click += async (s, ev) =>
                {
                    using OpenFileDialog openFileDialog = new()
                    {
                        InitialDirectory = this.AudioC.ImportDirectory,
                        Filter = "Audio File|*.wav;*.mp3;*.flac",
                        Multiselect = false,
                        Title = "Import a Loop Audio File",
                        RestoreDirectory = true
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var importedAudio = await this.AudioC.LoadAsync(openFileDialog.FileName);
                        if (importedAudio == null)
                        {
                            MessageBox.Show(this.WindowMain, "Failed to import the selected audio file.", "Import Audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (this.ListBox_audios != null)
                        {
                            this.ListBox_audios.SelectedIndex = -1;
                            this.ListBox_audios.SelectedItem = importedAudio;
                        }

                        LogCollection.Log($"{importedAudio?.Name} imported.");
                    }
                };
            }

            // Export button
            if (button_export != null)
            {
                button_export.Click += async (s, ev) =>
                {
                    if (this.SelectedTrack == null)
                    {
                        MessageBox.Show(this.WindowMain, "No track selected to export.", "Export Track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string selectedFormat = comboBox_format != null && comboBox_format.SelectedItem != null ? comboBox_format.SelectedItem.ToString() ?? "wav" : "wav";
                    int selectedBits = comboBox_bits != null && comboBox_bits.SelectedItem != null && int.TryParse(comboBox_bits.SelectedItem.ToString(), out int bits) ? bits : 16;
                    var resultFilePath = await this.AudioC.ExportAsync(this.SelectedTrack.Id, selectedFormat, selectedBits);
                    if (string.IsNullOrEmpty(resultFilePath))
                    {
                        MessageBox.Show(this.WindowMain, "Failed to export the selected track.", "Export Track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        LogCollection.Log($"{this.SelectedTrack.Name} exported as {selectedFormat} ({selectedBits} bits) to {resultFilePath}.");
                    }
                };
            }

            // Remove button
            if (button_remove != null)
            {
                button_remove.Click += async (s, ev) =>
                {
                    if (this.SelectedTrack == null)
                    {
                        MessageBox.Show(this.WindowMain, "No track selected to remove.", "Remove Track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string name = this.SelectedTrack.Name;

                    await this.AudioC.RemoveAsync(this.SelectedTrack.Id, true);
                    LogCollection.Log($"{name} removed from collection.");
                    this.SelectedTrack = null;
                };
            }

            // Format comboBox
            if (comboBox_format != null)
            {
                // Populate formats
                comboBox_format.Items.Clear();
                foreach (var format in this.AudioC.Exporter.AvailableExportFormats.Keys)
                {
                    comboBox_format.Items.Add(format.Trim('.').ToUpperInvariant());
                }
                comboBox_format.SelectedIndexChanged += (sender, e) =>
                 {
                     string selected = comboBox_format.SelectedItem?.ToString()?.Trim('.').ToLowerInvariant() ?? "wav";
                     string exportFormat = this.AudioC.Exporter.AvailableExportFormats.Keys.FirstOrDefault(f => f.Contains(selected, StringComparison.OrdinalIgnoreCase)) ?? ".wav";

                     if (comboBox_bits != null)
                     {
                         // Update bits options
                         comboBox_bits.Items.Clear();
                         if (this.AudioC.Exporter.AvailableExportFormats.TryGetValue(exportFormat, out int[]? bitsOptions))
                         {
                             foreach (var bits in bitsOptions)
                             {
                                 comboBox_bits.Items.Add(bits.ToString());
                             }
                             comboBox_bits.SelectedItem = bitsOptions.Last().ToString();
                         }
                     }
                 };
                comboBox_format.SelectedIndex = 0;
            }

            // Bits comboBox
            if (comboBox_bits != null)
            {
                // Nothing
            }

            // Browse button
            if (button_browse != null)
            {
                button_browse.Click += (s, ev) =>
                {
                    using FolderBrowserDialog folderBrowserDialog = new()
                    {
                        SelectedPath = this.AudioC.WorkingDirectory,
                        Description = "Select Working Directory"
                    };
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.AudioC.WorkingDirectory = folderBrowserDialog.SelectedPath;

                        if (label_workingDir != null)
                        {
                            label_workingDir.Text = Path.GetFullPath(this.AudioC.WorkingDirectory);
                        }
                    }
                };
            }

            // Working Directory label
            if (label_workingDir != null)
            {
                label_workingDir.Text = Path.GetFullPath(this.AudioC.WorkingDirectory);
            }
        }

        internal void Bind_Elements_BeatScan(Button? button_beatScan = null, TextBox? textBox_scannedBpm = null, NumericUpDown? numeric_lookRange = null, NumericUpDown? numeric_scanWidth = null, NumericUpDown? numeric_minBpm = null, NumericUpDown? numeric_maxBpm = null)
        {
            if (button_beatScan != null)
            {
                button_beatScan.Click += async (s, ev) =>
                {
                    if (this.SelectedTrack == null)
                    {
                        MessageBox.Show(this.WindowMain, "No track selected to scan for BPM.", "Beat Scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int lookRange = numeric_lookRange != null ? (int) Math.Clamp(numeric_lookRange.Value, numeric_lookRange.Minimum, numeric_lookRange.Maximum) : 4;
                    int scanWidth = numeric_scanWidth != null ? (int) Math.Clamp(numeric_scanWidth.Value, numeric_scanWidth.Minimum, numeric_scanWidth.Maximum) : 16384;

                    var detectedBpm = await this.AudioC.Scanner.ScanBpmAsync(this.SelectedTrack, scanWidth, lookRange, this.AudioC.BeatScanMinimumBpm, this.AudioC.BeatScanMaximumBpm);
                    if (detectedBpm > 0)
                    {
                        LogCollection.Log($"Detected BPM for {this.SelectedTrack.Name}: {detectedBpm} BPM");
                        if (textBox_scannedBpm != null)
                        {
                            textBox_scannedBpm.Text = detectedBpm.ToString("F3");
                        }
                    }
                    else
                    {
                        LogCollection.Log($"Failed to detect BPM for {this.SelectedTrack.Name}.");
                    }
                };
            }

            if (numeric_scanWidth != null)
            {
                this.Register_Numeric_Pow2(numeric_scanWidth);
            }

            if (numeric_minBpm != null)
            {
                this.AudioC.BeatScanMinimumBpm = (int) numeric_minBpm.Value;
                numeric_minBpm.ValueChanged += (s, ev) =>
                 {
                     this.AudioC.BeatScanMinimumBpm = (int) Math.Clamp(numeric_minBpm.Value, numeric_minBpm.Minimum, numeric_minBpm.Maximum);
                 };
            }

            if (numeric_maxBpm != null)
            {
                this.AudioC.BeatScanMaximumBpm = (int) numeric_maxBpm.Value;
                numeric_maxBpm.ValueChanged += (s, ev) =>
                 {
                     this.AudioC.BeatScanMaximumBpm = (int) Math.Clamp(numeric_maxBpm.Value, numeric_maxBpm.Minimum, numeric_maxBpm.Maximum);
                 };
            }
        }

        internal void Bind_Elements_Hue(CheckBox checkBox_hue, NumericUpDown? numericUpDown_hue = null, Button? button_strobe = null)
        {
			this.HueEffect = checkBox_hue.Checked;

			if (button_strobe != null)
			{
				this.StrobeEffect = button_strobe.ForeColor == Color.Red;
			}

			if (numericUpDown_hue != null)
			{
				// Initialen numericUpDown Wert setzen und speichern
				if (this.HueEffect)
				{
					// Sicherstellen, dass der NumericUpDown einen gültigen Wert hat
					if (numericUpDown_hue.Value <= 0)
					{
						numericUpDown_hue.Value = (decimal) this.DefaultHueIncrement;
					}
					this.StoredHueValue = (float) numericUpDown_hue.Value;

					// Initialen HueAdjustment setzen
					if (this.StrobeEffect)
					{
						this.HueAdjustment = 720.0f;
					}
					else
					{
						this.HueAdjustment = this.StoredHueValue;
					}
				}
				else
				{
					this.HueAdjustment = 0.0f;
				}

				// UI-Elemente initial setzen
				numericUpDown_hue.Enabled = this.HueEffect && !this.StrobeEffect;
			}
			else
			{
				this.HueAdjustment = this.HueEffect ? 2.0f : 0.0f;
			}

			checkBox_hue.CheckedChanged += (s, e) =>
			{
				this.HueEffect = checkBox_hue.Checked;

				if (numericUpDown_hue != null)
				{
					if (this.HueEffect)
					{
						numericUpDown_hue.Enabled = !this.StrobeEffect;
						if (numericUpDown_hue.Value <= 0)
						{
							numericUpDown_hue.Value = (decimal) this.DefaultHueIncrement;
						}
						this.StoredHueValue = (float) numericUpDown_hue.Value;

						if (!this.StrobeEffect)
						{
							this.HueAdjustment = this.StoredHueValue;
						}
					}
					else
					{
						this.StrobeEffect = false;
						if (button_strobe != null)
						{
							button_strobe.ForeColor = Color.Black;
						}

						numericUpDown_hue.Enabled = false;
						this.StoredHueValue = 0.0f;
						this.HueAdjustment = 0.0f;
					}
				}
				else
				{
					this.HueAdjustment = this.HueEffect ? 2.0f : 0.0f;
				}

				if (!this.HueEffect)
				{
					// Setze WaveColor zurück, wenn Hue ausgeschaltet ist
					this.WaveColor = this.Button_waveColor?.BackColor ?? Color.Black;
				}
			};

			if (numericUpDown_hue != null)
			{
				numericUpDown_hue.ValueChanged += (s, e) =>
				{
					if (this.HueEffect)
					{
						float newValue = (float) numericUpDown_hue.Value;

						this.StoredHueValue = newValue;

						if (!this.StrobeEffect)
						{
							this.HueAdjustment = newValue;
						}
					}
				};
			}

			if (button_strobe != null)
			{
				button_strobe.Tag = this.WaveColor;
				button_strobe.Click += (s, e) =>
				{
                    this.StrobeEffect = !this.StrobeEffect;
                    this.HueEffect = this.StrobeEffect || checkBox_hue.Checked;

					// Visuelles Feedback
					button_strobe.ForeColor = this.StrobeEffect ? Color.Red : Color.Black;

					if (this.StrobeEffect)
					{
						// Strobe aktivieren
						button_strobe.Tag = this.WaveColor;
						this.HueAdjustment = 144.7f;

						// NumericUpDown deaktivieren
						if (numericUpDown_hue != null)
						{
							numericUpDown_hue.Enabled = false;
						}
					}
					else
					{
						// Strobe deaktivieren

						// Setze HueAdjustment auf den zuletzt gespeicherten Wert zurück
						this.HueAdjustment = this.StoredHueValue;
                        this.WaveColor = button_strobe.Tag is Color storedColor ? storedColor : this.WaveColor;

						// NumericUpDown wieder aktivieren
						if (numericUpDown_hue != null)
						{
							numericUpDown_hue.Enabled = true;
						}
					}
				};
			}
		}


        // Private Methods
        private async Task WaveformTimer_Tick(int garbageCollectionDelay = 0)
        {
            // Prevent overlapping renders
            if (Interlocked.CompareExchange(ref this.isRendering, 1, 0) != 0)
            {
                return;
            }

            try
            {
                // RecordingTime textBox (UI thread already)
                if (this.TextBox_recordingTime != null && this.AudioC.IsRecording)
                {
                    var recordingTime = this.AudioC.Recorder.RecordingTime?.ToString(@"h\:mm\:ss\.fff");
                    try
                    {
                        this.TextBox_recordingTime.Text = recordingTime;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                // Timestamp textBox
                if (this.TextBox_timestamp != null && this.TextBox_timestamp.Tag == null && !this.isEditingTimestamp)
				{
                    var currentTime = this.SelectedTrack?.CurrentTime.ToString(@"h\:mm\:ss\.fff");
                    try
                    {
                        this.TextBox_timestamp.Text = currentTime;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                // Waveform PictureBox (with memory management)
                if (this.PictureBox_waveform != null)
                {
                    try
                    {
                        if (this.SelectedTrack != null)
                        {
							// --- Konsistente Berechnung in FRAMES (nicht in Floats) ---
							int channels = Math.Max(1, this.SelectedTrack.Channels);
							long totalFrames = this.SelectedTrack.Length / channels; // Anzahl Frames (pro Kanal)
							long currentFrame = this.SelectedTrack.Position; // Position liefert bereits Frames
							int offsetPixelsFromTime = (int) Math.Floor(currentFrame / (double) this.SamplesPerPixel);

							int visiblePixels = Math.Max(1, this.PictureBox_waveform.Width);
							long visibleFrames = (long) visiblePixels * this.SamplesPerPixel;
							long maxFrameOffset = Math.Max(0L, totalFrames - visibleFrames); // max. Frame-Offset

							// HScrollBar.Value ist in PIXELS
							int effectiveOffsetPixels = this.HScrollBar_offset?.Value ?? offsetPixelsFromTime;

							// Clamp effectiveOffsetPixels auf Basis der Frame-Grenzen
							// HINWEIS: Prüfen Sie, ob Sie HScrollBar.Maximum richtig gesetzt haben.
							// Es sollte HScrollBar_offset.Maximum = maxOffsetPixels + HScrollBar_offset.LargeChange - 1 sein.
							long maxOffsetPixels = (int) Math.Ceiling(maxFrameOffset / (double) this.SamplesPerPixel);
							effectiveOffsetPixels = (int) Math.Clamp(effectiveOffsetPixels, 0, (int) maxOffsetPixels);

							// Konvertiere PIXELS -> FRAMES -> FLOAT-Index (interleaved samples)
							long frameOffset = (long) effectiveOffsetPixels * this.SamplesPerPixel; // ⬅️ In Frames (Samples per Channel)
							long sampleOffsetFloats = frameOffset * channels; // In interleaved float-Indizes

							// Safety clamp: Darf nicht größer sein als vorhandene Float-Länge minus sichtbare Floats
							long maxFloatOffset = Math.Max(0L, this.SelectedTrack.Length - (visibleFrames * channels));

							if (sampleOffsetFloats > maxFloatOffset)
							{
								// 1. Klemme den Float-Index
								sampleOffsetFloats = maxFloatOffset;
                                frameOffset = sampleOffsetFloats / channels;
							}

							// Generate waveform off the UI if DrawWaveformAsync does heavy work; await it and then set image on UI
							Bitmap? waveformImage = null;
                            try
                            {
                                waveformImage = await this.SelectedTrack.DrawWaveformAsync(
                                    this.PictureBox_waveform.Width,
                                    this.PictureBox_waveform.Height,
                                    this.SamplesPerPixel,
                                    this.DrawEachChannel,
                                    this.CaretWidth,
                                    (this.SelectedTrack.PlayerPlaying || this.SelectedTrack.Paused) ? null : frameOffset,
                                    this.GetNextHue(),
                                    this.BackColor,
                                    this.CaretColor,
                                    this.SmoothenWaveform
                                ).ConfigureAwait(false);

                                // Scroll HScrollBar to follow playback if playing
                                if (this.HScrollBar_offset != null)
                                {
                                    if (this.SelectedTrack.PlayerPlaying)
                                    {
										// HScrollBar offset shall NOT be grabbable !!!

										this.WindowMain.Invoke(() =>
                                        {
											this.HScrollBar_offset.Value = Math.Min(this.HScrollBar_offset.Maximum - this.HScrollBar_offset.LargeChange + 1, offsetPixelsFromTime);
                                        });
                                    }
                                    else
                                    {
										// HScrollBar offset SHALL be grabbable !!!
									}
								}
							}
							catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            if (this.PictureBox_waveform.IsHandleCreated)
                            {
                                try
                                {
                                    this.PictureBox_waveform.Invoke(() =>
                                    {
                                        // Dispose old image
                                        if (this.PictureBox_waveform.Image != null)
                                        {
                                            var oldImage = this.PictureBox_waveform.Image;
                                            this.PictureBox_waveform.Image = null;
                                            oldImage.Dispose();
                                        }

                                        this.PictureBox_waveform.Image = waveformImage;
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                            }
                            else
                            {
                                // If handle not created, assign later (best-effort)
                                this.PictureBox_waveform.Image = waveformImage;
                            }
                        }
                        else
                        {
                            try
                            {
                                if (this.PictureBox_waveform.Image != null)
                                {
                                    var oldImage = this.PictureBox_waveform.Image;
                                    this.PictureBox_waveform.Image = null;
                                    oldImage.Dispose();
                                    if (garbageCollectionDelay <= 0)
                                    {
                                        GC.Collect();

                                    }
                                    else if (this.LastGarbageCollected - DateTime.Now < TimeSpan.FromMilliseconds(garbageCollectionDelay))
                                    {
                                        GC.Collect();
                                        this.LastGarbageCollected = DateTime.Now;
									}
                                }
                                this.PictureBox_waveform.Image = null;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            finally
            {
                Interlocked.Exchange(ref this.isRendering, 0);
            }
        }

        private void Register_Numeric_Pow2(NumericUpDown numeric)
        {
            // Store value in tag
            if (numeric.Tag == null)
            {
                numeric.Tag = (int) numeric.Value;
            }

            numeric.ValueChanged += (sender, e) =>
            {
                int oldValue = (int) numeric.Tag;
                if (numeric.Value > oldValue)
                {
                    numeric.Value = Math.Min(numeric.Maximum, oldValue * 2);
                }
                else if (numeric.Value < oldValue)
                {
                    numeric.Value = Math.Max(oldValue / 2, numeric.Minimum);
                }

                numeric.Tag = (int) numeric.Value;
            };
        }

        private void ListBox_audios_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            ListBox listBox = (ListBox) sender;

            // Sicherstellen, dass das Element existiert
            if (e.Index < 0 || e.Index >= listBox.Items.Count)
            {
                e.DrawBackground();
                return;
            }

            //1. Text und Hintergrund zeichnen

            // Zeichen den Hintergrund für den aktuellen Zustand (selected, normal)
            e.DrawBackground();

            // Hole das Datenobjekt für das aktuelle Element
            object item = listBox.Items[e.Index];
            // Hole den anzuzeigenden Text über DisplayMember ("Name")
            string itemText = item.GetType().GetProperty(listBox.DisplayMember)?.GetValue(item)?.ToString() ?? "(Error)";

            //2. Die Zeichenfläche definieren
            Rectangle textRect = e.Bounds;

            // Optional: Füge etwas Padding auf der linken Seite hinzu
            textRect.X += 2;
            textRect.Width -= 4;

            //3. Textformatierung festlegen

            TextFormatFlags flags = TextFormatFlags.VerticalCenter |
                            TextFormatFlags.Left |
                            TextFormatFlags.SingleLine |
                            TextFormatFlags.EndEllipsis;

            // Farbe des Textes bestimmen
            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                        ? SystemColors.HighlightText
                        : SystemColors.WindowText;

            //4. Text zeichnen
            TextRenderer.DrawText(
                e.Graphics,
                itemText,
                e.Font,
                textRect,
                textColor,
                flags
            );

            //5. Fokus-Rechteck zeichnen (wichtig für Zugänglichkeit, falls das Element ausgewählt ist)
            e.DrawFocusRectangle();
        }

        private void AdjustOffsetHScrollBarValues()
        {
            if (this.SelectedTrack == null || this.PictureBox_waveform == null || this.HScrollBar_offset == null)
            {
                return;
            }

            // Konsistente Einheiten: Frames (nicht in interleaved floats)
            int channels = Math.Max(1, this.SelectedTrack.Channels);
            long totalFrames = this.SelectedTrack.Length / channels;
            int visiblePixels = Math.Max(1, this.PictureBox_waveform.Width);

            long totalPixelsLong = (long)Math.Ceiling(totalFrames / (double)this.SamplesPerPixel); // pixels = frames / samplesPerPixel
            int largeChange = Math.Max(1, visiblePixels);
            long maxOffsetPixels = Math.Max(0, totalPixelsLong - visiblePixels);
            long effectiveMaximum = maxOffsetPixels + (largeChange - 1);

            this.HScrollBar_offset.Invoke(() =>
            {
                this.HScrollBar_offset.Minimum = 0;
                this.HScrollBar_offset.LargeChange = largeChange;
                this.HScrollBar_offset.SmallChange = Math.Max(1, largeChange / 10);

                // Maximum must be set so that usable range equals maxOffsetPixels
                this.HScrollBar_offset.Maximum = (int)Math.Min(int.MaxValue, Math.Max(this.HScrollBar_offset.Minimum, effectiveMaximum));

                // Ensure current value remains inside usable range [0, maxOffsetPixels]
                int usableMax = Math.Max(0, this.HScrollBar_offset.Maximum - this.HScrollBar_offset.LargeChange + 1);
                this.HScrollBar_offset.Value = Math.Min(usableMax, Math.Max(this.HScrollBar_offset.Minimum, this.HScrollBar_offset.Value));
            });
        }

        private Color GetNextHue(float? increment = null, bool updateWaveColor = true)
        {
            if (increment == null)
            {
                increment = this.HueAdjustment;
			}

            float currentHue = this.WaveColor.GetHue();
            float newHue = (currentHue + increment.Value) % 360f;
            
            if (updateWaveColor)
            {
                this.WaveColor = ColorFromHSV(newHue, 1.0f, 1.0f);
			}

			return ColorFromHSV(newHue, 1.0f, 1.0f);
		}

        public static Color ColorFromHSV(float hue, float saturation, float value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            float f = hue / 60 - (float)Math.Floor(hue / 60);
            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
            return hi switch
            {
                0 => Color.FromArgb(255, v, t, p),
                1 => Color.FromArgb(255, q, v, p),
                2 => Color.FromArgb(255, p, v, t),
                3 => Color.FromArgb(255, p, q, v),
                4 => Color.FromArgb(255, t, p, v),
                _ => Color.FromArgb(255, v, p, q),
            };
		}

        public static Color GetNegativeColor(Color color)
        {
            return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
		}
	}
}
