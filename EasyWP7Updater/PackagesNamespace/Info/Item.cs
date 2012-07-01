using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Packages.Info
{
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

        /// <summary>
        /// Creates a new Item
        /// </summary>
        /// <param name="desc">The description</param>
        /// <param name="type">The type</param>
        /// <param name="lang">The language</param>
        /// <param name="download">The download location</param>
        public Item(string desc, string type, string lang, Uri download)
        {
            Description = desc;
            switch (type.ToLower())
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

        /// <summary>
        /// Returns a string representation
        /// </summary>
        /// <returns>The description</returns>
        public override string ToString()
        {
            if (Description != "")
                return Description;

            switch (Type)
            {
                case ItemType.os:
                    return "OS update";
                case ItemType.language:
                    return "unamed language file";
                case ItemType.other:
                    return "unknown update";
            }

            return "unknown";
        }
    }

    /// <summary>
    /// The ItemType
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// The Item is os related
        /// </summary>
        os,
        /// <summary>
        /// The Item is language related
        /// </summary>
        language,
        /// <summary>
        /// The items relation is unknown
        /// </summary>
        other
    }
}
