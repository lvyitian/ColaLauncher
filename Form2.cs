using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher
{
    public partial class Form2 : Form
    {
        public static Form2 instance = null;
        private volatile JObject obj=null;
        public Form2()
        {
            instance = this;
            InitializeComponent();
        }

        private void GetVersion_Click(object sender, EventArgs e)
        {
            obj = null;
            try
            {
                if (!bunifuiOSSwitch1.Value)
                    obj = launcher.Version.getVersionListOfficial();
                else
                    obj = launcher.Version.getVersionListBang();
            }
            catch (Exception e2) { MessageBox.Show("获取版本列表失败! \n"+e2.ToString()); return; }
            listBox1.Items.Clear();
            foreach(JObject i in obj["versions"])
            {
                listBox1.Items.Add((String)i["id"]);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.instance.vmw = null;
            this.Dispose();
            return;
        }

        private String getVersionJsonURL(String ver)
        {
            foreach (JObject i in obj["versions"])
            {
                try
                {
                    if ((String)i["id"] == ver)
                        return (String)i["url"];
                }
                catch (Exception) { }
            }
            return null;
        }

        private void install_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                this.Enabled = false;
                if(!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\" + listBox1.SelectedItem + "\\" + listBox1.SelectedItem + ".json"))
                  launcher.Version.AddToDownloadList(bunifuiOSSwitch1.Value?("https://bmclapi2.bangbang93.com/version/" +listBox1.SelectedItem+"/json"):getVersionJsonURL((String)listBox1.SelectedItem), ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\" + listBox1.SelectedItem + "\\" + listBox1.SelectedItem + ".json", false, "");
                if(!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\" + listBox1.SelectedItem + "\\" + listBox1.SelectedItem + ".jar"))
                  launcher.Version.AddToDownloadList(bunifuiOSSwitch1.Value?("https://bmclapi2.bangbang93.com/version/" +listBox1.SelectedItem+"/client"):(String)(JObject.Parse(System.Text.Encoding.UTF8.GetString(launcher.Version.readURL(getVersionJsonURL((String)listBox1.SelectedItem))))["downloads"]["client"]["url"]), ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\" + listBox1.SelectedItem + "\\" + listBox1.SelectedItem +".jar", false, "");
                launcher.Version.DownloadIt();
                JObject versionObj = JObject.Parse(launcher.LaunchIt.readTextFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\" + listBox1.SelectedItem + "\\" + listBox1.SelectedItem + ".json"));
                foreach(JObject i in versionObj["libraries"])
                {
                    try
                    {
                        if(!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\libraries\\" +((String)i["downloads"]["artifact"]["path"]).Replace("/","\\")))
                        {
                            launcher.Version.AddToDownloadList((String)i["downloads"]["artifact"]["url"], ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\libraries\\" + ((String)i["downloads"]["artifact"]["path"]).Replace("/", "\\"),false,"");
                        }
                    }
                    catch (Exception) { }
                    try
                    {
                        launcher.Version.AddToDownloadList((String)i["downloads"]["classifiers"]["natives-windows"]["url"], ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\libraries\\" + ((String)i["downloads"]["classifiers"]["natives-windows"]["path"]).Replace("/", "\\"),true, ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\" + listBox1.SelectedItem + "\\" + listBox1.SelectedItem + "-natives");
                    }
                    catch (Exception) { }
                }
                launcher.Version.DownloadIt();
                if(!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\assets\\indexes\\" +versionObj["assetIndex"]["id"] +".json"))
                {
                    launcher.Version.AddToDownloadList((String)versionObj["assetIndex"]["url"], ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\assets\\indexes\\" + versionObj["assetIndex"]["id"] + ".json",false,"");
                    launcher.Version.DownloadIt();
                }
                JObject assetObj = JObject.Parse(launcher.LaunchIt.readTextFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\assets\\indexes\\" + versionObj["assetIndex"]["id"] + ".json"));
                foreach(JProperty i in assetObj["objects"])
                {
                    try
                    {
                        String twoha = ((String)i.Value["hash"]).Substring(0, 2);
                        if ((String)versionObj["assetIndex"]["id"] == "legacy")
                        {
                            if (!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\assets\\virtual\\legacy\\" + i.Name))
                            {
                                launcher.Version.AddToDownloadList("http://bmclapi2.bangbang93.com/assets/" + twoha + "/" + i.Value["hash"], ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\assets\\virtual\\legacy\\" + i.Name, false, "");
                            }
                        }
                        else
                        {
                            if (!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\assets\\objects\\" + twoha + "\\" + i.Value["hash"]))
                            {
                                launcher.Version.AddToDownloadList("http://bmclapi2.bangbang93.com/assets/" + twoha + "/" + i.Value["hash"], ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\assets\\objects\\" + twoha + "\\" + i.Value["hash"], false, "");
                            }
                        }
                    }
                    catch (Exception) { }
                }
                launcher.Version.DownloadIt();
                this.Enabled = true;
            }
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if(listBox1.Items.Count>0)
            GetVersion_Click(null,null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], this);
        }
    }
}
