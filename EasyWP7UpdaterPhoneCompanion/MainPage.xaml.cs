using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using WP7RootToolsSDK;
using System.Diagnostics;

namespace EasyWP7UpdaterPhoneCompanion
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            List<WPLanguage> langList = getInstalledLanguages();
            foreach (WPLanguage lang in langList)
            {
                Debug.WriteLine(lang.Code + " - " + lang.Name);
            }
        }
        public List<WPLanguage> getInstalledLanguages()
        {
            List<WPLanguage> langList = new List<WPLanguage>();
            RegistryKey key = WP7RootToolsSDK.Registry.GetKey(RegistryHyve.LocalMachine, @"MUI\Available");
            foreach (RegistryItem ri in key.GetSubItems())
            {
                try
                {
                    RegistryValue rv = (RegistryValue)ri;
                    if (rv.Type == RegistryValueType.String)
                    {
                        langList.Add(new WPLanguage((string)rv.Value, rv.ValueName));
                    }
                }
                catch (Exception) { }
            }
            return langList;
        }

        public class WPLanguage
        {
            public string Name { get; private set; }
            public string Code { get; private set; }
            public WPLanguage(string Name, string Code)
            {
                this.Name = Name;
                this.Code = Code;
            }
        }
    }
}