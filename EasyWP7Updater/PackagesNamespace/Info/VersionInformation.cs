using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Packages.Info
{
    /// <summary>
    /// Represents a update version
    /// </summary>
    public class VersionInformation
    {
        /// <summary>
        /// The version that will be updated from
        /// </summary>
        public string FromVersion { get; private set; }
        /// <summary>
        /// The version that the phone will be updated to
        /// </summary>
        public string ToVersion { get; private set; }

        /// <summary>
        /// A list of all the items associated with this Version
        /// </summary>
        public List<Item> Items { get; private set; }

        /// <summary>
        /// Creates a new VersionInformation
        /// </summary>
        /// <param name="toVersion">The target version</param>
        public VersionInformation(string toVersion)
            : this("", toVersion)
        { }

        /// <summary>
        /// Creates a new VersionInformation
        /// </summary>
        /// <param name="fromVersion">The version that will be updated from</param>
        /// <param name="toVersion">The version the phone will be updated to</param>
        public VersionInformation(string fromVersion, string toVersion)
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

        /// <summary>
        /// Creates a string representation of the Version information
        /// </summary>
        /// <returns>Either "to VERSION" or "OLDVERSION to NEWVERSION"</returns>
        public override string ToString()
        {
            if (FromVersion != "")
                return String.Format("{0} to {1}", FromVersion, ToVersion);
            return String.Format("to {0}", ToVersion);
        }
    }
}
