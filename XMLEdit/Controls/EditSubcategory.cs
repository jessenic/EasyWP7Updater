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
    public partial class EditSubcategory : UserControl
    {
        private BindableSubcategory boundSubcategory;

        public EditSubcategory(BindableSubcategory sc)
        {
            InitializeComponent();
            boundSubcategory = sc;
            nameTxtbx.Text = sc.BoundSubcategory.Name;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            boundSubcategory.UpdateSubcategory(nameTxtbx.Text);
        }
    }
}
