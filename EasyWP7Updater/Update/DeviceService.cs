using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.WindowsMobile.DeviceUpdate;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace EasyWP7Updater.Update
{
    /// <summary>
    /// Provides communication with a connected device.
    /// </summary>
    class DeviceService : IDisposable
    {
        public delegate void ServiceMessageEventhandler(object sender, UpdateMessageEventArgs args);
        /// <summary>
        /// Event that occures when the DeviceService sends a message, e.g. an error, a status update, etc.
        /// </summary>
        public event ServiceMessageEventhandler OnServiceMessageSent;

        public delegate void DevicesChangedEventhandler(object sender, List<BindableDeviceInformation> Devices);
        /// <summary>
        /// Fires when devices are connected or disconnected
        /// </summary>
        public event DevicesChangedEventhandler OnDevicesChanged;

        private EventHandler<DeviceConnectionChangedEventArgs> changedHandler;

        /// <summary>
        /// Contains a list of all present devices. Updated when devices are connected/disconnnected
        /// </summary>
        public List<BindableDeviceInformation> Devices;

        private Thread updateThread;

        /// <summary>
        /// Initializes the DeviceService
        /// </summary>
        public DeviceService()
        {
            changedHandler = new EventHandler<DeviceConnectionChangedEventArgs>(manager_DeviceConnectionChanged);
            DeviceManagerSingleton.Manager.DeviceConnectionChanged += changedHandler;
            UpdateDevices();
        }

        private class doUpdateArgs
        {
            public List<string> updates;
            public IDeviceInfo device;
            public bool withBackup;
        }

        private void doUpdate(object args)
        {
            doUpdateArgs arguments = args as doUpdateArgs;
            if (arguments != null)
            {
                IDevice d = (IDevice)null;
                try
                {
                    d = DeviceManagerSingleton.Manager.AcquireDevice(arguments.device.UniqueIdentifier);
                    if (d != null)
                    {
                        raiseMessageSent(String.Format("Applying updates to device {0} ({1})", arguments.device.Name, arguments.device.UniqueIdentifier), UpdateMessageEventArgs.MessageType.Log);
                        UpdateType type = UpdateType.IU;
                        if (arguments.withBackup)
                            type = UpdateType.IU | UpdateType.BACKUP;

                        IErrorInfo error = d.Update(arguments.updates.ToArray(), type, new Action<IUpdateProgress>(handleProgress), (object)null);

                        if (error != null)
                        {
                            raiseMessageSent(String.Format("Update on device {0} completed with error {1} - {2}", arguments.device.UniqueIdentifier, error.Code.ToString(), error.Description.ToString()), UpdateMessageEventArgs.MessageType.Log);
                        }

                        DeviceManagerSingleton.Manager.ReleaseDevice(d);
                    }
                }
                catch (Exception ex)
                {
                    raiseMessageSent(ex.Message, UpdateMessageEventArgs.MessageType.Log);
                    if (d != null)
                        DeviceManagerSingleton.Manager.ReleaseDevice(d);
                }
            }
        }

        private void manager_DeviceConnectionChanged(object sender, DeviceConnectionChangedEventArgs e)
        {
            switch (e.ChangeType)
            {
                case DeviceChangeType.DeviceArrival:
                    raiseMessageSent(String.Format("{0} - {1} has been connected", e.DeviceInfo.Name, e.DeviceInfo.UniqueIdentifier), UpdateMessageEventArgs.MessageType.Log);
                    break;
                case DeviceChangeType.DeviceRemoval:
                    raiseMessageSent(String.Format("{0} - {1} has been disconnected", e.DeviceInfo.Name, e.DeviceInfo.UniqueIdentifier), UpdateMessageEventArgs.MessageType.Log);
                    break;
            }

            UpdateDevices();

            if (OnDevicesChanged != null)
                OnDevicesChanged(this, this.Devices);
        }

        /// <summary>
        /// Forces the DeviceService to update the device list
        /// </summary>
        /// <returns>A copy of DeviceService.Devices</returns>
        public List<BindableDeviceInformation> UpdateDevices()
        {
            Devices = new List<BindableDeviceInformation>();
            IDeviceInfo[] connected = DeviceManagerSingleton.Manager.GetConnectedDeviceInfo();
            foreach (IDeviceInfo info in connected)
            {
                Devices.Add(new BindableDeviceInformation(info));
            }
            return Devices;
        }

        /// <summary>
        /// Updates the given device with the specified Images (CAB)
        /// </summary>
        /// <param name="device">The device that will be updated</param>
        /// <param name="updates">A list of the updates</param>
        /// <param name="withBackup">True when a backup should be created, otherwise false</param>
        public void UpdateImageUpdate(IDeviceInfo device, List<string> updates, bool withBackup)
        {
            if (updateThread == null || !updateThread.IsAlive)
            {
                updateThread = new Thread(new ParameterizedThreadStart(doUpdate));
                updateThread.SetApartmentState(ApartmentState.MTA);
                updateThread.Start(new doUpdateArgs(){ device = device, updates = updates, withBackup = withBackup});
            }
            else
            {
                raiseMessageSent("There is already an update in progress. Please wait for it to finish.", UpdateMessageEventArgs.MessageType.Log);
            }
        }

        private void handleProgress(IUpdateProgress progress)
        {
            if (progress.CurrentStep.StepCompleted)
            {
                raiseMessageSent(String.Format("Step {0} completed", progress.CurrentStep.Name), UpdateMessageEventArgs.MessageType.Log);
            }
            else
            {
                if (progress.CurrentStep.PercentageAvailable)
                {
                    raiseMessageSent(String.Format("Step {0}: {1}%", progress.CurrentStep.Name, progress.CurrentStep.Percentage), UpdateMessageEventArgs.MessageType.Log);
                }
                else
                {
                    raiseMessageSent(String.Format("{0} - {1}: working", progress.CurrentStep.Name, DateTime.Now.ToShortTimeString()), UpdateMessageEventArgs.MessageType.Log);
                }
            }
        }

        private void raiseMessageSent(string message)
        {
            if (OnServiceMessageSent != null)
                OnServiceMessageSent(this, new UpdateMessageEventArgs(message));
        }

        private void raiseMessageSent(string message, UpdateMessageEventArgs.MessageType type)
        {
            if (OnServiceMessageSent != null)
                OnServiceMessageSent(this, new UpdateMessageEventArgs(message, type));
        }

        /// <summary>
        /// Disposes the DeviceService
        /// </summary>
        public void Dispose()
        {
            Devices.Clear();
            Devices = null;
            changedHandler = null;
        }

        /// <summary>
        /// Restarts the device in SLDR mode
        /// </summary>
        /// <param name="device">The device that should be restarted</param>
        public static void RestartSLDRMode(IDeviceInfo device)
        {
            string uid = device.UniqueIdentifier;
            IDevice d = DeviceManagerSingleton.Manager.AcquireDevice(uid);
            try
            {
                d.Reboot(OSType.SLDR);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }

        /// <summary>
        /// Restarts the device in OS Mode
        /// </summary>
        /// <param name="device">The device that should be restarted</param>
        public static void RestartOSMode(IDeviceInfo device)
        {
            string uid = device.UniqueIdentifier;
            IDevice d = DeviceManagerSingleton.Manager.AcquireDevice(uid);
            try
            {
                d.Reboot(OSType.MAINOS);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }

        /// <summary>
        /// Performs a coldboot restart on the deive
        /// </summary>
        /// <param name="device">The device that should be restarted</param>
        public static void RestartColdboot(IDeviceInfo device)
        {
            string uid = device.UniqueIdentifier;
            IDevice d = DeviceManagerSingleton.Manager.AcquireDevice(uid);
            try
            {
                d.Reboot(OSType.COLDBOOT);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                DeviceManagerSingleton.Manager.ReleaseDevice(d);
            }
        }
    }
}
