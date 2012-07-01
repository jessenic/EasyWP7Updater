using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLEdit.Helper;

namespace XMLEdit.Controls
{
    public partial class EditItem : UserControl
    {
        BindableItem boundItem;

        public EditItem(BindableItem i)
        {
            InitializeComponent();
            boundItem = i;
            typeTxtbx.Text = i.BoundItem.Type.ToString();
            descriptionTxtbx.Text = i.BoundItem.Description;
            uriTxtbx.Text = i.BoundItem.Download.ToString();
            langidTxtbx.Text = i.BoundItem.LangId;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                boundItem.UpdateItem(descriptionTxtbx.Text, typeTxtbx.Text, new Uri(uriTxtbx.Text), langidTxtbx.Text);
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
