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
using System.Net;

namespace bingRewards
{
    public partial class Miner : Form
    {
        private string username;
        private string password;
        private string proxy;
        private string port;
        private int countDown = Properties.Settings.Default.desktopsearches;
        private int accountNum = 0;
        private bool mobile = false; //start with desktop
        string wordsFile = Application.StartupPath + Path.DirectorySeparatorChar + "words.txt";
        string accountsFile = Application.StartupPath + Path.DirectorySeparatorChar + "accounts.txt";
        public int selectedAcc = 0;

        public Miner()
        {
            InitializeComponent();
        }

        [DllImport("wininet.dll")]
        static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        }

        void RefreshIESettings(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;
            Struct_INTERNET_PROXY_INFO s_IPI;
            s_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            s_IPI.proxy = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(strProxy);
            s_IPI.proxyBypass = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi("Global");
            IntPtr intptrStruct = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(s_IPI));
            System.Runtime.InteropServices.Marshal.StructureToPtr(s_IPI, intptrStruct, true);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(s_IPI));
        }

        private void Miner_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Properties.Settings.Default.startminimized) >= 1)
                this.WindowState = FormWindowState.Minimized;

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

            if (Convert.ToInt32(Properties.Settings.Default.hidebrowser) >= 1)
                webBrowser1.Visible = false;

            speedmin.Text = Properties.Settings.Default.searchspeedmin.ToString();
            speedmax.Text = Properties.Settings.Default.searchspeedmax.ToString();

            ListAccounts();
            
            if (Convert.ToInt32(Properties.Settings.Default.autostart) >= 1)
                startTimer.Enabled = true;
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
                mobile = false;
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
                if (words[2] != null)
                    proxy = words[2];
                else
                    proxy = ""; //reset our proxy
                if (words[3] != null)
                    port = words[3];
                else
                    port = ""; //reset our port
                if (words[2] != null && words[3] != null)
                    RefreshIESettings(proxy + ":" + port); //set our proxy before doing anything else
            }
            catch
            {
                //MessageBox.Show("caught error");
                startTimer.Enabled = false;
                startBtn.Enabled = true;
                if (Convert.ToInt32(Properties.Settings.Default.autoclose) >= 1)
                    Application.Exit();
            }
        }

        private void search()
        {
            stopBtn.Enabled = true;
            string query = GetRandomSentence(randomNumber(3,6));
            string searchURL = "http://bing.com/search?q=";

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
                webBrowser1.Navigate(searchURL + query, null, null, "User-Agent: Mozilla/5.0 (iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3");
            else
                webBrowser1.Navigate(searchURL + query, null, null, "User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");

            if (webBrowser1.Url.ToString().Contains(@"?q="))
                countDown = countDown - 1;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (webBrowser1.Url == null)
                notesBox.Text = "(BLANK)";
            else
                notesBox.Text = webBrowser1.Url.ToString();
            stuckTimer.Enabled = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            stuckTimer.Enabled = false;
            if (webBrowser1.Url.ToString().Contains(@"login.live.com/login"))
            {
                foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All) //Force post (login).
                {
                    if (HtmlElement1.GetAttribute("name") == "loginfmt")
                        HtmlElement1.SetAttribute("value", username);
                    if (HtmlElement1.GetAttribute("name") == "passwd")
                        HtmlElement1.SetAttribute("value", password);
                    if (HtmlElement1.GetAttribute("value") == "Sign in")
                        HtmlElement1.InvokeMember("click");
                }
                return;
            }

            if (webBrowser1.Url.ToString() == "" || webBrowser1.Url == null || webBrowser1.Url.ToString().Contains(@"about:blank") || webBrowser1.Url.ToString().Contains(@"newagesoldier")) //could be refreshing page, or script behined the scenes
                return;

            if (webBrowser1.Url.ToString().Equals(@"http://www.msn.com/"))
            {
                dashboardWait.Enabled = true;
                webBrowser1.Navigate(new Uri("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1406628123&rver=6.0.5286.0&wp=MBI&wreply=https:%2F%2Fwww.bing.com%2Fsecure%2FPassport.aspx%3Frequrl%3Dhttp%253a%252f%252fwww.bing.com%252frewards%252fdashboard"));
                return;
            }

            if (webBrowser1.Url.ToString().Contains(@"bing.com/Passport") || webBrowser1.Url.ToString().Contains(@"live.com") || webBrowser1.Url.ToString().Contains(@"bing.com/secure"))
                return; //after logout, we are redirected. Please wait.

            if (mobile)
                searchModeBox.Text = "mobile";
            else
                searchModeBox.Text = "desktop";

            if (webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard"))
            {
                dashboardWait.Enabled = true;
                return;
            }

            searchesLeftBox.Text = countDown.ToString();
            accountBox.Text = username;

            //if (!webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard"))
            //    return;

            if (countDown == 0)
            {
                if (mobile) //just finished with mobile, back to desktop
                    startTimer.Enabled = true;
                else
                { //switch to mobile
                    mobile = true;
                    countDown = Properties.Settings.Default.mobilesearches;
                    searchTimer.Enabled = true;
                }
            }
            else
                searchTimer.Enabled = true;

            if (!webBrowser1.Url.ToString().Contains(@"?q="))
               return;
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            ReadAccounts(accountNum); //load in the accounts data first, then browse to cookie destroyer. This will trigger the start.
            //webBrowser1.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");

            try
            {
                string[] theCookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
                foreach (string currentFile in theCookies)
                {
                    System.IO.File.Delete(currentFile);
                }
            }
            catch
            {
                MessageBox.Show("error deleting cookies");
            }

            try
            {
                webBrowser1.Document.Window.Navigate(new Uri("https://login.live.com/logout.srf"));
                countDown = Properties.Settings.Default.desktopsearches;
            } catch
            {
                MessageBox.Show("error logging out");
            }

            try {
                accountNum = accountNum + 1; //next account
                startTimer.Enabled = false;
            } catch
            {
                MessageBox.Show("unknown error");
            }
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Interval = randomNumber(Properties.Settings.Default.searchspeedmin, Properties.Settings.Default.searchspeedmax);
            search();
            searchTimer.Enabled = false;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            startBtn.Enabled = false;
            if (countDown > 0 && !webBrowser1.Url.ToString().Contains(@"newagesoldier.com") && !webBrowser1.Url.ToString().Contains(@"about:blank"))
                searchTimer.Enabled = true;
            else
                startTimer.Enabled = true;
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
            System.Diagnostics.Process.Start("https://newagesoldier.com/forum");
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

        private void dashboardWait_Tick(object sender, EventArgs e)
        {
            searchTimer.Enabled = true;
            dashboardWait.Enabled = false;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void accounts_click(object sender, MouseEventArgs e)
        {
            
        }

        private void accounts_mousedown(object sender, MouseEventArgs e)
        {
            if (startBtn.Enabled == false)
                return; //currently running bot, dont allow right click

            if (e.Button == MouseButtons.Right)
            {
                listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                if (listBox1.SelectedIndex != -1)
                    contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void browseBingStoreWithAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            store storeForm = new store(selectedAcc);
            storeForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                selectedAcc = listBox1.SelectedIndex;
            //MessageBox.Show(listBox1.SelectedIndex.ToString() + "/" + selectedAcc.ToString());
        }
    }
}
