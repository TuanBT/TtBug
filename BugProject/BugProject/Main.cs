using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace BugProject
{
    /// <summary>
    /// File name: Main.cs
    /// Description: Control and test bugs
    /// How to use: _Load() method controls to init bugs. Comment SetVisibleCore() void for test (to visible the form).
    /// Author: TrungDQ
    /// </summary>
    /// 

    public partial class Main : Form
    {
        Random rand = new Random();
        private Bug b1;
        private Bug b2;
        private House frmHouse;

        public Main()
        {
            InitializeComponent();

            CONSTANT.normalImage = Properties.Resources.chickenA1;
            CONSTANT.specialImage = Properties.Resources.chickenA2;
            CONSTANT.normalTalk = Properties.Resources.talkSentences2.Split('\n');
            //CONSTANT.goodnightTalk = Properties.Resources.talkGoodNight2.Split('\n');
            BugManager.NewBugFreeTalking(1, true);

            CONSTANT.normalImage = Properties.Resources.lion1;
            CONSTANT.specialImage = Properties.Resources.lion2;
            CONSTANT.normalTalk = Properties.Resources.talkSentences.Split('\n');
            //CONSTANT.goodnightTalk = Properties.Resources.talkGoodNight.Split('\n');
            BugManager.NewBugFreeTalking(1, true);

            b1 = BugManager.bugList[0];
            b2 = BugManager.bugList[1];

            tmrMeet.Interval = 4000;
            tmrMeet.Start();

            tmrEvent.Interval = CONSTANT.timeEvent;
            tmrEvent.Start();
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
        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                value = false;
                CreateHandle();
            }
            //value = true;
            base.SetVisibleCore(value);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //BugManager.NewMoreBug();

            //b1.Stand();
            //b1.Left = b2.Left;
            //b1.Top = b2.Top;
            //b1.AppearTo(b2.Left, b2.Top);
            //b1.ContinousRun();
            //Console.WriteLine(a+"--"+b1.GetLeft());
            //Form frmHouse;
            
            //b1.Opacity = 0;
            //b2.Opacity = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // BugManager.RemoveAllBug();
            frmHouse.Dispose();
            frmHouse.Close();
            SleepHouse = false;
        }


        private void btnTalking_Click(object sender, EventArgs e)
        {
            BugManager.NewBugFreeTalking(1, true);
        }

        public bool IsMeet(Bug b1, Bug b2)
        {
            int t1 = b1.Top;
            int l1 = b1.Left;

            int t2 = b2.Top;
            int l2 = b2.Left;


            double disance = Math.Sqrt(Math.Pow((t1 - t2), 2) + Math.Pow((l1 - l2), 2));
            if (disance <= b1.Width)
            {
                return true;
            }
            return false;
        }

        private void tmrMeet_Tick(object sender, EventArgs e)
        {
            tmrMeet.Interval = 200;
            if (IsMeet(b1, b2))
            {
                b1.StopTalk();
                b2.StopTalk();
                b1.StartLove(CONSTANT.timeShowHeart);
                b2.StopMoveLove();
                tmrMeet.Interval = 10 * 1000;
            }
        }


        private bool SleepHouse=false;
        private void tmrEvent_Tick(object sender, EventArgs e)
        {
            int nowHour = DateTime.Now.Hour;
            //Chúc ngủ ngon
            if (nowHour >= 1 && nowHour <= 4 || nowHour >= 12 && nowHour <= 1)
            {
                if (!SleepHouse)
                {
                    //Cho viec nhay vao nha
                    frmHouse = new House();
                    frmHouse.Left = Screen.PrimaryScreen.Bounds.Width - frmHouse.GetPicZise().Width;
                    frmHouse.Top = Screen.PrimaryScreen.WorkingArea.Height - frmHouse.GetPicZise().Height;
                    frmHouse.Show();

                    tmrMeet.Stop();
                    b1.Stand();
                    b2.Stand();
                    b1.AppearTo(frmHouse.Left + 10, frmHouse.Top + 20);
                    b2.AppearTo(frmHouse.Left + 10, frmHouse.Top + 20);
                    b1.Visible = false;
                    b2.Visible = false;
                }
                SleepHouse = true;
            }
            else
            {
                if (SleepHouse)
                {
                    tmrMeet.Interval = 10*1000;
                    tmrMeet.Start();
                    b1.ContinousRun();
                    b2.ContinousRun();
                    b1.Visible = true;
                    b2.Visible = true;
                    frmHouse.Dispose();
                    SleepHouse = false;
                }
            }
        }
    }
}
