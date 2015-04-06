using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KilltTBug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcessesByName(Properties.Resources.regAppName))
            {
                if (p.Id != Process.GetCurrentProcess().Id)
                {
                    ProcessUtil.SuspendProcess(p.Id);
                }
            }
            foreach (Process p in Process.GetProcessesByName(Properties.Resources.protectorName))
            {
                ProcessUtil.SuspendProcess(p.Id);
            }

            ///////////////////////

            foreach (Process p in Process.GetProcessesByName(Properties.Resources.regAppName))
            {
                if (p.Id != Process.GetCurrentProcess().Id)
                {
                    p.Kill();
                }
            }
            foreach (Process p in Process.GetProcessesByName(Properties.Resources.protectorName))
            {
                p.Kill();
            }
        }
    }
}
