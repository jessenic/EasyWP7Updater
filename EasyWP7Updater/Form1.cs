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
using System.Diagnostics;
using System.Xml;

namespace EasyWP7Updater
{
    public partial class Form1 : Form
    {
        UpdateWP updateHelper;
        public Form1()
        {
            InitializeComponent();
            Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            this.Text = this.Text + " - Version " + ver.Major + "." + ver.Minor;
            webBrowser1.Url = new Uri("http://jessenic.github.com/EasyWP7Updater/news.html#" + ver.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
#if !DEBUG
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
#endif
            updateHelper = new UpdateWP(this);
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
            if (selectedCabsView.Items.Count > 0)
            {
                tabControl1.SelectedTab = sendCabsPage;
                DeviceInfo di = updateHelper.getDeviceInfo();
                AppendLog("Ready to send cabs to " + di.Name + " (" + di.Make + " " + di.Model + ").");
            }
            else
            {
                MessageBox.Show(this, "No cabs added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addCabsButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (string file in openFileDialog1.FileNames)
            {
                addCabToList(file);
            }
        }
        private void addCabToList(string file)
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
        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in selectedCabsView.SelectedItems)
            {
                selectedCabsView.Items.Remove(lvi);
            }
        }

        private void sendWithoutBackupButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you really want to send cabs WITHOUT TAKING A BACKUP?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SendCabs(false);
            }
        }

        private void sendWithBackupButton_Click(object sender, EventArgs e)
        {
            SendCabs(true);
        }
        public bool doBackup = true;
        public static string[] cabsToSend;
        private void SendCabs(bool backup)
        {
            if (!sendCabThread.IsBusy)
            {
                doBackup = backup;
                string[] cabs = new string[selectedCabsView.Items.Count];
                int i = 0;
                foreach (ListViewItem lvi in selectedCabsView.Items)
                {
                    cabs[i] = lvi.Name;
                    i++;
                }
                cabsToSend = cabs;
                sendCabThread.RunWorkerAsync();
            }
        }
        public void DataReceived(object sender, DataReceivedEventArgs e)
        {
            // e.Data is the line which was written to standard output
            System.Console.WriteLine(e.Data);
            AppendLogFromThread(e.Data);
        }
        public void ErrorReceived(object sender, DataReceivedEventArgs e)
        {
            // e.Data is the line which was written to standard output
            System.Console.Error.WriteLine(e.Data);
            AppendLogFromThread("ERROR: " + e.Data);
        }

        private void sendCabThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Process p = UpdateWP.sendCabs(doBackup, cabsToSend);
            p.OutputDataReceived += DataReceived;
            p.ErrorDataReceived += ErrorReceived;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
        }

        private void sendCabThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AppendLog("Done!");
        }
        private delegate void AppendLogCallback(string line);
        private void AppendLogFromThread(string line)
        {
            AppendLogCallback callback = new AppendLogCallback(AppendLog);
            this.Invoke(callback, new object[] { line });

        }

        private void AppendLog(string line)
        {
            StringBuilder sb = new StringBuilder(logBox.Text);
            sb.AppendLine(line);
            logBox.Text = sb.ToString();
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        private void selectedCabsView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void selectedCabsView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                addCabToList(file);
            }
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Current version is " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(), "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region Links
        private void viewOnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jessenic/EasyWP7Updater");
        }

        private void viewHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://jessenic.github.com/EasyWP7Updater/");
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://twitter.com/jessenic");
        }

        private void xDAForumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://forum.xda-developers.com/member.php?u=2936958");
        }

        private void issuesBugReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jessenic/EasyWP7Updater/issues");
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jessenic/EasyWP7Updater/wiki");
        }

        private void downloadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jessenic/EasyWP7Updater/downloads");
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jessenic/EasyWP7Updater/commits/master");
        }

        private void twitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.twitter.com/ChrisK91");
        }

        private void xDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://forum.xda-developers.com/member.php?u=1469777");
        }
        #endregion
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.ToString().StartsWith("http://jessenic.github.com/"))
            {
                Process.Start(e.Url.ToString());
                e.Cancel = true;
            }
        }
        private void downloadfromMSbutton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = downloadPage;
            UpdateDownloadLists("sources.xml");
        }
        public void UpdateDownloadLists(string cablisturl)
        {
            //TODO: Further testing for parsing function required
            //TODO: Set the itemsource for the category control
            string filename = Directory.GetCurrentDirectory()+@"\sources.xml";
            List<Packages.Category> categories = Packages.Packages.GetFromXml(filename);
            catSelectBox.Items.Clear();
            catSelectBox.Items.AddRange(categories.ToArray());

            subCatSelectBox.Items.Clear();
            versionBox.Items.Clear();
            selectLangBox.Items.Clear();
        }

        private void catSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Packages.Category selectedCat = catSelectBox.SelectedItem as Packages.Category;
            subCatSelectBox.Items.Clear();
            subCatSelectBox.Items.AddRange(selectedCat.Subcategories.ToArray());

            versionBox.Items.Clear();
            selectLangBox.Items.Clear();
        }

        private void subCatSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Packages.Subcategory selectedSubcat = subCatSelectBox.SelectedItem as Packages.Subcategory;
            versionBox.Items.Clear();
            versionBox.Items.AddRange(selectedSubcat.Versions.ToArray());

            selectLangBox.Items.Clear();
        }

        private void versionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filter out the languages
            List<Packages.Item> items = new List<Packages.Item>();
            Packages.Version selectedVersion = versionBox.SelectedItem as Packages.Version;

            for (int i = 0; i < selectedVersion.Items.Count; i++)
                if (selectedVersion.Items[i].Type == Packages.ItemType.language)
                    items.Add(selectedVersion.Items[i]);

            selectLangBox.Items.Clear();
            selectLangBox.Items.AddRange(items.ToArray());
        }

        private void selectLangBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
