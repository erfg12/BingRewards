namespace bingRewards
{
    partial class store
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
            this.dashboardBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.proxyBox = new System.Windows.Forms.TextBox();
            this.curAccount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.webAddressBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dashboardBrowser
            // 
            this.dashboardBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dashboardBrowser.Location = new System.Drawing.Point(0, 27);
            this.dashboardBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.dashboardBrowser.Name = "dashboardBrowser";
            this.dashboardBrowser.ScriptErrorsSuppressed = true;
            this.dashboardBrowser.Size = new System.Drawing.Size(854, 579);
            this.dashboardBrowser.TabIndex = 0;
            this.dashboardBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.proxyBox);
            this.panel1.Controls.Add(this.curAccount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.webAddressBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 26);
            this.panel1.TabIndex = 1;
            // 
            // proxyBox
            // 
            this.proxyBox.Enabled = false;
            this.proxyBox.Location = new System.Drawing.Point(240, 0);
            this.proxyBox.Name = "proxyBox";
            this.proxyBox.Size = new System.Drawing.Size(117, 20);
            this.proxyBox.TabIndex = 4;
            // 
            // curAccount
            // 
            this.curAccount.Enabled = false;
            this.curAccount.Location = new System.Drawing.Point(63, 0);
            this.curAccount.Name = "curAccount";
            this.curAccount.Size = new System.Drawing.Size(171, 20);
            this.curAccount.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(32, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backBtn
            // 
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(4, 1);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(26, 23);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "<";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // webAddressBox
            // 
            this.webAddressBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.webAddressBox.Enabled = false;
            this.webAddressBox.Location = new System.Drawing.Point(363, 0);
            this.webAddressBox.Name = "webAddressBox";
            this.webAddressBox.Size = new System.Drawing.Size(450, 20);
            this.webAddressBox.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(819, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "GO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dashboardBrowser);
            this.Name = "store";
            this.ShowIcon = false;
            this.Text = "WEB BROWSER";
            this.Load += new System.EventHandler(this.store_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser dashboardBrowser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.TextBox webAddressBox;
        private System.Windows.Forms.TextBox proxyBox;
        private System.Windows.Forms.TextBox curAccount;
        private System.Windows.Forms.Button button2;
    }
}