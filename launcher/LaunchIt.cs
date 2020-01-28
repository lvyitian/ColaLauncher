using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher.launcher
{
    class LaunchIt
    {
        public static volatile JObject temp = new JObject();
        public static String Login(String user, String pass)
        {
        	HttpWebRequest temp = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
            temp.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            temp.Method = "POST";
            temp.ContentType = "application/json";
            temp.KeepAlive = false;
            temp.AllowAutoRedirect = true;
            byte[] req = System.Text.Encoding.UTF8.GetBytes("{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + user + "\",\"password\":\"" + pass + "\",\"requestUser\":true}");
            temp.GetRequestStream().Write(req, 0, req.Length);
            HttpWebResponse temp2 = (HttpWebResponse)temp.GetResponse();
            Stream temp3 = temp2.GetResponseStream();
            StreamReader reader = new StreamReader(temp3, System.Text.Encoding.UTF8);
            string ret = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            temp2.Close();
            temp3.Close();
            //temp2.Dispose();
            temp3.Dispose();
            return ret;
        }
        public static void Launch(String version, String MinecraftDir, String username, String mem = "1024", String CustomJVMArgs = "", String CustomMinecraftArgs = "", bool debug = false, String java = @"javaw.exe", String uuid = null, String token = null)
        {
            String UUID = (uuid == null ? Guid.NewGuid().ToString() : uuid);
            String Token = (token == null ? UUID : token);
            JObject temp = JObject.Parse(readTextFile(MinecraftDir + "\\versions\\" + version + "\\" + version + ".json"));
            String lib = "";
            bool enableForge = false;
            if (temp["enableForge"] != null && (bool)temp["enableForge"])
                enableForge = true;
            foreach (JObject i in temp["libraries"])
            {
                //MessageBox.Show((String)i["downloads"]["artifact"]["path"]);
                try
                {
                    lib += "\"" + MinecraftDir + "\\libraries\\" + ((String)i["downloads"]["artifact"]["path"]).Replace("/", "\\") + "\";";
                }
                catch (Exception) {
                    if(enableForge)
                    {
                        try
                        {
                            lib += "\"" +MinecraftDir + "\\libraries\\" + (((String)i["name"]).Split(':')[0].Replace(".", "\\") + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':'), ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length)).Replace(":", "\\") + "\\" + (((String)i["name"]).Substring(((String)i["name"]).IndexOf(':') + 1, ((String)i["name"]).Length - ((String)i["name"]).Split(':')[0].Length - 1)).Replace(":", "-") + ".jar").Replace("/", "\\")+ "\";";
                        }
                        catch (Exception) { }
                    }
                    
                }
            };
            lib += "\"" + MinecraftDir + "\\versions\\" + version + "\\" + version + ".jar" + "\"";
            if (debug)
                MessageBox.Show(lib);
            String MainClass = null;
            if(enableForge)
              MainClass=(String)temp["mainClass"];
            else
            	MainClass="net.minecraft.client.main.Main";
            String mcArgs = "";
            
            try
            {
                foreach (var i in temp["arguments"]["game"])
                {
                    if (i is JValue && ((JValue)i).Type == JTokenType.String)
                    {
                        mcArgs += ((String)i).Replace("${user_properties}", "{}").Replace("${auth_player_name}", username).Replace("${version_name}", "H2OCLauncher").Replace("${ game_directory}", "\"" + MinecraftDir + "\"").Replace("${assets_root}", "\"" + MinecraftDir + "\\assets\"").Replace("${assets_index_name}", (String)temp["assetIndex"]["id"]).Replace("${auth_uuid}", UUID).Replace("${auth_access_token}", Token).Replace("${user_type}", Token == UUID ? "Legacy" : "Mojang").Replace("${version_type}", "H2OCLauncher").Replace("${game_directory}", "\"" + MinecraftDir + "\"") + " ";
                    }
                }
            }
            catch (Exception) { mcArgs = ((String)temp["minecraftArguments"]).Replace("${user_properties}", "{}").Replace("${auth_player_name}", username).Replace("${version_name}", "H2OCLauncher").Replace("${ game_directory}", "\"" + MinecraftDir + "\"").Replace("${assets_root}", "\"" + MinecraftDir + "\\assets\"").Replace("${assets_index_name}", (String)temp["assetIndex"]["id"]).Replace("${auth_uuid}", UUID).Replace("${auth_access_token}", Token).Replace("${user_type}", Token == UUID ? "Legacy" : "Mojang").Replace("${version_type}", "H2OCLauncher").Replace("${game_directory}", "\"" + MinecraftDir + "\""); }
            if (debug)
                MessageBox.Show(mcArgs);
            String Maxmem = mem;
            String JVMArgs = (String.IsNullOrEmpty(CustomJVMArgs) || String.IsNullOrWhiteSpace(CustomJVMArgs) ? "" : (CustomJVMArgs + " ")) + "-Xmn128M -Xmx" + Maxmem + "M -Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true -Djava.library.path=\"" + MinecraftDir + "\\versions\\" + version + "\\" + version + "-natives" + "\" -Dminecraft.client.jar=\"" + MinecraftDir + "\\versions\\" + version + "\\" + version + ".jar" + "\" -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=16M -XX:-UseAdaptiveSizePolicy -XX:-OmitStackTraceInFastThrow";

            String javaPath = java;//@"C:\Program Files\Java\jdk1.8.0_201\jre\bin\java.exe";
            Process temp3 = new Process();
            ProcessStartInfo si = new ProcessStartInfo();

            if (debug)
            {
                si.UseShellExecute = false;
                si.RedirectStandardOutput = true;
                si.RedirectStandardError = true;
                si.RedirectStandardInput = true;
            }
            /*else
            {
                si.WindowStyle = ProcessWindowStyle.Hidden;
            }*/


            si.FileName = javaPath;
            si.Arguments = JVMArgs + " -cp " + lib + " " + MainClass + " " + (String.IsNullOrEmpty(CustomMinecraftArgs) || String.IsNullOrWhiteSpace(CustomMinecraftArgs) ? "" : (CustomMinecraftArgs + " ")) + mcArgs;
            ///Clipboard.SetText(si.FileName+" "+si.Arguments);
            if (debug)
                MessageBox.Show(si.Arguments);
            temp3.StartInfo = si;
            temp3.Start();
            Form1.instance.Hide();
            string output = "";
            if (debug) output = temp3.StandardOutput.ReadToEnd();
            string err = "";
            if (debug) err = temp3.StandardError.ReadToEnd();
            temp3.WaitForExit();
            if (temp3.ExitCode != 0)
                MessageBox.Show("Minecraft异常退出 退出码: " + temp3.ExitCode);
            Form1.instance.Show();
            if (debug)
            {
                MessageBox.Show(output);
                MessageBox.Show(err);
            }

        }
        public static String readTextFile(String path)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, buf.Length);
                return System.Text.Encoding.UTF8.GetString(buf);
            }
        }
        public static byte[] readFile(String path)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, buf.Length);
                return buf;
            }
        }
        public static void writeTextFile(String path, String content)
        {
            if (File.Exists(path))
                File.Delete(path);
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] buf = System.Text.Encoding.UTF8.GetBytes(content);
                fs.Write(buf, 0, buf.Length);
            }
        }
        public static void Save(Control t = null)
        {

            foreach (Control i in t == null ? Form1.instance.Controls : t.Controls)
            {
                if (i is TextBox)
                {
                    temp[i.Name] = ((TextBox)i).Text;
                }
                else if (i is BunifuiOSSwitch)
                {
                    temp[i.Name] = ((BunifuiOSSwitch)i).Value;
                }
                else if (i is ComboBox)
                {
                    temp[i.Name] = ((ComboBox)i).Text;
                }
                else if (i is Panel)
                {
                    Save(i);
                }
            }
            temp["theme"] = new JArray(UI.ts);
            LaunchIt.writeTextFile("config.json", temp.ToString());
        }
        public static void LoadCon(Control t = null)
        {
            try
            {
                temp = Newtonsoft.Json.Linq.JObject.Parse(LaunchIt.readTextFile("config.json"));
            }
            catch (FileNotFoundException) { Save(); return; }
            foreach (Control i in t == null ? Form1.instance.Controls : t.Controls)
            {
                if (i is TextBox)
                {
                    JValue awa = (JValue)temp[i.Name];
                    if (awa != null)
                        ((TextBox)i).Text = (String)awa;
                }

                else if (i is BunifuiOSSwitch)
                {
                    JValue awa = (JValue)temp[i.Name];
                    if (awa != null)
                        ((BunifuiOSSwitch)i).Value = (bool)awa;
                }
                else if (i is ComboBox)
                {
                    JValue awa = (JValue)temp[i.Name];
                    if (awa != null)
                        if (((ComboBox)i).Items.Contains((String)awa))
                            ((ComboBox)i).SelectedItem = (String)awa;
                }
                else if (i is Panel)
                {
                    LoadCon(i);
                }
            }
            if (temp["theme"] == null)
                temp["theme"] = new JArray(UI.ts);
            ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form1.instance);
            if (Form2.instance != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form2.instance);
            if (Form3.instance != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form3.instance);
            if (Form4.instance != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form4.instance);
            for (int i = 0; i < Form5.instances.Count; i++)
                try
                {
                    ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3],Form5.instances[i]);
                }
                catch (Exception) { }
            if (Form1.instance.f6 != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form1.instance.f6);
        }
    }
}
