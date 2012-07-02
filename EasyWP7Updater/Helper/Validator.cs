using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace EasyWP7Updater.Helper
{
    public static class Validator
    {
        private static bool oldStartupValueSaved = false;
        private static bool oldStartupValue = true;

        public static bool ValidateSystem(bool backUpEnabled = false)
        {
            bool isValid = false;

            if (IsZuneRunning())
            {
                isValid = false;
                throw new InvalidOperationException("Zune is currently running. Please close Zune and retry");
            }

            return isValid;
        }

        private static bool IsZuneRunning()
        {
            Process[] processList = Process.GetProcessesByName("Zune");
            if (processList.Count() > 0)
                return true;
            return false;
        }

        public static void PreventZuneAutostart()
        {
            saveOldAutostart();
            setAutostart(false);
        }

        public static void RestoreZuneAutostart()
        {
            if (oldStartupValueSaved)
            {
                setAutostart(oldStartupValue);
            }
        }

        private static void saveOldAutostart()
        {
            if (!oldStartupValueSaved)
            {
                using(RegistryKey key = getAutoLaunchKey(false))
                {
                    object value = key.GetValue("AutoLaunchZuneOnConnect");
                    if (value != null)
                        oldStartupValue = (bool)value;
                    key.Flush();
                }
                oldStartupValueSaved = true;
            }
        }

        private static void setAutostart(bool autostart)
        {
            using (RegistryKey key = getAutoLaunchKey(true))
            {
                key.SetValue("AutoLaunchZuneOnConnect", autostart, RegistryValueKind.DWord);
                key.Flush();
            }
        }

        private static RegistryKey getAutoLaunchKey(bool writeAccess)
        {
            if (writeAccess)
            {
                return Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Zune\\Devices", true);
            }
            else
            {
                return Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Zune\\Devices", false);
            }
        }

        public static bool UpdateToNewerOS(string updateVersion, string phoneVersion)
        {
            string OSversion = phoneVersion;
            string[] tmp = OSversion.Split('-');
            OSversion = tmp[0];

            bool warning = false;

            string[] versionsPhone = OSversion.Split('.');
            string[] versionsUpdate = updateVersion.Split('.');

            if (versionsPhone.Length != versionsUpdate.Length)
                throw new Exception("Possible version mismatch");
            else
            {
                for (int i = 0; i < versionsPhone.Length; i++)
                {
                    int versionPhone = Convert.ToInt32(versionsPhone[i]);
                    int versionUpdate = Convert.ToInt32(versionsUpdate[i]);
                    if (versionUpdate < versionPhone)
                    {
                        warning = true;
                    }
                }
            }

            return !warning;
        }
    }
}
