namespace Breakbot404.Forms
{
    partial class WindowMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_samples = new ListBox();
            this.pictureBox_waveform = new PictureBox();
            this.button_import = new Button();
            this.button_cut = new Button();
            this.button_remove = new Button();
            this.groupBox_playback = new GroupBox();
            this.label_sampleRate = new Label();
            this.hScrollBar_sampleRate = new HScrollBar();
            this.button_copy = new Button();
            this.label_selectionMode = new Label();
            this.button_selectionMode = new Button();
            this.checkBox_seek = new CheckBox();
            this.textBox_recordingTime = new TextBox();
            this.button_record = new Button();
            this.textBox_timestamp = new TextBox();
            this.button_pause = new Button();
            this.button_playback = new Button();
            this.button_scanBpm = new Button();
            this.textBox_scannedBpm = new TextBox();
            this.vScrollBar_volume = new VScrollBar();
            this.groupBox_view = new GroupBox();
            this.checkBox_confirmOperations = new CheckBox();
            this.label_info_caretWidth = new Label();
            this.numericUpDown_caretWidth = new NumericUpDown();
            this.button_colorCaret = new Button();
            this.button_strobe = new Button();
            this.numericUpDown_hue = new NumericUpDown();
            this.checkBox_hue = new CheckBox();
            this.checkBox_smoothen = new CheckBox();
            this.checkBox_drawEachChannel = new CheckBox();
            this.label_info_samplesPerPixel = new Label();
            this.checkBox_scrollLog = new CheckBox();
            this.numericUpDown_samplesPerPixel = new NumericUpDown();
            this.label_info_colors = new Label();
            this.label_info_frameRate = new Label();
            this.numericUpDown_frameRate = new NumericUpDown();
            this.button_colorBack = new Button();
            this.button_colorWave = new Button();
            this.listBox_log = new ListBox();
            this.textBox_info = new TextBox();
            this.button_export = new Button();
            this.groupBox_exportSettings = new GroupBox();
            this.label_info_browse = new Label();
            this.label_info_exportBits = new Label();
            this.label_info_exportFormat = new Label();
            this.button_browse = new Button();
            this.label_workingDir = new Label();
            this.comboBox_bits = new ComboBox();
            this.comboBox_format = new ComboBox();
            this.groupBox_beatScan = new GroupBox();
            this.label_info_maxBpm = new Label();
            this.label_info_minBpm = new Label();
            this.numericUpDown_minBpm = new NumericUpDown();
            this.numericUpDown_maxBpm = new NumericUpDown();
            this.label_info_scanWidth = new Label();
            this.label_lookRange = new Label();
            this.numericUpDown_lookRange = new NumericUpDown();
            this.numericUpDown_scanWidth = new NumericUpDown();
            this.hScrollBar_offset = new HScrollBar();
            this.label_volume = new Label();
            this.groupBox_cutting = new GroupBox();
            this.label_info_truncateEnd = new Label();
            this.button_truncate = new Button();
            this.label_info_truncateStart = new Label();
            this.checkBox_keepOriginal = new CheckBox();
            this.numericUpDown_truncateEnd = new NumericUpDown();
            this.numericUpDown_truncateStart = new NumericUpDown();
            this.label_info_silenceWindow = new Label();
            this.numericUpDown_silenceWindow = new NumericUpDown();
            this.label_info_maxDuration = new Label();
            this.numericUpDown_maxDuration = new NumericUpDown();
            this.label_info_minDuration = new Label();
            this.numericUpDown_minDuration = new NumericUpDown();
            this.label_info_targetLufs = new Label();
            this.numericUpDown_targetLufs = new NumericUpDown();
            this.progressBar_cutting = new ProgressBar();
            this.button_reload = new Button();
            this.numericUpDown_timeMarkers = new NumericUpDown();
            this.checkBox_timeMarkers = new CheckBox();
            ((System.ComponentModel.ISupportInitialize) this.pictureBox_waveform).BeginInit();
            this.groupBox_playback.SuspendLayout();
            this.groupBox_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_caretWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_samplesPerPixel).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_frameRate).BeginInit();
            this.groupBox_exportSettings.SuspendLayout();
            this.groupBox_beatScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_minBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_maxBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_lookRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_scanWidth).BeginInit();
            this.groupBox_cutting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_truncateEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_truncateStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_silenceWindow).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_maxDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_minDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_targetLufs).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_timeMarkers).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_samples
            // 
            this.listBox_samples.FormattingEnabled = true;
            this.listBox_samples.ItemHeight = 15;
            this.listBox_samples.Location = new Point(997, 625);
            this.listBox_samples.Name = "listBox_samples";
            this.listBox_samples.Size = new Size(255, 184);
            this.listBox_samples.TabIndex = 0;
            // 
            // pictureBox_waveform
            // 
            this.pictureBox_waveform.BackColor = Color.White;
            this.pictureBox_waveform.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox_waveform.Location = new Point(12, 625);
            this.pictureBox_waveform.Name = "pictureBox_waveform";
            this.pictureBox_waveform.Size = new Size(800, 170);
            this.pictureBox_waveform.TabIndex = 1;
            this.pictureBox_waveform.TabStop = false;
            // 
            // button_import
            // 
            this.button_import.BackColor = SystemColors.Info;
            this.button_import.Location = new Point(916, 425);
            this.button_import.Name = "button_import";
            this.button_import.Size = new Size(75, 23);
            this.button_import.TabIndex = 2;
            this.button_import.Text = "Import";
            this.button_import.UseVisualStyleBackColor = false;
            // 
            // button_cut
            // 
            this.button_cut.Location = new Point(6, 206);
            this.button_cut.Name = "button_cut";
            this.button_cut.Size = new Size(65, 23);
            this.button_cut.TabIndex = 3;
            this.button_cut.Text = "Cut";
            this.button_cut.UseVisualStyleBackColor = true;
            // 
            // button_remove
            // 
            this.button_remove.BackColor = SystemColors.ControlLight;
            this.button_remove.Location = new Point(916, 512);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new Size(75, 23);
            this.button_remove.TabIndex = 4;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = false;
            // 
            // groupBox_playback
            // 
            this.groupBox_playback.BackColor = SystemColors.ControlLight;
            this.groupBox_playback.Controls.Add(this.label_sampleRate);
            this.groupBox_playback.Controls.Add(this.hScrollBar_sampleRate);
            this.groupBox_playback.Controls.Add(this.button_copy);
            this.groupBox_playback.Controls.Add(this.label_selectionMode);
            this.groupBox_playback.Controls.Add(this.button_selectionMode);
            this.groupBox_playback.Controls.Add(this.checkBox_seek);
            this.groupBox_playback.Controls.Add(this.textBox_recordingTime);
            this.groupBox_playback.Controls.Add(this.button_record);
            this.groupBox_playback.Controls.Add(this.textBox_timestamp);
            this.groupBox_playback.Controls.Add(this.button_pause);
            this.groupBox_playback.Controls.Add(this.button_playback);
            this.groupBox_playback.Location = new Point(835, 625);
            this.groupBox_playback.Name = "groupBox_playback";
            this.groupBox_playback.Size = new Size(156, 184);
            this.groupBox_playback.TabIndex = 5;
            this.groupBox_playback.TabStop = false;
            this.groupBox_playback.Text = "Playback";
            // 
            // label_sampleRate
            // 
            this.label_sampleRate.AutoSize = true;
            this.label_sampleRate.Font = new Font("Bahnschrift SemiCondensed", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.label_sampleRate.Location = new Point(6, 92);
            this.label_sampleRate.Margin = new Padding(3, 0, 5, 0);
            this.label_sampleRate.Name = "label_sampleRate";
            this.label_sampleRate.Size = new Size(112, 14);
            this.label_sampleRate.TabIndex = 18;
            this.label_sampleRate.Text = "Sample Rate: - (100%)";
            // 
            // hScrollBar_sampleRate
            // 
            this.hScrollBar_sampleRate.LargeChange = 1;
            this.hScrollBar_sampleRate.Location = new Point(6, 109);
            this.hScrollBar_sampleRate.Margin = new Padding(0, 3, 0, 0);
            this.hScrollBar_sampleRate.Maximum = 500;
            this.hScrollBar_sampleRate.Minimum = -500;
            this.hScrollBar_sampleRate.Name = "hScrollBar_sampleRate";
            this.hScrollBar_sampleRate.Size = new Size(144, 14);
            this.hScrollBar_sampleRate.TabIndex = 18;
            // 
            // button_copy
            // 
            this.button_copy.ForeColor = Color.Black;
            this.button_copy.Location = new Point(69, 22);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new Size(23, 23);
            this.button_copy.TabIndex = 18;
            this.button_copy.Text = "⿻";
            this.button_copy.UseVisualStyleBackColor = true;
            // 
            // label_selectionMode
            // 
            this.label_selectionMode.AutoSize = true;
            this.label_selectionMode.Font = new Font("Bahnschrift SemiCondensed", 9F, FontStyle.Underline, GraphicsUnit.Point,  0);
            this.label_selectionMode.Location = new Point(32, 25);
            this.label_selectionMode.Margin = new Padding(0, 0, 3, 0);
            this.label_selectionMode.Name = "label_selectionMode";
            this.label_selectionMode.Size = new Size(31, 14);
            this.label_selectionMode.TabIndex = 18;
            this.label_selectionMode.Text = "Look";
            // 
            // button_selectionMode
            // 
            this.button_selectionMode.Location = new Point(6, 22);
            this.button_selectionMode.Name = "button_selectionMode";
            this.button_selectionMode.Size = new Size(23, 23);
            this.button_selectionMode.TabIndex = 18;
            this.button_selectionMode.Tag = "";
            this.button_selectionMode.Text = "⛶";
            this.button_selectionMode.UseVisualStyleBackColor = true;
            // 
            // checkBox_seek
            // 
            this.checkBox_seek.AutoSize = true;
            this.checkBox_seek.Checked = true;
            this.checkBox_seek.CheckState = CheckState.Checked;
            this.checkBox_seek.Location = new Point(100, 25);
            this.checkBox_seek.Name = "checkBox_seek";
            this.checkBox_seek.Size = new Size(50, 19);
            this.checkBox_seek.TabIndex = 14;
            this.checkBox_seek.Text = "Seek";
            this.checkBox_seek.UseVisualStyleBackColor = true;
            // 
            // textBox_recordingTime
            // 
            this.textBox_recordingTime.Location = new Point(64, 126);
            this.textBox_recordingTime.Name = "textBox_recordingTime";
            this.textBox_recordingTime.PlaceholderText = "Not recording";
            this.textBox_recordingTime.Size = new Size(86, 23);
            this.textBox_recordingTime.TabIndex = 6;
            // 
            // button_record
            // 
            this.button_record.Location = new Point(35, 126);
            this.button_record.Name = "button_record";
            this.button_record.Size = new Size(23, 23);
            this.button_record.TabIndex = 6;
            this.button_record.Text = "●";
            this.button_record.UseVisualStyleBackColor = true;
            // 
            // textBox_timestamp
            // 
            this.textBox_timestamp.Location = new Point(64, 155);
            this.textBox_timestamp.MaxLength = 64;
            this.textBox_timestamp.Name = "textBox_timestamp";
            this.textBox_timestamp.PlaceholderText = "0:00:00.000";
            this.textBox_timestamp.ReadOnly = true;
            this.textBox_timestamp.Size = new Size(86, 23);
            this.textBox_timestamp.TabIndex = 6;
            this.textBox_timestamp.TabStop = false;
            // 
            // button_pause
            // 
            this.button_pause.Font = new Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_pause.ForeColor = Color.Gray;
            this.button_pause.Location = new Point(35, 155);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new Size(23, 23);
            this.button_pause.TabIndex = 6;
            this.button_pause.Text = "||";
            this.button_pause.UseVisualStyleBackColor = true;
            // 
            // button_playback
            // 
            this.button_playback.Location = new Point(6, 155);
            this.button_playback.Name = "button_playback";
            this.button_playback.Size = new Size(23, 23);
            this.button_playback.TabIndex = 6;
            this.button_playback.Tag = "■";
            this.button_playback.Text = "▶";
            this.button_playback.UseVisualStyleBackColor = true;
            // 
            // button_scanBpm
            // 
            this.button_scanBpm.Location = new Point(6, 27);
            this.button_scanBpm.Name = "button_scanBpm";
            this.button_scanBpm.Size = new Size(52, 23);
            this.button_scanBpm.TabIndex = 10;
            this.button_scanBpm.Text = "Scan";
            this.button_scanBpm.UseVisualStyleBackColor = true;
            // 
            // textBox_scannedBpm
            // 
            this.textBox_scannedBpm.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.textBox_scannedBpm.Location = new Point(64, 27);
            this.textBox_scannedBpm.MaxLength = 64;
            this.textBox_scannedBpm.Name = "textBox_scannedBpm";
            this.textBox_scannedBpm.PlaceholderText = "0.000 BPM";
            this.textBox_scannedBpm.ReadOnly = true;
            this.textBox_scannedBpm.Size = new Size(86, 23);
            this.textBox_scannedBpm.TabIndex = 10;
            this.textBox_scannedBpm.TabStop = false;
            // 
            // vScrollBar_volume
            // 
            this.vScrollBar_volume.Location = new Point(815, 625);
            this.vScrollBar_volume.Maximum = 1000;
            this.vScrollBar_volume.Name = "vScrollBar_volume";
            this.vScrollBar_volume.Size = new Size(17, 170);
            this.vScrollBar_volume.TabIndex = 6;
            // 
            // groupBox_view
            // 
            this.groupBox_view.BackColor = SystemColors.ControlLight;
            this.groupBox_view.Controls.Add(this.checkBox_timeMarkers);
            this.groupBox_view.Controls.Add(this.numericUpDown_timeMarkers);
            this.groupBox_view.Controls.Add(this.checkBox_confirmOperations);
            this.groupBox_view.Controls.Add(this.label_info_caretWidth);
            this.groupBox_view.Controls.Add(this.numericUpDown_caretWidth);
            this.groupBox_view.Controls.Add(this.button_colorCaret);
            this.groupBox_view.Controls.Add(this.button_strobe);
            this.groupBox_view.Controls.Add(this.numericUpDown_hue);
            this.groupBox_view.Controls.Add(this.checkBox_hue);
            this.groupBox_view.Controls.Add(this.checkBox_smoothen);
            this.groupBox_view.Controls.Add(this.checkBox_drawEachChannel);
            this.groupBox_view.Controls.Add(this.label_info_samplesPerPixel);
            this.groupBox_view.Controls.Add(this.checkBox_scrollLog);
            this.groupBox_view.Controls.Add(this.numericUpDown_samplesPerPixel);
            this.groupBox_view.Controls.Add(this.label_info_colors);
            this.groupBox_view.Controls.Add(this.label_info_frameRate);
            this.groupBox_view.Controls.Add(this.numericUpDown_frameRate);
            this.groupBox_view.Controls.Add(this.button_colorBack);
            this.groupBox_view.Controls.Add(this.button_colorWave);
            this.groupBox_view.Location = new Point(12, 12);
            this.groupBox_view.Name = "groupBox_view";
            this.groupBox_view.Size = new Size(180, 391);
            this.groupBox_view.TabIndex = 7;
            this.groupBox_view.TabStop = false;
            this.groupBox_view.Text = "View Settings";
            // 
            // checkBox_confirmOperations
            // 
            this.checkBox_confirmOperations.AutoSize = true;
            this.checkBox_confirmOperations.Location = new Point(6, 341);
            this.checkBox_confirmOperations.Name = "checkBox_confirmOperations";
            this.checkBox_confirmOperations.Size = new Size(131, 19);
            this.checkBox_confirmOperations.TabIndex = 18;
            this.checkBox_confirmOperations.Text = "Confirm Operations";
            this.checkBox_confirmOperations.UseVisualStyleBackColor = true;
            // 
            // label_info_caretWidth
            // 
            this.label_info_caretWidth.AutoSize = true;
            this.label_info_caretWidth.Location = new Point(6, 256);
            this.label_info_caretWidth.Name = "label_info_caretWidth";
            this.label_info_caretWidth.Size = new Size(73, 15);
            this.label_info_caretWidth.TabIndex = 18;
            this.label_info_caretWidth.Text = "Caret Width:";
            // 
            // numericUpDown_caretWidth
            // 
            this.numericUpDown_caretWidth.Location = new Point(124, 254);
            this.numericUpDown_caretWidth.Maximum = new decimal(new int[] { 48, 0, 0, 0 });
            this.numericUpDown_caretWidth.Name = "numericUpDown_caretWidth";
            this.numericUpDown_caretWidth.Size = new Size(50, 23);
            this.numericUpDown_caretWidth.TabIndex = 18;
            this.numericUpDown_caretWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // button_colorCaret
            // 
            this.button_colorCaret.BackColor = Color.IndianRed;
            this.button_colorCaret.Font = new Font("Bahnschrift SemiLight SemiConde", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_colorCaret.ForeColor = Color.Black;
            this.button_colorCaret.Location = new Point(58, 22);
            this.button_colorCaret.Margin = new Padding(1, 3, 1, 1);
            this.button_colorCaret.Name = "button_colorCaret";
            this.button_colorCaret.Size = new Size(38, 23);
            this.button_colorCaret.TabIndex = 18;
            this.button_colorCaret.Text = "Caret";
            this.button_colorCaret.UseVisualStyleBackColor = false;
            // 
            // button_strobe
            // 
            this.button_strobe.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_strobe.ForeColor = Color.Black;
            this.button_strobe.Location = new Point(151, 101);
            this.button_strobe.Name = "button_strobe";
            this.button_strobe.Size = new Size(23, 23);
            this.button_strobe.TabIndex = 14;
            this.button_strobe.Text = "🕱";
            this.button_strobe.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_hue
            // 
            this.numericUpDown_hue.DecimalPlaces = 3;
            this.numericUpDown_hue.Increment = new decimal(new int[] { 125, 0, 0, 196608 });
            this.numericUpDown_hue.Location = new Point(75, 101);
            this.numericUpDown_hue.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            this.numericUpDown_hue.Name = "numericUpDown_hue";
            this.numericUpDown_hue.Size = new Size(70, 23);
            this.numericUpDown_hue.TabIndex = 14;
            this.numericUpDown_hue.Value = new decimal(new int[] { 175, 0, 0, 131072 });
            // 
            // checkBox_hue
            // 
            this.checkBox_hue.AutoSize = true;
            this.checkBox_hue.Location = new Point(6, 103);
            this.checkBox_hue.Name = "checkBox_hue";
            this.checkBox_hue.Size = new Size(48, 19);
            this.checkBox_hue.TabIndex = 14;
            this.checkBox_hue.Text = "Hue";
            this.checkBox_hue.UseVisualStyleBackColor = true;
            // 
            // checkBox_smoothen
            // 
            this.checkBox_smoothen.AutoSize = true;
            this.checkBox_smoothen.Location = new Point(6, 76);
            this.checkBox_smoothen.Name = "checkBox_smoothen";
            this.checkBox_smoothen.Size = new Size(124, 19);
            this.checkBox_smoothen.TabIndex = 14;
            this.checkBox_smoothen.Text = "Smooth waveform";
            this.checkBox_smoothen.UseVisualStyleBackColor = true;
            // 
            // checkBox_drawEachChannel
            // 
            this.checkBox_drawEachChannel.AutoSize = true;
            this.checkBox_drawEachChannel.Location = new Point(6, 51);
            this.checkBox_drawEachChannel.Name = "checkBox_drawEachChannel";
            this.checkBox_drawEachChannel.Size = new Size(128, 19);
            this.checkBox_drawEachChannel.TabIndex = 12;
            this.checkBox_drawEachChannel.Text = "Draw each Channel";
            this.checkBox_drawEachChannel.UseVisualStyleBackColor = true;
            // 
            // label_info_samplesPerPixel
            // 
            this.label_info_samplesPerPixel.AutoSize = true;
            this.label_info_samplesPerPixel.Location = new Point(6, 285);
            this.label_info_samplesPerPixel.Name = "label_info_samplesPerPixel";
            this.label_info_samplesPerPixel.Size = new Size(77, 15);
            this.label_info_samplesPerPixel.TabIndex = 9;
            this.label_info_samplesPerPixel.Text = "Samples / px:";
            // 
            // checkBox_scrollLog
            // 
            this.checkBox_scrollLog.AutoSize = true;
            this.checkBox_scrollLog.Checked = true;
            this.checkBox_scrollLog.CheckState = CheckState.Checked;
            this.checkBox_scrollLog.Location = new Point(6, 366);
            this.checkBox_scrollLog.Name = "checkBox_scrollLog";
            this.checkBox_scrollLog.Size = new Size(144, 19);
            this.checkBox_scrollLog.TabIndex = 11;
            this.checkBox_scrollLog.Text = "Auto scroll Log Entries";
            this.checkBox_scrollLog.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_samplesPerPixel
            // 
            this.numericUpDown_samplesPerPixel.Location = new Point(109, 283);
            this.numericUpDown_samplesPerPixel.Maximum = new decimal(new int[] { 16384, 0, 0, 0 });
            this.numericUpDown_samplesPerPixel.Name = "numericUpDown_samplesPerPixel";
            this.numericUpDown_samplesPerPixel.Size = new Size(65, 23);
            this.numericUpDown_samplesPerPixel.TabIndex = 10;
            this.numericUpDown_samplesPerPixel.Value = new decimal(new int[] { 128, 0, 0, 0 });
            // 
            // label_info_colors
            // 
            this.label_info_colors.AutoSize = true;
            this.label_info_colors.Location = new Point(6, 26);
            this.label_info_colors.Name = "label_info_colors";
            this.label_info_colors.Size = new Size(44, 15);
            this.label_info_colors.TabIndex = 9;
            this.label_info_colors.Text = "Colors:";
            // 
            // label_info_frameRate
            // 
            this.label_info_frameRate.AutoSize = true;
            this.label_info_frameRate.Location = new Point(6, 314);
            this.label_info_frameRate.Name = "label_info_frameRate";
            this.label_info_frameRate.Size = new Size(69, 15);
            this.label_info_frameRate.TabIndex = 9;
            this.label_info_frameRate.Text = "Frame Rate:";
            // 
            // numericUpDown_frameRate
            // 
            this.numericUpDown_frameRate.Location = new Point(124, 312);
            this.numericUpDown_frameRate.Maximum = new decimal(new int[] { 144, 0, 0, 0 });
            this.numericUpDown_frameRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDown_frameRate.Name = "numericUpDown_frameRate";
            this.numericUpDown_frameRate.Size = new Size(50, 23);
            this.numericUpDown_frameRate.TabIndex = 9;
            this.numericUpDown_frameRate.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // button_colorBack
            // 
            this.button_colorBack.BackColor = Color.White;
            this.button_colorBack.Font = new Font("Bahnschrift SemiLight SemiConde", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_colorBack.Location = new Point(138, 22);
            this.button_colorBack.Margin = new Padding(1, 3, 1, 1);
            this.button_colorBack.Name = "button_colorBack";
            this.button_colorBack.Size = new Size(38, 23);
            this.button_colorBack.TabIndex = 10;
            this.button_colorBack.Text = "Back";
            this.button_colorBack.UseVisualStyleBackColor = false;
            // 
            // button_colorWave
            // 
            this.button_colorWave.BackColor = SystemColors.ActiveCaption;
            this.button_colorWave.Font = new Font("Bahnschrift SemiLight SemiConde", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_colorWave.Location = new Point(98, 22);
            this.button_colorWave.Margin = new Padding(1, 3, 1, 1);
            this.button_colorWave.Name = "button_colorWave";
            this.button_colorWave.Size = new Size(38, 23);
            this.button_colorWave.TabIndex = 9;
            this.button_colorWave.Text = "Wave";
            this.button_colorWave.UseVisualStyleBackColor = false;
            // 
            // listBox_log
            // 
            this.listBox_log.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.HorizontalScrollbar = true;
            this.listBox_log.ItemHeight = 13;
            this.listBox_log.Location = new Point(870, 12);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new Size(382, 407);
            this.listBox_log.TabIndex = 8;
            // 
            // textBox_info
            // 
            this.textBox_info.BackColor = SystemColors.ControlLight;
            this.textBox_info.BorderStyle = BorderStyle.FixedSingle;
            this.textBox_info.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.textBox_info.Location = new Point(997, 425);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.PlaceholderText = "No track or sample selected.";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new Size(255, 194);
            this.textBox_info.TabIndex = 9;
            this.textBox_info.TabStop = false;
            // 
            // button_export
            // 
            this.button_export.BackColor = SystemColors.InactiveCaption;
            this.button_export.Location = new Point(916, 483);
            this.button_export.Name = "button_export";
            this.button_export.Size = new Size(75, 23);
            this.button_export.TabIndex = 10;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = false;
            // 
            // groupBox_exportSettings
            // 
            this.groupBox_exportSettings.BackColor = SystemColors.ControlLight;
            this.groupBox_exportSettings.Controls.Add(this.label_info_browse);
            this.groupBox_exportSettings.Controls.Add(this.label_info_exportBits);
            this.groupBox_exportSettings.Controls.Add(this.label_info_exportFormat);
            this.groupBox_exportSettings.Controls.Add(this.button_browse);
            this.groupBox_exportSettings.Controls.Add(this.label_workingDir);
            this.groupBox_exportSettings.Controls.Add(this.comboBox_bits);
            this.groupBox_exportSettings.Controls.Add(this.comboBox_format);
            this.groupBox_exportSettings.Location = new Point(644, 12);
            this.groupBox_exportSettings.Name = "groupBox_exportSettings";
            this.groupBox_exportSettings.Size = new Size(220, 150);
            this.groupBox_exportSettings.TabIndex = 11;
            this.groupBox_exportSettings.TabStop = false;
            this.groupBox_exportSettings.Text = "Export Settings";
            // 
            // label_info_browse
            // 
            this.label_info_browse.AutoSize = true;
            this.label_info_browse.Location = new Point(6, 84);
            this.label_info_browse.Name = "label_info_browse";
            this.label_info_browse.Size = new Size(144, 15);
            this.label_info_browse.TabIndex = 12;
            this.label_info_browse.Text = "Browse Working Directory";
            // 
            // label_info_exportBits
            // 
            this.label_info_exportBits.AutoSize = true;
            this.label_info_exportBits.Location = new Point(6, 54);
            this.label_info_exportBits.Name = "label_info_exportBits";
            this.label_info_exportBits.Size = new Size(78, 15);
            this.label_info_exportBits.TabIndex = 12;
            this.label_info_exportBits.Text = "Quality (Bits):";
            // 
            // label_info_exportFormat
            // 
            this.label_info_exportFormat.AutoSize = true;
            this.label_info_exportFormat.Location = new Point(6, 25);
            this.label_info_exportFormat.Name = "label_info_exportFormat";
            this.label_info_exportFormat.Size = new Size(81, 15);
            this.label_info_exportFormat.TabIndex = 12;
            this.label_info_exportFormat.Text = "Save audio as:";
            // 
            // button_browse
            // 
            this.button_browse.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_browse.Location = new Point(178, 80);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new Size(36, 23);
            this.button_browse.TabIndex = 12;
            this.button_browse.Text = "[...]";
            this.button_browse.UseVisualStyleBackColor = true;
            // 
            // label_workingDir
            // 
            this.label_workingDir.AutoSize = true;
            this.label_workingDir.Font = new Font("Bahnschrift SemiLight SemiConde", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.label_workingDir.Location = new Point(4, 131);
            this.label_workingDir.Margin = new Padding(1, 0, 3, 0);
            this.label_workingDir.Name = "label_workingDir";
            this.label_workingDir.Padding = new Padding(0, 0, 0, 2);
            this.label_workingDir.Size = new Size(130, 16);
            this.label_workingDir.TabIndex = 12;
            this.label_workingDir.Text = "X:\\MyMusic\\_BreakBot404";
            // 
            // comboBox_bits
            // 
            this.comboBox_bits.FormattingEnabled = true;
            this.comboBox_bits.Location = new Point(129, 51);
            this.comboBox_bits.Name = "comboBox_bits";
            this.comboBox_bits.Size = new Size(85, 23);
            this.comboBox_bits.TabIndex = 12;
            this.comboBox_bits.Text = "Bits";
            // 
            // comboBox_format
            // 
            this.comboBox_format.FormattingEnabled = true;
            this.comboBox_format.Items.AddRange(new object[] { ".wav", ".mp3" });
            this.comboBox_format.Location = new Point(129, 22);
            this.comboBox_format.Name = "comboBox_format";
            this.comboBox_format.Size = new Size(85, 23);
            this.comboBox_format.TabIndex = 12;
            this.comboBox_format.Text = "Format";
            // 
            // groupBox_beatScan
            // 
            this.groupBox_beatScan.BackColor = SystemColors.ControlLight;
            this.groupBox_beatScan.Controls.Add(this.label_info_maxBpm);
            this.groupBox_beatScan.Controls.Add(this.label_info_minBpm);
            this.groupBox_beatScan.Controls.Add(this.numericUpDown_minBpm);
            this.groupBox_beatScan.Controls.Add(this.button_scanBpm);
            this.groupBox_beatScan.Controls.Add(this.numericUpDown_maxBpm);
            this.groupBox_beatScan.Controls.Add(this.textBox_scannedBpm);
            this.groupBox_beatScan.Controls.Add(this.label_info_scanWidth);
            this.groupBox_beatScan.Controls.Add(this.label_lookRange);
            this.groupBox_beatScan.Controls.Add(this.numericUpDown_lookRange);
            this.groupBox_beatScan.Controls.Add(this.numericUpDown_scanWidth);
            this.groupBox_beatScan.Location = new Point(478, 12);
            this.groupBox_beatScan.Name = "groupBox_beatScan";
            this.groupBox_beatScan.Size = new Size(160, 150);
            this.groupBox_beatScan.TabIndex = 12;
            this.groupBox_beatScan.TabStop = false;
            this.groupBox_beatScan.Text = "Beat Scan (BPM)";
            // 
            // label_info_maxBpm
            // 
            this.label_info_maxBpm.AutoSize = true;
            this.label_info_maxBpm.Location = new Point(93, 103);
            this.label_info_maxBpm.Name = "label_info_maxBpm";
            this.label_info_maxBpm.Size = new Size(60, 15);
            this.label_info_maxBpm.TabIndex = 14;
            this.label_info_maxBpm.Text = "Max. BPM";
            // 
            // label_info_minBpm
            // 
            this.label_info_minBpm.AutoSize = true;
            this.label_info_minBpm.Location = new Point(28, 103);
            this.label_info_minBpm.Name = "label_info_minBpm";
            this.label_info_minBpm.Size = new Size(59, 15);
            this.label_info_minBpm.TabIndex = 13;
            this.label_info_minBpm.Text = "Min. BPM";
            // 
            // numericUpDown_minBpm
            // 
            this.numericUpDown_minBpm.Location = new Point(28, 121);
            this.numericUpDown_minBpm.Maximum = new decimal(new int[] { 150, 0, 0, 0 });
            this.numericUpDown_minBpm.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
            this.numericUpDown_minBpm.Name = "numericUpDown_minBpm";
            this.numericUpDown_minBpm.Size = new Size(60, 23);
            this.numericUpDown_minBpm.TabIndex = 14;
            this.numericUpDown_minBpm.Value = new decimal(new int[] { 70, 0, 0, 0 });
            // 
            // numericUpDown_maxBpm
            // 
            this.numericUpDown_maxBpm.Location = new Point(94, 121);
            this.numericUpDown_maxBpm.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numericUpDown_maxBpm.Minimum = new decimal(new int[] { 80, 0, 0, 0 });
            this.numericUpDown_maxBpm.Name = "numericUpDown_maxBpm";
            this.numericUpDown_maxBpm.Size = new Size(60, 23);
            this.numericUpDown_maxBpm.TabIndex = 13;
            this.numericUpDown_maxBpm.Value = new decimal(new int[] { 210, 0, 0, 0 });
            // 
            // label_info_scanWidth
            // 
            this.label_info_scanWidth.AutoSize = true;
            this.label_info_scanWidth.Location = new Point(84, 59);
            this.label_info_scanWidth.Name = "label_info_scanWidth";
            this.label_info_scanWidth.Size = new Size(39, 15);
            this.label_info_scanWidth.TabIndex = 13;
            this.label_info_scanWidth.Text = "Width";
            // 
            // label_lookRange
            // 
            this.label_lookRange.AutoSize = true;
            this.label_lookRange.Location = new Point(28, 59);
            this.label_lookRange.Name = "label_lookRange";
            this.label_lookRange.Size = new Size(40, 15);
            this.label_lookRange.TabIndex = 14;
            this.label_lookRange.Text = "Range";
            // 
            // numericUpDown_lookRange
            // 
            this.numericUpDown_lookRange.Location = new Point(28, 77);
            this.numericUpDown_lookRange.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            this.numericUpDown_lookRange.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDown_lookRange.Name = "numericUpDown_lookRange";
            this.numericUpDown_lookRange.Size = new Size(50, 23);
            this.numericUpDown_lookRange.TabIndex = 15;
            this.numericUpDown_lookRange.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // numericUpDown_scanWidth
            // 
            this.numericUpDown_scanWidth.Location = new Point(84, 77);
            this.numericUpDown_scanWidth.Maximum = new decimal(new int[] { 65536, 0, 0, 0 });
            this.numericUpDown_scanWidth.Minimum = new decimal(new int[] { 32, 0, 0, 0 });
            this.numericUpDown_scanWidth.Name = "numericUpDown_scanWidth";
            this.numericUpDown_scanWidth.Size = new Size(70, 23);
            this.numericUpDown_scanWidth.TabIndex = 14;
            this.numericUpDown_scanWidth.Value = new decimal(new int[] { 16384, 0, 0, 0 });
            // 
            // hScrollBar_offset
            // 
            this.hScrollBar_offset.LargeChange = 2;
            this.hScrollBar_offset.Location = new Point(12, 798);
            this.hScrollBar_offset.Maximum = 1;
            this.hScrollBar_offset.Name = "hScrollBar_offset";
            this.hScrollBar_offset.Size = new Size(800, 14);
            this.hScrollBar_offset.TabIndex = 13;
            // 
            // label_volume
            // 
            this.label_volume.AutoSize = true;
            this.label_volume.Location = new Point(788, 607);
            this.label_volume.Name = "label_volume";
            this.label_volume.Size = new Size(44, 15);
            this.label_volume.TabIndex = 14;
            this.label_volume.Text = "100.0%";
            // 
            // groupBox_cutting
            // 
            this.groupBox_cutting.BackColor = SystemColors.ControlLight;
            this.groupBox_cutting.Controls.Add(this.label_info_truncateEnd);
            this.groupBox_cutting.Controls.Add(this.button_truncate);
            this.groupBox_cutting.Controls.Add(this.label_info_truncateStart);
            this.groupBox_cutting.Controls.Add(this.checkBox_keepOriginal);
            this.groupBox_cutting.Controls.Add(this.numericUpDown_truncateEnd);
            this.groupBox_cutting.Controls.Add(this.numericUpDown_truncateStart);
            this.groupBox_cutting.Controls.Add(this.label_info_silenceWindow);
            this.groupBox_cutting.Controls.Add(this.numericUpDown_silenceWindow);
            this.groupBox_cutting.Controls.Add(this.label_info_maxDuration);
            this.groupBox_cutting.Controls.Add(this.numericUpDown_maxDuration);
            this.groupBox_cutting.Controls.Add(this.label_info_minDuration);
            this.groupBox_cutting.Controls.Add(this.numericUpDown_minDuration);
            this.groupBox_cutting.Controls.Add(this.label_info_targetLufs);
            this.groupBox_cutting.Controls.Add(this.numericUpDown_targetLufs);
            this.groupBox_cutting.Controls.Add(this.button_cut);
            this.groupBox_cutting.Location = new Point(644, 168);
            this.groupBox_cutting.Name = "groupBox_cutting";
            this.groupBox_cutting.Size = new Size(220, 235);
            this.groupBox_cutting.TabIndex = 15;
            this.groupBox_cutting.TabStop = false;
            this.groupBox_cutting.Text = "Auto Cutting Settings";
            // 
            // label_info_truncateEnd
            // 
            this.label_info_truncateEnd.AutoSize = true;
            this.label_info_truncateEnd.Location = new Point(149, 159);
            this.label_info_truncateEnd.Name = "label_info_truncateEnd";
            this.label_info_truncateEnd.Size = new Size(27, 15);
            this.label_info_truncateEnd.TabIndex = 21;
            this.label_info_truncateEnd.Text = "End";
            // 
            // button_truncate
            // 
            this.button_truncate.BackColor = SystemColors.ControlLight;
            this.button_truncate.Location = new Point(6, 177);
            this.button_truncate.Name = "button_truncate";
            this.button_truncate.Size = new Size(65, 23);
            this.button_truncate.TabIndex = 18;
            this.button_truncate.Text = "Truncate";
            this.button_truncate.UseVisualStyleBackColor = false;
            // 
            // label_info_truncateStart
            // 
            this.label_info_truncateStart.AutoSize = true;
            this.label_info_truncateStart.Location = new Point(78, 159);
            this.label_info_truncateStart.Name = "label_info_truncateStart";
            this.label_info_truncateStart.Size = new Size(31, 15);
            this.label_info_truncateStart.TabIndex = 20;
            this.label_info_truncateStart.Text = "Start";
            // 
            // checkBox_keepOriginal
            // 
            this.checkBox_keepOriginal.AutoSize = true;
            this.checkBox_keepOriginal.Checked = true;
            this.checkBox_keepOriginal.CheckState = CheckState.Checked;
            this.checkBox_keepOriginal.Location = new Point(117, 210);
            this.checkBox_keepOriginal.Name = "checkBox_keepOriginal";
            this.checkBox_keepOriginal.Size = new Size(97, 19);
            this.checkBox_keepOriginal.TabIndex = 17;
            this.checkBox_keepOriginal.Text = "Keep Original";
            this.checkBox_keepOriginal.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_truncateEnd
            // 
            this.numericUpDown_truncateEnd.DecimalPlaces = 2;
            this.numericUpDown_truncateEnd.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numericUpDown_truncateEnd.Location = new Point(149, 177);
            this.numericUpDown_truncateEnd.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numericUpDown_truncateEnd.Name = "numericUpDown_truncateEnd";
            this.numericUpDown_truncateEnd.Size = new Size(65, 23);
            this.numericUpDown_truncateEnd.TabIndex = 19;
            // 
            // numericUpDown_truncateStart
            // 
            this.numericUpDown_truncateStart.DecimalPlaces = 2;
            this.numericUpDown_truncateStart.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numericUpDown_truncateStart.Location = new Point(78, 177);
            this.numericUpDown_truncateStart.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numericUpDown_truncateStart.Name = "numericUpDown_truncateStart";
            this.numericUpDown_truncateStart.Size = new Size(65, 23);
            this.numericUpDown_truncateStart.TabIndex = 18;
            // 
            // label_info_silenceWindow
            // 
            this.label_info_silenceWindow.AutoSize = true;
            this.label_info_silenceWindow.Location = new Point(6, 111);
            this.label_info_silenceWindow.Name = "label_info_silenceWindow";
            this.label_info_silenceWindow.Size = new Size(113, 15);
            this.label_info_silenceWindow.TabIndex = 23;
            this.label_info_silenceWindow.Text = "Silence Window ms:";
            // 
            // numericUpDown_silenceWindow
            // 
            this.numericUpDown_silenceWindow.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericUpDown_silenceWindow.Location = new Point(149, 109);
            this.numericUpDown_silenceWindow.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericUpDown_silenceWindow.Name = "numericUpDown_silenceWindow";
            this.numericUpDown_silenceWindow.Size = new Size(65, 23);
            this.numericUpDown_silenceWindow.TabIndex = 22;
            this.numericUpDown_silenceWindow.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // label_info_maxDuration
            // 
            this.label_info_maxDuration.AutoSize = true;
            this.label_info_maxDuration.Location = new Point(6, 82);
            this.label_info_maxDuration.Name = "label_info_maxDuration";
            this.label_info_maxDuration.Size = new Size(103, 15);
            this.label_info_maxDuration.TabIndex = 21;
            this.label_info_maxDuration.Text = "Max. Duration ms:";
            // 
            // numericUpDown_maxDuration
            // 
            this.numericUpDown_maxDuration.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            this.numericUpDown_maxDuration.Location = new Point(149, 80);
            this.numericUpDown_maxDuration.Maximum = new decimal(new int[] { 2500, 0, 0, 0 });
            this.numericUpDown_maxDuration.Name = "numericUpDown_maxDuration";
            this.numericUpDown_maxDuration.Size = new Size(65, 23);
            this.numericUpDown_maxDuration.TabIndex = 20;
            this.numericUpDown_maxDuration.Value = new decimal(new int[] { 650, 0, 0, 0 });
            // 
            // label_info_minDuration
            // 
            this.label_info_minDuration.AutoSize = true;
            this.label_info_minDuration.Location = new Point(6, 53);
            this.label_info_minDuration.Name = "label_info_minDuration";
            this.label_info_minDuration.Size = new Size(102, 15);
            this.label_info_minDuration.TabIndex = 19;
            this.label_info_minDuration.Text = "Min. Duration ms:";
            // 
            // numericUpDown_minDuration
            // 
            this.numericUpDown_minDuration.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            this.numericUpDown_minDuration.Location = new Point(149, 51);
            this.numericUpDown_minDuration.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numericUpDown_minDuration.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericUpDown_minDuration.Name = "numericUpDown_minDuration";
            this.numericUpDown_minDuration.Size = new Size(65, 23);
            this.numericUpDown_minDuration.TabIndex = 18;
            this.numericUpDown_minDuration.Value = new decimal(new int[] { 75, 0, 0, 0 });
            // 
            // label_info_targetLufs
            // 
            this.label_info_targetLufs.AutoSize = true;
            this.label_info_targetLufs.Location = new Point(6, 24);
            this.label_info_targetLufs.Name = "label_info_targetLufs";
            this.label_info_targetLufs.Size = new Size(72, 15);
            this.label_info_targetLufs.TabIndex = 17;
            this.label_info_targetLufs.Text = "Target LUFS:";
            // 
            // numericUpDown_targetLufs
            // 
            this.numericUpDown_targetLufs.DecimalPlaces = 2;
            this.numericUpDown_targetLufs.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            this.numericUpDown_targetLufs.Location = new Point(149, 22);
            this.numericUpDown_targetLufs.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numericUpDown_targetLufs.Minimum = new decimal(new int[] { 96, 0, 0, int.MinValue });
            this.numericUpDown_targetLufs.Name = "numericUpDown_targetLufs";
            this.numericUpDown_targetLufs.Size = new Size(65, 23);
            this.numericUpDown_targetLufs.TabIndex = 16;
            this.numericUpDown_targetLufs.Value = new decimal(new int[] { 14, 0, 0, int.MinValue });
            // 
            // progressBar_cutting
            // 
            this.progressBar_cutting.Location = new Point(644, 409);
            this.progressBar_cutting.Name = "progressBar_cutting";
            this.progressBar_cutting.Size = new Size(220, 10);
            this.progressBar_cutting.TabIndex = 16;
            // 
            // button_reload
            // 
            this.button_reload.Location = new Point(916, 454);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new Size(75, 23);
            this.button_reload.TabIndex = 17;
            this.button_reload.Text = "Reload";
            this.button_reload.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_timeMarkers
            // 
            this.numericUpDown_timeMarkers.DecimalPlaces = 3;
            this.numericUpDown_timeMarkers.Increment = new decimal(new int[] { 125, 0, 0, 196608 });
            this.numericUpDown_timeMarkers.Location = new Point(113, 225);
            this.numericUpDown_timeMarkers.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            this.numericUpDown_timeMarkers.Minimum = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numericUpDown_timeMarkers.Name = "numericUpDown_timeMarkers";
            this.numericUpDown_timeMarkers.Size = new Size(61, 23);
            this.numericUpDown_timeMarkers.TabIndex = 19;
            this.numericUpDown_timeMarkers.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // checkBox_timeMarkers
            // 
            this.checkBox_timeMarkers.AutoSize = true;
            this.checkBox_timeMarkers.Location = new Point(6, 226);
            this.checkBox_timeMarkers.Name = "checkBox_timeMarkers";
            this.checkBox_timeMarkers.Size = new Size(101, 19);
            this.checkBox_timeMarkers.TabIndex = 20;
            this.checkBox_timeMarkers.Text = "Time Markers:";
            this.checkBox_timeMarkers.UseVisualStyleBackColor = true;
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1264, 821);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.progressBar_cutting);
            this.Controls.Add(this.groupBox_cutting);
            this.Controls.Add(this.label_volume);
            this.Controls.Add(this.hScrollBar_offset);
            this.Controls.Add(this.groupBox_beatScan);
            this.Controls.Add(this.groupBox_exportSettings);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.textBox_info);
            this.Controls.Add(this.listBox_log);
            this.Controls.Add(this.groupBox_view);
            this.Controls.Add(this.vScrollBar_volume);
            this.Controls.Add(this.groupBox_playback);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.pictureBox_waveform);
            this.Controls.Add(this.listBox_samples);
            this.Name = "WindowMain";
            this.Text = "BreakBot404 (Forms UI)";
            ((System.ComponentModel.ISupportInitialize) this.pictureBox_waveform).EndInit();
            this.groupBox_playback.ResumeLayout(false);
            this.groupBox_playback.PerformLayout();
            this.groupBox_view.ResumeLayout(false);
            this.groupBox_view.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_caretWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_hue).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_samplesPerPixel).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_frameRate).EndInit();
            this.groupBox_exportSettings.ResumeLayout(false);
            this.groupBox_exportSettings.PerformLayout();
            this.groupBox_beatScan.ResumeLayout(false);
            this.groupBox_beatScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_minBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_maxBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_lookRange).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_scanWidth).EndInit();
            this.groupBox_cutting.ResumeLayout(false);
            this.groupBox_cutting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_truncateEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_truncateStart).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_silenceWindow).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_maxDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_minDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_targetLufs).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_timeMarkers).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ListBox listBox_samples;
        private PictureBox pictureBox_waveform;
        private Button button_import;
        private Button button_cut;
        private Button button_remove;
        private GroupBox groupBox_playback;
        private TextBox textBox_timestamp;
        private Button button_pause;
        private Button button_playback;
        private TextBox textBox_recordingTime;
        private Button button_record;
        private VScrollBar vScrollBar_volume;
        private GroupBox groupBox_view;
        private ListBox listBox_log;
        private Label label_info_samplesPerPixel;
        private NumericUpDown numericUpDown_samplesPerPixel;
        private Label label_info_colors;
        private Button button_colorBack;
        private Button button_colorWave;
        private Label label_info_frameRate;
        private NumericUpDown numericUpDown_frameRate;
        private TextBox textBox_info;
        private Button button_scanBpm;
        private TextBox textBox_scannedBpm;
        private CheckBox checkBox_scrollLog;
        private Button button_export;
        private GroupBox groupBox_exportSettings;
        private Label label_workingDir;
        private ComboBox comboBox_bits;
        private ComboBox comboBox_format;
        private Button button_browse;
        private Label label_info_browse;
        private Label label_info_exportBits;
        private Label label_info_exportFormat;
        private CheckBox checkBox_drawEachChannel;
        private GroupBox groupBox_beatScan;
        private Label label_info_scanWidth;
        private Label label_lookRange;
        private NumericUpDown numericUpDown_lookRange;
        private NumericUpDown numericUpDown_scanWidth;
        private Label label_info_maxBpm;
        private Label label_info_minBpm;
        private NumericUpDown numericUpDown_minBpm;
        private NumericUpDown numericUpDown_maxBpm;
        private HScrollBar hScrollBar_offset;
        private CheckBox checkBox_smoothen;
        private NumericUpDown numericUpDown_hue;
        private CheckBox checkBox_hue;
        private CheckBox checkBox_seek;
        private Button button_strobe;
        private Label label_volume;
        private GroupBox groupBox_cutting;
        private Label label_info_silenceWindow;
        private NumericUpDown numericUpDown_silenceWindow;
        private Label label_info_maxDuration;
        private NumericUpDown numericUpDown_maxDuration;
        private Label label_info_minDuration;
        private NumericUpDown numericUpDown_minDuration;
        private Label label_info_targetLufs;
        private NumericUpDown numericUpDown_targetLufs;
        private CheckBox checkBox_keepOriginal;
        private ProgressBar progressBar_cutting;
        private Button button_reload;
        private Button button_truncate;
        private NumericUpDown numericUpDown_truncateStart;
        private Label label_info_truncateEnd;
        private Label label_info_truncateStart;
        private NumericUpDown numericUpDown_truncateEnd;
        private Button button_selectionMode;
        private Label label_selectionMode;
        private Button button_copy;
        private HScrollBar hScrollBar_sampleRate;
        private Label label_sampleRate;
		private Button button_colorCaret;
		private Label label_info_caretWidth;
		private NumericUpDown numericUpDown_caretWidth;
        private CheckBox checkBox_confirmOperations;
        private CheckBox checkBox_timeMarkers;
        private NumericUpDown numericUpDown_timeMarkers;
    }
}
