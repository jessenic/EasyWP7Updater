using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Packages.Info
{

    /// <summary>
    /// Represents a subcategory
    /// </summary>
    public class Subcategory
    {
        /// <summary>
        /// The name of the subcategory
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The associated versions
        /// </summary>
        public List<VersionInformation> Versions { get; private set; }

        /// <summary>
        /// Creates a new subcategory
        /// </summary>
        /// <param name="name">The name of the subcategory</param>
        public Subcategory(string name)
        {
            Name = name;
            Versions = new List<VersionInformation>();
        }

        /// <summary>
        /// Returns a string representating the subcategory
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Adds a version to the subcategory
        /// </summary>
        /// <param name="v">The version to add</param>
        public void AddVersion(VersionInformation v)
        {
            Versions.Add(v);
        }

        /// <summary>
        /// Adds a range of versions to the subcategory
        /// </summary>
        /// <param name="versions">The versions to add</param>
        public void AddVersions(IEnumerable<VersionInformation> versions)
        {
            Versions.AddRange(versions);
        }
    }
}
