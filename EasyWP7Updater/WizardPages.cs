using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyWP7Updater
{
    class WizardPages : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }
        public void NextPage()
        {
            int nextTab = this.SelectedIndex + 1;
            if (nextTab < this.TabCount)
            {
                this.SelectedIndex = nextTab;
            }
        }

        public void PreviousPage()
        {
            int nextTab = this.SelectedIndex - 1;
            if (nextTab < this.TabCount && nextTab >= 0)
            {
                this.SelectedIndex = nextTab;
            }
        }
    }
}
