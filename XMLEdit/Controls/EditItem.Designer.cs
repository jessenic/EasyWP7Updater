namespace XMLEdit.Controls
{
    partial class EditItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlsGrpbx = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.descriptionTxtbx = new System.Windows.Forms.TextBox();
            this.typeTxtbx = new System.Windows.Forms.TextBox();
            this.typeLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.uriTxtbx = new System.Windows.Forms.TextBox();
            this.uriLbl = new System.Windows.Forms.Label();
            this.langidTxtbx = new System.Windows.Forms.TextBox();
            this.langidLbl = new System.Windows.Forms.Label();
            this.controlsGrpbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsGrpbx
            // 
            this.controlsGrpbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsGrpbx.Controls.Add(this.saveBtn);
            this.controlsGrpbx.Controls.Add(this.descriptionTxtbx);
            this.controlsGrpbx.Controls.Add(this.langidTxtbx);
            this.controlsGrpbx.Controls.Add(this.uriTxtbx);
            this.controlsGrpbx.Controls.Add(this.typeTxtbx);
            this.controlsGrpbx.Controls.Add(this.langidLbl);
            this.controlsGrpbx.Controls.Add(this.uriLbl);
            this.controlsGrpbx.Controls.Add(this.typeLbl);
            this.controlsGrpbx.Controls.Add(this.descriptionLbl);
            this.controlsGrpbx.Location = new System.Drawing.Point(3, 3);
            this.controlsGrpbx.Name = "controlsGrpbx";
            this.controlsGrpbx.Size = new System.Drawing.Size(498, 510);
            this.controlsGrpbx.TabIndex = 2;
            this.controlsGrpbx.TabStop = false;
            this.controlsGrpbx.Text = "Edit item";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(416, 123);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Apply";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // descriptionTxtbx
            // 
            this.descriptionTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTxtbx.Location = new System.Drawing.Point(46, 19);
            this.descriptionTxtbx.Name = "descriptionTxtbx";
            this.descriptionTxtbx.Size = new System.Drawing.Size(445, 20);
            this.descriptionTxtbx.TabIndex = 2;
            // 
            // typeTxtbx
            // 
            this.typeTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeTxtbx.AutoCompleteCustomSource.AddRange(new string[] {
            "os",
            "language",
            "other"});
            this.typeTxtbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.typeTxtbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.typeTxtbx.Location = new System.Drawing.Point(47, 45);
            this.typeTxtbx.Name = "typeTxtbx";
            this.typeTxtbx.Size = new System.Drawing.Size(445, 20);
            this.typeTxtbx.TabIndex = 2;
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Location = new System.Drawing.Point(6, 48);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(31, 13);
            this.typeLbl.TabIndex = 1;
            this.typeLbl.Text = "Type";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Location = new System.Drawing.Point(6, 22);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(35, 13);
            this.descriptionLbl.TabIndex = 0;
            this.descriptionLbl.Text = "Desc.";
            // 
            // uriTxtbx
            // 
            this.uriTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriTxtbx.Location = new System.Drawing.Point(47, 71);
            this.uriTxtbx.Name = "uriTxtbx";
            this.uriTxtbx.Size = new System.Drawing.Size(445, 20);
            this.uriTxtbx.TabIndex = 2;
            // 
            // uriLbl
            // 
            this.uriLbl.AutoSize = true;
            this.uriLbl.Location = new System.Drawing.Point(6, 74);
            this.uriLbl.Name = "uriLbl";
            this.uriLbl.Size = new System.Drawing.Size(26, 13);
            this.uriLbl.TabIndex = 1;
            this.uriLbl.Text = "URI";
            // 
            // langidTxtbx
            // 
            this.langidTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.langidTxtbx.Location = new System.Drawing.Point(47, 97);
            this.langidTxtbx.Name = "langidTxtbx";
            this.langidTxtbx.Size = new System.Drawing.Size(445, 20);
            this.langidTxtbx.TabIndex = 2;
            // 
            // langidLbl
            // 
            this.langidLbl.AutoSize = true;
            this.langidLbl.Location = new System.Drawing.Point(6, 100);
            this.langidLbl.Name = "langidLbl";
            this.langidLbl.Size = new System.Drawing.Size(42, 13);
            this.langidLbl.TabIndex = 1;
            this.langidLbl.Text = "LangID";
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlsGrpbx);
            this.Name = "EditItem";
            this.Size = new System.Drawing.Size(504, 516);
            this.controlsGrpbx.ResumeLayout(false);
            this.controlsGrpbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlsGrpbx;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox descriptionTxtbx;
        private System.Windows.Forms.TextBox typeTxtbx;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.TextBox uriTxtbx;
        private System.Windows.Forms.Label uriLbl;
        private System.Windows.Forms.TextBox langidTxtbx;
        private System.Windows.Forms.Label langidLbl;

    }
}
