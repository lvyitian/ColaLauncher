using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher.launcher
{
    class Forge
    {
        public static volatile String FORGE_LIST = "https://bmclapi2.bangbang93.com/forge/minecraft/:id";
        public static volatile String FORGE_DOWNLOAD = "https://bmclapi2.bangbang93.com/forge/download?mcversion=:mcv&version=:fv&category=:t&format=:f";
        public static JObject readJson(String url)
        {
            return JObject.Parse(System.Text.Encoding.UTF8.GetString(Version.readURL(url)));
        }
        public static JArray readJsonArray(String url)
        {
            return JArray.Parse(System.Text.Encoding.UTF8.GetString(Version.readURL(url)));
        }
        public static JArray getForgeList(String version)
        {
            return readJsonArray(FORGE_LIST.Replace(":id",version));
        }
        public static byte[] downloadForge(String version,String forge,String dt,String form,String bran=null)
        {
            return Version.readURL(FORGE_DOWNLOAD.Replace(":mcv",version).Replace(":fv",forge+(bran==null || String.IsNullOrEmpty(bran) || String.IsNullOrWhiteSpace(bran)?"":("&branch="+bran))).Replace(":t",dt).Replace(":f",form));
        }
    }
}
