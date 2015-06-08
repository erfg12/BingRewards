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
    public partial class Miner : Form
    {
        private string username;
        private string password;
        private int countDown = Properties.Settings.Default.desktopsearches;
        private int accountNum = 0;
        private bool mobile = false; //start with desktop
        string wordsFile = Application.StartupPath + Path.DirectorySeparatorChar + "words.txt";
        string accountsFile = Application.StartupPath + Path.DirectorySeparatorChar + "accounts.txt";

        public Miner()
        {
            InitializeComponent();
        }

        private void Miner_Load(object sender, EventArgs e)
        {
            webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebDocumentCompleted2);
            if (Convert.ToInt32(Properties.Settings.Default.startminimized) >= 1)
                this.WindowState = FormWindowState.Minimized;
            searchTimer.Enabled = false;
            startTimer.Enabled = false;
            webBrowser1.ScriptErrorsSuppressed = true;
            fileCheck();

            if (Properties.Settings.Default.startspeed > 60000) //anything faster than this is too slow
                stuckTimer.Interval = Properties.Settings.Default.startspeed + 1000;

            if (Properties.Settings.Default.startspeed > 100) //anything lower than this is too fast
                startTimer.Interval = Properties.Settings.Default.startspeed;
            else
                startTimer.Interval = 100;

            if (Properties.Settings.Default.searchspeedmin > 100 && Properties.Settings.Default.searchspeedmax > 100)
                searchTimer.Interval = randomNumber(Properties.Settings.Default.searchspeedmin, Properties.Settings.Default.searchspeedmax);
            else
                searchTimer.Interval = 100;

            if (Convert.ToInt32(Properties.Settings.Default.autostart) >= 1)
                ReadAccounts(accountNum);

            if (Convert.ToInt32(Properties.Settings.Default.hidebrowser) >= 1)
                webBrowser1.Visible = false;

            speedmin.Text = Properties.Settings.Default.searchspeedmin.ToString();
            speedmax.Text = Properties.Settings.Default.searchspeedmax.ToString();

            ListAccounts();

            //MessageBox.Show("DEBUG: searchspeed=" + searchTimer.Interval.ToString() + " startspeed=" + startTimer.Interval.ToString());
        }

        private void ListAccounts()
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
                        content = rLine;
                        i++;
                    }
                }
            }
            catch
            {
            }
        }

        public int getXoffset(HtmlElement el)
        {
            int xPos = el.OffsetRectangle.Left;
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                xPos += tempEl.OffsetRectangle.Left;
                tempEl = tempEl.OffsetParent;
            }
            return xPos;
        }

        public int getYoffset(HtmlElement el)
        {
            int yPos = el.OffsetRectangle.Top;
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                yPos += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }
            return yPos;
        }

        public bool fileExists(string fileName)
        {
            if (!File.Exists(fileName))
                return false;
            else
                return true;
        }

        public void fileCheck()
        {
            if (!fileExists(accountsFile))
                MessageBox.Show("File " + accountsFile + " is missing!");
            if (!fileExists(wordsFile))
                MessageBox.Show("File " + wordsFile + " is missing!");
        }

        private int randomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string GetRandomSentence(int wordCount)
        {
            Random rnd = new Random();
            string[] words = System.IO.File.ReadAllLines(wordsFile);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < wordCount; i++)
            {
                // Select a random word from the array
                builder.Append(words[rnd.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim();

            // Set the first letter of the first word in the sentenece to uppercase
            if (wordCount >= 4)
                sentence = char.ToUpper(sentence[0]) + sentence.Substring(1) + ".";

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
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
                startTimer.Enabled = false;
                startBtn.Enabled = true;
                webBrowser1.Navigate(new Uri("https://login.live.com/logout.srf")); //done, log out
                if (Convert.ToInt32(Properties.Settings.Default.autoclose) >= 1)
                    closeTimer.Enabled = true;
            }
        }

        private void search(Boolean skip = false)
        {
            stopBtn.Enabled = true;
            string query = GetRandomSentence(randomNumber(3,6));
            string searchURL = "http://bing.com/search?q=";

            if (webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard"))
            {
                if (!skip)
                {
                    startTimer.Enabled = true;
                    return;
                }
            }

            if (!mobile)
            {
                if (countDown == 1) //Change to mobile when done with desktop searching.
                {
                    mobile = true;
                    countDown = Properties.Settings.Default.mobilesearches;
                }
            }

            if (Properties.Settings.Default.searchtype.Contains("image"))
                searchURL = "http://www.bing.com/images/search?q=";
            else if (Properties.Settings.Default.searchtype.Contains("video"))
                searchURL = "http://www.bing.com/videos/search?q=";
            else if (Properties.Settings.Default.searchtype.Contains("map"))
                searchURL = "http://www.bing.com/maps/default.aspx?q=";
            else if (Properties.Settings.Default.searchtype.Contains("news"))
                searchURL = "http://www.bing.com/news/search?q=";
            else if (Properties.Settings.Default.searchtype.Contains("explore") || Properties.Settings.Default.searchtype.Contains("more"))
                searchURL = "http://www.bing.com/explore?q=";

            if (mobile)
            {
                webBrowser1.Navigate(searchURL + query, null, null, "User-Agent: Mozilla/5.0 (iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3");
                if (countDown == 1) //We're on our last search. Reset to desktop.
                    mobile = false;
            }
            else
                webBrowser1.Navigate(searchURL + query, null, null, "");

            if (webBrowser1.Url.ToString().Contains(@"?q="))
                countDown = countDown - 1;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            stuckTimer.Enabled = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            stuckTimer.Enabled = false;
            if (webBrowser1.Url.ToString() == "about:blank" || webBrowser1.Url.ToString() == "" || webBrowser1.Url == null || webBrowser1.Url.ToString().Contains(@"newagesoldier.com"))
                return;

            if (webBrowser1.Url.ToString().Contains(@"msn.com"))
                webBrowser1.Navigate(new Uri("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1406628123&rver=6.0.5286.0&wp=MBI&wreply=https:%2F%2Fwww.bing.com%2Fsecure%2FPassport.aspx%3Frequrl%3Dhttp%253a%252f%252fwww.bing.com%252frewards%252fdashboard"));

            if (mobile)
                searchModeBox.Text = "mobile";
            else
                searchModeBox.Text = "desktop";

            searchesLeftBox.Text = countDown.ToString();
            accountBox.Text = username;

            notesBox.Text = webBrowser1.Url.ToString();
            if (webBrowser1.Url.ToString().Contains(@"login.live.com/login"))
            {
                foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All) //Force post (login).
                {
                    if (HtmlElement1.GetAttribute("name") == "login")
                        HtmlElement1.SetAttribute("value", username);
                    if (HtmlElement1.GetAttribute("name") == "passwd")
                        HtmlElement1.SetAttribute("value", password);
                    if (HtmlElement1.GetAttribute("value") == "Sign in")
                        HtmlElement1.InvokeMember("click");
                }
                return;
            }

            if (webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard"))
                startTimer.Enabled = true;

            if (webBrowser1.Url.ToString().Contains(@"bing.com/Passport") || webBrowser1.Url.ToString().Contains(@"login.live.com/gls") || webBrowser1.Url.ToString().Contains(@"login.live.com/logout") || webBrowser1.Url.ToString().Contains(@"bing.com/secure") || webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard") || webBrowser1.Url.ToString().Contains(@"msn.com"))
                return; //let timer finish the login process before reading another account OR going to the next search.

            if (!webBrowser1.Url.ToString().Contains(@"?q="))
                return;

            if (countDown >= 1)
                searchTimer.Enabled = true;
            else
                ReadAccounts(accountNum);
        }

        private void startTimer_Tick(object sender, EventArgs e)
        { //this is just so we can debug and watch to make sure we are really logged in.
            if (!webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard"))
                return;
            if (countDown == 0 && !mobile)
                countDown = Properties.Settings.Default.desktopsearches;
            search(true);
            accountNum = accountNum + 1; //next account
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            if (!webBrowser1.Url.ToString().Contains(@"?q="))
                return;
            search();
            searchTimer.Enabled = false;
            searchTimer.Interval = randomNumber(Properties.Settings.Default.searchspeedmin, Properties.Settings.Default.searchspeedmax);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            startBtn.Enabled = false;
            if (countDown > 0)
                searchTimer.Enabled = true;
            else
                ReadAccounts(accountNum);
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stuckTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Enabled = true;
        }

        void WebDocumentCompleted2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser2.Document.Window.ScrollTo(0, 9999);
        }

        private void readmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("readme.txt");
        }

        private void forumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://newagesoldier.com/forum/viewforum.php?f=4");
        }

        private void softwareInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://newagesoldier.com/bing-rewards-bot/");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings settingsForm = new settings();
            settingsForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchTimer.Enabled = false;
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
        }

        private void aboutThisSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.Show();
        }
    }
}
