using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher.launcher
{
    class UI
    {
        public static int[] ts = new int[4] { 255, 46, 139, 87 };
        public static void changeTheme(int a,int r,int g,int b, Control c = null)
        {
            ts = new int[4] { a, r, g, b };
            foreach(Control i in c==null?Form1.instance.Controls:c.Controls)
            {
                if (i.Name == "panel3" || i is Button || i is ListBox)
                    i.BackColor = Color.FromArgb(a,r,g,b);
                if (i is Panel)
                    changeTheme(a, r, g, b, i);
            }
        }
        
    }
}
