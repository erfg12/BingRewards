using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bingRewards
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.startspeedBox, "Start Speed In Milliseconds");
            tt.SetToolTip(this.searchspeedminBox, "Search Speed Minimum In Milliseconds");
            tt.SetToolTip(this.searchspeedmaxBox, "Search Speed Maximum In Milliseconds");
            tt.SetToolTip(this.autostartBox, "Automatically Start Searching On Program Open");
            tt.SetToolTip(this.hidebrowserBox, "Display Browser Window");
            tt.SetToolTip(this.mobilesearchesBox, "Mobile Searches Quantity");
            tt.SetToolTip(this.desktopsearchesBox, "Desktop Searches Quantity");
            tt.SetToolTip(this.autocloseBox, "Automatically Close Bing Bot Upon Completion");
            tt.SetToolTip(this.startminimizedBox, "Start Bing Bot Minimized");
            tt.SetToolTip(this.searchtypeBox, "Search Type");

            autostartBox.DropDownStyle = ComboBoxStyle.DropDownList;
            hidebrowserBox.DropDownStyle = ComboBoxStyle.DropDownList;
            autocloseBox.DropDownStyle = ComboBoxStyle.DropDownList;
            startminimizedBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchtypeBox.DropDownStyle = ComboBoxStyle.DropDownList;

            accountsBox.Text = System.IO.File.ReadAllText("accounts.txt");
            searchWordsBox.Text = System.IO.File.ReadAllText("words.txt");
            
            startspeedBox.Text = Properties.Settings.Default.startspeed.ToString();
            searchspeedminBox.Text = Properties.Settings.Default.searchspeedmin.ToString();
            searchspeedmaxBox.Text = Properties.Settings.Default.searchspeedmax.ToString();
            autostartBox.Text = Properties.Settings.Default.autostart.ToString();
            hidebrowserBox.Text = Properties.Settings.Default.hidebrowser.ToString();
            mobilesearchesBox.Text = Properties.Settings.Default.mobilesearches.ToString();
            desktopsearchesBox.Text = Properties.Settings.Default.desktopsearches.ToString();
            autocloseBox.Text = Properties.Settings.Default.autoclose.ToString();
            startminimizedBox.Text = Properties.Settings.Default.startminimized.ToString();
            searchtypeBox.Text = Properties.Settings.Default.searchtype;
        }

        private void defaultsBtn_Click(object sender, EventArgs e)
        {
            startspeedBox.Text = "6000";
            searchspeedminBox.Text = "1000";
            searchspeedmaxBox.Text = "3000";
            autostartBox.Text = "false";
            hidebrowserBox.Text = "false";
            mobilesearchesBox.Text = "20";
            desktopsearchesBox.Text = "30";
            autocloseBox.Text = "false";
            startminimizedBox.Text = "false";
            searchtypeBox.Text = "normal";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.startspeed = Convert.ToInt32(startspeedBox.Text);
            Properties.Settings.Default.searchspeedmin = Convert.ToInt32(searchspeedminBox.Text);
            Properties.Settings.Default.searchspeedmax = Convert.ToInt32(searchspeedmaxBox.Text);
            Properties.Settings.Default.autostart = Convert.ToBoolean(autostartBox.Text);
            Properties.Settings.Default.hidebrowser = Convert.ToBoolean(hidebrowserBox.Text);
            Properties.Settings.Default.mobilesearches = Convert.ToInt32(mobilesearchesBox.Text);
            Properties.Settings.Default.desktopsearches = Convert.ToInt32(desktopsearchesBox.Text);
            Properties.Settings.Default.autoclose = Convert.ToBoolean(autocloseBox.Text);
            Properties.Settings.Default.startminimized = Convert.ToBoolean(startminimizedBox.Text);
            Properties.Settings.Default.searchtype = searchtypeBox.Text;
            Properties.Settings.Default.Save();

            System.IO.File.WriteAllText("accounts.txt", accountsBox.Text);
            System.IO.File.WriteAllText("words.txt", searchWordsBox.Text);

            this.Close();
        }

        private void mobilesearchesBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
