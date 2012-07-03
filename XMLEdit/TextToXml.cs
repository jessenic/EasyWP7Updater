using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace XMLEdit
{
    public partial class TextToXml : Form
    {
        Regex cabLinkRegex = new Regex("(http.*?://.*?.cab)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex isLangRegex = new Regex("lang_([0-9A-Fa-f]{0,4})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex versionRegex = new Regex(@"([0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,4}\.[0-9]{1,4})", RegexOptions.Compiled |RegexOptions.IgnoreCase);
        public TextToXml()
        {
            InitializeComponent();
        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            string input = inputTxtbx.Text;

            if (input != "")
            {
                StringBuilder sb = new StringBuilder();
                Match matchLinks = cabLinkRegex.Match(input);
                List<string> links = new List<string>();
                Dictionary<string, int> languagePartNo = new Dictionary<string, int>();

                while (matchLinks.Success)
                {
                    links.Add(matchLinks.Groups[0].Value);
                    matchLinks = matchLinks.NextMatch();
                }

                foreach (string s in links)
                {
                    string description = "OS Update";
                    string languageId = "";
                    string type = "os";
                    string fromVersion = "";
                    string toVersion = "";
                    if (isLangRegex.IsMatch(s))
                    {
                        //link is a language
                        Match langIdMatch = isLangRegex.Match(s);
                        languageId = langIdMatch.Groups[1].Value.ToUpper();

                        if (!languagePartNo.ContainsKey(languageId))
                            languagePartNo.Add(languageId, 0);

                        languagePartNo[languageId] = languagePartNo[languageId] + 1;
                        string languageName = EasyWP7Updater.Helper.LanguageList.LanguagesById[languageId];

                        description = String.Format("{0} - Part {1}", languageName, languagePartNo[languageId]);
                        type = "language";
                    }

                    if (versionRegex.IsMatch(s))
                    {
                        //s contains at least one version
                        MatchCollection m = versionRegex.Matches(s);

                        if (m.Count == 2)
                        {
                            fromVersion = m[0].Groups[1].Value;
                            toVersion = m[1].Groups[1].Value;
                        }
                        else
                        {
                            toVersion = m[0].Groups[1].Value;
                        }
                    }

                    if (type != "language")
                    {
                        if (fromVersion != "" && toVersion != "")
                        {
                            description = String.Format("{0} - from {1} to {2}", description, fromVersion, toVersion);
                        }
                        else if (fromVersion != "")
                        {
                            description = String.Format("{0} - to {1}", description, toVersion);
                        }
                    }

                    sb.AppendLine("<Item>");
                    sb.AppendLine(String.Format("<Description>{0}</Description>", description));
                    sb.AppendLine(String.Format("<Type>{0}</Type>", type));
                    sb.AppendLine(String.Format("<Download>{0}</Download>", s));

                    if(languageId != "")
                        sb.AppendLine(String.Format("<LangId>{0}</LangId>", languageId));

                    sb.AppendLine("</Item>");
                }

                outputTxtbx.Text = sb.ToString();
            }
        }
    }
}
