using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWO
{
    public partial class Form2 : Form
    {
        private string s1 = string.Empty;
        private string s2 = string.Empty;
        public Form2(bool isnew,string s,string z,string t)
        {
            
            InitializeComponent();
            s1 = s;
            s2 = z;
            if (isnew)
            {
                this.textBox1.ReadOnly = false;
                this.FormClosing += Form2_FormClosing1;
            }
            else
            {
                ExeType.SelectedIndex = getIndex(t);
                this.textBox1.Text = s;
                this.textBox2.Text = z;
            }

        }

        private void Form2_FormClosing1(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                NewSave();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }
        private void NewSave()
        {
            var r = regex.regexs;
            r.Add(new XBridge.Config.RegexItem
            {
                Regex = textBox1.Text,
                @out = new XBridge.Config.Out
                {
                    text = textBox2.Text,
                    type = getType(ExeType.SelectedIndex)
                }
            });
            regex.regexs = r;
            File.WriteAllText("regex.json", JsonConvert.SerializeObject(regex.regexs, Formatting.Indented));
        }
        private void save()
        {
            var r = regex.regexs;
            foreach (var i in r)
            {
                if (i.Regex == s1)
                {
                    i.@out.text = textBox2.Text;
                    i.@out.type = getType(ExeType.SelectedIndex);
                    regex.regexs = r;
                    File.WriteAllText("regex.json", JsonConvert.SerializeObject(regex.regexs, Formatting.Indented));
                }
            }
        }

        private static  string getType(int a)
        {
            switch (a)
            {
                case 0:
                    return "chat";
                case 1:
                    return "join";
                case 2:
                    return "left";
                case 3:
                    return "log";
                case 4:
                    return "plantext";
                default:
                    return "unknow";

            }
        }
        private int getIndex(string a)
        {
            switch (a)
            {
                case "chat":
                    return 0;
                case "join":
                    return 1;
                case "left":
                    return 2;
                case "log":
                    return 3;
                case "plantext":
                    return 4;
                default:
                    return 0;
            }
        }

    }
}
