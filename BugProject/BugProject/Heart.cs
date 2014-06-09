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
    public partial class Heart : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        long oldWindowLong;
        public Heart()
        {
            InitializeComponent();
            BackColor = Color.White;
            TransparencyKey = Color.White;
            SetFormTransparent(this.Handle);
        }

        public void SetFormTransparent(IntPtr Handle)
        {
            oldWindowLong = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, Convert.ToInt32(oldWindowLong | 0x80000 | 0x20));
        }

        public void SetFormNormal(IntPtr Handle)
        {
            SetWindowLong(Handle, -20, Convert.ToInt32(oldWindowLong | 0x80000));
        }
    }
}
