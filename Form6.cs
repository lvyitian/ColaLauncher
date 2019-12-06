using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher
{
    public partial class Form6 : Form
    {
        public volatile bool isClosed = false;
        public volatile JArray list = null;
        public volatile String version = null;
        private Form6()
        {
            this.Disposed += Form6_Disposed;
            InitializeComponent();
        }

        private void Form6_Disposed(object sender, EventArgs e)
        {
            Form6_FormClosed(sender,null);
        }

        public Form6(String ver):this()
        {
            this.version = ver;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            list = launcher.Forge.getForgeList(version);
            listBox1.Items.Clear();
            String[] vl = new String[list.Count];
            int i2 = 0;
            foreach (JObject i in list)
            {
                try
                {
                    vl[i2]=((String)i["version"]);
                }
                catch (Exception) { }
                i2++;
            }
            List<String> tl = new List<String>();
            foreach (String i in vl)
                if (!String.IsNullOrEmpty(i) && !String.IsNullOrWhiteSpace(i))
                    tl.Add(i);
            VersionStrWrapper[] v2 = new VersionStrWrapper[tl.Count];
            for (int i = 0; i < tl.Count; i++)
                v2[i] = tl[i];
            Array.Sort(v2);
            String[] v3 = new String[v2.Length];
            for (int i = 0; i < v2.Length; i++)
                v3[i] = v2[i];
            listBox1.Items.AddRange(v3);
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.isClosed = true;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.button1.Text = "安装中...";
            try
            {
                String fv = (String)listBox1.SelectedItem;
                byte[] buf = launcher.Forge.downloadForge(version, fv, "installer", "jar");
                //launcher.Version.writeFile("debug.jar",buf);
                ZipInputStream t = new ZipInputStream(new MemoryStream(buf));
                ZipEntry te = null;
                byte[] profi = null;
                while ((te = t.GetNextEntry()) != null)
                {
                    if (te.IsFile)
                        if (te.Name == "install_profile.json")
                        {
                            MemoryStream ms = new MemoryStream();
                            int by = -1;
                            while ((by = t.ReadByte()) != -1)
                                ms.WriteByte((byte)by);
                            profi = ms.ToArray();
                            ms.Close();
                            break;
                        }
                }
                if (profi == null)
                {
                    throw new Exception("Cannot find information file");
                }
                String pro = System.Text.Encoding.UTF8.GetString(profi);
                JObject proObj = JObject.Parse(pro);
                if (proObj["spec"] != null)
                {
                    if ((String)proObj["minecraft"] != version)
                        throw new Exception("Version doesn't match");
                    JArray libs = (JArray)proObj["libraries"];
                    foreach(JObject i in libs)
                    {
                        try
                        {
                            if(!String.IsNullOrEmpty((String)i["downloads"]["artifact"]["url"]) && !String.IsNullOrWhiteSpace((String)i["downloads"]["artifact"]["url"]))
                            if(!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\libraries\\" + ((String)i["downloads"]["artifact"]["path"]).Replace("/", "\\")))
                              launcher.Version.AddToDownloadList((String)i["downloads"]["artifact"]["url"], ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\libraries\\" + ((String)i["downloads"]["artifact"]["path"]).Replace("/", "\\"), false, "");
                        }
                        catch (Exception) { }
                    }
                    launcher.Version.DownloadIt();
                    Directory.CreateDirectory(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\"+version+"-forge."+fv);
                    Directory.CreateDirectory(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\"+version+"-forge."+fv+"\\"+version+"-forge."+fv+"-natives");
                    foreach(String i in Directory.EnumerateFiles(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\"+version+"\\"+version+"-natives"))
                    {
                    	File.Copy(i,((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"])+"\\versions\\"+version+"-forge."+fv+"\\"+version+"-forge."+fv+"-natives\\"+Path.GetFileName(i));
                    }
                    launcher.Version.writeFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "-forge." + fv+"\\" + version + "-forge."+fv+".jar", launcher.LaunchIt.readFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version+"\\"+version+".jar"));
                    JObject ovobj = JObject.Parse(launcher.LaunchIt.readTextFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "\\" + version + ".json"));
                    foreach(JObject i in libs)
                      ((JArray)ovobj["libraries"]).Add(i);
                    launcher.Version.writeFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "-forge." + fv + "\\" + version + "-forge." + fv + ".json",System.Text.Encoding.UTF8.GetBytes(ovobj.ToString()));
                    //done
                }
                else if(proObj["install"]!=null && proObj["versionInfo"]!=null){
                    if ((String)proObj["install"]["minecraft"] != version)
                        throw new Exception("Version doesn't match");
                    throw new Exception("暂不支持旧版Forge安装!");
                    /*JArray libs = (JArray)proObj["versionInfo"]["libraries"];
                    foreach (JObject i in libs)
                    {
                        try
                        {
                            //Artifact a = new Artifact((String)i["name"]);
                            //MessageBox.Show(a.getPath());
                            //String[] spl = ((String)i["name"]).Split(':');
                            //String path = "";
                            //foreach (String i2 in spl)
                            //{
                            //    path += i2.Replace(".", "\\") + "\\";
                            //}
                            //path += spl[spl.Length - 1] + ".jar";
                            //MessageBox.Show(path);
                            MessageBox.Show((((String)i["name"]).Split(':')[0].Replace(".", "\\") + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':'), ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length)).Replace(":", "\\") + "\\" + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':') + 1, ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length - 1)).Replace(":", "-") + ".jar").Replace("\\", "/"));
                            MessageBox.Show(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\libraries\\" + (((String)i["name"]).Split(':')[0].Replace(".", "\\") + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':') , ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length)).Replace(":", "\\")+"\\"+(((String)i["name"]).Substring(((String)i["name"]).IndexOf(':')+1, ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length-1)).Replace(":","-")+".jar").Replace("/", "\\"));
                            if (!String.IsNullOrEmpty((String)i["url"]) && !String.IsNullOrWhiteSpace((String)i["url"]))
                               if (!File.Exists(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\libraries\\" + (((String)i["name"]).Split(':')[0].Replace(".", "\\") + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':'), ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length)).Replace(":", "\\") + "\\" + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':') + 1, ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length - 1)).Replace(":", "-") + ".jar").Replace("/", "\\")))
                                   launcher.Version.AddToDownloadList((String)i["url"]+ (((String)i["name"]).Split(':')[0].Replace(".", "\\") + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':'), ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length)).Replace(":", "\\") + "\\" + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':') + 1, ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length - 1)).Replace(":", "-") + ".jar").Replace("\\", "/"), ((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\libraries\\" + (((String)i["name"]).Split(':')[0].Replace(".", "\\") + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':'), ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length)).Replace(":", "\\") + "\\" + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':') + 1, ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length - 1)).Replace(":", "-") + ".jar").Replace("/", "\\"), false, "");
                        }
                        catch (Exception e233) { MessageBox.Show(e233.ToString()); }
                    }
                    launcher.Version.DownloadIt();
                    Directory.CreateDirectory(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "-forge." + fv);
                    launcher.Version.writeFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "-forge." + fv + "\\" + version + "-forge." + fv + ".jar", launcher.LaunchIt.readFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "\\" + version + ".jar"));
                    JObject ovobj = JObject.Parse(launcher.LaunchIt.readTextFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "\\" + version + ".json"));
                    foreach (JObject i in libs)
                        ((JArray)ovobj["libraries"]).Add(i);
                    launcher.Version.writeFile(((launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]) + "\\versions\\" + version + "-forge." + fv + "\\" + version + "-forge." + fv + ".json", System.Text.Encoding.UTF8.GetBytes(ovobj.ToString()));
                    //done*/
                }
                else
                {
                    throw new Exception("Failed to find critical information");
                }
            }
            catch (Exception e3) { MessageBox.Show("Forge安装失败! \n"+e3.ToString());goto end; }
            end:
            this.button1.Text = "安装";
            this.Enabled = true;
        }
    }
}
