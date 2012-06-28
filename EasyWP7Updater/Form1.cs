using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyWP7Updater.Properties;

namespace EasyWP7Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void viewOnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!Settings.Default.HideWarningOnStartup)
            {
                WarningForm wf = new WarningForm();
                wf.ShowDialog();
                if (wf.exit)
                {
                    wf.Dispose();
                    this.Dispose();
                }
                else
                {
                    wf.Dispose();
                }
            }
        }
    }
}
