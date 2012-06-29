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
            // Print SharpPcap version 
            string ver = SharpPcap.Version.VersionString;
            Console.WriteLine("SharpPcap {0}, Example1.IfList.cs", ver);

            // Retrieve the device list
            CaptureDeviceList devices = CaptureDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices were found on this machine");
            }
            else
            {
                foreach (ICaptureDevice dev in devices)
                {
                    deviceBox.Items.Add(dev);
                }
            }

        }

        private void deviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            testButton.Enabled = true;
            selectedCaptureDevice = (ICaptureDevice)deviceBox.SelectedItem;
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
        }

        private static ICaptureDevice selectedCaptureDevice;
        private void captureWorker_DoWork(object sender, DoWorkEventArgs e)
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

            Console.WriteLine("-- Listening on {0} for 10 seconds",
                device.Description);

            // Start the capturing process
            device.StartCapture();

            //Wait 60s
            Thread.Sleep(60000);

            // Stop the capturing process
            device.StopCapture();

            // Close the pcap device
            device.Close();
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
            Console.WriteLine("captureWorked done.");
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (!captureWorker.IsBusy)
            {
                captureWorker.RunWorkerAsync();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the test button and it will sniff cabs for 60s, this feature is not fully implemented yet!");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.winpcap.org/install/");
        }
    }
}
