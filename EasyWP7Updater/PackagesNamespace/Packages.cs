using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using EasyWP7Updater.Packages.Info;

namespace EasyWP7Updater.Packages
{
    public class Packages
    {
        /// <summary>
        /// Will extract the update information from the given file
        /// </summary>
        /// <param name="filename">The file to parse (filname or URI)</param>
        /// <returns>List with all the Categories found</returns>
        public static List<Category> GetFromXml(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            List<Category> returnMe = new List<Category>();

            //Iterate over every second level element
            foreach (XmlNode element in doc.DocumentElement.ChildNodes)
            {
                switch (element.Name)
                {
                    //element is a Category
                    case "Category":

                        //Create the category that will be added to the list
                        string name = element.SelectSingleNode("Name").InnerText;
                        string type = element.SelectSingleNode("Type").InnerText;

                        Category c = new Category(name, type);
                        Subcategory sc = null;

                        //iterate over third level elements
                        foreach (XmlNode subcatNode in element.ChildNodes)
                        {
                            if (subcatNode.Name == "Subcategory")
                            {
                                string subcatName = "";

                                List<Item> items = new List<Item>();
                                List<VersionInformation> versions = new List<VersionInformation>();

                                foreach (XmlNode subcatElement in subcatNode.ChildNodes)
                                {
                                    switch (subcatElement.Name)
                                    {
                                        case "Name":
                                            subcatName = subcatElement.InnerText;
                                            continue;
                                        case "Version":
                                            string fromVersion = "";
                                            string toVersion = "";

                                            if(subcatElement.Attributes.GetNamedItem("From") != null)
                                                fromVersion = subcatElement.Attributes.GetNamedItem("From").InnerText;

                                            if (subcatElement.Attributes.GetNamedItem("To") != null)
                                                toVersion = subcatElement.Attributes.GetNamedItem("To").InnerText;

                                            foreach (XmlNode versionElement in subcatElement.ChildNodes)
                                            {
                                                switch (versionElement.Name)
                                                {
                                                    case "Item":
                                                        string desc = "";
                                                        string itemType = "";
                                                        string language = "";
                                                        Uri download = null;

                                                        //iterate over fourth level elements
                                                        foreach (XmlNode itemElement in versionElement.ChildNodes)
                                                        {
                                                            switch (itemElement.Name)
                                                            {
                                                                case "Description":
                                                                    desc = itemElement.InnerText;
                                                                    continue;
                                                                case "Type":
                                                                    itemType = itemElement.InnerText;
                                                                    continue;
                                                                case "LangId":
                                                                    language = itemElement.InnerText;
                                                                    continue;
                                                                case "Download":
                                                                    download = new Uri(itemElement.InnerText);
                                                                    continue;
                                                                default:
                                                                    if (System.Diagnostics.Debugger.IsAttached)
                                                                        System.Diagnostics.Debugger.Log(0, "XmlParser", "Element unrecognized and discarded: " + itemElement.Name);
                                                                    break;
                                                            }
                                                        }

                                                        items.Add(new Item(desc, itemType, language, download));

                                                        continue;
                                                }
                                            }

                                            VersionInformation v = new VersionInformation(fromVersion, toVersion);
                                            v.AddItems(items);
                                            items.Clear();
                                            versions.Add(v);

                                            continue;
                                        default:
                                            if (System.Diagnostics.Debugger.IsAttached)
                                                System.Diagnostics.Debugger.Log(0, "XmlParser", "Element unrecognized and discarded: " + subcatElement.Name);
                                            break;
                                    }
                                }
                                sc = new Subcategory(subcatName);
                                sc.AddVersions(versions);

                                c.AddSubcategory(sc);
                            }
                        }

                        returnMe.Add(c);

                        break;
                    default:
                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Log(0, "XmlParser", "Element unrecognized and discarded: " + element.Name);
                        break;
                }
            }

            return returnMe;
        }

        /// <summary>
        /// Serializes the given list into a XML
        /// </summary>
        /// <param name="categories">The list to serialize</param>
        public static void SaveToXML(List<Category> categories, string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("Categories");

            foreach (Category c in categories)
            {
                XmlNode categoryNode = doc.CreateElement("Category");

                XmlNode categoryName = doc.CreateElement("Name");
                categoryName.InnerText = c.Name;

                XmlNode categoryType = doc.CreateElement("Type");
                categoryType.InnerText = c.Type.ToString();

                categoryNode.AppendChild(categoryName);
                categoryNode.AppendChild(categoryType);

                foreach (Subcategory sc in c.Subcategories)
                {
                    XmlNode subcategoryNode = doc.CreateElement("Subcategory");
                    XmlNode subcategoryName = doc.CreateElement("Name");
                    subcategoryName.InnerText = sc.Name;
                    subcategoryNode.AppendChild(subcategoryName);

                    foreach (VersionInformation vi in sc.Versions)
                    {
                        XmlNode versionNode = doc.CreateElement("Version");

                        if (vi.FromVersion != "")
                        {
                            XmlAttribute fromVersion = doc.CreateAttribute("From");
                            fromVersion.InnerText = vi.FromVersion;
                            versionNode.Attributes.Append(fromVersion);
                        }

                        XmlAttribute toVersion = doc.CreateAttribute("To");
                        toVersion.InnerText = vi.ToVersion;
                        versionNode.Attributes.Append(toVersion);

                        foreach (Item i in vi.Items)
                        {
                            XmlElement itemNode = doc.CreateElement("Item");

                            XmlElement downloadNode = doc.CreateElement("Download");
                            downloadNode.InnerText = i.Download.ToString();
                            itemNode.AppendChild(downloadNode);

                            XmlElement descNode = doc.CreateElement("Description");
                            descNode.InnerText = i.Description;
                            itemNode.AppendChild(descNode);

                            XmlElement itemTypeNode = doc.CreateElement("Type");
                            itemTypeNode.InnerText = i.Type.ToString();
                            itemNode.AppendChild(itemTypeNode);

                            if (i.Type == ItemType.language)
                            {
                                XmlElement langIdNode = doc.CreateElement("LangId");
                                langIdNode.InnerText = i.LangId;
                                itemNode.AppendChild(langIdNode);
                            }

                            versionNode.AppendChild(itemNode);
                        }
                        subcategoryNode.AppendChild(versionNode);
                    }
                    categoryNode.AppendChild(subcategoryNode);
                }
                root.AppendChild(categoryNode);
            }

            doc.AppendChild(root);

            doc.Save(filename);
        }
    }
}
