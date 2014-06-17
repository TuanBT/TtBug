using BugProject.ImageForm;
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
        private EventImage frmEventIamge;

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

            b2 = BugManager.bugList[0];
            b1 = BugManager.bugList[1];

            tmrMeet.Interval = CONSTANT.waitMeetTime;
            tmrMeet.Start();

            tmrEvent.Interval = CONSTANT.timeEvent;
            tmrEvent.Start();

            tmrUpdate.Interval = 1 * 60 * 60 * 1000; //1h
            tmrUpdate.Start();
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
            //Process.Start(Path.GetTempPath() + "UpdatetTBugs.exe");
            b2.Left = b1.Left - b2.Width;
            b2.Top = b1.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // BugManager.RemoveAllBug();
            b1.Stand();
        }


        private void btnTalking_Click(object sender, EventArgs e)
        {
            //BugManager.NewBugFreeTalking(1, true);
        }

        public bool IsMeet(Bug b1, Bug b2)
        {
            int t1 = b1.Top;
            int l1 = b1.Left;

            int t2 = b2.Top;
            int l2 = b2.Left;


            double disance = Math.Sqrt(Math.Pow((t1 - t2), 2) + Math.Pow((l1 - l2), 2));
            if (disance < b1.Width)
            {
                return true;
            }
            return false;
            //return true;
        }

        private int countMeet = 0;
        private void tmrMeet_Tick(object sender, EventArgs e)
        {
            tmrMeet.Interval = 200;
            if (frmEventIamge != null)
            {
                frmEventIamge.Dispose();
                frmEventIamge = null;
                b1.ChangeIamge(Properties.Resources.lion1);
                b2.ChangeIamge(Properties.Resources.chickenA1);
                b1.Opacity = 0.5;
                b2.Opacity = 0.5;
                b1.ContinousRun();
                b2.ContinousRun();
                tmrMeet.Interval = CONSTANT.waitMeetTime;
                return;
            }
            if (IsMeet(b1, b2))
            {
                b1.TopMost = true;
                b1.TopLevel = true;
                b2.TopMost = true;
                b2.TopLevel = true;
                if (countMeet == CONSTANT.countMeet)
                {
                    b1.StopTalk();
                    b2.StopTalk();
                    b1.Stand();
                    b2.Stand();
                    countMeet = 0;


                    int numrand = rand.Next(1, 5); //Từ 1-4
                    if (numrand == 1)
                    {
                        //Code hien mua trai tim
                        b1.StartLove(CONSTANT.timeShowHeart, true, Properties.Resources.lion2);
                        b2.StartLove(CONSTANT.timeShowHeart, false, Properties.Resources.hatching_chicken_in_love);
                        frmEventIamge = new EventImage();
                        frmEventIamge.ChangeImage(Properties.Resources.heart_liebe);
                        frmEventIamge.ReziseForm();
                        frmEventIamge.Left = (b1.Left < b2.Left ? b1.Left : b2.Left) - b1.Width;
                        frmEventIamge.Top = (b1.Top < b2.Top ? b1.Top : b2.Top) - b1.Height;
                        frmEventIamge.Show();
                        //Thời gian hiển thị
                        tmrMeet.Interval = (5 * 1000) + 500; //5s30
                    }
                    if (numrand == 2)
                    {
                        //Code hien rain
                        frmEventIamge = new EventImage();
                        frmEventIamge.ChangeImage(Properties.Resources.Rain);
                        frmEventIamge.ReziseForm();
                        frmEventIamge.Left = (b1.Left < b2.Left ? b1.Left : b2.Left) - b1.Width;
                        frmEventIamge.Top = (b1.Top < b2.Top ? b1.Top : b2.Top) - b1.Height * 3 / 2;
                        frmEventIamge.Show();
                        //Thời gian hiển thị
                        tmrMeet.Interval = 5 * 1000; //5s
                    }
                    if (numrand == 3)
                    {
                        //Trời sao
                        b1.Opacity = 0;
                        b2.Opacity = 0;
                        b2.Left = b1.Left - b2.Width;
                        b2.Top = b1.Top;
                        frmEventIamge = new EventImage();
                        frmEventIamge.ChangeImage(Properties.Resources.StarSky);
                        frmEventIamge.ReziseForm();
                        frmEventIamge.Left = b1.Left - 210;
                        frmEventIamge.Top = b1.Top - 150;
                        frmEventIamge.Show();
                        //Thời gian hiển thị
                        tmrMeet.Interval = (2 * 1000) + 500; //2s30
                    }
                    if (numrand == 4)
                    {
                        //sét
                        frmEventIamge = new EventImage();
                        frmEventIamge.ChangeImage(Properties.Resources.Lightning_spin);
                        frmEventIamge.ReziseForm();
                        frmEventIamge.Left = b1.Left - 120;
                        frmEventIamge.Top = b1.Top - 100;
                        frmEventIamge.Show();
                        b1.ChangeIamge(Properties.Resources.lion1_black);
                        b2.ChangeIamge(Properties.Resources.chicken_black);
                        //Thời gian hiển thị
                        tmrMeet.Interval = 2 * 1000; // 2s
                    }
                }
                else
                {
                    countMeet++;
                    b1.StopTalk();
                    b2.StopTalk();
                    b1.StartLove(CONSTANT.timeShowHeart, true, Properties.Resources.lion2);
                    b2.StartLove(CONSTANT.timeShowHeart, false, Properties.Resources.hatching_chicken_in_love);
                    tmrMeet.Interval = CONSTANT.waitMeetTime;
                }
            }
        }


        private bool SleepHouse = false;
        private void tmrEvent_Tick(object sender, EventArgs e)
        {
            int nowHour = DateTime.Now.Hour;
            //Đi ngủ
            if (nowHour >= 0 && nowHour <= 4 || nowHour >= 12 && nowHour < 13)
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
                    tmrMeet.Interval = CONSTANT.waitMeetTime;
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

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            Process.Start(Path.GetTempPath() + "UpdatetTBugs.exe");
        }
    }
}
