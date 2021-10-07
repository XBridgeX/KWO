using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using XBridge.Config;

namespace KWO
{
    public partial class Form1 : Form
    {
        public static Form1 MainForm;
        public Form2 form2;
        public static Process bds;
        static FileInfo bdspath;
        public static cfg fcfg;
        public static bool rt = false;
        public static WSS wss;
        public static ListBox regexbox;
        public static TextBox console;
        public static StringBuilder tmplog = new StringBuilder();
        public static StringBuilder logs = new StringBuilder();
        public Form1()
        {
            //BDSStatus.ForeColor = Color.Red;
            try
            {
                #region 配置文件
                if (!File.Exists("cfg.json"))
                {
                    var f = new cfg
                    {
                        bdspath = "",
                        wskey = "password",
                        wsport = 8080
                    };
                    File.WriteAllText("cfg.json", JsonConvert.SerializeObject(f, Formatting.Indented));
                }
                if (!File.Exists("regex.json"))
                {
                    File.WriteAllText("regex.json", "[]");
                }
                Directory.CreateDirectory("logs");
                #endregion 
                regex.regexs = JsonConvert.DeserializeObject<List<RegexItem>>(File.ReadAllText("regex.json"));
                fcfg = JsonConvert.DeserializeObject<cfg>(File.ReadAllText("cfg.json"));
                wss = new WSS(fcfg.wsport, fcfg.wskey);
                InitializeComponent();
                regexbox = regexs;
                MainForm = this;
                foreach (var i in regex.regexs)
                {
                    regexs.Items.Add(i.Regex);
                }
                this.WS_STATUS_Light.ForeColor = Color.Green;
                this.WS_STATUS_Light.Text = "已开启";
                WS_Port.Text = fcfg.wsport.ToString();
                WS_KEY.Text = fcfg.wskey.ToString();
                this.BDSPath_text.Text = fcfg.bdspath;
                regexs.Hide();
                console = bdsconsole;
                this.FormClosing += Form1_FormClosed;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                WS_KEY.MouseHover += WS_KEY_MouseHover;
                WS_KEY.MouseLeave += WS_KEY_MouseLeave;
                WS_STATUS_Light.MouseDoubleClick += WS_STATUS_Light_MouseDoubleClick;
                try
                {
                    bdspath = new FileInfo(fcfg.bdspath);
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KWO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
       }

        private void WS_STATUS_Light_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WS_STATUS_Light.Text == "已关闭")
                return;
            if(MessageBox.Show("是否关闭websocket服务器？","KWO",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                wss.stop();
                WS_STATUS_Light.ForeColor = Color.Maroon;
                WS_STATUS_Light.Text = "已关闭";
            }
            
        }

        private void WS_KEY_MouseLeave(object sender, EventArgs e)
        {
            WS_KEY.PasswordChar = '*';
        }

        private void WS_KEY_MouseHover(object sender, EventArgs e)
        {
            this.WS_KEY.PasswordChar = Char.MinValue;
        }

        private void Form1_FormClosed(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!bds.HasExited)
                {

                    if (MessageBox.Show("服务器仍在运行！\n您确定要关闭面板吗", "KWO", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        bds.Kill();
                        File.AppendAllText($"./logs/{DateTime.Now.ToString("yyyy-M-d")}.log", logs.ToString());
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

            }
            catch { }

        }

        private void ChoseBDSPath_Click(object sender, EventArgs e)
        {
            Thread chosefile = new Thread(Chose_file);
            chosefile.SetApartmentState(ApartmentState.STA);
            chosefile.Start();
        }

        private void Chose_file()
        {
            //选择文件
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string file = dialog.FileName;
                if (!string.IsNullOrEmpty(file))
                {
                    FileInfo ff = new FileInfo(file);
                    bdspath = ff;
                    BDSPath_text.Text = ff.FullName;
                    fcfg.bdspath = ff.FullName;
                    SAVE();
                }
            }

        }
        private void SAVE()
        {
            File.WriteAllText("cfg.json", JsonConvert.SerializeObject(fcfg, Formatting.Indented));
        }
        Process CreateProcess(string filename, string dir)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = filename;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.RedirectStandardInput = true;
            ps.StartInfo.RedirectStandardError = true;
            ps.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            if (!string.IsNullOrEmpty(dir))
                ps.StartInfo.WorkingDirectory = dir;
            ps.EnableRaisingEvents = true;
            ps.OutputDataReceived += Ps_OutputDataReceived;
            ps.Exited += Ps_Exited;
            return ps;
        }

        private void Ps_Exited(object sender, EventArgs e)
        {
            wss.sendClose();
            BDSStatus.ForeColor = Color.Maroon;
            BDSStatus.Invoke(new Action(()=>
            {
                this.BDSStatus.Text = "已关闭";
                //MessageBox.Show("ok");
            }));
            StartBDS.Enabled = true;
            File.AppendAllText($"./logs/{DateTime.Now.ToString("yyyy-M-d")}.log", logs.ToString());
            if (AutoRestart.Checked)
            {
                addConsoleLine("10秒后重启");
                Task.Run(() =>
                {
                    StartBDS.Enabled = false;
                    Thread.Sleep(10000);
                    start_bds();
                });
            }

        }

        private void Ps_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Data))
                    return;
                if (rt)
                {
                    rt = false;
                    try
                    {
                        wss.sendCMD(e.Data);
                    }
                    catch { }

                    return;
                }
                if (NoSelecter.Checked && e.Data == "No targets matched selector")
                {
                    return;
                }
                tmplog.Append(e.Data+"\n");
                regex.on_regex(tmplog.ToString());
                addConsoleLine(e.Data);
                logs.AppendLine(e.Data);
                //this.BDSConsole.TopIndex = this.BDSConsole.Items.Count - (int)(this.BDSConsole.Height / this.BDSConsole.ItemHeight);
                if (bdsconsole.Lines.Length > 500)
                {
                    try
                    {
                        File.AppendAllText($"./logs/{DateTime.Now.ToString("yyyy-M-d")}.log", logs.ToString());
                        logs.Clear();
                    }
                    catch { }
                    Console.Clear();
                }
                    
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void sendCMD_Click(object sender, EventArgs e)
        {
            if (bds != null)
            {
                try
                {
            bds.StandardInput.WriteLine(bds.StandardInput.Encoding.GetString(Encoding.UTF8.GetBytes(CMDInput.Text)));
            CMDInput.Clear();
        }
                catch (Exception ex)
                {
                    addConsoleLine(ex.ToString());
                }
            }
            else
            {
                addConsoleLine("服务器未启动，无法执行命令");
            }

        }
        public void addConsoleLine(string t)
        {
            bdsconsole.AppendText(t + Environment.NewLine);
        }
        private void run()
        {
            while (true)
            {
                if (BDSStatus.ForeColor == Color.Red)
                {
                    BDSStatus.ForeColor = Color.Green;
                }
                else
                {
                    BDSStatus.ForeColor = Color.Red;
                }
                Thread.Sleep(300);
            }
        }

        private void StartBDS_Click(object sender, EventArgs e)
        {
         
            if (!string.IsNullOrWhiteSpace(BDSPath_text.Text))
            {
                if (!File.Exists(BDSPath_text.Text))
                {
                    MessageBox.Show("服务端路径不存在！", "KWO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                start_bds();
            }
        }
        public void start_bds()
        {
            if (bds == null)
            {
                bds = new Process();
            }
            bds = CreateProcess(BDSPath_text.Text, bdspath.DirectoryName);
            var b = new Thread(() =>
            {
                bds.Start();
                bds.BeginErrorReadLine();
                bds.BeginOutputReadLine();
                bds.WaitForExit(0);
            });
            b.IsBackground = true;
            b.Start();
            BDSStatus.ForeColor = Color.Green;
            wss.sendStart();
            BDSStatus.Text = "已开启";
            StartBDS.Enabled = false;
        }
        private void STOPBDS_Click(object sender, EventArgs e)
        {
            if (bds.HasExited == false)
            {
                bds.Kill();               
                StartBDS.Enabled = true;
                MessageBox.Show("服务器已强行停止", "KWO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void WS_Port_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(WS_Port.Text,out var foo) == false)
            {
                MessageBox.Show("请输入正确的数值", "WSPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WS_Port.Clear();
                return;
            }
            fcfg.wsport = int.Parse(WS_Port.Text);
            SAVE();
        }

        private void WS_KEY_TextChanged(object sender, EventArgs e)
        {
            fcfg.wskey = WS_KEY.Text; 
            SAVE();
        }

        private void 配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regexs.Show();
            bdsconsole.Hide();
        }

        private void 视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regexs.Hide();
            bdsconsole.Show();
        }

        private void regex_edit_Click(object sender, EventArgs e)
        {
            if (regexs.SelectedIndex == -1)
                return;
            if (form2 == null)
            {
                var reg = regex.regexs.ToArray()[regexbox.SelectedIndex];
                form2 = new Form2(reg.Regex, reg.@out.text, reg.@out.type);
                form2.FormClosed += Form2_FormClosed;
                form2.Show();
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2 = null;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本：1.1.2.3\n作者：Lition\nEmial：dreamgqf@163.com\n如果你发现任何问题，可以联系我", "关于作者", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 重载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                regex.regexs = JsonConvert.DeserializeObject<List<RegexItem>>(File.ReadAllText("regex.json"));
                regexs.Items.Clear();
                foreach (var i in regex.regexs)
                {
                    regexs.Items.Add(i.Regex);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "KWO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
