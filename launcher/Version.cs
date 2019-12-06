using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher.launcher
{
    class Version
    {
        public volatile static Form3 dmw = null;
        public static List<String> URLs = new List<String>();
        public static List<String> Locs = new List<string>();
        public static List<bool> needUn = new List<bool>();
        public static List<String> UnLoc = new List<string>();
        public static List<String> Getversion(String RootDir)
        {
            if (!Directory.Exists(RootDir + @"\versions\"))
                return new List<string>();
            String[] version = Directory.GetDirectories(RootDir + @"\versions\");
            List<String> versions = new List<String>();
            for (int i = 0; i < version.Length; i++)
            {
                versions.Add(version[i].Replace(RootDir + @"\versions\", ""));
            }
            return versions;
        }
        public static JObject getVersionListOfficial()
        {
        	HttpWebRequest temp = (HttpWebRequest)WebRequest.Create("https://launchermeta.mojang.com/mc/game/version_manifest.json");
            temp.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            temp.Method = "GET";
            temp.KeepAlive = false;
            temp.AllowAutoRedirect = true;
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
            return JObject.Parse(ret);
        }
        public static JObject getVersionListBang()
        {
        	HttpWebRequest temp = (HttpWebRequest)WebRequest.Create("https://bmclapi2.bangbang93.com/mc/game/version_manifest.json");
            temp.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            temp.Method = "GET";
            temp.KeepAlive = false;
            temp.AllowAutoRedirect = true;
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
            return JObject.Parse(ret);
        }
        public static void AddToDownloadList(String downloadurltext, String downloadlocation, bool isunzip, String unziploc)
        {
            downloadlocation = downloadlocation.Replace("/", "\\");
            unziploc = unziploc.Replace("/", "\\");
            Locs.Add(downloadlocation);
            needUn.Add(isunzip);
            UnLoc.Add(unziploc);
            URLs.Add(downloadurltext);
        }
        /// <summary>
        /// unZip文件解压缩
        /// </summary>
        /// <param name="sourceFile">要解压的文件</param>
        /// <param name="path">要解压到的目录</param>
        public static void ZipDeCompress(string sourceFile, string path)
        {
            if (!File.Exists(sourceFile))
            {
                throw new ArgumentException("要解压的文件不存在。");
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (!theEntry.IsFile)
                        continue;
                    string fileName = System.IO.Path.GetFileName(theEntry.Name);
                    if (fileName != string.Empty)
                    {
                        if(!theEntry.Name.Contains("META-INF") && !File.Exists(path + @"\" + theEntry.Name))
                        {
                            using (FileStream streamWriter = File.Open(path + @"\" + theEntry.Name, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                            {
                                int size = 4096;
                                byte[] data = new byte[4096];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void writeFile(String path, byte[] content)
        {
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                fs.Write(content, 0, content.Length);
            }
        }
        public static byte[] readURL(String url)
        {
        	HttpWebRequest temp = (HttpWebRequest)WebRequest.Create(url);
            temp.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            temp.Method = "GET";
            temp.KeepAlive = false;
            temp.AllowAutoRedirect = true;
            HttpWebResponse temp2 = (HttpWebResponse)temp.GetResponse();
            Stream temp3 = temp2.GetResponseStream();
            MemoryStream ms = new MemoryStream();
            int cb = -1;
            while (true)
            {
                cb = temp3.ReadByte();
                if (cb == -1)
                    break;
                ms.WriteByte((byte)cb);
            }
            byte[] ret = ms.ToArray();
            ms.Close();
            ms.Dispose();
            temp2.Close();
            temp3.Close();
            //temp2.Dispose();
            temp3.Dispose();
            return ret;
        }
        public static void DownloadIt()
        {
            try
            {
                if (Form2.instance != null)
                    Form2.instance.Hide();
            }
            catch (Exception) { }
            Thread tempt = new Thread(() =>
            {
                dmw = new Form3();
                try
                {
                    Application.Run(dmw);
                }
                catch (Exception) { }
            });
            tempt.SetApartmentState(ApartmentState.STA);
            tempt.Start();
            while (dmw == null) { Thread.Sleep(1); }
            foreach (String i in URLs)
                dmw.listBox1.Items.Add(i);
            dmw.progressBar1.Maximum = URLs.Count;
            for (int i = 0; i < dmw.listBox1.Items.Count; i++)
            {
                if (dmw.button1.Enabled == false)
                {
                    break;
                }
                dmw.listBox1.SelectedIndex = i;
                String url = (String)dmw.listBox1.Items[i];
                try
                {
                    dmw.listBox1.Items[i] = url + " 正在下载...";
                    if (!File.Exists(Locs[i]))
                    {
                        Directory.CreateDirectory(Locs[i].Substring(0, Locs[i].LastIndexOf('\\')));
                        writeFile(Locs[i], readURL(url));
                    }
                    dmw.listBox1.Items[i] = url + " 下载完毕";
                    if(needUn[i])
                    {
                        dmw.listBox1.Items[i] = url + " 正在解压...";
                        ZipDeCompress(Locs[i],UnLoc[i]);
                        dmw.listBox1.Items[i] = url + " 解压完毕";
                    }
                }
                catch (Exception e)
                {
                    new Thread(()=>MessageBox.Show(e.ToString())).Start();
                    dmw.listBox1.Items[i] = url + " 发生错误";
                }
                dmw.progressBar1.Value = i + 1;
                dmw.label1.Text = String.Concat(Math.Round((double)(i + 1) / (double)URLs.Count*(double)100))+"%";
            }
            URLs.Clear();
            Locs.Clear();
            needUn.Clear();
            UnLoc.Clear();
            while (true)
            {
                try
                {
                    dmw.listBox1.Items.Clear();
                    dmw.button1.Enabled = true;
                    dmw.Dispose();
                    break;
                }
                catch (Exception) { }
                Thread.Sleep(1);
            }
            dmw = null;
            try
            {
                if (Form2.instance != null)
                    Form2.instance.Show();
            }
            catch (Exception) { }
        }
    }
}
