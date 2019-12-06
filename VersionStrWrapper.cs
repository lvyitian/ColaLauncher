using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher
{
    public class VersionStrWrapper : IComparable
    {
        public String str = null;
        public VersionStrWrapper(String s)
        {
            str = s;
        }

        public int CompareTo(object obj)
        {
            //MessageBox.Show("awa");
            if(obj is String)
            {
                String sobj = (String)obj;
                String[] ver = sobj.Split('.');
                String[] cver = str.Split('.');
                for (int i = 0;i < cver.Length;i++)
                {
                    if (int.Parse(cver[i]) > int.Parse(ver[i]))
                        return -1;
                    else if (int.Parse(cver[i]) < int.Parse(ver[i]))
                        return 1;
                }
                return 0;
            }else if (obj is VersionStrWrapper)
            {
                String sobj = (VersionStrWrapper)obj;
                String[] ver = sobj.Split('.');
                String[] cver = str.Split('.');
                for (int i = 0; i < cver.Length; i++)
                {
                    if (int.Parse(cver[i]) > int.Parse(ver[i]))
                        return -1;
                    else if (int.Parse(cver[i]) < int.Parse(ver[i]))
                        return 1;
                }
                return 0;
            }
            else
            {
                throw new Exception("Unsupported type");
            }
        }

        public static implicit operator String(VersionStrWrapper s)
        {
            return s.str;
        }
        public static implicit operator VersionStrWrapper(String s)
        {
            return new VersionStrWrapper(s);
        }
        public override string ToString()
        {
            return str;
        }
    }
}
