namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.label4 = new System.Windows.Forms.Label();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(2, 96);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(844, 458);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mode";
            // 
            // searchesLeftBox
            // 
            this.searchesLeftBox.Enabled = false;
            this.searchesLeftBox.Location = new System.Drawing.Point(55, 33);
            this.searchesLeftBox.Name = "searchesLeftBox";
            this.searchesLeftBox.Size = new System.Drawing.Size(152, 20);
            this.searchesLeftBox.TabIndex = 3;
            // 
            // searchModeBox
            // 
            this.searchModeBox.Enabled = false;
            this.searchModeBox.Location = new System.Drawing.Point(55, 56);
            this.searchModeBox.Name = "searchModeBox";
            this.searchModeBox.Size = new System.Drawing.Size(152, 20);
            this.searchModeBox.TabIndex = 4;
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(5, 13);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(47, 13);
            this.accountLabel.TabIndex = 5;
            this.accountLabel.Text = "Account";
            // 
            // accountBox
            // 
            this.accountBox.Enabled = false;
            this.accountBox.Location = new System.Drawing.Point(55, 10);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(152, 20);
            this.accountBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 13);
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
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.startBtn.Location = new System.Drawing.Point(767, 57);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 11;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(742, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "NewAgeSoldier.com";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // notesBox
            // 
            this.notesBox.Enabled = false;
            this.notesBox.Location = new System.Drawing.Point(301, 9);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(541, 21);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 556);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.notesBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.searchModeBox);
            this.Controls.Add(this.searchesLeftBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bing Rewards Search Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Timer closeTimer;
    }
}

