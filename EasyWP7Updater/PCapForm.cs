using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;
using System.Threading;
using PacketDotNet;
using System.Net;
using System.IO;

namespace EasyWP7Updater
{
    public partial class PCapForm : Form
    {
        public PCapForm()
        {
            InitializeComponent();
        }

        private void PCapForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Print SharpPcap version 
                string ver = SharpPcap.Version.VersionString;
                Console.WriteLine("SharpPcap {0}, Example1.IfList.cs", ver);

                // Retrieve the device list
                CaptureDeviceList devices = CaptureDeviceList.Instance;

                // If no devices were found print an error
                if (devices.Count < 1)
                {
                    Console.WriteLine("No devices were found on this machine");
                    MessageBox.Show(this, "Error accessing network cards. Make sure you have latest version of WinPcap installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ICaptureDevice dev in devices)
                    {
                        deviceBox.Items.Add(dev);
                    }
                }
                runWorker = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error accessing network cards. Make sure you have latest version of WinPcap installed. Error description: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deviceBox.SelectedItem != null)
            {
                if (!captureWorker.IsBusy)
                {
                    startButton.Enabled = true;
                    testButton.Enabled = true;
                    selectedCaptureDevice = (ICaptureDevice)deviceBox.SelectedItem;
                }
            }
        }

        private delegate void AddCabToBoxCallback(string cab);
        private void AddCabToBoxFromThread(string cab)
        {
            AddCabToBoxCallback callback = new AddCabToBoxCallback(AddCabToBox);
            this.Invoke(callback, new object[] { cab });

        }

        private void AddCabToBox(string cab)
        {
            foundCabsBox.Items.Add(cab);
            foundCabsBox.SelectedItems.Add(cab);
            if (testing)
            {
                runWorker = false;
                testing = false;
                MessageBox.Show(this, "This adapter is the one you use for internet! Please use this when sniffing Zune updates.", "Testing done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private static bool runWorker = true;
        private static bool testing = false;
        private static ICaptureDevice selectedCaptureDevice;
        private void captureWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Extract a device from the list
                ICaptureDevice device = selectedCaptureDevice;

                // Register our handler function to the
                // 'packet arrival' event
                device.OnPacketArrival +=
                    new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

                // Open the device for capturing
                int readTimeoutMilliseconds = 1000;
                device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

                Console.WriteLine("-- Listening on {0}", device.Description);

                // Start the capturing process
                device.StartCapture();

                //Loop until cancelled
                while (runWorker) { }

                // Stop the capturing process
                device.StopCapture();

                // Close the pcap device
                device.Close();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Prints the time and length of each received packet
        /// </summary>
        private void device_OnPacketArrival(object sender, CaptureEventArgs args)
        {
            TcpPacket packet = TcpPacket.GetEncapsulated(TcpPacket.ParsePacket(args.Device.LinkType, args.Packet.Data));
            if (packet != null)
            {
                if (packet.DestinationPort == 80 && packet.PayloadData != null)
                {
                    string packetContents = Encoding.ASCII.GetString(packet.PayloadData).Trim();
                    if (packetContents.Length > 20)
                    {
                        if (packetContents.Contains(".cab"))
                        {
                            Console.WriteLine(packet);
                            Console.WriteLine(packetContents);
                            AddCabToBoxFromThread(packetContents);
                        }
                    }
                }
            }
        }

        private void captureWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("captureWorker done.");
            testButton.Enabled = true;
            startButton.Text = "Start sniffing";
            deviceBox.Enabled = true;
            runWorker = true;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (!captureWorker.IsBusy)
            {
                testing = true;
                runWorker = true;
                captureWorker.RunWorkerAsync();
                testButton.Enabled = false;
                startButton.Text = "Stop testing";
                deviceBox.Enabled = false;
                WebClient wc = new WebClient();
                wc.DownloadDataCompleted += new DownloadDataCompletedEventHandler(wc_DownloadDataCompleted);
                wc.DownloadDataAsync(new Uri(@"http://download.windowsupdate.com/msdownload/update/software/dflt/2011/05/311983_ak7004_uldr.pks_afd84eaa79b0fbca528675950d3203820e457a4f.cab"));
            }
        }
        private void wc_DownloadDataCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Test done.");
            runWorker = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!captureWorker.IsBusy)
            {
                runWorker = true;
                captureWorker.RunWorkerAsync();
                testButton.Enabled = false;
                startButton.Text = "Stop sniffing";
                deviceBox.Enabled = false;
            }
            else
            {
                runWorker = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.winpcap.org/install/");
        }

        private void PCapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            runWorker = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string file = saveFileDialog1.FileName;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please post this on http://forum.xda-developers.com/showthread.php?t=1739638");
            int i = 0;
            foreach (string item in foundCabsBox.Items)
            {
                sb.AppendLine("=== Sniffed cab " + i + " ===");
                sb.AppendLine(item);
                sb.AppendLine();
                sb.AppendLine();
                i++;
            }
            using (StreamWriter outfile =
                new StreamWriter(file))
            {
                outfile.Write(sb.ToString());
            }

        }

        private void foundCabsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foundCabsBox.SelectedItems != null)
            {
                saveButton.Enabled = true;
            }
        }
    }
}
