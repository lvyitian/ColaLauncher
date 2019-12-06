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
using System.Threading;

namespace ColaLauncher
{
    public partial class Form1 : Form
    {
        public static Form1 instance=null;
        public volatile Form2 vmw = null;
        public volatile Form4 f4 = null;
        public volatile Form6 f6 = null;
        public static int memo = 1024;
        public static bool debug = false;
        public static String JVMArgs = "";
        public static String MCArgs = "";
        
        public Form1()
        {
           
            instance = this;
            InitializeComponent();
            ColaLauncher.launcher.LaunchIt.LoadCon();
        }

       



        private void Launcher_Click(object sender, EventArgs e)
        {
            if(versionText.SelectedIndex<0)
            {
                MessageBox.Show("请选择一个版本进行启动");
                return;
            }
            if(bunifuiOSSwitch1.Value)
            {
                if (String.IsNullOrEmpty(email.Text) || String.IsNullOrWhiteSpace(email.Text))
                {
                    MessageBox.Show("请输入一个有效的邮箱");
                    return;
                }
                if(String.IsNullOrEmpty(password.Text) ||String.IsNullOrWhiteSpace(password.Text))
                {
                    MessageBox.Show("密码不能为空");
                    return;
                }
            }
            else
            {
                if(email.Text.Contains(" ") || String.IsNullOrEmpty(email.Text) || String.IsNullOrWhiteSpace(email.Text))
                {
                    MessageBox.Show("请输入一个有效的游戏ID");
                    return;
                }
            }
            if (launcher.LaunchIt.temp["javapath"]==null)
            {
                MessageBox.Show("你没有设置java路径.(如果你找不到路径,但确实安装了java,可以改为java.exe)");
                return;
            }

            
            if (launcher.LaunchIt.temp["mem"]==null || !isNumber((String)launcher.LaunchIt.temp["mem"]))
            {
                MessageBox.Show("你没有设置内存,将使用默认内存(1024M)");
                memo = 1024;
            }
            else
            {
                memo = int.Parse((String)launcher.LaunchIt.temp["mem"]);
            }
            if (launcher.LaunchIt.temp["isdebu"]!=null && ((bool)launcher.LaunchIt.temp["isdebu"]))
            {
                debug = true;
            }
            if (launcher.LaunchIt.temp["mcargs"] != null)
            {
                MCArgs = (String)launcher.LaunchIt.temp["mcargs"];
            }
            if (launcher.LaunchIt.temp["jvmarg"] != null)
            {
                JVMArgs = (String)launcher.LaunchIt.temp["jvmarg"];
            }
            if (bunifuiOSSwitch1.Value)
            {
                JObject ret = null;
                try
                {
                    ret = JObject.Parse(launcher.LaunchIt.Login(this.email.Text, this.password.Text));
                }
                catch (Exception e2) { MessageBox.Show("获取Mojang账号AccessToken失败! \n"+e2.ToString()); return; }
                ColaLauncher.launcher.LaunchIt.Launch(this.versionText.Text, (launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"], (String)ret["selectedProfile"]["name"],String.Concat(memo), JVMArgs, MCArgs, debug, (String)(launcher.LaunchIt.temp["javapath"]), (String)ret["selectedProfile"]["id"], (String)ret["accessToken"]);
            }
            else
            {
                ColaLauncher.launcher.LaunchIt.Launch(this.versionText.Text, (launcher.LaunchIt.temp["minecraftpath"] == null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"])) ? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"], this.email.Text, String.Concat(memo), JVMArgs, MCArgs, debug, (String)(launcher.LaunchIt.temp["javapath"]), null, null);
            }
            //MessageBox.Show(ret);
            ColaLauncher.launcher.LaunchIt.Save();
            if (Form4.instance!=null) 
             ColaLauncher.launcher.LaunchIt.Save(Form4.instance);
        }

        private bool isNumber(string v)
        {
            if (string.IsNullOrEmpty(v) || string.IsNullOrWhiteSpace(v))
                return false;
            foreach(char i in v)
            {
                if (!char.IsDigit(i))
                    return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            versionText.Items.Clear();
            foreach (String i in ColaLauncher.launcher.Version.Getversion((launcher.LaunchIt.temp["minecraftpath"]==null || String.IsNullOrEmpty((String)launcher.LaunchIt.temp["minecraftpath"]) || String.IsNullOrWhiteSpace((String)launcher.LaunchIt.temp["minecraftpath"]))? (Application.StartupPath + @"\.minecraft") : (String)launcher.LaunchIt.temp["minecraftpath"]))
                versionText.Items.Add(i);
            ColaLauncher.launcher.LaunchIt.LoadCon();
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if (bunifuiOSSwitch1.Value)
            {
                this.label2.Text = "正版账号";
                this.label3.Text = "正版密码";
                this.label3.Show();
                this.password.Show();
                this.pictureBox3.Show();
                this.pictureBox4.Show();
                this.panel2.Size = new Size(this.panel2.Width,120);

            }
            else
            {
                this.label2.Text = "游戏ID";
                this.label3.Hide();
                this.password.Hide();
                this.pictureBox3.Hide();
                this.pictureBox4.Hide();
                this.panel2.Size = new Size(this.panel2.Width, 148-80);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
        
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(vmw==null)
            {
                Thread tempt=new Thread(()=> {
                    vmw = new Form2();
                    Application.Run(vmw);
                    
                });
                tempt.SetApartmentState(ApartmentState.STA);
                tempt.IsBackground = true;
                tempt.Start();
                while(vmw==null)
                {
                    Thread.Sleep(1);
                }
            }
            else
            {
                vmw.BringToFront();
                vmw.Focus();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1_Load(null,null);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (f4 == null)
            {
                Thread tempt = new Thread(() =>
                {
                    f4 = new Form4();
                    Application.Run(f4);
                });
                tempt.SetApartmentState(ApartmentState.STA);
                tempt.IsBackground = true;
                tempt.Start();
                while (f4 == null)
                {
                    Thread.Sleep(1);
                }
            }
            else
            {
                f4.BringToFront();
                f4.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(versionText.SelectedIndex>=0)
            {
                if(versionText.Text.ToLower().Contains("forge"))
                {
                    MessageBox.Show("此版本已安装Forge!");
                    return;
                }
                this.Enabled = false;
                this.Hide();
                String s = versionText.Text;
                Thread tempt = new Thread(() => {
                    f6 = new Form6(s);
                    Application.Run(f6);
                });
                tempt.SetApartmentState(ApartmentState.STA);
                tempt.IsBackground = true;
                tempt.Start();
                while (tempt.IsAlive)
                {
                    Thread.Sleep(1);
                }
                f6.Dispose();
                f6 = null;
                this.Enabled = true;
                this.Show();
            }
            else
            {
                MessageBox.Show("请先选中一个版本!");
                return;
            }
        }
    }
}
