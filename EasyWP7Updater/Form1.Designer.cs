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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new EasyWP7Updater.WizardPages();
            this.firstPage = new System.Windows.Forms.TabPage();
            this.InstallDownloadedCabsButton = new System.Windows.Forms.Button();
            this.downloadFromROMProviderButton = new System.Windows.Forms.Button();
            this.downloadfromMSbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.predownloadedSelectionPage = new System.Windows.Forms.TabPage();
            this.addCabsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedCabsView = new System.Windows.Forms.ListView();
            this.sendSelectedCabsButton = new System.Windows.Forms.Button();
            this.sendCabsPage = new System.Windows.Forms.TabPage();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.firstPage.SuspendLayout();
            this.predownloadedSelectionPage.SuspendLayout();
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
            this.viewOnGitHubToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // viewOnGitHubToolStripMenuItem
            // 
            this.viewOnGitHubToolStripMenuItem.Name = "viewOnGitHubToolStripMenuItem";
            this.viewOnGitHubToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.viewOnGitHubToolStripMenuItem.Text = "View on GitHub";
            this.viewOnGitHubToolStripMenuItem.Click += new System.EventHandler(this.viewOnGitHubToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // startOverToolStripMenuItem
            // 
            this.startOverToolStripMenuItem.Name = "startOverToolStripMenuItem";
            this.startOverToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.startOverToolStripMenuItem.Text = "Start over";
            this.startOverToolStripMenuItem.Click += new System.EventHandler(this.startOverToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "cab";
            this.openFileDialog1.Filter = "CAB files|*.cab|All Files|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select cabs";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.firstPage);
            this.tabControl1.Controls.Add(this.predownloadedSelectionPage);
            this.tabControl1.Controls.Add(this.sendCabsPage);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 300);
            this.tabControl1.TabIndex = 2;
            // 
            // firstPage
            // 
            this.firstPage.BackColor = System.Drawing.SystemColors.Control;
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
            this.sendCabsPage.Location = new System.Drawing.Point(4, 22);
            this.sendCabsPage.Name = "sendCabsPage";
            this.sendCabsPage.Padding = new System.Windows.Forms.Padding(3);
            this.sendCabsPage.Size = new System.Drawing.Size(669, 274);
            this.sendCabsPage.TabIndex = 2;
            this.sendCabsPage.Text = "Send cabs page";
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
    }
}

