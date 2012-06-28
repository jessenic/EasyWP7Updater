using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyWP7Updater.Properties;
using System.IO;

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

        private void InstallDownloadedCabsButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = predownloadedSelectionPage;
        }

        private void startOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = firstPage;
        }

        private void sendSelectedCabsButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = sendCabsPage;
        }

        private void addCabsButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (string file in openFileDialog1.FileNames)
            {
                bool has = false;
                foreach (ListViewItem lvi1 in selectedCabsView.Items)
                {
                    if (lvi1.Name == file)
                    {
                        has = true;
                    }
                }
                if (!has)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Name = file;
                    lvi.Text = Path.GetFileName(file);
                    lvi.ToolTipText = file;
                    selectedCabsView.Items.Add(lvi);
                }
            }
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in selectedCabsView.SelectedItems)
            {
                selectedCabsView.Items.Remove(lvi);
            }
        }
    }
}
