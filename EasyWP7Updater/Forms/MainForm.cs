using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyWP7Updater.Properties;
using EasyWP7Updater.Update;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace EasyWP7Updater.Forms
{
    public partial class MainForm : Form
    {
        DeviceService deviceService;
        public bool doBackup = true;
        public static string[] cabsToSend;

        public MainForm()
        {
            InitializeComponent();
            Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            this.Text = this.Text + " - Version " + ver.Major + "." + ver.Minor;
            webBrowser1.Url = new Uri("http://jessenic.github.com/EasyWP7Updater/news.html#" + ver.ToString());
            deviceService = new DeviceService();
            deviceService.OnUpdateWPMessageSent += new DeviceService.UpdateWPMessageEventhandler(handleUpdateMessage);
            deviceService.OnDevicesChanged += new DeviceService.DevicesChangedEventhandler(updateHelper_OnDevicesChanged);
            refreshDevices();
        }

        private void updateHelper_OnDevicesChanged(object sender, List<BindableDeviceInformation> Devices)
        {
            refreshDevices();
        }

        private void refreshDevices()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(refreshDevices));
            }
            else
            {
                devicesSelectMenu.DropDownItems.Clear();
                foreach (BindableDeviceInformation device in deviceService.Devices)
                {
                    EasyWP7Updater.Controls.DeviceMenuItem i = new Controls.DeviceMenuItem(device, devicesSelectMenu);
                    devicesSelectMenu.DropDownItems.Add(i);
                }
            }
        }

        private BindableDeviceInformation getSelectedDevice()
        {
            BindableDeviceInformation d = null;

            foreach (Controls.DeviceMenuItem i in devicesSelectMenu.DropDownItems)
            {
                if (i.Checked)
                {
                    d = i.Device;
                    break;
                }
            }

            return d;
        }

        private void handleUpdateMessage(object sender, UpdateMessageEventArgs args)
        {
            switch (args.Type)
            {
                case UpdateMessageEventArgs.MessageType.Error:
                    MessageBox.Show(args.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UpdateMessageEventArgs.MessageType.Info:
                    MessageBox.Show(args.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case UpdateMessageEventArgs.MessageType.Warning:
                    MessageBox.Show(args.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case UpdateMessageEventArgs.MessageType.Log:
                    AppendLog(args.Message);
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                /*DeviceInfo di = updateHelper.getDeviceInfo();
                AppendLog("Ready to send cabs to " + di.Name + " (" + di.Make + " " + di.Model + ").");*/
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
            BindableDeviceInformation d = getSelectedDevice();
            if (d != null)
            {
                bool takeBackup = takeBackupCheckbox.Checked;
                List<string> cabs = new List<string>();

                foreach (ListViewItem i in selectedCabsView.Items)
                    cabs.Add(i.Name);

                bool proceed = takeBackup;

                if (!takeBackup && (MessageBox.Show("Do you really want to continue WITHOUT taking a backup?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    proceed = true;
                }

                if (proceed)
                {
                    AppendLog("Updating");
                    deviceService.UpdateCAB(d.DeviceInfo, cabs, takeBackup);
                }
                else
                {
                    AppendLog("Aborted by user");
                }
            }
            else
            {
                AppendLog("No device selected");
            }
        }

        private void AppendLog(string line)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendLog), line);
            }
            else
            {
                StringBuilder sb = new StringBuilder(logBox.Text);
                sb.AppendLine(line);
                logBox.Text = sb.ToString();
                logBox.SelectionStart = logBox.Text.Length;
                logBox.ScrollToCaret();
            }
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

        private void UpdateDownloadLists(string cablisturl)
        {
            string filename = Directory.GetCurrentDirectory() + @"\sources.xml";
            List<Packages.Info.Category> categories = Packages.Packages.GetFromXml(filename);
            catSelectBox.Items.Clear();
            catSelectBox.Items.AddRange(categories.ToArray());

            subCatSelectBox.Items.Clear();
            versionBox.Items.Clear();
            selectLangBox.Items.Clear();
        }

        private void catSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Packages.Info.Category selectedCat = catSelectBox.SelectedItem as Packages.Info.Category;
            subCatSelectBox.Items.Clear();
            subCatSelectBox.Items.AddRange(selectedCat.Subcategories.ToArray());

            versionBox.Items.Clear();
            selectLangBox.Items.Clear();
        }

        private void subCatSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Packages.Info.Subcategory selectedSubcat = subCatSelectBox.SelectedItem as Packages.Info.Subcategory;
            versionBox.Items.Clear();
            versionBox.Items.AddRange(selectedSubcat.Versions.ToArray());

            selectLangBox.Items.Clear();
        }

        private void versionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filter out the languages
            List<Packages.Info.Item> items = new List<Packages.Info.Item>();
            Packages.Info.VersionInformation selectedVersion = versionBox.SelectedItem as Packages.Info.VersionInformation;

            for (int i = 0; i < selectedVersion.Items.Count; i++)
                if (selectedVersion.Items[i].Type == Packages.Info.ItemType.language)
                    items.Add(selectedVersion.Items[i]);

            selectLangBox.Items.Clear();
            selectLangBox.Items.AddRange(items.ToArray());
        }

        private void selectLangBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceService.Dispose();
            DeviceManagerSingleton.Cleanup();
            deviceService = null;
        }
    }
}
