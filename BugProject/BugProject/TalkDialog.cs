using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BugProject
{
    public partial class TalkDialog : Form
    {
        public String strSay = "";
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        long oldWindowLong;
        public TalkDialog()
        {
            InitializeComponent();
            SetFormTransparent(this.Handle);

        }

        public void SetFormTransparent(IntPtr Handle)
        {
            oldWindowLong = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, Convert.ToInt32(oldWindowLong | 0x80000 | 0x20));
        }



        public TalkDialog(String say)
        {
            strSay = say;
            InitializeComponent();
            SetFormTransparent(this.Handle);
        }

        private void TalkDialog_Load(object sender, EventArgs e)
        {
            lbTalk.Text = strSay;
        }

    }
}
