using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EasyWP7Updater.Packages
{
    class Packages
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
                                List<Version> versions = new List<Version>();

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

                                            Version v = new Version(fromVersion, toVersion);
                                            v.AddItems(items);
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
    }

    /// <summary>
    /// Represents an update category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The name of the category
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The type of the category
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// Contains all subcategories
        /// </summary>
        public List<Subcategory> Subcategories { get; private set; }

        public Category(string name, string type)
        {
            Name = name;
            Type = type;
            Subcategories = new List<Subcategory>();
        }

        /// <summary>
        /// Adds a subcategory
        /// </summary>
        /// <param name="subcategorie">The subcategory to add</param>
        public void AddSubcategory(Subcategory subcategorie)
        {
            Subcategories.Add(subcategorie);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// Represents a subcategory
    /// </summary>
    public class Subcategory
    {
        /// <summary>
        /// The name of the subcategory
        /// </summary>
        public string Name { get; private set; }
        public List<Version> Versions { get; private set; }

        public Subcategory(string name)
        {
            Name = name;
            Versions = new List<Version>();
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddVersion(Version v)
        {
            Versions.Add(v);
        }

        public void AddVersions(IEnumerable<Version> versions)
        {
            Versions.AddRange(versions);
        }
    }


    public class Version
    {
        public string FromVersion { get; private set; }
        public string ToVersion { get; private set; }

        /// <summary>
        /// A list of all the items associated with this Version
        /// </summary>
        public List<Item> Items { get; private set; }

        public Version(string toVersion)
            : this("", toVersion)
        { }

        public Version(string fromVersion, string toVersion)
        {
            FromVersion = fromVersion;
            ToVersion = toVersion;
            Items = new List<Item>();
        }

        /// <summary>
        /// Adds a single item
        /// </summary>
        /// <param name="item">The item to add</param>
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Adds multiple items
        /// </summary>
        /// <param name="items">The IEnumerable containing the items to add</param>
        public void AddItems(IEnumerable<Item> items)
        {
            Items.AddRange(items);
        }

        public override string ToString()
        {
            if (FromVersion != "")
                return String.Format("{0} to {1}", FromVersion, ToVersion);
            return String.Format("to {0}", ToVersion);
        }
    }

    /// <summary>
    /// Represents a item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// The type
        /// </summary>
        public ItemType Type { get; private set; }
        /// <summary>
        /// The language
        /// </summary>
        public string LangId { get; private set; }
        /// <summary>
        /// The download location
        /// </summary>
        public Uri Download { get; private set; }

        public Item(string desc, string type, string lang, Uri download)
        {
            Description = desc;
            switch (type)
            {
                case "os":
                    Type = ItemType.os;
                    break;
                case "language":
                    Type = ItemType.language;
                    break;
                default:
                    Type = ItemType.other;
                    break;
            }
            LangId = lang;
            Download = download;
        }

        public override string ToString()
        {
            return Description;
        }
    }

    public enum ItemType
    {
        os,
        language,
        other
    }
}
