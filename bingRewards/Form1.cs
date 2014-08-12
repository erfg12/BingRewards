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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string username;
        private string password;
        private int countDown = 0;
        private int accountNum = 0;
        private bool mobile = false; //start with desktop
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        private string settingsFile = Application.StartupPath + Path.DirectorySeparatorChar + "settings.ini";
        private string wordsFile = Application.StartupPath + Path.DirectorySeparatorChar + "words.txt";
        private string accountsFile = Application.StartupPath + Path.DirectorySeparatorChar + "accounts.txt";
        MultiplatformIni iniSettings;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ReadSettings("settings", "startminimized")) >= 1)
                this.WindowState = FormWindowState.Minimized;
            searchTimer.Enabled = false;
            startTimer.Enabled = false;
            webBrowser1.ScriptErrorsSuppressed = true;
            fileCheck();
            if (fileExists(settingsFile) && Convert.ToInt32(ReadSettings("settings", "startspeed")) > 100)
                startTimer.Interval = Convert.ToInt32(ReadSettings("settings", "startspeed"));
            else
                startTimer.Interval = 100;
            if (fileExists(settingsFile) && Convert.ToInt32(ReadSettings("settings", "searchspeed")) > 100)
                searchTimer.Interval = Convert.ToInt32(ReadSettings("settings", "searchspeed"));
            else
                searchTimer.Interval = 100;
            if (fileExists(settingsFile) && Convert.ToInt32(ReadSettings("settings", "autostart")) >= 1)
                ReadAccounts(accountNum);
            if (fileExists(settingsFile) && Convert.ToInt32(ReadSettings("settings", "hidebrowser")) >= 1)
                webBrowser1.Visible = false;
            //MessageBox.Show("DEBUG: searchspeed=" + searchTimer.Interval.ToString() + " startspeed=" + startTimer.Interval.ToString());
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
            if (!fileExists(settingsFile))
                MessageBox.Show("File " + settingsFile + " is missing!");
            if (!fileExists(accountsFile))
                MessageBox.Show("File " + accountsFile + " is missing!");
            if (!fileExists(wordsFile))
                MessageBox.Show("File " + wordsFile + " is missing!");
        }

        public string ReadSettings(string section, string key)
        {
            iniSettings = new MultiplatformIni(settingsFile);
            return iniSettings.ReadString(section, key, "0");
        }

        private int randomNumber()
        {
            Random random = new Random();
            return random.Next(3, 6);
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
                //clearCookies();
                string content = File.ReadLines(accountsFile).ElementAt(line);
                string[] words = content.Split('/');
                startBtn.Enabled = false;
                username = words[0];
                password = words[1];
                webBrowser1.Navigate(new Uri("https://login.live.com/logout.srf"));
                return;
            }
            catch
            {
                startTimer.Enabled = false;
                startBtn.Enabled = true;
                webBrowser1.Navigate(new Uri("http://newagesoldier.com/myfiles/donations.html"));
                if (fileExists(settingsFile) && Convert.ToInt32(ReadSettings("settings", "autoclose")) >= 1)
                    closeTimer.Enabled = true;
                return;
            }
        }

        private void search(Boolean skip = false)
        {
            string query = GetRandomSentence(randomNumber());
            string searchURL = "http://bing.com/search?q=";

            if (webBrowser1.Url.ToString().Contains(@"newagesoldier.com"))
                return;

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
                    countDown = Convert.ToInt32(ReadSettings("settings", "mobilesearches"));
                }
            }

            if (ReadSettings("settings", "searchtype").Contains("image"))
                searchURL = "http://www.bing.com/images/search?q=";
            else if (ReadSettings("settings", "searchtype").Contains("video"))
                searchURL = "http://www.bing.com/videos/search?q=";
            else if (ReadSettings("settings", "searchtype").Contains("map"))
                searchURL = "http://www.bing.com/maps/default.aspx?q=";
            else if (ReadSettings("settings", "searchtype").Contains("news"))
                searchURL = "http://www.bing.com/news/search?q=";
            else if (ReadSettings("settings", "searchtype").Contains("explore") || ReadSettings("settings", "searchtype").Contains("more"))
                searchURL = "http://www.bing.com/explore?q=";

            if (mobile)
            {
                webBrowser1.Navigate(searchURL + query, null, null, "User-Agent: Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");
                if (countDown == 1) //We're on our last search. Reset to desktop.
                    mobile = false;
            } 
            else
                webBrowser1.Navigate(new Uri(searchURL + query));

            if (webBrowser1.Url.ToString().Contains(@"?q="))
                countDown = countDown - 1;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
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
            countDown = (Convert.ToInt32(ReadSettings("settings", "desktopsearches")));
            search(true);
            accountNum = accountNum + 1; //next account
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            if (!webBrowser1.Url.ToString().Contains(@"?q="))
                return;
            search();
            searchTimer.Enabled = false;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            ReadAccounts(accountNum);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.newagesoldier.com");
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // END OF MY CODE

    class MultiplatformIni
    {
        private String iniFilePath;
        public String IniPath
        {
            get { return iniFilePath; }
        }
        private static Char decSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToCharArray()[0];
        private static Regex keyValRegex = new Regex(
          @"((\s)*(?<Key>([^\=^\n]+))[\s^\n]*\=(\s)*(?<Value>([^\n]+(\n){0,1})))",
            RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled |
            RegexOptions.CultureInvariant
        );
        private static Regex secRegex = new Regex(
          @"(\[)*(?<Section>([^\]^\n]+))(\])",
          RegexOptions.Compiled | RegexOptions.CultureInvariant
        );

        private ArrayList newValues = new ArrayList();
        struct sectKeyVal
        {
            public String section, key, value;
            public sectKeyVal(String section, String key, String value)
            {
                this.section = section;
                this.key = key;
                this.value = value;
            }
        }

        public MultiplatformIni(String iniFilePath)
        {
            this.iniFilePath = iniFilePath;
        }
        ~MultiplatformIni()
        {
            Flush();
        }

        private bool isThisTheSection(String line, ref String sectionName)
        {
            Match match = secRegex.Match(line);
            if (match.Success)
            {
                String currSection = match.Groups["Section"].Value as String;
                return (currSection != null && currSection.CompareTo(sectionName) == 0);
            }
            return false;
        }
        private bool isThisTheKey(String line, ref String key, ref String value)
        {
            Match match = keyValRegex.Match(line);
            if (match.Success)
            {
                String currKey = match.Groups["Key"].Value as String;
                if (currKey != null && currKey.CompareTo(key) == 0)
                {
                    value = match.Groups["Value"].Value as String;
                    return true;
                }
            }
            else if (secRegex.Match(line).Success)
                value = "Section"; // Oops, we're at the next section
            return false;
        }

        public String ReadString(String section, String key, String defaultValue)
        {
            FileStream fileStream = new FileStream(iniFilePath, FileMode.OpenOrCreate, FileAccess.Read);
            TextReader reader = new StreamReader(fileStream);
            bool sectionFound = false;

            String line;
            while ((line = reader.ReadLine()) != null)
            {
                /* First we find our section,
                   then - the key */
                if (!sectionFound)
                    sectionFound = isThisTheSection(line, ref section);
                else
                {
                    String value = "";
                    if (isThisTheKey(line, ref key, ref value))
                    {
                        fileStream.Close();
                        return value;
                    }
                }
            }

            fileStream.Close();
            return defaultValue;
        }
        public int ReadInt(String section, String key, int defaultValue)
        {
            return Int32.Parse(ReadString(section, key, defaultValue.ToString()));
        }
        public Double ReadDouble(String section, String key, Double defaultValue)
        {
            return Double.Parse(
                ReadString(section, key, defaultValue.ToString()).Replace('.', decSep).Replace(',', decSep)
            );
        }
        public void WriteString(String section, String key, String value)
        {
            int sameKeyNum = -1;
            for (int i = 0; i < newValues.Count; i++)
            {
                sectKeyVal s = (sectKeyVal)newValues[i];
                if ((s.section == section) && (s.key == key))
                    sameKeyNum = i;
            }
            if (sameKeyNum != -1)
                newValues.RemoveAt(sameKeyNum);

            newValues.Add(new sectKeyVal(section, key, value));
        }
        public void Flush()
        {
            /* This is where all the magic is done
               We read our INI file, parse the
               new values and add them to the file
               before we write it */

            // First we read our file
            FileStream fileStream = new FileStream(iniFilePath, FileMode.OpenOrCreate, FileAccess.Read);
            TextReader reader = new StreamReader(fileStream);

            String[] lines = reader.ReadToEnd().Replace('\r', '\0').Split('\n');
            fileStream.Close();

            // Create our work list and fill it
            List<String> linesList = new List<String>();
            foreach (String s in lines)
                linesList.Add(s);

            foreach (sectKeyVal s in newValues)
            {
                String section = s.section;
                String key = s.key;
                String value = s.value;

                bool sectionFound = false, keyFound = false;
                String keyval = "";

                List<String> tempList = new List<String>();
                for (int i = 0; i < linesList.Count; i++)
                {
                    String line = linesList[i];

                    // Did we find our section yet?
                    if (!sectionFound)
                        sectionFound = isThisTheSection(linesList[i], ref section);
                    else
                    {
                        // Did we find our key?
                        if (isThisTheKey(linesList[i], ref key, ref keyval))
                        {
                            if (value != keyval)
                                line = key + "=" + value;
                            keyFound = true;
                        }
                        else if (keyval == "Section" && !keyFound)
                        {
                            /* We found the beginning of 
                               the next section. */
                            keyval = "";
                            keyFound = true;

                            if (linesList[i - 1].Trim() == "")
                                tempList[tempList.Count - 1] = key + "=" + value;
                            else
                                tempList.Add(key + "=" + value);
                            tempList.Add("");
                        }
                        else if (i == linesList.Count - 1 && !keyFound)
                        {   /* Looks like we're at the end of file
                               and we found our section */
                            tempList.Add(key + "=" + value);
                        }
                    }
                    tempList.Add(line.TrimEnd('\0'));
                }
                linesList = tempList;

                /* The section or the key weren't found
                   so we add them */
                if (!sectionFound && !keyFound)
                {
                    if (linesList.Count == 1 && linesList[linesList.Count - 1].Trim() == "")
                        linesList.RemoveAt(0);
                    else
                        linesList.Add("");

                    linesList.Add("[" + section + "]");
                    linesList.Add(key + "=" + value);
                }
            }

            // Finally write our file
            fileStream = new FileStream(iniFilePath, FileMode.Create, FileAccess.Write);
            TextWriter writer = new StreamWriter(fileStream);

            for (int i = 0; i < linesList.Count; i++)
                if (!((i == linesList.Count - 1) && (linesList[i].Trim() == "")))
                    writer.WriteLine(linesList[i]);

            writer.Flush();
            fileStream.Close();
        }
        public void WriteInt(String section, String key, int value)
        {
            WriteString(section, key, value.ToString());
        }
        public void WriteDouble(String section, String key, Double value)
        {
            WriteString(section, key, value.ToString());
        }
    }
}
