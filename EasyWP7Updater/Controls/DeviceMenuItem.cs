using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyWP7Updater.Controls
{
    class DeviceMenuItem : ToolStripMenuItem
    {
        Update.BindableDeviceInformation device;

        public DeviceMenuItem(Update.BindableDeviceInformation device) : base()
        {
            this.Text = device.ToString();
            this.Enabled = true;

            this.device = device;

            ToolStripMenuItem restart = new ToolStripMenuItem("Boot into SLDR");
            restart.Click += new EventHandler(restart_click);

            ToolStripMenuItem sldr = new ToolStripMenuItem("Boot into OS");
            sldr.Click += new EventHandler(sldr_click);

            this.DropDownItems.Add(restart);
            this.DropDownItems.Add(sldr);
        }

        private void sldr_click(object sender, EventArgs e)
        {
            EasyWP7Updater.Update.DeviceService.RestartSLDRMode(device.DeviceInfo);
        }

        private void restart_click(object sender, EventArgs e)
        {
            EasyWP7Updater.Update.DeviceService.RestartOSMode(device.DeviceInfo);
        }

    }
}
