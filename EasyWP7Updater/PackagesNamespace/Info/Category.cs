using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Packages.Info
{
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
        public CategoryType Type { get; private set; }
        /// <summary>
        /// Contains all subcategories
        /// </summary>
        public List<Subcategory> Subcategories { get; private set; }

        /// <summary>
        /// Creates a new Category
        /// </summary>
        /// <param name="name">The name of the category</param>
        /// <param name="type">The type of the category</param>
        public Category(string name, string type)
        {
            Name = name;
            switch (type.Trim().ToLower())
            {
                case "fw":
                case "firmware":
                    Type = CategoryType.firmware;
                    break;
                case "os":
                    Type = CategoryType.os;
                    break;
                default:
                    Type = CategoryType.other;
                    break;
            }
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

        /// <summary>
        /// Get a string representating the category
        /// </summary>
        /// <returns>The name of the category</returns>
        public override string ToString()
        {
            return Name;
        }

        public enum CategoryType
        {
            os,
            firmware,
            other
        }
    }
}
