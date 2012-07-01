using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages.Info;

namespace XMLEdit.Helper
{
    public class BindableItem : TreeNode
    {
        public Item BoundItem { get; private set; }

        public BindableItem(Item i)
        {
            this.Text = i.ToString();
            this.Tag = "Item";
            BoundItem = i;
        }

        public void UpdateItem(string description, string type, Uri location, string langid)
        {
            Item newItem = new Item(description, type, langid, location);
            this.Text = newItem.ToString();
            BoundItem = newItem;
        }
    }
}
