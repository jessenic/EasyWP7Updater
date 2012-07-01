using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages.Info;

namespace XMLEdit.Helper
{
    public class BindableSubcategory : TreeNode
    {
        public Subcategory BoundSubcategory {get; private set;}

        public BindableSubcategory(Subcategory sc)
        {
            this.Text = sc.ToString();
            this.Tag = "Subcategory";
            BoundSubcategory = sc;

            foreach (VersionInformation v in sc.Versions)
                this.Nodes.Add(new BindableVersion(v));
        }

        public void AddVersion(VersionInformation v)
        {
            this.Nodes.Add(new BindableVersion(v));
        }

        public void UpdateSubcategory(string name)
        {
            Subcategory sc = new Subcategory(name);
            sc.Versions.AddRange(BoundSubcategory.Versions);
            this.Text = sc.ToString();
            BoundSubcategory = sc;
        }
    }
}
