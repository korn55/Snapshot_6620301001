using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace USB_Camera
{
    public partial class MainForm : Form
    {
        private VideoCapture? _capture;
        private CascadeClassifier _faceDetector;
        private bool _isCameraConnected = false;
        private bool _isSnapshotRunning = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            try
            {
                _capture = new VideoCapture();
                _capture.ImageGrabbed += ProcessFrame;
                _faceDetector = new CascadeClassifier("haarcascade_frontalface_default.xml");

                _capture.Start();
                _isCameraConnected = true;
                lblCameraStatus.Text = "Camera: Connected";
            }
            catch (Exception ex)
            {
                _isCameraConnected = false;
                lblCameraStatus.Text = "Camera: Disconnected";
                MessageBox.Show($"Error initializing camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFrame(object? sender, EventArgs e)
        {
            if (!_isCameraConnected || _capture == null) return;

            Mat frame = new Mat();
            _capture.Retrieve(frame);

            using var imageFrame = frame.ToImage<Bgr, byte>(); // Original colored frame
            using var grayFrame = imageFrame.Convert<Gray, byte>(); // Grayscale frame for face detection

            // Face detection
            var faces = _faceDetector.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);
            foreach (var face in faces)
            {
                imageFrame.Draw(face, new Bgr(Color.Red), 2); // Draw on colored frame only

                // Display the first detected face in grayscale (show the first face for detection)
                if (face == faces[0])
                {
                    var faceImage = grayFrame.GetSubRect(face).Clone();
                    pbDetectedFace.Image = faceImage.ToBitmap();
                }
            }

            pbLiveFeed.Image = imageFrame.ToBitmap(); // Display colored frame with detection
        }

        private async void btnSnapshot_Click(object sender, EventArgs e)
        {
            if (_isSnapshotRunning || !_isCameraConnected) return;

            _isSnapshotRunning = true;
            btnSnapshot.Enabled = false;

            try
            {
                int interval = (int)numericSnapshotInterval.Value * 1000;
                string saveFolder = txtSavePath.Text;

                if (string.IsNullOrWhiteSpace(saveFolder) || !Directory.Exists(saveFolder))
                {
                    MessageBox.Show("Please specify a valid save folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                while (_isSnapshotRunning)
                {
                    Mat frame = new Mat();
                    _capture.Retrieve(frame);

                    using var imageFrame = frame.ToImage<Bgr, byte>(); // Original frame
                    using var grayFrame = imageFrame.Convert<Gray, byte>(); // Convert to grayscale

                    // Create a clean snapshot without detection rectangles
                    var snapshot = grayFrame.ToBitmap();

                    // Generate a unique file name using the current date and time
                    string fileName = Path.Combine(saveFolder, $"Snapshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
                    snapshot.Save(fileName); // Save grayscale snapshot
                    lstLog.Items.Add($"[Saved to]: {fileName}");

                    // Wait for the specified interval before taking the next snapshot
                    await Task.Delay(interval);
                }
            }
            finally
            {
                _isSnapshotRunning = false;
                btnSnapshot.Enabled = true;
            }
        }

        private void btnStopSnapshot_Click(object sender, EventArgs e)
        {
            _isSnapshotRunning = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _capture?.Dispose();
        }
    }
}
