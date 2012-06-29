﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace EasyWP7Updater.Update
{
    class UpdateWP
    {
        public static string updateWPPath;
        public delegate void UpdateWPMessageEventhandler(object sender, UpdateMessageEventArgs args);
        public event UpdateWPMessageEventhandler OnUpdateWPMessageSent;

        public UpdateWP()
        {
            updateWPPath = Path.Combine(Path.GetDirectoryName(new Uri(base.GetType().Assembly.CodeBase).LocalPath), (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "x86") ? "tools\\x86" : "tools\\x64");
        }

        public static Process sendCabs(bool backup, string[] cabs)
        {
            Process p = new Process();
            StringBuilder args = new StringBuilder();
            args.Append("/iu");
            foreach (string cab in cabs)
            {
                args.Append(" \"" + cab + "\"");
            }
            if (backup)
            {
                args.Append(" /enablebackup");
            }
            p.StartInfo.Arguments = args.ToString();
            p.StartInfo.FileName = updateWPPath + "\\UpdateWP.exe";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            return p;
        }

        public DeviceInfo getDeviceInfo()
        {
            Process p = new Process();
            p.StartInfo.Arguments = "/list";
            p.StartInfo.FileName = updateWPPath + "\\UpdateWP.exe";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            DeviceInfo di = new DeviceInfo();
            string line;
            while ((line = p.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                Console.WriteLine(line);
                String[] split = line.Split(new char[] { ':' }, 2);
                if (line.ToLower().StartsWith("name"))
                {
                    di.Name = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("id"))
                {
                    di.PnPPath = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("sn"))
                {
                    di.SerialNumber = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("kitlname"))
                {
                    di.KITLName = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("manufacturer"))
                {
                    di.Make = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("modelid"))
                {
                    di.ModelId = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("model"))
                {
                    di.Model = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("mobileoperator"))
                {
                    di.MobileOperator = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("version"))
                {
                    di.OSVersion = split[1].Trim();
                }
                else if (line.ToLower().StartsWith("error"))
                {
                    raiseMessageSent(line, UpdateMessageEventArgs.MessageType.Error);
                }
            }
            line = null;
            while ((line = p.StandardError.ReadLine()) != null)
            {
                raiseMessageSent(line, UpdateMessageEventArgs.MessageType.Error);
            }
            di.DeviceConnected = true;
            return di;
        }

        private void raiseMessageSent(string message)
        {
            if (OnUpdateWPMessageSent != null)
                OnUpdateWPMessageSent(this, new UpdateMessageEventArgs(message));
        }

        private void raiseMessageSent(string message, UpdateMessageEventArgs.MessageType type)
        {
            if(OnUpdateWPMessageSent != null)
                OnUpdateWPMessageSent(this, new UpdateMessageEventArgs(message, type));
        }
    }
}
