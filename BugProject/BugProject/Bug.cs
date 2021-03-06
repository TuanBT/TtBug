﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BugProject
{
    /// <summary>
    /// File name: Bug.cs
    /// Description: Basic class of bug: rotating, moving, talking...
    /// How to use: Create new child class and add more function to maintan
    /// Author: TrungDQ + TuanBT
    /// </summary>

    public partial class Bug : Form
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

        public Image normalImage;
        public Image specialIamge;

        private int exsilonTalkLeft = 10;
        private int exsilonTalkHeight = -110;

        private int exsilonHeartLeft = -10;
        private int exsilonHeartHeight = -30;

        const int step = 5;
        const int appr = 50;

        int toTop, toLeft;
        double stepRatio = 0;
        int hDis = 0;
        int wDis = 0;
        int whDis = 0;

        Action<Boolean> callBack;

        private bool ignorMouse = false; //Bỏ qua sự tác động của chuộ. Tức là đụng vào cũng không di chuyển

        Form frmTalkDialog;
        private Form frmHeart;
        public Boolean isTalking = false;
        private bool stopMove = false;

        public Bug()
        {
            InitializeComponent();
            normalImage = CONSTANT.normalImage;
            specialIamge = CONSTANT.specialImage;
            picNormal.Image = normalImage;
            BackColor = Color.White;
            TransparencyKey = Color.White;
            this.Opacity = CONSTANT.opacityBug;
            SetFormTransparent(this.Handle);
        }


        public int GetLeft()
        {
            return this.Left;
        }

        public void ChangeIamge(Image image)
        {
            picNormal.Image = image;
        }

        public void AppearLocation(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }


        private Bitmap RotateImage(Bitmap b, float angle)
        {
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        public void RotateBugImage(int degree)
        {
            //this.picNormal.Image = this.RotateImage((Bitmap)picNormal.Image, degree);
        }

        //More function for basic bug: talk, ...

        public void RotateBug(Point p)
        {
            double angle = 0;
            if (p.Y == 0)
            {
                if (p.X > 0)
                {
                    angle = 0;
                }
                else if (p.X < 0)
                {
                    angle = Math.PI;
                }
            }
            else if (p.Y > 0)
            {
                angle = Math.Atan(p.X * 1.0 / p.Y);
            }
            else if (p.Y < 0)
            {
                if (p.X > 0)
                {
                    angle = Math.PI + Math.Atan(p.X * 1.0 / p.Y);
                }
                else if (p.X < 0)
                {
                    angle = Math.PI + Math.Atan(p.X * 1.0 / p.Y);
                }
                else if (p.X == 0)
                {
                    angle = Math.PI;
                }
            }

            int degree = Convert.ToInt32(angle * 180 / Math.PI);
            RotateBugImage(degree);
        }


        private Point ChangeToDecac(int fromLeft, int fromTop, int toLeft, int toTop)
        {
            int x = fromLeft - toLeft;
            int y = fromTop - toTop;
            x *= -1;
            return new Point(x, y);
        }

        //Điều khiển xuất hiện bằng tay
        public void AppearTo(int left, int top)
        {
            tmrAppear.Tick += new EventHandler((sender, e) => tmrAppear_Tick(sender, e, left, top));
            tmrAppear.Interval = 100;
            tmrAppear.Start();
        }

        private void tmrAppear_Tick(object sender, EventArgs e, int left, int top)
        {
            if (this.Left != left && this.Top != top)
            {
                this.Opacity -= 0.1;
                if (this.Opacity == 0)
                {
                    this.Left = left;
                    this.Top = top;
                    this.Opacity = 0.1;
                }
                return;
            }

            this.Opacity += 0.1;
            if (this.Opacity >= 0.5)
            {
                this.Opacity = 0.5;
                tmrAppear.Stop();
                return;
            }
        }

        public void MoveBug(int left, int top, int speed, Action<Boolean> c)
        {
            //Neu dung chay de noi, va chuot khong di vao thi phai dung lai
            if (stopMove && speed != 1 || VARIABLE.isStand || ignorMouse)
            {
                left = this.Left;
                top = this.Top;
            }

            RotateBug(ChangeToDecac(this.Left, this.Top, left, top));

            toTop = top;
            toLeft = left;
            hDis = Math.Abs(this.Top - toTop);
            wDis = Math.Abs(this.Left - toLeft);
            whDis = Convert.ToInt32(Math.Sqrt(hDis * hDis + wDis * wDis));
            stepRatio = step * 1.0 / whDis;

            timer1.Interval = speed;
            timer1.Start();

            callBack = c;
        }

        private void Bug_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (VARIABLE.isStand)
            {
                timer1.Stop();
                callBack(true);
            }
            if (Math.Sqrt((this.Top - toTop) * (this.Top - toTop) + (this.Left - toLeft) * (this.Left - toLeft)) > appr)
            {
                int fromLeft = this.Left;
                int fromTop = this.Top;

                if (fromLeft > toLeft)
                {
                    this.Left = fromLeft - Convert.ToInt32(wDis * stepRatio);
                }
                else if (fromLeft < toLeft)
                {
                    this.Left = fromLeft + Convert.ToInt32(wDis * stepRatio);
                }
                if (fromTop > toTop)
                {
                    this.Top = fromTop - Convert.ToInt32(hDis * stepRatio);
                }
                else if (fromTop < toTop)
                {
                    this.Top = fromTop + Convert.ToInt32(hDis * stepRatio);
                }
            }
            else
            {
                timer1.Stop();
                callBack(true);
            }
        }

        private void tmrTalk_Tick(object sender, EventArgs e)
        {
            //Edit Position
            frmTalkDialog.Left = this.Left + exsilonTalkLeft;
            frmTalkDialog.Top = this.Top + exsilonTalkHeight;
        }

        //Dừng không chạy nữa. Đồng thời dừng hết các hoạt động nói năng
        public void Stand()
        {
            StopTalk();
            StopLove();
            VARIABLE.isStand = true;
            VARIABLE.accepTalk = false;

        }

        //Dừng không chạy nữa
        public void ContinousRun()
        {
            VARIABLE.isStand = false;
            VARIABLE.accepTalk = true;
        }

       

        private void tmrStandLove_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            picNormal.Image = normalImage;
            stopMove = false;
            tmrStandLove.Stop();
        }

        public void StartTalk(String say, int milisecond)
        {
            if (!VARIABLE.accepTalk)
            {
                return;
            }
            if (isTalking)
            {
                StopTalk();
            }

            //Dung tu di chuyen
            timer1.Enabled = false;
            stopMove = true;

            //Co the them lenh chuyen qua hinh khac khi noi
            picNormal.Image = specialIamge;

            frmTalkDialog = new TalkDialog(say);
            frmTalkDialog.Left = this.Left + exsilonTalkLeft;
            frmTalkDialog.Top = this.Top + exsilonTalkHeight;
            frmTalkDialog.Show();
            isTalking = true;
            tmrTalk.Start();
            tmrCountDown.Interval = milisecond;
            tmrCountDown.Start();
        }
        public void StopTalk()
        {
            timer1.Enabled = true;
            try
            {
                //Chuyen ve hinh cu
                picNormal.Image = normalImage;
                stopMove = false;

                frmTalkDialog.Dispose();
                frmTalkDialog = null;
                tmrTalk.Stop();
                isTalking = false;
            }
            catch { }
        }

        private void tmrHeart_Tick(object sender, EventArgs e)
        {
            //frmHeart.Left = this.Left + exsilonHeartLeft;
            //frmHeart.Top = this.Top + exsilonHeartHeight;
        }

        public void StartLove(int milisecond,bool isShowHeart, Image loveIamge)
        {
            //Co the them lenh chuyen qua hinh khac khi noi
            timer1.Enabled = false;
            picNormal.Image = loveIamge;
            stopMove = true;
            VARIABLE.accepTalk = false;

            if (isShowHeart)
            {
                frmHeart = new Heart();
                frmHeart.Left = this.Left + exsilonHeartLeft;
                frmHeart.Top = this.Top + exsilonHeartHeight;
                frmHeart.Show();
            }
            //isTalking = true;
            //tmrHeart.Start();
            tmrCountDown.Interval = milisecond;
            tmrCountDown.Start();
        }

        public void StopLove()
        {
            
            try
            {
                frmHeart.Dispose();
                frmHeart = null;
            }
            catch { }
            timer1.Enabled = true;
            VARIABLE.accepTalk = true;
        }

        private void tmrCountDown_Tick(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            StopTalk();
            StopLove();
        }

        private void Bug_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTalk();
        }


    }
}
