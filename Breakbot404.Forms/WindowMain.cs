namespace Breakbot404.Forms
{
    public partial class WindowMain : Form
    {
        private readonly WindowMainViewModel ViewModel;

        public WindowMain()
        {
            this.InitializeComponent();

            this.ViewModel = new WindowMainViewModel(this, (int) this.numericUpDown_frameRate.Value, 500);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 0);

            this.Load += this.WindowMain_Load;
        }

        private void WindowMain_Load(object? sender, EventArgs e)
        {
            this.ViewModel.Bind_ListBox_Log(this.listBox_log, this.checkBox_scrollLog);
            this.ViewModel.Bind_Elements_View(this.listBox_samples, this.pictureBox_waveform, this.numericUpDown_frameRate, this.numericUpDown_samplesPerPixel, this.hScrollBar_offset, this.button_colorWave, this.button_colorBack, this.checkBox_drawEachChannel, this.checkBox_smoothen, this.checkBox_seek, this.textBox_info);
            this.ViewModel.Bind_Elements_Playback(this.button_playback, this.button_pause, this.textBox_timestamp, this.button_record, this.textBox_recordingTime, this.vScrollBar_volume, this.label_volume, this.hScrollBar_sampleRate, this.label_sampleRate);
            this.ViewModel.Bind_Elements_IO(this.button_import, this.button_reload, this.button_export, this.button_remove, this.comboBox_format, this.comboBox_bits, this.button_browse, this.label_workingDir);
            this.ViewModel.Bind_Elements_BeatScan(this.button_scanBpm, this.textBox_scannedBpm, this.numericUpDown_lookRange, this.numericUpDown_scanWidth, this.numericUpDown_minBpm, this.numericUpDown_maxBpm);
            this.ViewModel.Bind_Elements_Hue(this.checkBox_hue, this.numericUpDown_hue, this.button_strobe);
            this.ViewModel.Bind_Elements_Cutting(this.button_cut, this.button_truncate, this.numericUpDown_targetLufs, this.numericUpDown_minDuration, this.numericUpDown_maxDuration, this.numericUpDown_silenceWindow, this.numericUpDown_truncateStart, this.numericUpDown_truncateEnd, this.checkBox_keepOriginal);
            this.ViewModel.Bind_Elements_SelectionMode(this.button_selectionMode, this.label_selectionMode, this.button_copy);


        }
    }
}
