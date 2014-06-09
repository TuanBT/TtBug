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
        private void Main_Load(object sender, EventArgs e)
        {
            int dayNum = HowManyDay();

            if (dayNum <= 3) //from 0 to 3
            {
                //Call some friends
                for (int i = 0; i < dayNum; ++i)
                {
                    Thread.Sleep(50);
                    BugManager.NewBug();
                }
            }
            else if (dayNum <= 9) //from 4 to 9
            {
                //Talk something
                BugManager.NewBugFreeTalking(1, true);
                Thread.Sleep(50);
                BugManager.NewBugFreeTalking(0, true);
            }
            else if (dayNum <= 10) // day 10
            {
                //Say goodbye
                BugManager.NewBugFreeTalking(2, true);
            }
            else if (dayNum > 10) // The end
            {
                //Be good!
                //SetUp.SelfKill();
            }
        }

        public Main()
        {
            InitializeComponent();
            BugManager.NewBugFreeTalking(1, true);
            BugManager.NewBugFreeTalking2(1, true);
            tmrMeet.Interval = 400;
            tmrMeet.Start();
            //Main_Load(null, null);
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


        public int HowManyDay()
        {
            object c = Registry.GetValue(Properties.Resources.regApp, Properties.Resources.regDate, "0");

            if (c == null)
            {
                Registry.LocalMachine.CreateSubKey(Properties.Resources.regDate);
                Registry.SetValue(Properties.Resources.regApp, Properties.Resources.regDate, DateTime.Today.ToString());
                return 0;
            }
            else
            {
                if (((String)c).Equals("0"))
                {
                    Registry.SetValue(Properties.Resources.regApp, Properties.Resources.regDate, DateTime.Today.ToString());
                    return 0;
                }
                else
                {
                    DateTime dt = DateTime.Parse(((String)c));
                    return DateTime.Today.Subtract(dt).Days;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BugManager.RemoveAllBug();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Bug_Test bt = new Bug_Test();
            bt.Show();
        }

        private void btnTalking_Click(object sender, EventArgs e)
        {
            BugManager.NewBugFreeTalking(1,true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BugManager.NewBugFreeTalking2(1, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        Random random = new Random();
        public bool IsMeet(Bug b1,Bug2 b2)
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
            Bug2 b2 = BugManager.bugList2[0];

           if(IsMeet(b1,b2))
           {
             b1.StartLove(CONSTANT.timeShowHeart);
             b2.StopMove();
             tmrMeet.Interval = 10*1000;
           }
        }
    }
}
