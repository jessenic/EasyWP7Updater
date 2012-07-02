using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XMLEdit.Helper;

namespace XMLEdit.Controls
{
    public partial class EditCategory : UserControl
    {
        private BindableCategory boundCategory;

        public EditCategory(BindableCategory bc)
        {
            InitializeComponent();
            boundCategory = bc;
            nameTxtbx.Text = boundCategory.BoundCategory.Name;
            typeTxtbx.Text = boundCategory.BoundCategory.Type.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            boundCategory.UpdateCategory(nameTxtbx.Text, typeTxtbx.Text);
        }
    }
}
