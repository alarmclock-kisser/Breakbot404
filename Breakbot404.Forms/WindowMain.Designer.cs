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
            this.button_strobe = new Button();
            this.numericUpDown_hue = new NumericUpDown();
            this.checkBox_hue = new CheckBox();
            this.checkBox_smoothen = new CheckBox();
            this.checkBox_drawEachChannel = new CheckBox();
            this.label_info_samplesPerPixel = new Label();
            this.numericUpDown_samplesPerPixel = new NumericUpDown();
            this.label_info_colors = new Label();
            this.button_colorBack = new Button();
            this.button_colorWave = new Button();
            this.label_info_frameRate = new Label();
            this.numericUpDown_frameRate = new NumericUpDown();
            this.checkBox_scrollLog = new CheckBox();
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
            ((System.ComponentModel.ISupportInitialize) this.pictureBox_waveform).BeginInit();
            this.groupBox_playback.SuspendLayout();
            this.groupBox_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_samplesPerPixel).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_frameRate).BeginInit();
            this.groupBox_exportSettings.SuspendLayout();
            this.groupBox_beatScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_minBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_maxBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_lookRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.numericUpDown_scanWidth).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_samples
            // 
            this.listBox_samples.FormattingEnabled = true;
            this.listBox_samples.ItemHeight = 15;
            this.listBox_samples.Location = new Point(1052, 625);
            this.listBox_samples.Name = "listBox_samples";
            this.listBox_samples.Size = new Size(200, 184);
            this.listBox_samples.TabIndex = 0;
            // 
            // pictureBox_waveform
            // 
            this.pictureBox_waveform.BackColor = Color.White;
            this.pictureBox_waveform.Location = new Point(12, 625);
            this.pictureBox_waveform.Name = "pictureBox_waveform";
            this.pictureBox_waveform.Size = new Size(855, 170);
            this.pictureBox_waveform.TabIndex = 1;
            this.pictureBox_waveform.TabStop = false;
            // 
            // button_import
            // 
            this.button_import.BackColor = SystemColors.Info;
            this.button_import.Location = new Point(890, 647);
            this.button_import.Name = "button_import";
            this.button_import.Size = new Size(75, 23);
            this.button_import.TabIndex = 2;
            this.button_import.Text = "Import";
            this.button_import.UseVisualStyleBackColor = false;
            // 
            // button_cut
            // 
            this.button_cut.Location = new Point(890, 676);
            this.button_cut.Name = "button_cut";
            this.button_cut.Size = new Size(75, 23);
            this.button_cut.TabIndex = 3;
            this.button_cut.Text = "Cut";
            this.button_cut.UseVisualStyleBackColor = true;
            // 
            // button_remove
            // 
            this.button_remove.BackColor = SystemColors.ControlLight;
            this.button_remove.Location = new Point(971, 676);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new Size(75, 23);
            this.button_remove.TabIndex = 4;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = false;
            // 
            // groupBox_playback
            // 
            this.groupBox_playback.Controls.Add(this.checkBox_seek);
            this.groupBox_playback.Controls.Add(this.textBox_recordingTime);
            this.groupBox_playback.Controls.Add(this.button_record);
            this.groupBox_playback.Controls.Add(this.textBox_timestamp);
            this.groupBox_playback.Controls.Add(this.button_pause);
            this.groupBox_playback.Controls.Add(this.button_playback);
            this.groupBox_playback.Location = new Point(890, 705);
            this.groupBox_playback.Name = "groupBox_playback";
            this.groupBox_playback.Size = new Size(156, 104);
            this.groupBox_playback.TabIndex = 5;
            this.groupBox_playback.TabStop = false;
            this.groupBox_playback.Text = "Playback";
            // 
            // checkBox_seek
            // 
            this.checkBox_seek.AutoSize = true;
            this.checkBox_seek.Checked = true;
            this.checkBox_seek.CheckState = CheckState.Checked;
            this.checkBox_seek.Location = new Point(100, 20);
            this.checkBox_seek.Name = "checkBox_seek";
            this.checkBox_seek.Size = new Size(50, 19);
            this.checkBox_seek.TabIndex = 14;
            this.checkBox_seek.Text = "Seek";
            this.checkBox_seek.UseVisualStyleBackColor = true;
            // 
            // textBox_recordingTime
            // 
            this.textBox_recordingTime.Location = new Point(64, 45);
            this.textBox_recordingTime.Name = "textBox_recordingTime";
            this.textBox_recordingTime.PlaceholderText = "Not recording";
            this.textBox_recordingTime.Size = new Size(86, 23);
            this.textBox_recordingTime.TabIndex = 6;
            // 
            // button_record
            // 
            this.button_record.Location = new Point(35, 45);
            this.button_record.Name = "button_record";
            this.button_record.Size = new Size(23, 23);
            this.button_record.TabIndex = 6;
            this.button_record.Text = "●";
            this.button_record.UseVisualStyleBackColor = true;
            // 
            // textBox_timestamp
            // 
            this.textBox_timestamp.Location = new Point(64, 74);
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
            this.button_pause.Location = new Point(35, 74);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new Size(23, 23);
            this.button_pause.TabIndex = 6;
            this.button_pause.Text = "||";
            this.button_pause.UseVisualStyleBackColor = true;
            // 
            // button_playback
            // 
            this.button_playback.Location = new Point(6, 74);
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
            this.vScrollBar_volume.Location = new Point(870, 625);
            this.vScrollBar_volume.Maximum = 1000;
            this.vScrollBar_volume.Name = "vScrollBar_volume";
            this.vScrollBar_volume.Size = new Size(17, 170);
            this.vScrollBar_volume.TabIndex = 6;
            // 
            // groupBox_view
            // 
            this.groupBox_view.Controls.Add(this.button_strobe);
            this.groupBox_view.Controls.Add(this.numericUpDown_hue);
            this.groupBox_view.Controls.Add(this.checkBox_hue);
            this.groupBox_view.Controls.Add(this.checkBox_smoothen);
            this.groupBox_view.Controls.Add(this.checkBox_drawEachChannel);
            this.groupBox_view.Controls.Add(this.label_info_samplesPerPixel);
            this.groupBox_view.Controls.Add(this.numericUpDown_samplesPerPixel);
            this.groupBox_view.Controls.Add(this.label_info_colors);
            this.groupBox_view.Controls.Add(this.button_colorBack);
            this.groupBox_view.Controls.Add(this.button_colorWave);
            this.groupBox_view.Controls.Add(this.label_info_frameRate);
            this.groupBox_view.Controls.Add(this.numericUpDown_frameRate);
            this.groupBox_view.Location = new Point(890, 450);
            this.groupBox_view.Name = "groupBox_view";
            this.groupBox_view.Size = new Size(156, 191);
            this.groupBox_view.TabIndex = 7;
            this.groupBox_view.TabStop = false;
            this.groupBox_view.Text = "View Settings";
            // 
            // button_strobe
            // 
            this.button_strobe.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_strobe.ForeColor = Color.Black;
            this.button_strobe.Location = new Point(127, 101);
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
            this.numericUpDown_hue.Location = new Point(60, 101);
            this.numericUpDown_hue.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            this.numericUpDown_hue.Name = "numericUpDown_hue";
            this.numericUpDown_hue.Size = new Size(61, 23);
            this.numericUpDown_hue.TabIndex = 14;
            this.numericUpDown_hue.Value = new decimal(new int[] { 175, 0, 0, 131072 });
            // 
            // checkBox_hue
            // 
            this.checkBox_hue.AutoSize = true;
            this.checkBox_hue.Location = new Point(6, 105);
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
            this.label_info_samplesPerPixel.Location = new Point(6, 132);
            this.label_info_samplesPerPixel.Name = "label_info_samplesPerPixel";
            this.label_info_samplesPerPixel.Size = new Size(77, 15);
            this.label_info_samplesPerPixel.TabIndex = 9;
            this.label_info_samplesPerPixel.Text = "Samples / px:";
            // 
            // numericUpDown_samplesPerPixel
            // 
            this.numericUpDown_samplesPerPixel.Location = new Point(90, 130);
            this.numericUpDown_samplesPerPixel.Maximum = new decimal(new int[] { 16384, 0, 0, 0 });
            this.numericUpDown_samplesPerPixel.Name = "numericUpDown_samplesPerPixel";
            this.numericUpDown_samplesPerPixel.Size = new Size(60, 23);
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
            // button_colorBack
            // 
            this.button_colorBack.BackColor = Color.White;
            this.button_colorBack.Font = new Font("Bahnschrift SemiLight SemiConde", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.button_colorBack.Location = new Point(112, 22);
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
            this.button_colorWave.Location = new Point(68, 22);
            this.button_colorWave.Name = "button_colorWave";
            this.button_colorWave.Size = new Size(38, 23);
            this.button_colorWave.TabIndex = 9;
            this.button_colorWave.Text = "Wave";
            this.button_colorWave.UseVisualStyleBackColor = false;
            // 
            // label_info_frameRate
            // 
            this.label_info_frameRate.AutoSize = true;
            this.label_info_frameRate.Location = new Point(6, 161);
            this.label_info_frameRate.Name = "label_info_frameRate";
            this.label_info_frameRate.Size = new Size(69, 15);
            this.label_info_frameRate.TabIndex = 9;
            this.label_info_frameRate.Text = "Frame Rate:";
            // 
            // numericUpDown_frameRate
            // 
            this.numericUpDown_frameRate.Location = new Point(105, 159);
            this.numericUpDown_frameRate.Maximum = new decimal(new int[] { 144, 0, 0, 0 });
            this.numericUpDown_frameRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDown_frameRate.Name = "numericUpDown_frameRate";
            this.numericUpDown_frameRate.Size = new Size(45, 23);
            this.numericUpDown_frameRate.TabIndex = 9;
            this.numericUpDown_frameRate.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // checkBox_scrollLog
            // 
            this.checkBox_scrollLog.AutoSize = true;
            this.checkBox_scrollLog.Checked = true;
            this.checkBox_scrollLog.CheckState = CheckState.Checked;
            this.checkBox_scrollLog.Location = new Point(870, 425);
            this.checkBox_scrollLog.Name = "checkBox_scrollLog";
            this.checkBox_scrollLog.Size = new Size(106, 19);
            this.checkBox_scrollLog.TabIndex = 11;
            this.checkBox_scrollLog.Text = "Auto scroll Log";
            this.checkBox_scrollLog.UseVisualStyleBackColor = true;
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
            this.textBox_info.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.textBox_info.Location = new Point(1052, 425);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.PlaceholderText = "No track or sample selected.";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new Size(200, 194);
            this.textBox_info.TabIndex = 9;
            this.textBox_info.TabStop = false;
            // 
            // button_export
            // 
            this.button_export.BackColor = SystemColors.InactiveCaption;
            this.button_export.Location = new Point(971, 647);
            this.button_export.Name = "button_export";
            this.button_export.Size = new Size(75, 23);
            this.button_export.TabIndex = 10;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = false;
            // 
            // groupBox_exportSettings
            // 
            this.groupBox_exportSettings.Controls.Add(this.label_info_browse);
            this.groupBox_exportSettings.Controls.Add(this.label_info_exportBits);
            this.groupBox_exportSettings.Controls.Add(this.label_info_exportFormat);
            this.groupBox_exportSettings.Controls.Add(this.button_browse);
            this.groupBox_exportSettings.Controls.Add(this.label_workingDir);
            this.groupBox_exportSettings.Controls.Add(this.comboBox_bits);
            this.groupBox_exportSettings.Controls.Add(this.comboBox_format);
            this.groupBox_exportSettings.Location = new Point(664, 12);
            this.groupBox_exportSettings.Name = "groupBox_exportSettings";
            this.groupBox_exportSettings.Size = new Size(200, 150);
            this.groupBox_exportSettings.TabIndex = 11;
            this.groupBox_exportSettings.TabStop = false;
            this.groupBox_exportSettings.Text = "Export Settings";
            // 
            // label_info_browse
            // 
            this.label_info_browse.AutoSize = true;
            this.label_info_browse.Location = new Point(6, 108);
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
            this.button_browse.Location = new Point(158, 104);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new Size(36, 23);
            this.button_browse.TabIndex = 12;
            this.button_browse.Text = "[...]";
            this.button_browse.UseVisualStyleBackColor = true;
            // 
            // label_workingDir
            // 
            this.label_workingDir.AutoSize = true;
            this.label_workingDir.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            this.label_workingDir.Location = new Point(6, 134);
            this.label_workingDir.Name = "label_workingDir";
            this.label_workingDir.Size = new Size(139, 13);
            this.label_workingDir.TabIndex = 12;
            this.label_workingDir.Text = "X:\\MyMusic\\_BreakBot404";
            // 
            // comboBox_bits
            // 
            this.comboBox_bits.FormattingEnabled = true;
            this.comboBox_bits.Location = new Point(129, 51);
            this.comboBox_bits.Name = "comboBox_bits";
            this.comboBox_bits.Size = new Size(65, 23);
            this.comboBox_bits.TabIndex = 12;
            this.comboBox_bits.Text = "Bits";
            // 
            // comboBox_format
            // 
            this.comboBox_format.FormattingEnabled = true;
            this.comboBox_format.Items.AddRange(new object[] { ".wav", ".mp3" });
            this.comboBox_format.Location = new Point(129, 22);
            this.comboBox_format.Name = "comboBox_format";
            this.comboBox_format.Size = new Size(65, 23);
            this.comboBox_format.TabIndex = 12;
            this.comboBox_format.Text = "Format";
            // 
            // groupBox_beatScan
            // 
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
            this.groupBox_beatScan.Location = new Point(498, 12);
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
            this.hScrollBar_offset.Size = new Size(855, 14);
            this.hScrollBar_offset.TabIndex = 13;
            // 
            // label_volume
            // 
            this.label_volume.AutoSize = true;
            this.label_volume.Location = new Point(840, 607);
            this.label_volume.Name = "label_volume";
            this.label_volume.Size = new Size(44, 15);
            this.label_volume.TabIndex = 14;
            this.label_volume.Text = "100.0%";
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1264, 821);
            this.Controls.Add(this.label_volume);
            this.Controls.Add(this.hScrollBar_offset);
            this.Controls.Add(this.groupBox_beatScan);
            this.Controls.Add(this.checkBox_scrollLog);
            this.Controls.Add(this.groupBox_exportSettings);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.textBox_info);
            this.Controls.Add(this.listBox_log);
            this.Controls.Add(this.groupBox_view);
            this.Controls.Add(this.vScrollBar_volume);
            this.Controls.Add(this.groupBox_playback);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_cut);
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
    }
}
