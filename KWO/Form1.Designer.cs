
namespace KWO
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bdsconsole = new System.Windows.Forms.TextBox();
            this.regexs = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.regex_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.regex_del = new System.Windows.Forms.ToolStripMenuItem();
            this.重载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StartBDS = new System.Windows.Forms.Button();
            this.ChoseBDSPath = new System.Windows.Forms.Button();
            this.BDSPath_text = new System.Windows.Forms.TextBox();
            this.BDSPath = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.WS_STATUS_Light = new System.Windows.Forms.Label();
            this.WSStatus = new System.Windows.Forms.Label();
            this.BDSStatus_text = new System.Windows.Forms.Label();
            this.BDSStatus = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.NoSelecter = new System.Windows.Forms.CheckBox();
            this.AutoRestart = new System.Windows.Forms.CheckBox();
            this.STOPBDS = new System.Windows.Forms.Button();
            this.sendCMD = new System.Windows.Forms.Button();
            this.CMDInput = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.WS_KEY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WS_Port_Name = new System.Windows.Forms.Label();
            this.WS_Port = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regex_new = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bdsconsole);
            this.panel1.Controls.Add(this.regexs);
            this.panel1.Location = new System.Drawing.Point(232, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 321);
            this.panel1.TabIndex = 0;
            // 
            // bdsconsole
            // 
            this.bdsconsole.BackColor = System.Drawing.Color.White;
            this.bdsconsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bdsconsole.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bdsconsole.Location = new System.Drawing.Point(0, 0);
            this.bdsconsole.Multiline = true;
            this.bdsconsole.Name = "bdsconsole";
            this.bdsconsole.ReadOnly = true;
            this.bdsconsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bdsconsole.Size = new System.Drawing.Size(556, 304);
            this.bdsconsole.TabIndex = 8;
            this.bdsconsole.WordWrap = false;
            // 
            // regexs
            // 
            this.regexs.ContextMenuStrip = this.contextMenuStrip1;
            this.regexs.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regexs.FormattingEnabled = true;
            this.regexs.ItemHeight = 20;
            this.regexs.Location = new System.Drawing.Point(0, 0);
            this.regexs.Name = "regexs";
            this.regexs.Size = new System.Drawing.Size(556, 304);
            this.regexs.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regex_edit,
            this.regex_del,
            this.regex_new,
            this.重载ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // regex_edit
            // 
            this.regex_edit.Name = "regex_edit";
            this.regex_edit.Size = new System.Drawing.Size(180, 22);
            this.regex_edit.Text = "编辑";
            this.regex_edit.Click += new System.EventHandler(this.regex_edit_Click);
            // 
            // regex_del
            // 
            this.regex_del.Name = "regex_del";
            this.regex_del.Size = new System.Drawing.Size(180, 22);
            this.regex_del.Text = "删除";
            this.regex_del.Click += new System.EventHandler(this.regex_del_Click);
            // 
            // 重载ToolStripMenuItem
            // 
            this.重载ToolStripMenuItem.Name = "重载ToolStripMenuItem";
            this.重载ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.重载ToolStripMenuItem.Text = "重载";
            this.重载ToolStripMenuItem.Click += new System.EventHandler(this.重载ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.StartBDS);
            this.panel2.Controls.Add(this.ChoseBDSPath);
            this.panel2.Controls.Add(this.BDSPath_text);
            this.panel2.Controls.Add(this.BDSPath);
            this.panel2.Location = new System.Drawing.Point(12, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 129);
            this.panel2.TabIndex = 0;
            // 
            // StartBDS
            // 
            this.StartBDS.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartBDS.Location = new System.Drawing.Point(9, 88);
            this.StartBDS.Name = "StartBDS";
            this.StartBDS.Size = new System.Drawing.Size(75, 23);
            this.StartBDS.TabIndex = 1;
            this.StartBDS.Text = "启动";
            this.StartBDS.UseVisualStyleBackColor = true;
            this.StartBDS.Click += new System.EventHandler(this.StartBDS_Click);
            // 
            // ChoseBDSPath
            // 
            this.ChoseBDSPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChoseBDSPath.Location = new System.Drawing.Point(122, 88);
            this.ChoseBDSPath.Name = "ChoseBDSPath";
            this.ChoseBDSPath.Size = new System.Drawing.Size(75, 23);
            this.ChoseBDSPath.TabIndex = 2;
            this.ChoseBDSPath.Text = "选择";
            this.ChoseBDSPath.UseVisualStyleBackColor = true;
            this.ChoseBDSPath.Click += new System.EventHandler(this.ChoseBDSPath_Click);
            // 
            // BDSPath_text
            // 
            this.BDSPath_text.BackColor = System.Drawing.SystemColors.Control;
            this.BDSPath_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BDSPath_text.Location = new System.Drawing.Point(5, 50);
            this.BDSPath_text.Name = "BDSPath_text";
            this.BDSPath_text.ReadOnly = true;
            this.BDSPath_text.ShortcutsEnabled = false;
            this.BDSPath_text.Size = new System.Drawing.Size(192, 23);
            this.BDSPath_text.TabIndex = 1;
            this.BDSPath_text.TabStop = false;
            this.BDSPath_text.WordWrap = false;
            // 
            // BDSPath
            // 
            this.BDSPath.AutoSize = true;
            this.BDSPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BDSPath.Location = new System.Drawing.Point(3, 21);
            this.BDSPath.Name = "BDSPath";
            this.BDSPath.Size = new System.Drawing.Size(106, 21);
            this.BDSPath.TabIndex = 0;
            this.BDSPath.Text = "服务端主路径";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.WS_STATUS_Light);
            this.panel4.Controls.Add(this.WSStatus);
            this.panel4.Controls.Add(this.BDSStatus_text);
            this.panel4.Controls.Add(this.BDSStatus);
            this.panel4.Location = new System.Drawing.Point(12, 205);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "---------------------------";
            // 
            // WS_STATUS_Light
            // 
            this.WS_STATUS_Light.AutoSize = true;
            this.WS_STATUS_Light.BackColor = System.Drawing.SystemColors.ControlLight;
            this.WS_STATUS_Light.Cursor = System.Windows.Forms.Cursors.Default;
            this.WS_STATUS_Light.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WS_STATUS_Light.ForeColor = System.Drawing.Color.Maroon;
            this.WS_STATUS_Light.Location = new System.Drawing.Point(120, 65);
            this.WS_STATUS_Light.Name = "WS_STATUS_Light";
            this.WS_STATUS_Light.Size = new System.Drawing.Size(21, 14);
            this.WS_STATUS_Light.TabIndex = 6;
            this.WS_STATUS_Light.Text = "🟨";
            // 
            // WSStatus
            // 
            this.WSStatus.AutoSize = true;
            this.WSStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WSStatus.Location = new System.Drawing.Point(5, 62);
            this.WSStatus.Name = "WSStatus";
            this.WSStatus.Size = new System.Drawing.Size(73, 20);
            this.WSStatus.TabIndex = 5;
            this.WSStatus.Text = "WS状态：";
            // 
            // BDSStatus_text
            // 
            this.BDSStatus_text.AutoSize = true;
            this.BDSStatus_text.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BDSStatus_text.Location = new System.Drawing.Point(4, 12);
            this.BDSStatus_text.Name = "BDSStatus_text";
            this.BDSStatus_text.Size = new System.Drawing.Size(93, 20);
            this.BDSStatus_text.TabIndex = 4;
            this.BDSStatus_text.Text = "服务端状态：";
            // 
            // BDSStatus
            // 
            this.BDSStatus.AutoSize = true;
            this.BDSStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BDSStatus.ForeColor = System.Drawing.Color.Maroon;
            this.BDSStatus.Location = new System.Drawing.Point(120, 17);
            this.BDSStatus.Name = "BDSStatus";
            this.BDSStatus.Size = new System.Drawing.Size(21, 14);
            this.BDSStatus.TabIndex = 0;
            this.BDSStatus.Text = "🟨";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.NoSelecter);
            this.panel5.Controls.Add(this.AutoRestart);
            this.panel5.Controls.Add(this.STOPBDS);
            this.panel5.Controls.Add(this.sendCMD);
            this.panel5.Controls.Add(this.CMDInput);
            this.panel5.Location = new System.Drawing.Point(232, 339);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(556, 100);
            this.panel5.TabIndex = 0;
            // 
            // NoSelecter
            // 
            this.NoSelecter.AutoSize = true;
            this.NoSelecter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NoSelecter.Location = new System.Drawing.Point(190, 64);
            this.NoSelecter.Name = "NoSelecter";
            this.NoSelecter.Size = new System.Drawing.Size(168, 24);
            this.NoSelecter.TabIndex = 8;
            this.NoSelecter.Text = "忽略未找到目标的提示";
            this.NoSelecter.UseVisualStyleBackColor = true;
            // 
            // AutoRestart
            // 
            this.AutoRestart.AutoSize = true;
            this.AutoRestart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AutoRestart.Location = new System.Drawing.Point(28, 64);
            this.AutoRestart.Name = "AutoRestart";
            this.AutoRestart.Size = new System.Drawing.Size(84, 24);
            this.AutoRestart.TabIndex = 7;
            this.AutoRestart.Text = "自动重启";
            this.AutoRestart.UseVisualStyleBackColor = true;
            // 
            // STOPBDS
            // 
            this.STOPBDS.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.STOPBDS.Location = new System.Drawing.Point(453, 63);
            this.STOPBDS.Name = "STOPBDS";
            this.STOPBDS.Size = new System.Drawing.Size(75, 23);
            this.STOPBDS.TabIndex = 4;
            this.STOPBDS.Text = "强行停止";
            this.STOPBDS.UseVisualStyleBackColor = true;
            this.STOPBDS.Click += new System.EventHandler(this.STOPBDS_Click);
            // 
            // sendCMD
            // 
            this.sendCMD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendCMD.Location = new System.Drawing.Point(453, 19);
            this.sendCMD.Name = "sendCMD";
            this.sendCMD.Size = new System.Drawing.Size(75, 23);
            this.sendCMD.TabIndex = 3;
            this.sendCMD.Text = "发送";
            this.sendCMD.UseVisualStyleBackColor = true;
            this.sendCMD.Click += new System.EventHandler(this.sendCMD_Click);
            // 
            // CMDInput
            // 
            this.CMDInput.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CMDInput.Location = new System.Drawing.Point(28, 19);
            this.CMDInput.Name = "CMDInput";
            this.CMDInput.Size = new System.Drawing.Size(379, 26);
            this.CMDInput.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.WS_KEY);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.WS_Port_Name);
            this.panel3.Controls.Add(this.WS_Port);
            this.panel3.Location = new System.Drawing.Point(12, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 5;
            // 
            // WS_KEY
            // 
            this.WS_KEY.Location = new System.Drawing.Point(80, 63);
            this.WS_KEY.Name = "WS_KEY";
            this.WS_KEY.PasswordChar = '*';
            this.WS_KEY.Size = new System.Drawing.Size(100, 21);
            this.WS_KEY.TabIndex = 8;
            this.WS_KEY.TextChanged += new System.EventHandler(this.WS_KEY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "密匙";
            this.label3.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Websocket";
            // 
            // WS_Port_Name
            // 
            this.WS_Port_Name.AutoSize = true;
            this.WS_Port_Name.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WS_Port_Name.Location = new System.Drawing.Point(14, 26);
            this.WS_Port_Name.Name = "WS_Port_Name";
            this.WS_Port_Name.Size = new System.Drawing.Size(37, 20);
            this.WS_Port_Name.TabIndex = 7;
            this.WS_Port_Name.Text = "端口";
            // 
            // WS_Port
            // 
            this.WS_Port.Location = new System.Drawing.Point(80, 29);
            this.WS_Port.Name = "WS_Port";
            this.WS_Port.Size = new System.Drawing.Size(100, 21);
            this.WS_Port.TabIndex = 6;
            this.WS_Port.TextChanged += new System.EventHandler(this.WS_Port_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视图ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.视图ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.视图ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.视图ToolStripMenuItem.Text = "视图";
            this.视图ToolStripMenuItem.Click += new System.EventHandler(this.视图ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.配置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.配置ToolStripMenuItem.Text = "配置";
            this.配置ToolStripMenuItem.Click += new System.EventHandler(this.配置ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.关于ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // regex_new
            // 
            this.regex_new.Name = "regex_new";
            this.regex_new.Size = new System.Drawing.Size(180, 22);
            this.regex_new.Text = "新建";
            this.regex_new.Click += new System.EventHandler(this.regex_new_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KWO";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label BDSPath;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox BDSPath_text;
        private System.Windows.Forms.Button sendCMD;
        private System.Windows.Forms.TextBox CMDInput;
        private System.Windows.Forms.Button ChoseBDSPath;
        private System.Windows.Forms.Label BDSStatus;
        private System.Windows.Forms.Label BDSStatus_text;
        private System.Windows.Forms.Label WS_STATUS_Light;
        private System.Windows.Forms.Label WSStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartBDS;
        private System.Windows.Forms.Button STOPBDS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label WS_Port_Name;
        private System.Windows.Forms.TextBox WS_Port;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.TextBox WS_KEY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox regexs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem regex_edit;
        private System.Windows.Forms.ToolStripMenuItem regex_del;
        private System.Windows.Forms.CheckBox AutoRestart;
        private System.Windows.Forms.CheckBox NoSelecter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重载ToolStripMenuItem;
        private System.Windows.Forms.TextBox bdsconsole;
        private System.Windows.Forms.ToolStripMenuItem regex_new;
    }
}

