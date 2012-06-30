using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsMobile.DeviceUpdate;

namespace EasyWP7Updater.Update
{
    /// <summary>
    /// Use this class to access the DeviceManager. 
    /// </summary>
    public static class DeviceManagerSingleton
    {
        [ThreadStatic]
        private static IDeviceManager _manager;

        /// <summary>
        /// Returns always the same DeviceManager
        /// </summary>
        public static IDeviceManager Manager
        {
            get
            {
                if (_manager == null)
                    _manager = DeviceManager.Instance;
                return _manager;
            }
        }

        /// <summary>
        /// Cleans up the resources used by the singleton. Always call this before exiting the application.
        /// </summary>
        public static void Cleanup()
        {
            GC.SuppressFinalize(_manager);
            _manager = null;
        }
    }
}
