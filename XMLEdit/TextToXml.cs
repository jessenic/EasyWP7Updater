using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLEdit
{
    public partial class TextToXml : Form
    {
        const string rawOsLink = "<Item>\r\n<Download>{0}</Download>\r\n<Type>OS</Type>\r\n<Description>OS Update</Description></Item>";
        public TextToXml()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = textBox1.Text;
            String[] links = input.Split('\n');

            StringBuilder sb = new StringBuilder();
            foreach (string s in links)
            {
                sb.AppendLine(String.Format(rawOsLink, s.Trim()));
            }

            textBox2.Text = sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String input = textBox1.Text;
            String[] links = input.Split('\n');

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < links.Length; i++)
            {


                string[] languageParts = links[i].Trim().Split(' ');
                string languageId = languageParts[1].Replace(" ", "").Replace(":", "").Replace("(", "").Replace(")", "");

                i++;
                string linkOne = links[i];
                i++;
                string linkTwo = links[i];
                i++;

                sb.Append("<Item>");
                sb.AppendFormat("<Description>{0} - Part 1</Description>", languageParts[0]);
                sb.Append("<Type>Language</Type>");
                sb.AppendFormat("<Download>{0}</Download>", linkOne.Trim());
                sb.Append("</Item>");
                sb.Append("<Item>");
                sb.AppendFormat("<Description>{0} - Part 2</Description>", languageParts[0]);
                sb.Append("<Type>Language</Type>");
                sb.AppendFormat("<Download>{0}</Download>", linkTwo.Trim());
                sb.Append("</Item>");
            }

            textBox2.Text = sb.ToString();
        }
    }
}
