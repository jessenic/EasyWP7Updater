using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Helper
{
    public static class LanguageList
    {
        private static Dictionary<string, string> _languages;
        private static Dictionary<string, string> _languagesById;

        public static Dictionary<string, string> Languages
        {
            get
            {
                if (_languages == null)
                    initialize();
                return _languages;
            }
            private set
            {
                _languages = value;
            }
        }

        public static Dictionary<string, string> LanguagesById
        {
            get
            {
                if (_languagesById == null)
                    initialize();
                return _languagesById;
            }
            private set
            {
                _languagesById = value;
            }
        }

        private static void initialize()
        {
            _languages = new Dictionary<string, string>();
            _languages.Add("Chinese (simplified)", "0804");
            _languages.Add("Chinese (traditional)", "0404");
            _languages.Add("Czech", "0405");
            _languages.Add("Danish", "0406");
            _languages.Add("Dutch", "0413");
            _languages.Add("English (US)", "0409");
            _languages.Add("English (GB)", "0809");
            _languages.Add("Finnish", "040B");
            _languages.Add("French", "040C");
            _languages.Add("German", "0407");
            _languages.Add("Greek", "0408");
            _languages.Add("Hungarian", "040E");
            _languages.Add("Indonesian", "0421");
            _languages.Add("Italian", "0410");
            _languages.Add("Japanese", "0411");
            _languages.Add("Korean", "0412");
            _languages.Add("Malay", "043E");
            _languages.Add("Norwegian", "0414");
            _languages.Add("Polish", "0415");
            _languages.Add("Portugese (Brazil)", "0416");
            _languages.Add("Portugese (Portugal)", "0816");
            _languages.Add("Russian", "0419");
            _languages.Add("Spanish", "0C0A");
            _languages.Add("Swedish", "041D");

            _languagesById = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> kvp in _languages)
            {
                _languagesById.Add(kvp.Value, kvp.Key);
            }
        }
    }
}
