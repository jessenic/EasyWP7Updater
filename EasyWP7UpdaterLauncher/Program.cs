using System;

namespace EasyWP7UpdaterLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "";
            try
            {
                bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
                file = (is64bit ? "x86" : "x64") + @"\EasyWP7Updater.exe";
                System.Diagnostics.Process.Start(file);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to launch " + file + ": " + ex.Message + "\n\r\n\r\n\rFull error:\n\r"+ex.ToString(), "Error: " + ex.Message, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
