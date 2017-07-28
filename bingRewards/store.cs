using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace bingRewards
{
    public partial class store : Form
    {
        int _storeIndex;
        public store(int storeIndex)
        {
            InitializeComponent();
            this._storeIndex = storeIndex;
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
            WebBrowserHelper.ClearCache();

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

            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;
            Struct_INTERNET_PROXY_INFO s_IPI;
            s_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            s_IPI.proxy = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(strProxy);
            s_IPI.proxyBypass = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi("Global");

            IntPtr intptrStruct = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(s_IPI));
            InternetSetOption(IntPtr.Zero, 81, intptrStruct, 0); // clear cookies
            //InternetSetOption(IntPtr.Zero, 42, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(s_IPI)); // flush cache (crashes in win10)
            InternetSetOption(IntPtr.Zero, 1, intptrStruct, 0); // allow all cookies

            if (strProxy != ":") //if we have a proxy:port
            {
                System.Runtime.InteropServices.Marshal.StructureToPtr(s_IPI, intptrStruct, true);
                InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(s_IPI)); // set proxy
            }
            
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            dashboardBrowser.GoBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboardBrowser.GoForward();
        }

        string accountsFile = Application.StartupPath + Path.DirectorySeparatorChar + "accounts.txt";

        private string username;
        private string password;
        private string proxy;
        private string port;

        private void store_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(_storeIndex.ToString());

            if (getAccountDetails(_storeIndex))
            {
                if (username != "")
                {
                    //store url = http://www.bing.com/rewards/redeem/shop
                    //HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1406628123&rver=6.0.5286.0&wp=MBI&wreply=https:%2F%2Fwww.bing.com%2Fsecure%2FPassport.aspx%3Frequrl%3Dhttp%253a%252f%252fwww.bing.com%252frewards%252fdashboard");
                    //if (proxy != "" && port != "")
                    RefreshIESettings(proxy + ":" + port);
                    dashboardBrowser.Navigate(new Uri("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1406628123&rver=6.0.5286.0&wp=MBI&wreply=https:%2F%2Fwww.bing.com%2Fsecure%2FPassport.aspx%3Frequrl%3Dhttp%253a%252f%252fwww.bing.com%252frewards%252fdashboard"/*https://www.google.com/search?q=what+is+my+ip&oq=what+is+my+ip"*/), null, null, "User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                }
                else
                    MessageBox.Show("ERROR: Couldn't locate account in accounts.txt file.");
            }
        }

        private bool getAccountDetails(int line)
        {
            try
            {
                string content = "";
                using (StreamReader r = new StreamReader(accountsFile))
                {
                    string rLine;
                    int i = 0;
                    string[] uName;
                    while ((rLine = r.ReadLine()) != null)
                    {
                        uName = rLine.Split('/');
                        if (i == line)
                            content = rLine;
                        i++;
                    }
                }
                string[] words = content.Split('/');
                username = words[0];
                curAccount.Text = username;
                password = words[1];

                int c = words.Length;
                if (c > 2)
                {
                    proxy = words[2];
                    proxyBox.Text = proxy;
                    port = words[3];
                }
                else
                {
                    proxy = ""; //reset our proxy
                    port = ""; //reset our port
                }
                return true;
            }
            catch
            {
                MessageBox.Show("caught error");
                return false;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (dashboardBrowser.Url != null)
                webAddressBox.Text = dashboardBrowser.Url.ToString();

            if (dashboardBrowser.Url.ToString().Contains(@"login.live.com/login"))
            {
                foreach (HtmlElement HtmlElement1 in dashboardBrowser.Document.Body.All) //Force post (login).
                {
                    if (HtmlElement1.GetAttribute("name") == "loginfmt")
                        HtmlElement1.SetAttribute("value", username);
                    if (HtmlElement1.GetAttribute("name") == "passwd")
                        HtmlElement1.SetAttribute("value", password);
                    if (HtmlElement1.GetAttribute("value") == "Sign in")
                        HtmlElement1.InvokeMember("click");
                }
            }

            //if (dashboardBrowser.Url.ToString().Equals(@"http://www.msn.com/") || dashboardBrowser.Url.ToString().Contains(@"bing.com/rewards/dashboard")) //done logging in
            //    dashboardBrowser.Navigate(new Uri("http://www.bing.com/rewards/redeem/shop"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!webAddressBox.Text.Contains("http"))
                webAddressBox.Text = "http://" + webAddressBox.Text;
            dashboardBrowser.Navigate(new Uri(webAddressBox.Text));
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            dashboardBrowser.Navigate(dashboardBrowser.StatusText);
            e.Cancel = true;
        }

        private void store_Closing(object sender, FormClosingEventArgs e)
        {
            dashboardBrowser.Navigate(new Uri("https://login.live.com/logout.srf"));
            while (dashboardBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }
    }
}
