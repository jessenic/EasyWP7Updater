using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyWP7Updater.Forms
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(Exception ex)
        {
            InitializeComponent();

            StringBuilder message = new StringBuilder();
            message.AppendLine(ex.Message);
            message.AppendLine(ex.StackTrace);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
