using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
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
                    RefreshIESettings(proxy + ":" + port);
                    webBrowser1.Navigate(new Uri("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1406628123&rver=6.0.5286.0&wp=MBI&wreply=https:%2F%2Fwww.bing.com%2Fsecure%2FPassport.aspx%3Frequrl%3Dhttp%253a%252f%252fwww.bing.com%252frewards%252fdashboard"/*https://www.google.com/search?q=what+is+my+ip&oq=what+is+my+ip"*/));
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
                if (words[2] != null)
                {
                    proxy = words[2];
                    proxyBox.Text = proxy;
                }
                else
                    proxy = ""; //reset our proxy
                if (words[3] != null)
                    port = words[3];
                else
                    port = ""; //reset our port
                return true;
            }
            catch
            {
                //MessageBox.Show("caught error");
                return false;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url != null)
                webAddressBox.Text = webBrowser1.Url.ToString();

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
            }

            if (webBrowser1.Url.ToString().Equals(@"http://www.msn.com/") || webBrowser1.Url.ToString().Contains(@"bing.com/rewards/dashboard")) //done logging in
                webBrowser1.Navigate(new Uri("http://www.bing.com/rewards/redeem/shop"));
        }
    }
}
