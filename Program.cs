using System;
using System.Windows.Forms;
using USB_Camera;

namespace FaceDetectionApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                // Display any unhandled errors
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}",
                                "Application Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
