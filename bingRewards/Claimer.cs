using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Web;

namespace bingRewards
{
    public partial class Claimer : Form
    {
        private string username;
        private string password;
        private int countDown = 0;
        private int accountNum = 0;
        MultiplatformIni iniSettings;

        string accountsFile = Application.StartupPath + Path.DirectorySeparatorChar + "accounts.txt";

        public Claimer()
        {
            InitializeComponent();
        }

        private void Claimer_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        public bool fileExists(string fileName)
        {
            if (!File.Exists(fileName))
                return false;
            else
                return true;
        }

        private void ReadAccounts(int line)
        {
            try
            {
                string content = "";
                using (StreamReader r = new StreamReader(accountsFile))
                {
                    string rLine;
                    int i = 0;
                    string[] uName;
                    listBox1.Items.Clear();
                    while ((rLine = r.ReadLine()) != null)
                    {
                        uName = rLine.Split('/');
                        listBox1.Items.Add(uName[0]);
                        if (i == line)
                            content = rLine;
                        i++;
                    }
                }
                string[] words = content.Split('/');
                startBtn.Enabled = false;
                username = words[0];
                password = words[1];

                webBrowser1.Navigate(new Uri("https://login.live.com/logout.srf"));
            }
            catch
            {
                startBtn.Enabled = true;
                webBrowser1.Navigate(new Uri("https://login.live.com/logout.srf")); //done, log out
            }
        }        

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            ReadAccounts(accountNum);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.newagesoldier.com");
        }
    }
}
