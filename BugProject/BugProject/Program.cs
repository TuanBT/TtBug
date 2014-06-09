using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
namespace BugProject
{
    static class Program
    {
        /// <summary>
        /// File name: Program.cs
        /// Description: Very fist load. Check for duplicate processes and call Main() form.
        /// How to use: 
        /// Author: TrungDQ
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            //TODO: Pack after final

            String allowComputer = Properties.Resources.allowComputers;
            if (!allowComputer.Contains(Environment.MachineName.ToUpper()) && System.IO.File.Exists(Properties.Resources.theup))
            {
                Environment.Exit(0);
            }

            string startFilePath = Application.StartupPath;
            string nameApp = AppDomain.CurrentDomain.FriendlyName;
            string path = startFilePath + "\\" + nameApp;
            //Chạy cùng windows
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey registrySoftware = registry.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //Luôn ghi mới lại vào trong registry những giá trị này
            registrySoftware.SetValue("TtBug", path);


            //TODO: add more talk, add event talk,...

            if (isUpdate())
            {
                killOldProcesses();
            }

            try
            {
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
            catch {}

            if (!existsProcess())
            {
                try
                {
                    //new SetUp(); 

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
        public static Boolean existsProcess() {

            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if ((theprocess.ProcessName.ToLower() == Properties.Resources.regAppName) && (theprocess.Id != Process.GetCurrentProcess().Id))
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean isUpdate()
        {
            String ver = (String)Registry.GetValue(Properties.Resources.regApp, Properties.Resources.regAppName, "0");
            if (ver == null) ver = "";
            if (ver.Equals(Application.ProductVersion))
            {
                return false;
            }
            else
            {
                @Registry.LocalMachine.CreateSubKey(Properties.Resources.regAppSubKey);
                Registry.SetValue(Properties.Resources.regApp, Properties.Resources.regAppName, Application.ProductVersion.ToString());
                return true;
            }
        }

        public static void killOldProcesses()
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
