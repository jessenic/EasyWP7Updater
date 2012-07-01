using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages.Info;

namespace XMLEdit.Helper
{
    class BindableRoot : TreeNode
    {
        public BindableRoot()
        {
            this.Text = "Root";
            this.Tag = "Root";
        }

        public void AddCategory(Category c)
        {
            this.Nodes.Add(new BindableCategory(c));
        }
    }
}
