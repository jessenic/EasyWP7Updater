using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyWP7Updater.Properties;

namespace EasyWP7Updater.Forms
{
    public partial class WarningForm : Form
    {
        public WarningForm()
        {
            InitializeComponent();
        }
        public bool exit = false;
        private void button1_Click(object sender, EventArgs e)
        {
            exit = false;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            exit = true;
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.HideWarningOnStartup = checkBox1.Checked;
            Settings.Default.Save();
        }
    }
}
