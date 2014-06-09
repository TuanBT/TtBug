using System;
using System.Diagnostics;
using System.Windows.Forms;
//Bug_Free2
namespace BugProject
{

    /// <summary>
    /// File name: Bug_Free.cs
    /// Description: Free Mode - bug run random and stay away from mouse
    /// How to use: Create new instance and call Show() method
    /// Author: TrungDQ + TuanBT
    /// </summary>
    class Bug_Free2 : Bug2
    {
        #region Winform design

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.ComponentModel.IContainer components;
    
        public Bug_Free2() {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // Bug_Free2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(64, 39);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Bug_Free2";
            this.Load += new System.EventHandler(this.Bug_Free_Load);
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
#endregion

        Random ran = new Random();
        int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private int range = CONSTANT.range;
        private int appr = CONSTANT.appr;
        private int standWaitingTimeMin = CONSTANT.standWaitingTimeMin;
        private int standWaitingTimeMax = CONSTANT.standWaitingTimeMax;
        private int randomRotateMin = CONSTANT.randomRotateMin;
        private int randomRotateMax = CONSTANT.randomRotateMax;
        private int protectedRange = CONSTANT.protectedRange;

        private void Bug_Free_Load(object sender, EventArgs e)
        {
            AppearLocation(width / 2, height / 2);
            timer4.Interval = CONSTANT.timeMouseOn;
            timer4.Start();
            Action();
        }

        private object MoveDone(Boolean ok)
        {
            timer4.Start();
            timer2.Interval = ran.Next(standWaitingTimeMin, standWaitingTimeMax);
            timer2.Start();
            timer3.Interval = ran.Next(randomRotateMin, randomRotateMax);
            timer3.Start();
            return null;
        }


        public int DetermindLeft(int left)
        {
            int newLeft = -1;
            while (newLeft < 0 || newLeft > width || Math.Abs(newLeft - left) * 2 <= appr || (newLeft > Cursor.Position.X - protectedRange && newLeft < Cursor.Position.X + protectedRange))
            {
                int ranNum = ran.Next(-range, range);
                newLeft = left + ranNum;
            }
            return newLeft;
        }

        public int DetermindTop(int top)
        {
            int newTop = -1;
            while (newTop < 0 || newTop > height || Math.Abs(newTop - top) * 2 <= appr || (newTop > Cursor.Position.Y - protectedRange && newTop < Cursor.Position.Y + protectedRange))
            {
                int ranNum = ran.Next(-range, range);
                newTop = top + ranNum;
            }
            return newTop;
        }

        public void Action()
        {
            int left = DetermindLeft(this.Left);
            int top = DetermindTop(this.Top);
            int speed;
            if (timer4.Enabled == true)
            {
                speed = ran.Next(10, 100);
            }
            else
            {
                speed = 1;
            }
            MoveBug(left, top, speed, (result) => MoveDone(result));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            Action();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            RotateBugImage(ran.Next(0, 360));
            timer3.Interval = ran.Next(700, 1000);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (this.Left > Cursor.Position.X - protectedRange && this.Left < Cursor.Position.X + protectedRange)
            {
                if (this.Top > Cursor.Position.Y - protectedRange && this.Top < Cursor.Position.Y + protectedRange)
                {
                    timer4.Stop();
                    Action();
                }
            }
        }
    }
}
