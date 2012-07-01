using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages.Info;

namespace XMLEdit.Helper
{
    public class BindableVersion : TreeNode
    {
        public VersionInformation BoundVersion { get; private set; }

        public BindableVersion(VersionInformation v)
        {
            this.Text = v.ToString();
            this.Tag = "Version";
            BoundVersion = v;

            foreach (Item i in v.Items)
                this.Nodes.Add(new BindableItem(i));
        }

        public void AddItem(Item i)
        {
            this.Nodes.Add(new BindableItem(i));
        }

        public void UpdateVersion(string from, string to)
        {
            VersionInformation vi = new VersionInformation(from, to);
            vi.Items.AddRange(BoundVersion.Items);
            this.Text = vi.ToString();
            BoundVersion = vi;
        }
    }
}
