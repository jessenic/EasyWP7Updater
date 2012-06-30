using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyWP7Updater.Controls
{
    class DeviceMenuItem : ToolStripMenuItem
    {
        public Update.BindableDeviceInformation Device { get; private set; }
        ToolStripDropDownButton parent;

        public DeviceMenuItem(Update.BindableDeviceInformation device, ToolStripDropDownButton parent)
            : base()
        {
            this.parent = parent;

            this.Text = device.ToString();
            this.Enabled = true;

            this.CheckOnClick = true;

            this.Device = device;

            this.CheckedChanged += new EventHandler(checkedChanged);
#if DEBUG
            ToolStripMenuItem restart = new ToolStripMenuItem("Boot into SLDR");
            restart.Click += new EventHandler(restart_click);

            ToolStripMenuItem sldr = new ToolStripMenuItem("Boot into OS");
            sldr.Click += new EventHandler(sldr_click);

            this.DropDownItems.Add(restart);
            this.DropDownItems.Add(sldr);
#endif
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            foreach (DeviceMenuItem i in parent.DropDownItems)
            {
                if (i != this)
                {
                    i.Checked = false;
                }
            }
        }

#if DEBUG
        private void sldr_click(object sender, EventArgs e)
        {
            EasyWP7Updater.Update.DeviceService.RestartSLDRMode(Device.DeviceInfo);
        }

        private void restart_click(object sender, EventArgs e)
        {
            EasyWP7Updater.Update.DeviceService.RestartOSMode(Device.DeviceInfo);
        }
#endif
    }
}
