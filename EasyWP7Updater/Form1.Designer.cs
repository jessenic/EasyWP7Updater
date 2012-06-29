namespace EasyWP7Updater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuesBugReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jessenicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xDAForumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sendCabThread = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new EasyWP7Updater.WizardPages();
            this.firstPage = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label3 = new System.Windows.Forms.Label();
            this.InstallDownloadedCabsButton = new System.Windows.Forms.Button();
            this.downloadFromROMProviderButton = new System.Windows.Forms.Button();
            this.downloadfromMSbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.predownloadedSelectionPage = new System.Windows.Forms.TabPage();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.addCabsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedCabsView = new System.Windows.Forms.ListView();
            this.sendSelectedCabsButton = new System.Windows.Forms.Button();
            this.sendCabsPage = new System.Windows.Forms.TabPage();
            this.logBox = new System.Windows.Forms.TextBox();
            this.sendWithoutBackupButton = new System.Windows.Forms.Button();
            this.sendWithBackupButton = new System.Windows.Forms.Button();
            this.downloadPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.selectLangBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.versionBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.subCatSelectBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.catSelectBox = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.firstPage.SuspendLayout();
            this.predownloadedSelectionPage.SuspendLayout();
            this.sendCabsPage.SuspendLayout();
            this.downloadPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 331);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(702, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startOverToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startOverToolStripMenuItem
            // 
            this.startOverToolStripMenuItem.Name = "startOverToolStripMenuItem";
            this.startOverToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.startOverToolStripMenuItem.Text = "Start over";
            this.startOverToolStripMenuItem.Click += new System.EventHandler(this.startOverToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHomepageToolStripMenuItem,
            this.viewOnGitHubToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // viewHomepageToolStripMenuItem
            // 
            this.viewHomepageToolStripMenuItem.Name = "viewHomepageToolStripMenuItem";
            this.viewHomepageToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.viewHomepageToolStripMenuItem.Text = "View homepage";
            this.viewHomepageToolStripMenuItem.Click += new System.EventHandler(this.viewHomepageToolStripMenuItem_Click);
            // 
            // viewOnGitHubToolStripMenuItem
            // 
            this.viewOnGitHubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceCodeToolStripMenuItem,
            this.changelogToolStripMenuItem,
            this.issuesBugReportsToolStripMenuItem,
            this.wikiToolStripMenuItem,
            this.downloadsToolStripMenuItem});
            this.viewOnGitHubToolStripMenuItem.Name = "viewOnGitHubToolStripMenuItem";
            this.viewOnGitHubToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.viewOnGitHubToolStripMenuItem.Text = "View on GitHub";
            this.viewOnGitHubToolStripMenuItem.Click += new System.EventHandler(this.viewOnGitHubToolStripMenuItem_Click);
            // 
            // sourceCodeToolStripMenuItem
            // 
            this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            this.sourceCodeToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.sourceCodeToolStripMenuItem.Text = "Source Code";
            this.sourceCodeToolStripMenuItem.Click += new System.EventHandler(this.viewOnGitHubToolStripMenuItem_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // issuesBugReportsToolStripMenuItem
            // 
            this.issuesBugReportsToolStripMenuItem.Name = "issuesBugReportsToolStripMenuItem";
            this.issuesBugReportsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.issuesBugReportsToolStripMenuItem.Text = "Issues and Bug reports";
            this.issuesBugReportsToolStripMenuItem.Click += new System.EventHandler(this.issuesBugReportsToolStripMenuItem_Click);
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            this.wikiToolStripMenuItem.Click += new System.EventHandler(this.wikiToolStripMenuItem_Click);
            // 
            // downloadsToolStripMenuItem
            // 
            this.downloadsToolStripMenuItem.Name = "downloadsToolStripMenuItem";
            this.downloadsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.downloadsToolStripMenuItem.Text = "Downloads";
            this.downloadsToolStripMenuItem.Click += new System.EventHandler(this.downloadsToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jessenicToolStripMenuItem});
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.creditsToolStripMenuItem.Text = "Made by...";
            // 
            // jessenicToolStripMenuItem
            // 
            this.jessenicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twitterToolStripMenuItem,
            this.xDAForumsToolStripMenuItem});
            this.jessenicToolStripMenuItem.Name = "jessenicToolStripMenuItem";
            this.jessenicToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.jessenicToolStripMenuItem.Text = "jessenic";
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.twitterToolStripMenuItem.Text = "Twitter";
            this.twitterToolStripMenuItem.Click += new System.EventHandler(this.twitterToolStripMenuItem_Click);
            // 
            // xDAForumsToolStripMenuItem
            // 
            this.xDAForumsToolStripMenuItem.Name = "xDAForumsToolStripMenuItem";
            this.xDAForumsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.xDAForumsToolStripMenuItem.Text = "XDA Forums";
            this.xDAForumsToolStripMenuItem.Click += new System.EventHandler(this.xDAForumsToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "cab";
            this.openFileDialog1.Filter = "CAB files|*.cab|All Files|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select cabs";
            // 
            // sendCabThread
            // 
            this.sendCabThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendCabThread_DoWork);
            this.sendCabThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sendCabThread_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.firstPage);
            this.tabControl1.Controls.Add(this.predownloadedSelectionPage);
            this.tabControl1.Controls.Add(this.sendCabsPage);
            this.tabControl1.Controls.Add(this.downloadPage);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 300);
            this.tabControl1.TabIndex = 2;
            // 
            // firstPage
            // 
            this.firstPage.BackColor = System.Drawing.SystemColors.Control;
            this.firstPage.Controls.Add(this.webBrowser1);
            this.firstPage.Controls.Add(this.label3);
            this.firstPage.Controls.Add(this.InstallDownloadedCabsButton);
            this.firstPage.Controls.Add(this.downloadFromROMProviderButton);
            this.firstPage.Controls.Add(this.downloadfromMSbutton);
            this.firstPage.Controls.Add(this.label1);
            this.firstPage.Location = new System.Drawing.Point(4, 22);
            this.firstPage.Name = "firstPage";
            this.firstPage.Padding = new System.Windows.Forms.Padding(3);
            this.firstPage.Size = new System.Drawing.Size(669, 274);
            this.firstPage.TabIndex = 0;
            this.firstPage.Text = "Selection page";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(319, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(344, 264);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Downloading is not implemented yet, but it will be super easy";
            // 
            // InstallDownloadedCabsButton
            // 
            this.InstallDownloadedCabsButton.Location = new System.Drawing.Point(10, 96);
            this.InstallDownloadedCabsButton.Name = "InstallDownloadedCabsButton";
            this.InstallDownloadedCabsButton.Size = new System.Drawing.Size(238, 23);
            this.InstallDownloadedCabsButton.TabIndex = 4;
            this.InstallDownloadedCabsButton.Text = "Install already downloaded cabs";
            this.InstallDownloadedCabsButton.UseVisualStyleBackColor = true;
            this.InstallDownloadedCabsButton.Click += new System.EventHandler(this.InstallDownloadedCabsButton_Click);
            // 
            // downloadFromROMProviderButton
            // 
            this.downloadFromROMProviderButton.Enabled = false;
            this.downloadFromROMProviderButton.Location = new System.Drawing.Point(10, 66);
            this.downloadFromROMProviderButton.Name = "downloadFromROMProviderButton";
            this.downloadFromROMProviderButton.Size = new System.Drawing.Size(238, 23);
            this.downloadFromROMProviderButton.TabIndex = 3;
            this.downloadFromROMProviderButton.Text = "Download cabs from a ROM provider";
            this.downloadFromROMProviderButton.UseVisualStyleBackColor = true;
            // 
            // downloadfromMSbutton
            // 
            this.downloadfromMSbutton.Location = new System.Drawing.Point(10, 36);
            this.downloadfromMSbutton.Name = "downloadfromMSbutton";
            this.downloadfromMSbutton.Size = new System.Drawing.Size(238, 23);
            this.downloadfromMSbutton.TabIndex = 2;
            this.downloadfromMSbutton.Text = "Download official cabs from Microsoft servers";
            this.downloadfromMSbutton.UseVisualStyleBackColor = true;
            this.downloadfromMSbutton.Click += new System.EventHandler(this.downloadfromMSbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "What do you want to do?";
            // 
            // predownloadedSelectionPage
            // 
            this.predownloadedSelectionPage.BackColor = System.Drawing.SystemColors.Control;
            this.predownloadedSelectionPage.Controls.Add(this.removeSelectedButton);
            this.predownloadedSelectionPage.Controls.Add(this.addCabsButton);
            this.predownloadedSelectionPage.Controls.Add(this.label2);
            this.predownloadedSelectionPage.Controls.Add(this.selectedCabsView);
            this.predownloadedSelectionPage.Controls.Add(this.sendSelectedCabsButton);
            this.predownloadedSelectionPage.Location = new System.Drawing.Point(4, 22);
            this.predownloadedSelectionPage.Name = "predownloadedSelectionPage";
            this.predownloadedSelectionPage.Padding = new System.Windows.Forms.Padding(3);
            this.predownloadedSelectionPage.Size = new System.Drawing.Size(669, 274);
            this.predownloadedSelectionPage.TabIndex = 1;
            this.predownloadedSelectionPage.Text = "Select downloaded cabs";
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeSelectedButton.Location = new System.Drawing.Point(367, 246);
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(134, 23);
            this.removeSelectedButton.TabIndex = 4;
            this.removeSelectedButton.Text = "Remove selected cabs";
            this.removeSelectedButton.UseVisualStyleBackColor = true;
            this.removeSelectedButton.Click += new System.EventHandler(this.removeSelectedButton_Click);
            // 
            // addCabsButton
            // 
            this.addCabsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addCabsButton.Location = new System.Drawing.Point(507, 245);
            this.addCabsButton.Name = "addCabsButton";
            this.addCabsButton.Size = new System.Drawing.Size(75, 23);
            this.addCabsButton.TabIndex = 3;
            this.addCabsButton.Text = "Add Cabs";
            this.addCabsButton.UseVisualStyleBackColor = true;
            this.addCabsButton.Click += new System.EventHandler(this.addCabsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Drag and Drop cabs to the box below or press the Add Cabs -button";
            // 
            // selectedCabsView
            // 
            this.selectedCabsView.AllowDrop = true;
            this.selectedCabsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedCabsView.Location = new System.Drawing.Point(6, 23);
            this.selectedCabsView.Name = "selectedCabsView";
            this.selectedCabsView.ShowItemToolTips = true;
            this.selectedCabsView.Size = new System.Drawing.Size(657, 216);
            this.selectedCabsView.TabIndex = 1;
            this.selectedCabsView.UseCompatibleStateImageBehavior = false;
            this.selectedCabsView.View = System.Windows.Forms.View.List;
            this.selectedCabsView.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectedCabsView_DragDrop);
            this.selectedCabsView.DragEnter += new System.Windows.Forms.DragEventHandler(this.selectedCabsView_DragEnter);
            // 
            // sendSelectedCabsButton
            // 
            this.sendSelectedCabsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendSelectedCabsButton.Location = new System.Drawing.Point(588, 245);
            this.sendSelectedCabsButton.Name = "sendSelectedCabsButton";
            this.sendSelectedCabsButton.Size = new System.Drawing.Size(75, 23);
            this.sendSelectedCabsButton.TabIndex = 0;
            this.sendSelectedCabsButton.Text = "Send cabs";
            this.sendSelectedCabsButton.UseVisualStyleBackColor = true;
            this.sendSelectedCabsButton.Click += new System.EventHandler(this.sendSelectedCabsButton_Click);
            // 
            // sendCabsPage
            // 
            this.sendCabsPage.BackColor = System.Drawing.SystemColors.Control;
            this.sendCabsPage.Controls.Add(this.logBox);
            this.sendCabsPage.Controls.Add(this.sendWithoutBackupButton);
            this.sendCabsPage.Controls.Add(this.sendWithBackupButton);
            this.sendCabsPage.Location = new System.Drawing.Point(4, 22);
            this.sendCabsPage.Name = "sendCabsPage";
            this.sendCabsPage.Padding = new System.Windows.Forms.Padding(3);
            this.sendCabsPage.Size = new System.Drawing.Size(669, 274);
            this.sendCabsPage.TabIndex = 2;
            this.sendCabsPage.Text = "Send cabs page";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(7, 6);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(656, 233);
            this.logBox.TabIndex = 3;
            // 
            // sendWithoutBackupButton
            // 
            this.sendWithoutBackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendWithoutBackupButton.Location = new System.Drawing.Point(7, 244);
            this.sendWithoutBackupButton.Name = "sendWithoutBackupButton";
            this.sendWithoutBackupButton.Size = new System.Drawing.Size(176, 23);
            this.sendWithoutBackupButton.TabIndex = 2;
            this.sendWithoutBackupButton.Text = "Send cabs without backing up";
            this.sendWithoutBackupButton.UseVisualStyleBackColor = true;
            this.sendWithoutBackupButton.Click += new System.EventHandler(this.sendWithoutBackupButton_Click);
            // 
            // sendWithBackupButton
            // 
            this.sendWithBackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendWithBackupButton.Location = new System.Drawing.Point(495, 245);
            this.sendWithBackupButton.Name = "sendWithBackupButton";
            this.sendWithBackupButton.Size = new System.Drawing.Size(168, 23);
            this.sendWithBackupButton.TabIndex = 1;
            this.sendWithBackupButton.Text = "Send cabs and take a backup";
            this.sendWithBackupButton.UseVisualStyleBackColor = true;
            this.sendWithBackupButton.Click += new System.EventHandler(this.sendWithBackupButton_Click);
            // 
            // downloadPage
            // 
            this.downloadPage.BackColor = System.Drawing.SystemColors.Control;
            this.downloadPage.Controls.Add(this.label7);
            this.downloadPage.Controls.Add(this.selectLangBox);
            this.downloadPage.Controls.Add(this.label6);
            this.downloadPage.Controls.Add(this.versionBox);
            this.downloadPage.Controls.Add(this.label5);
            this.downloadPage.Controls.Add(this.subCatSelectBox);
            this.downloadPage.Controls.Add(this.label4);
            this.downloadPage.Controls.Add(this.catSelectBox);
            this.downloadPage.Location = new System.Drawing.Point(4, 22);
            this.downloadPage.Name = "downloadPage";
            this.downloadPage.Padding = new System.Windows.Forms.Padding(3);
            this.downloadPage.Size = new System.Drawing.Size(669, 274);
            this.downloadPage.TabIndex = 3;
            this.downloadPage.Text = "Download Page";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(520, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Select ALL installed langs";
            // 
            // selectLangBox
            // 
            this.selectLangBox.FormattingEnabled = true;
            this.selectLangBox.Location = new System.Drawing.Point(520, 28);
            this.selectLangBox.Name = "selectLangBox";
            this.selectLangBox.Size = new System.Drawing.Size(143, 238);
            this.selectLangBox.TabIndex = 6;
            this.selectLangBox.SelectedIndexChanged += new System.EventHandler(this.selectLangBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Select Version";
            // 
            // versionBox
            // 
            this.versionBox.FormattingEnabled = true;
            this.versionBox.Location = new System.Drawing.Point(367, 28);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(146, 238);
            this.versionBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Select Subcategory";
            // 
            // subCatSelectBox
            // 
            this.subCatSelectBox.FormattingEnabled = true;
            this.subCatSelectBox.Location = new System.Drawing.Point(189, 28);
            this.subCatSelectBox.Name = "subCatSelectBox";
            this.subCatSelectBox.Size = new System.Drawing.Size(171, 238);
            this.subCatSelectBox.TabIndex = 2;
            this.subCatSelectBox.SelectedIndexChanged += new System.EventHandler(this.subCatSelectBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Select category";
            // 
            // catSelectBox
            // 
            this.catSelectBox.FormattingEnabled = true;
            this.catSelectBox.Location = new System.Drawing.Point(7, 28);
            this.catSelectBox.Name = "catSelectBox";
            this.catSelectBox.Size = new System.Drawing.Size(175, 238);
            this.catSelectBox.TabIndex = 0;
            this.catSelectBox.SelectedIndexChanged += new System.EventHandler(this.catSelectBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 353);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Easy WP7.x Updater";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.firstPage.ResumeLayout(false);
            this.firstPage.PerformLayout();
            this.predownloadedSelectionPage.ResumeLayout(false);
            this.predownloadedSelectionPage.PerformLayout();
            this.sendCabsPage.ResumeLayout(false);
            this.sendCabsPage.PerformLayout();
            this.downloadPage.ResumeLayout(false);
            this.downloadPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnGitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabPage firstPage;
        private System.Windows.Forms.TabPage predownloadedSelectionPage;
        private WizardPages tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InstallDownloadedCabsButton;
        private System.Windows.Forms.Button downloadFromROMProviderButton;
        private System.Windows.Forms.Button downloadfromMSbutton;
        private System.Windows.Forms.TabPage sendCabsPage;
        private System.Windows.Forms.ToolStripMenuItem startOverToolStripMenuItem;
        private System.Windows.Forms.Button sendSelectedCabsButton;
        private System.Windows.Forms.Button addCabsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView selectedCabsView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button removeSelectedButton;
        private System.Windows.Forms.Button sendWithoutBackupButton;
        private System.Windows.Forms.Button sendWithBackupButton;
        private System.Windows.Forms.TextBox logBox;
        private System.ComponentModel.BackgroundWorker sendCabThread;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem viewHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jessenicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xDAForumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuesBugReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage downloadPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox versionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox subCatSelectBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox catSelectBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox selectLangBox;
    }
}

