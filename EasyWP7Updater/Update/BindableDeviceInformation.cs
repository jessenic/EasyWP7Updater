using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsMobile.DeviceUpdate;

namespace EasyWP7Updater.Update
{
    /// <summary>
    /// Provides a easy way to bind IDeviceInfos to controls
    /// </summary>
    class BindableDeviceInformation
    {
        /// <summary>
        /// The underlying device
        /// </summary>
        public IDeviceInfo DeviceInfo { get; private set; }

        /// <summary>
        /// Creates a BindableDeviceInfo
        /// </summary>
        /// <param name="deviceInfo">The device that should be bindable</param>
        public BindableDeviceInformation(IDeviceInfo deviceInfo)
        {
            DeviceInfo = deviceInfo;
        }

        /// <summary>
        /// Returns a string representating the device
        /// </summary>
        /// <returns>The name or the UID of the device</returns>
        public override string ToString()
        {
            if (DeviceInfo.Name != "")
                return DeviceInfo.Name;
            return DeviceInfo.UniqueIdentifier;
        }
    }
}
