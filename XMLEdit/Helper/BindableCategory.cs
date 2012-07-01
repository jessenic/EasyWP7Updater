using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages.Info;

namespace XMLEdit.Helper
{
    public class BindableCategory : TreeNode
    {
        public Category BoundCategory { get; private set; }

        public BindableCategory(Category bindMe)
        {
            this.Text = bindMe.ToString();
            this.Tag = "Category";
            BoundCategory = bindMe;

            foreach (Subcategory sc in bindMe.Subcategories)
            {
                this.Nodes.Add(new BindableSubcategory(sc));
            }
        }

        public void AddSubcategory(Subcategory sc)
        {
            this.Nodes.Add(new BindableSubcategory(sc));
        }

        public void UpdateCategory(string name, string type)
        {
            Category updated = new Category(name, type);
            updated.Subcategories.AddRange(BoundCategory.Subcategories);
            this.Text = updated.ToString();
            BoundCategory = updated;
        }
    }
}
