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
using System.Net;

namespace EasyWP7Updater.Forms
{
    public partial class MainForm : Form
    {
        #region Fields
        DeviceService deviceService;
        public bool doBackup = true;
        //public static string[] cabsToSend;
        private bool lastDownloaded = false;
        private int currentItem = 0;
        private List<string> cabsToSend = new List<string>();
        private List<string> selectedLanguageIDs = new List<string>();
        string downloadDir = Directory.GetCurrentDirectory() + @"\download\";
        #endregion
        #region Form stuff
        public MainForm()
        {
            InitializeComponent();
            Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            this.Text = this.Text + " - Version " + ver.Major + "." + ver.Minor;
            webBrowser1.Url = new Uri("http://jessenic.github.com/EasyWP7Updater/news.html#" + ver.ToString());
            deviceService = new DeviceService();
            deviceService.OnServiceMessageSent += new DeviceService.ServiceMessageEventhandler(handleUpdateMessage);
            deviceService.OnDevicesChanged += new DeviceService.DevicesChangedEventhandler(updateHelper_OnDevicesChanged);
            refreshDevices();

            foreach(KeyValuePair<string, string> s in Helper.LanguageList.Languages)
                selectInstalledLanguagesBox.Items.Add(s.Key);

            for (int i = 0; i < selectInstalledLanguagesBox.Items.Count; i++)
                selectInstalledLanguagesBox.SetItemChecked(i, true);
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceService.Dispose();
            DeviceManagerSingleton.Cleanup();
            deviceService = null;
        }
        #endregion
        #region Menu Strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void captureZuneUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PCapForm pcform = new PCapForm();
            pcform.Show();
        }

        private void startOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = firstPage;
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
        #endregion
        #region Selection Page
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.ToString().StartsWith("http://jessenic.github.com/"))
            {
                WarningForm wf = new WarningForm();
                wf.ShowDialog();
                if (wf.exit)
                {
                    wf.Dispose();
                    DeviceManagerSingleton.Cleanup();
                    this.Dispose();
                }
                else
                {
                    wf.Dispose();
                }
                Process.Start(e.Url.ToString());
                e.Cancel = true;
            }
        }

        private void downloadfromMSbutton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = selectInstalledLanguagesPage;

#if DEBUG
            string filename = Directory.GetCurrentDirectory() + @"\sources.xml";
#else
            string filename = "http://jessenic.github.com/EasyWP7Updater/updates.xml";
#endif
            List<Packages.Info.Category> categories = Packages.Packages.GetFromXml(filename);
            catSelectBox.Items.Clear();
            catSelectBox.Items.AddRange(categories.ToArray());

            subCatSelectBox.Items.Clear();
            versionBox.Items.Clear();
            selectLangBox.Items.Clear();
        }

        private void InstallDownloadedCabsButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = predownloadedSelectionPage;
        }
        #endregion
        #region Select Downloaded cabs page

        private void sendSelectedCabsButton_Click(object sender, EventArgs e)
        {
            if (selectedCabsView.Items.Count > 0)
            {
                cabsToSend = new List<string>();

                foreach (ListViewItem i in selectedCabsView.Items)
                    cabsToSend.Add(i.Name);

                logUpdates();
                tabControl1.SelectedTab = sendCabsPage;
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

        #endregion
        #region Send cabs page
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

        private void sendWithoutBackupButton_Click(object sender, EventArgs e)
        {
            BindableDeviceInformation d = getSelectedDevice();
            if (d != null)
            {
                bool takeBackup = takeBackupCheckbox.Checked;

                bool proceed = takeBackup;

                if (!takeBackup && (MessageBox.Show("Do you really want to continue WITHOUT taking a backup?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    proceed = true;
                }

                if (proceed)
                {
                    AppendLog("Updating");
                    deviceService.UpdateImageUpdate(d.DeviceInfo, cabsToSend, takeBackup);
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
                this.BeginInvoke(new Action<string>(AppendLog), line);
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

        private void logUpdates()
        {
            BindableDeviceInformation d = getSelectedDevice();
            if (d != null)
            {
                AppendLog(String.Format("The following updates will be sent to {0} ({1}):", d.DeviceInfo.Name, d.DeviceInfo.UniqueIdentifier));
            }
            else
            {
                AppendLog("The following updates are selected:");
            }

            foreach (string u in cabsToSend)
                AppendLog(u);
        }

        private void catSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Packages.Info.Category selectedCat = catSelectBox.SelectedItem as Packages.Info.Category;
            if (selectedCat != null)
            {
                subCatSelectBox.Items.Clear();
                subCatSelectBox.Items.AddRange(selectedCat.Subcategories.ToArray());

                versionBox.Items.Clear();
                selectLangBox.Items.Clear();
            }
        }

        private void subCatSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Packages.Info.Subcategory selectedSubcat = subCatSelectBox.SelectedItem as Packages.Info.Subcategory;
            if (selectedSubcat != null)
            {
                versionBox.Items.Clear();
                versionBox.Items.AddRange(selectedSubcat.Versions.ToArray());

                selectLangBox.Items.Clear();
            }
        }

        private void versionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filter out the languages
            List<Packages.Info.Item> items = new List<Packages.Info.Item>();
            Packages.Info.VersionInformation selectedVersion = versionBox.SelectedItem as Packages.Info.VersionInformation;
            if (selectedVersion != null)
            {
                for (int i = 0; i < selectedVersion.Items.Count; i++)
                    if (selectedVersion.Items[i].Type == Packages.Info.ItemType.language)
                        items.Add(selectedVersion.Items[i]);

                selectLangBox.Items.Clear();
                selectLangBox.Items.AddRange(items.ToArray());

                //Check the device OS version
                BindableDeviceInformation d = getSelectedDevice();
                if (d != null)
                {
                    try
                    {
                        string OSversion = d.DeviceInfo.OSVersion;
                        string[] tmp = OSversion.Split('-');
                        OSversion = tmp[0];

                        bool warning = false;
                        bool osUpdate = false;

                        string[] versionsPhone = OSversion.Split('.');
                        string[] versionsUpdate = selectedVersion.ToVersion.Split('.');

                        if (versionsPhone.Length != versionsUpdate.Length)
                            throw new Exception("Possible version mismatch");
                        else
                        {
                            for (int i = 0; i < versionsPhone.Length; i++)
                            {
                                int versionPhone = Convert.ToInt32(versionsPhone[i]);
                                int versionUpdate = Convert.ToInt32(versionsUpdate[i]);
                                if(versionUpdate < versionPhone)
                                {
                                    warning = true;
                                }

                                if (i == 0 && versionUpdate == 7)
                                    osUpdate = true;
                            }
                        }

                        if(warning && osUpdate)
                            MessageBox.Show(String.Format("Your phone already has this (or a newer) version installed. Please continue only if you are sure that you want to install the update {0}", selectedVersion.ToString()), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to compare OS Versions, " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

                //Check istalled languages
                if (selectedLanguageIDs.Count != 0 && selectedVersion.IsLanguageAware)
                {
                    List<string> notFound = new List<string>();
                    bool everythingFound = true;

                    foreach (string languageId in selectedLanguageIDs)
                    {
                        bool currentFound = false;
                        for (int i = 0; i < selectLangBox.Items.Count; i++)
                        {
                            Packages.Info.Item item = selectLangBox.Items[i] as Packages.Info.Item;
                            if (item.LangId.Trim().ToLower() == languageId.Trim().ToLower())
                            {
                                currentFound = true;
                                selectLangBox.SetItemChecked(i, true);
                            }
                        }

                        if (!currentFound)
                        {
                            everythingFound = false;
                            notFound.Add(Helper.LanguageList.LanguagesById[languageId]);
                        }
                    }

                    if (!everythingFound)
                    {
                        MessageBox.Show(String.Format("At least one language has not been found. You can continue anyway, but note that missing languages can make your device unusable!\r\nMissing languages: {0}", String.Join(", ", notFound)), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void selectLangBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void downloadSelectedCabs_Click(object sender, EventArgs e)
        {
            List<Packages.Info.Item> toDownload = new List<Packages.Info.Item>();

            //add all updates except languages
            foreach (Packages.Info.Item i in (versionBox.SelectedItem as Packages.Info.VersionInformation).Items)
            {
                if (i.Type != Packages.Info.ItemType.language)
                    toDownload.Add(i);
            }

            //add all selected languages
            foreach (Packages.Info.Item item in selectLangBox.CheckedItems)
            {
                Packages.Info.Item i = item as Packages.Info.Item;
                toDownload.Add(i);
            }

            downloadOverviewList.Items.Clear();
            downloadOverviewList.Items.AddRange(toDownload.ToArray());

            continueWithDownloaded.Enabled = false;
            startDownloadButton.Enabled = true;
            tabControl1.SelectedTab = downloadSelected;
        }

        private void startDownloadButton_Click(object sender, EventArgs e)
        {
            startDownloadButton.Enabled = false;
            lastDownloaded = false;
            downloadNext();
        }

        private void downloadNext()
        {
            for (int i = 0; i < downloadOverviewList.Items.Count; i++)
            {
                if (!downloadOverviewList.GetItemChecked(i))
                {
                    WebClient downloader = new WebClient();

                    downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_progressChanged);
                    downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(downloader_downloadComplete);

                    Packages.Info.Item itemToDownload = downloadOverviewList.Items[i] as Packages.Info.Item;

                    if (!Directory.Exists(downloadDir))
                        Directory.CreateDirectory(downloadDir);

                    string downloadLocation = downloadDir + Path.GetFileName(itemToDownload.Download.LocalPath);

                    currentItem = i;
                    downloader.DownloadFileAsync(itemToDownload.Download, downloadLocation);
                    break;
                }

                if (i == (downloadOverviewList.Items.Count - 1))
                    lastDownloaded = true;
            }

            continueWithDownloaded.Enabled = lastDownloaded;
        }

        private void downloader_downloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            downloadOverviewList.SetItemChecked(currentItem, true);
            downloadNext();
        }

        private void downloader_progressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            downloadProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        private void continueWithDownloaded_Click(object sender, EventArgs e)
        {
            cabsToSend = new List<string>();

            foreach (Packages.Info.Item i in downloadOverviewList.Items)
            {
                string file = downloadDir + Path.GetFileName(i.Download.LocalPath);
                cabsToSend.Add(file);
            }

            logUpdates();
            tabControl1.SelectedTab = sendCabsPage;
        }

        private void continueWithUpdateSelectionBtn_Click(object sender, EventArgs e)
        {
            if ((selectInstalledLanguagesBox.CheckedItems.Count == 0) && (MessageBox.Show("Do you really want to proceed without selecting your installed languages? Missing language packs can make your phone unusable!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes))
            {
                tabControl1.SelectedTab = downloadPage;
            }
            else
            {
                selectedLanguageIDs = new List<string>();
                foreach (string s in selectInstalledLanguagesBox.CheckedItems)
                {
                    selectedLanguageIDs.Add(Helper.LanguageList.Languages[s]);
                }
                tabControl1.SelectedTab = downloadPage;
            }
        }
        #endregion
    }
}
