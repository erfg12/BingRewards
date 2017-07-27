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
            this.searchesLeftBox = new System.Windows.Forms.TextBox();
            this.accountLabel = new System.Windows.Forms.Label();
            this.accountBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.startBtn = new System.Windows.Forms.Button();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.stuckTimer = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.speedmin = new System.Windows.Forms.TextBox();
            this.speedmax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.dashboardWait = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseBingStoreWithAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(6, 19);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(852, 576);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Left";
            // 
            // searchesLeftBox
            // 
            this.searchesLeftBox.Enabled = false;
            this.searchesLeftBox.Location = new System.Drawing.Point(323, 8);
            this.searchesLeftBox.Name = "searchesLeftBox";
            this.searchesLeftBox.Size = new System.Drawing.Size(47, 20);
            this.searchesLeftBox.TabIndex = 3;
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(8, 11);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(47, 13);
            this.accountLabel.TabIndex = 5;
            this.accountLabel.Text = "Account";
            // 
            // accountBox
            // 
            this.accountBox.Enabled = false;
            this.accountBox.Location = new System.Drawing.Point(58, 8);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(226, 20);
            this.accountBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Address";
            // 
            // startTimer
            // 
            this.startTimer.Interval = 9000;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // searchTimer
            // 
            this.searchTimer.Interval = 9000;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Beige;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.startBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startBtn.Location = new System.Drawing.Point(864, 8);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(60, 19);
            this.startBtn.TabIndex = 11;
            this.startBtn.Text = "START";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // notesBox
            // 
            this.notesBox.Enabled = false;
            this.notesBox.Location = new System.Drawing.Point(577, 7);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(280, 21);
            this.notesBox.TabIndex = 10;
            this.notesBox.Text = "(BLANK)";
            // 
            // stuckTimer
            // 
            this.stuckTimer.Interval = 60000;
            this.stuckTimer.Tick += new System.EventHandler(this.stuckTimer_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 576);
            this.listBox1.TabIndex = 13;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.accounts_click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.accounts_mousedown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 602);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(166, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 602);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Browser";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Speeds";
            // 
            // speedmin
            // 
            this.speedmin.Enabled = false;
            this.speedmin.Location = new System.Drawing.Point(416, 8);
            this.speedmin.Name = "speedmin";
            this.speedmin.Size = new System.Drawing.Size(54, 20);
            this.speedmin.TabIndex = 19;
            // 
            // speedmax
            // 
            this.speedmax.Enabled = false;
            this.speedmax.Location = new System.Drawing.Point(480, 8);
            this.speedmax.Name = "speedmax";
            this.speedmax.Size = new System.Drawing.Size(50, 20);
            this.speedmax.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "-";
            // 
            // stopBtn
            // 
            this.stopBtn.BackColor = System.Drawing.Color.MistyRose;
            this.stopBtn.Enabled = false;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopBtn.ForeColor = System.Drawing.Color.Red;
            this.stopBtn.Location = new System.Drawing.Point(930, 8);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(60, 19);
            this.stopBtn.TabIndex = 22;
            this.stopBtn.Text = "STOP";
            this.stopBtn.UseVisualStyleBackColor = false;
            this.stopBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // dashboardWait
            // 
            this.dashboardWait.Interval = 50000;
            this.dashboardWait.Tick += new System.EventHandler(this.dashboardWait_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseBingStoreWithAccountToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 26);
            // 
            // browseBingStoreWithAccountToolStripMenuItem
            // 
            this.browseBingStoreWithAccountToolStripMenuItem.Name = "browseBingStoreWithAccountToolStripMenuItem";
            this.browseBingStoreWithAccountToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.browseBingStoreWithAccountToolStripMenuItem.Text = "Go To Dashboard With Account";
            this.browseBingStoreWithAccountToolStripMenuItem.Click += new System.EventHandler(this.browseBingStoreWithAccountToolStripMenuItem_Click);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.LightSteelBlue;
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings.ForeColor = System.Drawing.Color.Black;
            this.settings.Location = new System.Drawing.Point(996, 8);
            this.settings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(35, 19);
            this.settings.TabIndex = 23;
            this.settings.Text = "Edit";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 638);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.speedmax);
            this.Controls.Add(this.speedmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.notesBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.searchesLeftBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Miner";
            this.Text = "Bing Rewards Search Bot";
            this.Load += new System.EventHandler(this.Miner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchesLeftBox;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.TextBox accountBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Timer stuckTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox speedmin;
        private System.Windows.Forms.TextBox speedmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Timer dashboardWait;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem browseBingStoreWithAccountToolStripMenuItem;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button settings;
    }
}

