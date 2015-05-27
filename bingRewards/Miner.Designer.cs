namespace bingRewards
{
    partial class Miner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Miner));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchesLeftBox = new System.Windows.Forms.TextBox();
            this.searchModeBox = new System.Windows.Forms.TextBox();
            this.accountLabel = new System.Windows.Forms.Label();
            this.accountBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.startBtn = new System.Windows.Forms.Button();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.stuckTimer = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.speedmin = new System.Windows.Forms.TextBox();
            this.speedmax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(6, 19);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(962, 706);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mode";
            // 
            // searchesLeftBox
            // 
            this.searchesLeftBox.Enabled = false;
            this.searchesLeftBox.Location = new System.Drawing.Point(389, 33);
            this.searchesLeftBox.Name = "searchesLeftBox";
            this.searchesLeftBox.Size = new System.Drawing.Size(47, 20);
            this.searchesLeftBox.TabIndex = 3;
            // 
            // searchModeBox
            // 
            this.searchModeBox.Enabled = false;
            this.searchModeBox.Location = new System.Drawing.Point(254, 33);
            this.searchModeBox.Name = "searchModeBox";
            this.searchModeBox.Size = new System.Drawing.Size(88, 20);
            this.searchModeBox.TabIndex = 4;
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(8, 36);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(47, 13);
            this.accountLabel.TabIndex = 5;
            this.accountLabel.Text = "Account";
            // 
            // accountBox
            // 
            this.accountBox.Enabled = false;
            this.accountBox.Location = new System.Drawing.Point(58, 33);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(149, 20);
            this.accountBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(665, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Address";
            // 
            // startTimer
            // 
            this.startTimer.Interval = 50000;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // searchTimer
            // 
            this.searchTimer.Interval = 50000;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.startBtn.Location = new System.Drawing.Point(1118, 31);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 11;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // notesBox
            // 
            this.notesBox.Enabled = false;
            this.notesBox.Location = new System.Drawing.Point(712, 32);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(398, 21);
            this.notesBox.TabIndex = 10;
            this.notesBox.Text = "If you see windows login page, do not fill it in or login. The system will login " +
    "itself. The search results will come up with 0 results most of the time. Ignore " +
    "this, this still counts as a search.";
            // 
            // closeTimer
            // 
            this.closeTimer.Interval = 30000;
            this.closeTimer.Tick += new System.EventHandler(this.closeTimer_Tick);
            // 
            // stuckTimer
            // 
            this.stuckTimer.Interval = 60000;
            this.stuckTimer.Tick += new System.EventHandler(this.stuckTimer_Tick);
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 706);
            this.listBox1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 731);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(219, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(974, 731);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Browser";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser2);
            this.panel1.Location = new System.Drawing.Point(1200, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 760);
            this.panel1.TabIndex = 16;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(0, 0);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(260, 760);
            this.webBrowser2.TabIndex = 0;
            this.webBrowser2.Url = new System.Uri("https://newagesoldier.com/bing-rewards-program-thanks/", System.UriKind.Absolute);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1472, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Speeds";
            // 
            // speedmin
            // 
            this.speedmin.Enabled = false;
            this.speedmin.Location = new System.Drawing.Point(490, 33);
            this.speedmin.Name = "speedmin";
            this.speedmin.Size = new System.Drawing.Size(54, 20);
            this.speedmin.TabIndex = 19;
            // 
            // speedmax
            // 
            this.speedmax.Enabled = false;
            this.speedmax.Location = new System.Drawing.Point(554, 33);
            this.speedmax.Name = "speedmax";
            this.speedmax.Size = new System.Drawing.Size(50, 20);
            this.speedmax.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(544, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "-";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readmeToolStripMenuItem,
            this.forumsToolStripMenuItem,
            this.softwareInformationToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripDropDownButton1.Text = "Support";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // readmeToolStripMenuItem
            // 
            this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
            this.readmeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.readmeToolStripMenuItem.Text = "Readme";
            this.readmeToolStripMenuItem.Click += new System.EventHandler(this.readmeToolStripMenuItem_Click);
            // 
            // forumsToolStripMenuItem
            // 
            this.forumsToolStripMenuItem.Name = "forumsToolStripMenuItem";
            this.forumsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.forumsToolStripMenuItem.Text = "Support Forums";
            this.forumsToolStripMenuItem.Click += new System.EventHandler(this.forumsToolStripMenuItem_Click);
            // 
            // softwareInformationToolStripMenuItem
            // 
            this.softwareInformationToolStripMenuItem.Name = "softwareInformationToolStripMenuItem";
            this.softwareInformationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.softwareInformationToolStripMenuItem.Text = "Software Information";
            this.softwareInformationToolStripMenuItem.Click += new System.EventHandler(this.softwareInformationToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(38, 20);
            this.toolStripDropDownButton2.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 798);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.speedmax);
            this.Controls.Add(this.speedmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.notesBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.searchModeBox);
            this.Controls.Add(this.searchesLeftBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Miner";
            this.Text = "Bing Rewards Search Bot";
            this.Load += new System.EventHandler(this.Miner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchesLeftBox;
        private System.Windows.Forms.TextBox searchModeBox;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.TextBox accountBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Timer closeTimer;
        private System.Windows.Forms.Timer stuckTimer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox speedmin;
        private System.Windows.Forms.TextBox speedmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem readmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

