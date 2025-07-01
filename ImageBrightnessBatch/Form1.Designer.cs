namespace ImageBrightnessBatch
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.NumericUpDown numEnd;
        private System.Windows.Forms.NumericUpDown numStep;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxChanged;
        private System.Windows.Forms.ProgressBar progressBar1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtSource = new TextBox();
            txtTarget = new TextBox();
            btnSource = new Button();
            btnTarget = new Button();
            cmbFormat = new ComboBox();
            numStart = new NumericUpDown();
            numEnd = new NumericUpDown();
            numStep = new NumericUpDown();
            btnRun = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxChanged = new PictureBox();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)numStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChanged).BeginInit();
            SuspendLayout();
            // 
            // txtSource
            // 
            txtSource.Location = new Point(20, 17);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(592, 27);
            txtSource.TabIndex = 0;
            // 
            // txtTarget
            // 
            txtTarget.Location = new Point(20, 50);
            txtTarget.Name = "txtTarget";
            txtTarget.Size = new Size(592, 27);
            txtTarget.TabIndex = 2;
            // 
            // btnSource
            // 
            btnSource.Location = new Point(618, 14);
            btnSource.Name = "btnSource";
            btnSource.Size = new Size(106, 33);
            btnSource.TabIndex = 1;
            btnSource.Text = "원본 폴더";
            btnSource.Click += btnSource_Click;
            // 
            // btnTarget
            // 
            btnTarget.Location = new Point(618, 47);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(106, 33);
            btnTarget.TabIndex = 3;
            btnTarget.Text = "목표 폴더";
            btnTarget.Click += btnTarget_Click;
            // 
            // cmbFormat
            // 
            cmbFormat.Items.AddRange(new object[] { "jpg", "png", "bmp" });
            cmbFormat.Location = new Point(20, 80);
            cmbFormat.Name = "cmbFormat";
            cmbFormat.Size = new Size(70, 28);
            cmbFormat.TabIndex = 4;
            // 
            // numStart
            // 
            numStart.DecimalPlaces = 1;
            numStart.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numStart.Location = new Point(110, 80);
            numStart.Maximum = new decimal(new int[] { 1000, 0, 0, 131072 });
            numStart.Minimum = new decimal(new int[] { 10, 0, 0, 131072 });
            numStart.Name = "numStart";
            numStart.Size = new Size(120, 27);
            numStart.TabIndex = 5;
            numStart.Value = new decimal(new int[] { 10, 0, 0, 131072 });
            numStart.ValueChanged += numStart_ValueChanged;
            // 
            // numEnd
            // 
            numEnd.DecimalPlaces = 1;
            numEnd.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numEnd.Location = new Point(240, 80);
            numEnd.Maximum = new decimal(new int[] { 1000, 0, 0, 131072 });
            numEnd.Minimum = new decimal(new int[] { 10, 0, 0, 131072 });
            numEnd.Name = "numEnd";
            numEnd.Size = new Size(120, 27);
            numEnd.TabIndex = 6;
            numEnd.Value = new decimal(new int[] { 10, 0, 0, 131072 });
            numEnd.ValueChanged += numEnd_ValueChanged;
            // 
            // numStep
            // 
            numStep.DecimalPlaces = 1;
            numStep.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numStep.Location = new Point(366, 81);
            numStep.Maximum = new decimal(new int[] { 100, 0, 0, 131072 });
            numStep.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numStep.Name = "numStep";
            numStep.Size = new Size(120, 27);
            numStep.TabIndex = 7;
            numStep.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            numStep.ValueChanged += numStep_ValueChanged;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(730, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(158, 86);
            btnRun.TabIndex = 8;
            btnRun.Text = "실행";
            btnRun.Click += btnRun_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(12, 128);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(432, 225);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 9;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxChanged
            // 
            pictureBoxChanged.Location = new Point(456, 128);
            pictureBoxChanged.Name = "pictureBoxChanged";
            pictureBoxChanged.Size = new Size(432, 225);
            pictureBoxChanged.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxChanged.TabIndex = 10;
            pictureBoxChanged.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 359);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(876, 29);
            progressBar1.TabIndex = 11;
            // 
            // Form1
            // 
            ClientSize = new Size(900, 400);
            Controls.Add(txtSource);
            Controls.Add(btnSource);
            Controls.Add(txtTarget);
            Controls.Add(btnTarget);
            Controls.Add(cmbFormat);
            Controls.Add(numStart);
            Controls.Add(numEnd);
            Controls.Add(numStep);
            Controls.Add(btnRun);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(pictureBoxChanged);
            Controls.Add(progressBar1);
            Name = "Form1";
            Text = "Batch Image Brightness";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStep).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChanged).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
