using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsMobile.DeviceUpdate;

namespace EasyWP7Updater.Update
{
    class BindableDeviceInformation
    {
        public IDeviceInfo DeviceInfo { get; private set; }

        public BindableDeviceInformation(IDeviceInfo deviceInfo)
        {
            DeviceInfo = deviceInfo;
        }

        public override string ToString()
        {
            if (DeviceInfo.Name != "")
                return DeviceInfo.Name;
            return DeviceInfo.UniqueIdentifier;
        }
    }
}
