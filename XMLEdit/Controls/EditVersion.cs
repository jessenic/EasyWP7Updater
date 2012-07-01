using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages.Info;
using XMLEdit.Helper;

namespace XMLEdit.Controls
{
    public partial class EditVersion : UserControl
    {
        BindableVersion boundVersion;

        public EditVersion(BindableVersion v)
        {
            InitializeComponent();
            fromTxtbx.Text = v.BoundVersion.FromVersion;
            toTxtbx.Text = v.BoundVersion.ToVersion;
            boundVersion = v;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            boundVersion.UpdateVersion(fromTxtbx.Text, toTxtbx.Text);
        }
    }
}
