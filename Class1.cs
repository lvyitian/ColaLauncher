using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaLauncher
{
    public class Class1 : CommonDialog
    {
        public Form5 dialog=new Form5();
        public String path { get { return dialog==null?"":dialog.path; } set { if (dialog != null) dialog.path = value; } }
        public override void Reset()
        {
            if (dialog != null && !dialog.IsDisposed)
            {
                dialog.DialogResult = DialogResult.Cancel;
                dialog.Dispose();
            }
            dialog = new Form5();
        }
        public void Close()
        {
            if (dialog != null && !dialog.IsDisposed)
            {
                dialog.DialogResult = DialogResult.Cancel;
                dialog.Dispose();
            }
        }
        protected override bool RunDialog(IntPtr hwndOwner)
        {
            dialog.ShowDialog(NativeWindow.FromHandle(hwndOwner));
            return true;
        }
        public void Dispose()
        {
            if(dialog!=null && !dialog.IsDisposed)
            dialog.Dispose();
            base.Dispose();
        }
    }
}
