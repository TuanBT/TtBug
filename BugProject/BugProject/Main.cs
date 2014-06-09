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

        public Main()
        {
            InitializeComponent();

            CONSTANT.normalImage = Properties.Resources.lion1;
            CONSTANT.specialImage = Properties.Resources.lion2;
            CONSTANT.normalTalk = Properties.Resources.talkSentences.Split('\n');
            CONSTANT.goodnightTalk = Properties.Resources.talkGoodNight.Split('\n');
            BugManager.NewBugFreeTalking(1, true);

            CONSTANT.normalImage = Properties.Resources.chickenA1;
            CONSTANT.specialImage = Properties.Resources.chickenA2;
            CONSTANT.normalTalk = Properties.Resources.talkSentences2.Split('\n');
            CONSTANT.goodnightTalk = Properties.Resources.talkGoodNight2.Split('\n');
            BugManager.NewBugFreeTalking(1, true);

            tmrMeet.Interval = 4000;
            tmrMeet.Start();
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
            BugManager.NewMoreBug();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BugManager.RemoveAllBug();
        }


        private void btnTalking_Click(object sender, EventArgs e)
        {
            BugManager.NewBugFreeTalking(1,true);
        }

        public bool IsMeet(Bug b1,Bug b2)
        {
            int t1 = b1.Top;
            int l1 = b1.Left;

            int t2 = b2.Top;
            int l2 = b2.Left;


            double disance = Math.Sqrt(Math.Pow((t1 - t2),2) + Math.Pow((l1 - l2),2));
            if(disance<=b1.Width)
            {
                return true;
            }
            return false;
        }

        private void tmrMeet_Tick(object sender, EventArgs e)
        {
            tmrMeet.Interval = 200;
            Bug b1 = BugManager.bugList[0];
            Bug b2 = BugManager.bugList[1];

           if(IsMeet(b1,b2))
           {
             b1.StartLove(CONSTANT.timeShowHeart);
             b2.StopMove();
             tmrMeet.Interval = 10*1000;
           }
        }

        private void tmrEvent_Tick(object sender, EventArgs e)
        {
             int nowHour = DateTime.Now.Hour;
             Bug b1 = BugManager.bugList[0];
             Bug b2 = BugManager.bugList[1];

            //Chúc ngủ ngon
            if(nowHour>=22 && nowHour<=4)
            {
                //Cho viec nhay vao giuong ngu
            }
        }
    }
}
