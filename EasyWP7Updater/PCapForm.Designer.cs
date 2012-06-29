namespace EasyWP7Updater
{
    partial class PCapForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.startButton = new System.Windows.Forms.Button();
            this.deviceBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.captureWorker = new System.ComponentModel.BackgroundWorker();
            this.foundCabsBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is a very experimental feature and requires the WinPcap driver.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(345, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Download WinPcap";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(634, 247);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start sniffing";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // deviceBox
            // 
            this.deviceBox.FormattingEnabled = true;
            this.deviceBox.HorizontalScrollbar = true;
            this.deviceBox.Location = new System.Drawing.Point(12, 52);
            this.deviceBox.Name = "deviceBox";
            this.deviceBox.Size = new System.Drawing.Size(697, 69);
            this.deviceBox.TabIndex = 3;
            this.deviceBox.SelectedIndexChanged += new System.EventHandler(this.deviceBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select capturing device";
            // 
            // testButton
            // 
            this.testButton.Enabled = false;
            this.testButton.Location = new System.Drawing.Point(553, 247);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // captureWorker
            // 
            this.captureWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.captureWorker_DoWork);
            this.captureWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.captureWorker_RunWorkerCompleted);
            // 
            // foundCabsBox
            // 
            this.foundCabsBox.FormattingEnabled = true;
            this.foundCabsBox.Location = new System.Drawing.Point(12, 128);
            this.foundCabsBox.Name = "foundCabsBox";
            this.foundCabsBox.Size = new System.Drawing.Size(697, 108);
            this.foundCabsBox.TabIndex = 6;
            // 
            // PCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 282);
            this.Controls.Add(this.foundCabsBox);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deviceBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Name = "PCapForm";
            this.Text = "Zune Update sniffer";
            this.Load += new System.EventHandler(this.PCapForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListBox deviceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button testButton;
        private System.ComponentModel.BackgroundWorker captureWorker;
        private System.Windows.Forms.ListBox foundCabsBox;
    }
}