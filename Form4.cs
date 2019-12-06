using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher
{
    public partial class Form4 : Form
    {
        private volatile bool nohan = false;
        public static volatile String guidt= Guid.NewGuid().ToString();
        public OpenFileDialog fileDialog = null;
        public Class1 folderDialog = null;
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public static Form4 instance = null;

        public Form4()
        {
            instance = this;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "EndDialog")]
        public extern static bool EndDialog(int hWnd, IntPtr result);
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "FindWindowA")]
        public extern static int FindWindowA(String lpClassName, String lpWindowName);
        /*[DllImport("user32.dll", SetLastError = true, EntryPoint = "FindWindowExA")]
        public extern static int FindWindowExA(IntPtr handle,IntPtr child,String classname,String windowname);*/

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(fileDialog!=null)
            {
                EndDialog(FindWindowA(null, "请选择java.exe/javaw.exe " + guidt), new IntPtr((int)DialogResult.Cancel));
            }
            fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择java.exe/javaw.exe "+guidt;
            fileDialog.Filter = "java.exe|java.exe|javaw.exe|javaw.exe"; 
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.javapath.Text = fileDialog.FileName;                
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ColaLauncher.launcher.LaunchIt.LoadCon(Form4.instance);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ColaLauncher.launcher.UI.changeTheme(255, 93, 108, 193, Form1.instance);
            if(Form2.instance!=null)
            ColaLauncher.launcher.UI.changeTheme(255, 93, 108, 193, Form2.instance);
            if (Form3.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 93, 108, 193, Form3.instance);
            if (Form4.instance!=null)
            {
                ColaLauncher.launcher.UI.changeTheme(255, 93, 108, 193, Form4.instance);
            }
            for (int i = 0; i < Form5.instances.Count; i++)
                try
                {
                    ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form5.instances[i]);
                }
                catch (Exception) { }
            if (Form1.instance.f6 != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form1.instance.f6);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ColaLauncher.launcher.UI.changeTheme(255, 46, 139, 87, Form1.instance);
            if (Form2.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 46, 139, 87, Form2.instance);
            if (Form3.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 46, 139, 87, Form3.instance);
            if (Form4.instance != null)
            {
                ColaLauncher.launcher.UI.changeTheme(255, 46, 139, 87, Form4.instance);
            }
            for (int i = 0; i < Form5.instances.Count; i++)
                try
                {
                    ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form5.instances[i]);
                }
                catch (Exception) { }
            if (Form1.instance.f6 != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form1.instance.f6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
                ColaLauncher.launcher.UI.changeTheme(255, 180, 71, 163, Form1.instance);
            if (Form2.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 180, 71, 163, Form2.instance);
            if (Form3.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 180, 71, 163, Form3.instance);
            if (Form4.instance != null)
            {
                ColaLauncher.launcher.UI.changeTheme(255, 180, 71, 163, Form4.instance);
            }
            for (int i = 0; i < Form5.instances.Count; i++)
                try
                {
                    ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form5.instances[i]);
                }
                catch (Exception) { }
            if (Form1.instance.f6 != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form1.instance.f6);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ColaLauncher.launcher.UI.changeTheme(255, 61, 61, 61, Form1.instance);
            if (Form2.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 61, 61, 61, Form2.instance);
            if (Form3.instance != null)
                ColaLauncher.launcher.UI.changeTheme(255, 61, 61, 61, Form3.instance);
            if (Form4.instance != null)
            {
                ColaLauncher.launcher.UI.changeTheme(255, 61, 61, 61, Form4.instance);
            }
            for (int i = 0; i < Form5.instances.Count; i++)
                try
                {
                    ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form5.instances[i]);
                }
                catch (Exception) { }
            if (Form1.instance.f6 != null)
                ColaLauncher.launcher.UI.changeTheme((int)launcher.LaunchIt.temp["theme"][0], (int)launcher.LaunchIt.temp["theme"][1], (int)launcher.LaunchIt.temp["theme"][2], (int)launcher.LaunchIt.temp["theme"][3], Form1.instance.f6);
        }



        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileDialog != null)
            {
                EndDialog(FindWindowA(null, "请选择java.exe/javaw.exe " + guidt), new IntPtr((int)DialogResult.Cancel));
            }
            if (folderDialog != null && folderDialog.dialog != null)
                while (!folderDialog.dialog.IsDisposed)
                {
                    try
                    {
                        folderDialog.Close();
                        break;
                    }
                    catch (Exception) { }
                }
            Form1.instance.f4 = null;
            ColaLauncher.launcher.LaunchIt.Save(Form4.instance);
        }

        private void mem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == '\u0008'))
            {
                e.Handled = true;
            }
        }

        private void mem_TextChanged(object sender, EventArgs e)
        {
            if (!nohan)
            {
                nohan = true;
                try
                {
                   mem.Text = String.Concat(Int32.Parse(mem.Text));
                }
                catch (Exception) { mem.Text = ""; }
                finally { nohan = false; }

            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            if (folderDialog != null && folderDialog.dialog != null)
                while (!folderDialog.dialog.IsDisposed)
                {
                    try
                    {
                        folderDialog.Close();
                        break;
                    }
                    catch (Exception) { }
                }
            folderDialog = new Class1();
            folderDialog.dialog.Text = "请选择.minecraft文件夹";
            folderDialog.ShowDialog();
            if (folderDialog.dialog.DialogResult == DialogResult.OK)
                minecraftpath.Text = folderDialog.path;
        }
    }
}
