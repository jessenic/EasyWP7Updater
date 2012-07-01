namespace XMLEdit.Controls
{
    partial class EditVersion
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
            this.fromTxtbx = new System.Windows.Forms.TextBox();
            this.toTxtbx = new System.Windows.Forms.TextBox();
            this.toLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.controlsGrpbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsGrpbx
            // 
            this.controlsGrpbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsGrpbx.Controls.Add(this.saveBtn);
            this.controlsGrpbx.Controls.Add(this.fromTxtbx);
            this.controlsGrpbx.Controls.Add(this.toTxtbx);
            this.controlsGrpbx.Controls.Add(this.toLbl);
            this.controlsGrpbx.Controls.Add(this.fromLbl);
            this.controlsGrpbx.Location = new System.Drawing.Point(3, 3);
            this.controlsGrpbx.Name = "controlsGrpbx";
            this.controlsGrpbx.Size = new System.Drawing.Size(498, 510);
            this.controlsGrpbx.TabIndex = 1;
            this.controlsGrpbx.TabStop = false;
            this.controlsGrpbx.Text = "Edit version";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(416, 71);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Apply";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // fromTxtbx
            // 
            this.fromTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromTxtbx.Location = new System.Drawing.Point(46, 19);
            this.fromTxtbx.Name = "fromTxtbx";
            this.fromTxtbx.Size = new System.Drawing.Size(445, 20);
            this.fromTxtbx.TabIndex = 2;
            // 
            // toTxtbx
            // 
            this.toTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toTxtbx.Location = new System.Drawing.Point(47, 45);
            this.toTxtbx.Name = "toTxtbx";
            this.toTxtbx.Size = new System.Drawing.Size(445, 20);
            this.toTxtbx.TabIndex = 2;
            // 
            // toLbl
            // 
            this.toLbl.AutoSize = true;
            this.toLbl.Location = new System.Drawing.Point(6, 48);
            this.toLbl.Name = "toLbl";
            this.toLbl.Size = new System.Drawing.Size(20, 13);
            this.toLbl.TabIndex = 1;
            this.toLbl.Text = "To";
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Location = new System.Drawing.Point(6, 22);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(30, 13);
            this.fromLbl.TabIndex = 0;
            this.fromLbl.Text = "From";
            // 
            // EditVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlsGrpbx);
            this.Name = "EditVersion";
            this.Size = new System.Drawing.Size(504, 516);
            this.controlsGrpbx.ResumeLayout(false);
            this.controlsGrpbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlsGrpbx;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox fromTxtbx;
        private System.Windows.Forms.TextBox toTxtbx;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label fromLbl;
    }
}
