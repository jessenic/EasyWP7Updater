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
        private string downloadDir = Directory.GetCurrentDirectory() + @"\download\";
        private Queue<string> cabsQueue = new Queue<string>();
        private bool backupTaken = false;
        private int currentUpdate = 0;
        private bool takeBackup;
        private BindableDeviceInformation deviceToUpdate;
        private bool closeOnStart = false;
        #endregion
        #region Form stuff
        public MainForm()
        {
            InitializeComponent();
            Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            this.Text = this.Text + " - Version " + ver.Major + "." + ver.Minor;
            webBrowser1.Url = new Uri("http://jessenic.github.com/EasyWP7Updater/news.html#" + ver.ToString());
            checkForZune();
            try
            {
                if (!closeOnStart)
                {
                    deviceService = new DeviceService();
                    deviceService.OnServiceMessageSent += new DeviceService.ServiceMessageEventhandler(handleUpdateMessage);
                    deviceService.OnDevicesChanged += new DeviceService.DevicesChangedEventhandler(updateHelper_OnDevicesChanged);
                    deviceService.OnUpdateFinished += new EventHandler(updateFinished);
                    refreshDevices();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));

                if (is64bit)
                {
                    if (MessageBox.Show("This application requires the x64 version of the WP Support Tool. Do you want to open the downloadpage?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start(@"http://download.microsoft.com/download/6/6/6/666ED30F-15E4-4287-8E73-CE08CCE07AAB/WPSupportToolv2-amd64.msi");
                    }
                }
                else
                {
                    if (MessageBox.Show("This application requires the x86 version of the WP Support Tool. Do you want to open the downloadpage?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start(@"http://download.microsoft.com/download/6/6/6/666ED30F-15E4-4287-8E73-CE08CCE07AAB/WPSupportToolv2-x86.msi");
                    }
                }

                closeOnStart = true;
            }

            foreach (KeyValuePair<string, string> s in Helper.LanguageList.Languages)
                selectInstalledLanguagesBox.Items.Add(s.Key);

            for (int i = 0; i < selectInstalledLanguagesBox.Items.Count; i++)
                selectInstalledLanguagesBox.SetItemChecked(i, true);
        }
        private void checkForZune()
        {
           Process[] processesByName = Process.GetProcessesByName("Zune");
            if ((processesByName != null) && (processesByName.Length > 0))
            {
                DialogResult dr = MessageBox.Show("Zune is currently running, some features might not be present. Please ignore this if you want to capture Zune updates.", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Abort)
                {
                    closeOnStart = true;
                }
                else if(dr == System.Windows.Forms.DialogResult.Ignore)
                {
                    closeOnStart = true;
                    PCapForm pcf = new PCapForm();
                    pcf.ShowDialog(this);
                }
                else
                {
                    checkForZune();
                }
            }
        }
        //execute sendNextCab on UI thread
        private void updateFinished(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(sendNextCab));
            }
            else
            {
                sendNextCab();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (closeOnStart)
                closeMainForm();
#if !DEBUG
            else if (!Settings.Default.HideWarningOnStartup)
            {
                WarningForm wf = new WarningForm();
                wf.ShowDialog();
                if (wf.exit)
                {
                    wf.Dispose();
                    closeMainForm();
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
            closeMainForm();
        }

        private void closeMainForm()
        {
            if (deviceService != null)
                deviceService.Dispose();

            DeviceManagerSingleton.Cleanup();
            deviceService = null;
            this.Dispose();
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
            Console.WriteLine("Getting the selected device...");
            BindableDeviceInformation d = null;

            foreach (Controls.DeviceMenuItem i in devicesSelectMenu.DropDownItems)
            {
                if (i.Checked)
                {
                    d = i.Device;
                    Console.WriteLine(d.DeviceInfo.Name + " is the selected device.");
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
                takeBackup = takeBackupCheckbox.Checked;

                bool proceed = takeBackup;

                if (!takeBackup && (MessageBox.Show("Do you really want to continue WITHOUT taking a backup?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    proceed = true;
                }

                if (proceed)
                {
                    AppendLog("Updating");
                    backupTaken = false;
                    currentUpdate = 0;
                    cabsQueue = new Queue<string>();

                    foreach (string s in cabsToSend)
                    {
                        cabsQueue.Enqueue(s);
                    }

                    deviceToUpdate = getSelectedDevice();
                    sendNextCab();
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

        private void sendNextCab()
        {
            if (cabsQueue.Count != 0)
            {
                currentUpdate++;
                AppendLog(String.Format("Applying update {0} of {1}", currentUpdate, cabsToSend.Count));
                sendCABsButton.Enabled = false;

                string file = cabsQueue.Dequeue();
                if (!backupTaken && takeBackup)
                {
                    deviceService.UpdateImageUpdate(deviceToUpdate.DeviceInfo, file, true);
                    backupTaken = true;
                }
                else
                {
                    deviceService.UpdateImageUpdate(deviceToUpdate.DeviceInfo, file, false);
                }
            }
            else
            {
                AppendLog("Finished");
                sendCABsButton.Enabled = true;
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
                BindableDeviceInformation d = getSelectedDevice();
                foreach (EasyWP7Updater.Packages.Info.VersionInformation ver in selectedSubcat.Versions)
                {
                    //Validate the selected update
                    if (d != null)
                    {
                        try
                        {
                            switch (((Packages.Info.Category)catSelectBox.SelectedItem).Type)
                            {
                                case Packages.Info.Category.CategoryType.os:
                                    if (!Helper.Validator.AreOSVersionsTheSame(ver.FromVersion, d.DeviceInfo.OSVersion))
                                        ver.IsNotUpdateable = true;
                                    break;

                                case Packages.Info.Category.CategoryType.firmware:
                                    //Todo: validate if selected firmware can be applied
                                    break;
                                default:
                                    MessageBox.Show(((Packages.Info.Category)catSelectBox.SelectedItem).Name + " has a wrong type: " + ((Packages.Info.Category)catSelectBox.SelectedItem).Type.ToString());
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Unable to compare OS Versions, " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No device was selected.");
                    }
                    versionBox.Items.Add(ver);
                }

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

                //Validate the selected update
                if (selectedVersion.IsNotUpdateable)
                {
                    MessageBox.Show(String.Format("Your phone already has this (or a newer) version installed. Please continue only if you are sure that you want to install the update {0}", selectedVersion.ToString()), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show(String.Format("At least one language has not been found. You can continue anyway, but note that missing languages can make your device unusable!\r\nMissing languages: {0}", String.Join(", ", notFound.ToArray())), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
