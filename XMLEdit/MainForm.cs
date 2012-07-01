using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWP7Updater.Packages;
using EasyWP7Updater.Packages.Info;
using XMLEdit.Controls;
using XMLEdit.Helper;

namespace XMLEdit
{
    public partial class MainForm : Form
    {
        BindableRoot root;

        public MainForm()
        {
            InitializeComponent();
            clearTree();
        }

        private void clearTree()
        {
            xmlStructureTrvw.Nodes.Clear();
            root = new BindableRoot();
            xmlStructureTrvw.Nodes.Add(root);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openXmlOFDlg.ShowDialog() == DialogResult.OK)
            {
                buildTree(Packages.GetFromXml(openXmlOFDlg.FileName));
            }
        }

        private void buildTree(List<Category> categories)
        {
            clearTree();
            foreach (Category c in categories)
            {
                root.AddCategory(c);
            }
        }

        private void xmlStructureTrvw_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                Control control;
                switch (e.Node.Tag.ToString())
                {
                    case "Category":
                        controlContainerPnl.Controls.Clear();
                        control = new EditCategory(e.Node as BindableCategory);
                        control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                        controlContainerPnl.Controls.Add(control);

                        addNewBtn.Text = "Add new subcategory";
                        addNewBtn.Enabled = true;
                        break;
                    case "Subcategory":
                        controlContainerPnl.Controls.Clear();
                        control = new EditSubcategory(e.Node as BindableSubcategory);
                        control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                        controlContainerPnl.Controls.Add(control);

                        addNewBtn.Text = "Add new version";
                        addNewBtn.Enabled = true;
                        break;
                    case "Version":
                        controlContainerPnl.Controls.Clear();
                        control = new EditVersion(e.Node as BindableVersion);
                        control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                        controlContainerPnl.Controls.Add(control);

                        addNewBtn.Text = "Add new item";
                        addNewBtn.Enabled = true;
                        break;
                    case "Item":
                        controlContainerPnl.Controls.Clear();
                        control = new EditItem(e.Node as BindableItem);
                        control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                        controlContainerPnl.Controls.Add(control);

                        addNewBtn.Text = "Cannot add further depth";
                        addNewBtn.Enabled = false;
                        break;
                    case "Root":
                        controlContainerPnl.Controls.Clear();

                        addNewBtn.Text = "Add new category";
                        addNewBtn.Enabled = true;
                        break;

                }
            }
        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            TreeNode node = xmlStructureTrvw.SelectedNode;

            if (node != null && node.Tag != null)
            {
                switch (node.Tag.ToString())
                {
                    case "Category":
                        (node as BindableCategory).AddSubcategory(new Subcategory("new subcategory"));
                        break;
                    case "Subcategory":
                        (node as BindableSubcategory).AddVersion(new VersionInformation("9999.9.9.9"));
                        break;
                    case "Version":
                        (node as BindableVersion).AddItem(new Item("new item", "other", "", new Uri("http://example.org")));
                        break;
                    case "Root":
                        (node as BindableRoot).AddCategory(new Category("new category", "other"));
                        break;

                }

                node.Expand();
            }
        }

        private void xmlStructureTrvw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (xmlStructureTrvw.SelectedNode.Tag.ToString() != "Root")
                    xmlStructureTrvw.SelectedNode.Remove();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveXmlSFDlg.ShowDialog() == DialogResult.OK)
            {
                //BuildList
                List<Category> categories = new List<Category>();
                foreach (BindableCategory bc in root.Nodes)
                {
                    Category c = new Category(bc.BoundCategory.Name, bc.BoundCategory.Name);
                    foreach (BindableSubcategory bsc in bc.Nodes)
                    {
                        Subcategory sc = new Subcategory(bsc.BoundSubcategory.Name);
                        foreach (BindableVersion bv in bsc.Nodes)
                        {
                            VersionInformation vi = new VersionInformation(bv.BoundVersion.FromVersion, bv.BoundVersion.ToVersion);
                            foreach(BindableItem bi in bv.Nodes)
                            {
                                Item i = new Item(bi.BoundItem.Description, bi.BoundItem.Type.ToString(), bi.BoundItem.LangId, bi.BoundItem.Download);
                                vi.AddItem(i);
                            }
                            sc.AddVersion(vi);
                        }
                        c.AddSubcategory(sc);
                    }
                    categories.Add(c);
                }

                Packages.SaveToXML(categories, saveXmlSFDlg.FileName);
            }
        }

        private void text2XmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextToXml dlg = new TextToXml();
            dlg.Show();
        }
    }
}
