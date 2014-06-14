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
    public partial class House : Form
    {

        #region Trong suot
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        long oldWindowLong;
        public void SetFormTransparent(IntPtr Handle)
        {
            oldWindowLong = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, Convert.ToInt32(oldWindowLong | 0x80000 | 0x20));
        }

        public void SetFormNormal(IntPtr Handle)
        {
            SetWindowLong(Handle, -20, Convert.ToInt32(oldWindowLong | 0x80000));
        }
        #endregion

        private int mainLeft;
        private int mainTop;

        public House()
        {
            InitializeComponent();
            BackColor = Color.White;
            TransparencyKey = Color.White;
            SetFormTransparent(this.Handle);
            tmrCursor.Interval = 300;
            tmrCursor.Start();
        }

        private void House_Load(object sender, EventArgs e)
        {
            mainLeft = this.Left;
            mainTop = this.Top;
        }

        public Size GetPicZise()
        {
            return new Size(pictureBox1.Width, pictureBox1.Height);
        }

        private void tmrCursor_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(this.Left + "---" + Cursor.Position.X);
            if (this.Left <= Cursor.Position.X && this.Left + pictureBox1.Width >= Cursor.Position.X)
            {
                //Console.WriteLine(Cursor.Position.X + "---" + Cursor.Position.Y);
                if (this.Top <= Cursor.Position.Y && this.Top + pictureBox1.Height >= Cursor.Position.Y)
                {
                    // MessageBox.Show("asd");
                    //this.Opacity = 0.1;
                    //this.Visible = false;
                    this.Top -= 200;

                }
            }
            else
            {
                //this.Opacity = 0.8;
                //this.Visible = true;
                this.Left = mainLeft;
                this.Top = mainTop;
            }
        }


    }
}
