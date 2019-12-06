using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher
{
    public partial class Form5 : Form
    {
        public static volatile List<Form5> instances = new List<Form5>();
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public String path = "";
        public bool ok = false;
        public Guid needMore = Guid.NewGuid();
        public Form5()
        {
            this.Disposed += Form5_Disposed;
            InitializeComponent();
            instances.Add(this);
            ColaLauncher.launcher.UI.changeTheme(launcher.UI.ts[0], launcher.UI.ts[1], launcher.UI.ts[2], launcher.UI.ts[3], this);
        }

        private void Form5_Disposed(object sender, EventArgs e)
        {
            Form5_FormClosed(sender,null);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("root "+needMore.ToString());
            treeView1.Nodes[0].Nodes.Add("needMore " + needMore.ToString());
            //addNodes(treeView1.Nodes[0]);
        }
        private void addNodes(TreeNode node=null,long depth=0)
        {
            if(node==null)
            {
                String[] d=Environment.GetLogicalDrives();
                for(int i=0;i<d.Length;i++)
                {
                    treeView1.Nodes.Add(d[i]);
                    treeView1.Nodes[i].Nodes.Add("needMore " + needMore.ToString());
                    //addNodes(treeView1.Nodes[i],depth+1);
                }
            }
            else if(node.Text == "root " + needMore.ToString())
            {
                String[] d = Environment.GetLogicalDrives();
                for (int i = 0; i < d.Length; i++)
                {
                    node.Nodes.Add(d[i]);
                    node.Nodes[i].Nodes.Add("needMore " + needMore.ToString());
                    //addNodes(node.Nodes[i],depth+1);
                }
            }
            else
            {
                if (depth > 1)
                    return;
                String dir = node.Text;
                try
                {
                    IEnumerable<string> te = Directory.EnumerateDirectories(dir);
                    for (int i = 0; i < te.Count(); i++)
                    {
                        if (node.Nodes.ContainsKey(te.ElementAt(i)))
                            continue;
                        node.Nodes.Add(te.ElementAt(i));
                        node.Nodes[i].Nodes.Add("needMore "+needMore.ToString());
                        //addNodes(node.Nodes[i],depth+1);
                    }
                }
                catch (Exception) { return; }
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ok)
                this.DialogResult = DialogResult.Cancel;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("needMore "+needMore.ToString());
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Text == "root " + needMore.ToString())
            {
                e.Node.Nodes.Clear();
                addNodes(e.Node);
                return;
            }
            if(e.Node.Nodes.Count==1 && e.Node.Nodes[0].Text=="needMore "+needMore.ToString())
            {
                e.Node.Nodes.Clear();
                addNodes(e.Node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root " + needMore.ToString())
                return;
            this.ok = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.path = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root " + needMore.ToString())
                return;
            this.ok = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            instances.Remove(this);
        }
    }
}
