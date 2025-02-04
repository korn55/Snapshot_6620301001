namespace USB_Camera
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pbLiveFeed;
        private System.Windows.Forms.PictureBox pbDetectedFace;
        private System.Windows.Forms.Label lblCameraStatus;
        private System.Windows.Forms.Label lblRecordingStatus;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Button btnStopSnapshot;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.NumericUpDown numericSnapshotInterval;
        private System.Windows.Forms.Label lblSnapshotInterval;
        private System.Windows.Forms.ListBox lstLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pbLiveFeed = new System.Windows.Forms.PictureBox();
            this.pbDetectedFace = new System.Windows.Forms.PictureBox();
            this.lblCameraStatus = new System.Windows.Forms.Label();
            this.lblRecordingStatus = new System.Windows.Forms.Label();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.btnStopSnapshot = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.numericSnapshotInterval = new System.Windows.Forms.NumericUpDown();
            this.lblSnapshotInterval = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();

            ((System.ComponentModel.ISupportInitialize)(this.pbLiveFeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSnapshotInterval)).BeginInit();
            this.SuspendLayout();

            // Live Feed PictureBox
            this.pbLiveFeed.Location = new System.Drawing.Point(12, 12);
            this.pbLiveFeed.Size = new System.Drawing.Size(640, 480);
            this.pbLiveFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // Detected Face PictureBox
            this.pbDetectedFace.Location = new System.Drawing.Point(660, 12);
            this.pbDetectedFace.Size = new System.Drawing.Size(160, 160);
            this.pbDetectedFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // Camera Status Label
            this.lblCameraStatus.Location = new System.Drawing.Point(12, 500);
            this.lblCameraStatus.Size = new System.Drawing.Size(200, 23);
            this.lblCameraStatus.Text = "Camera: Disconnected";

            // Snapshot Button
            this.btnSnapshot.Location = new System.Drawing.Point(12, 530);
            this.btnSnapshot.Size = new System.Drawing.Size(100, 30);
            this.btnSnapshot.Text = "Start Snapshot";
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);

            // Stop Snapshot Button
            this.btnStopSnapshot.Location = new System.Drawing.Point(120, 530);
            this.btnStopSnapshot.Size = new System.Drawing.Size(100, 30);
            this.btnStopSnapshot.Text = "Stop Snapshot";
            this.btnStopSnapshot.Click += new System.EventHandler(this.btnStopSnapshot_Click);

            // Save Path TextBox
            this.txtSavePath.Location = new System.Drawing.Point(300, 530);
            this.txtSavePath.Size = new System.Drawing.Size(300, 23);

            // Save Path Label
            this.lblSavePath.Location = new System.Drawing.Point(300, 500);
            this.lblSavePath.Size = new System.Drawing.Size(100, 23);
            this.lblSavePath.Text = "Save Path:";

            // Snapshot Interval NumericUpDown
            this.numericSnapshotInterval.Location = new System.Drawing.Point(660, 530);
            this.numericSnapshotInterval.Minimum = 1;
            this.numericSnapshotInterval.Maximum = 60;
            this.numericSnapshotInterval.Value = 3;

            // Snapshot Interval Label
            this.lblSnapshotInterval.Location = new System.Drawing.Point(660, 500);
            this.lblSnapshotInterval.Size = new System.Drawing.Size(120, 23);
            this.lblSnapshotInterval.Text = "Interval (sec):";

            // Log ListBox
            this.lstLog.Location = new System.Drawing.Point(12, 580);
            this.lstLog.Size = new System.Drawing.Size(800, 200);

            // Main Form
            this.ClientSize = new System.Drawing.Size(824, 800);
            this.Controls.Add(this.pbLiveFeed);
            this.Controls.Add(this.pbDetectedFace);
            this.Controls.Add(this.lblCameraStatus);
            this.Controls.Add(this.lblRecordingStatus);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.btnStopSnapshot);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.lblSavePath);
            this.Controls.Add(this.numericSnapshotInterval);
            this.Controls.Add(this.lblSnapshotInterval);
            this.Controls.Add(this.lstLog);
            this.Text = "USB Camera with Face Detection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.pbLiveFeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSnapshotInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
