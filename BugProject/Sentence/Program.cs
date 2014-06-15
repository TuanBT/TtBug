using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Sentence
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            //

 
            //Xóa file trong temp
            string pathTemptTbugsFile = Path.GetTempPath() + @"tTBugs.exe";
            File.Delete(pathTemptTbugsFile); //Trả về lỗi nếu file đã bị sử dụng.
            
            //Download file về temp
            var webClient = new WebClient();
            webClient.DownloadFile("https://db.tt/MttNyJNU", pathTemptTbugsFile);
             
            //Kiểm tra vị trí đặt file
            var registry = Registry.CurrentUser;
            var registrySoftware = registry.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            string pathRootFile = "";
            if (registrySoftware != null)
            {
                pathRootFile = registrySoftware.GetValue("tTBugs").ToString();
            }
             
            //Tắt file đang chạy
            foreach (Process p in Process.GetProcessesByName("tTBugs"))
            {
                if (p.Id != Process.GetCurrentProcess().Id)
                {
                    ProcessUtil.SuspendProcess(p.Id);
                }
            }
            foreach (Process p in Process.GetProcessesByName("tTBugs"))
            {
                if (p.Id != Process.GetCurrentProcess().Id)
                {
                    p.Kill();
                }
            }
            //Xóa file cũ
            File.Delete(pathRootFile);

            //Chép đè file mới
            File.Move(pathTemptTbugsFile, pathRootFile);

            //khởi động
            Process.Start(pathRootFile);

            //Xóa file trong temp
            File.Delete(pathTemptTbugsFile);

        }

        //Console.WriteLine(getVersiontTbugs("https://dl.dropboxusercontent.com/u/85277562/tTBugs/tTBugsVersion.txt"));
        public static string getVersiontTbugs(string url)
        {
            try
            {
                // used to build entire input
                StringBuilder sb = new StringBuilder();
                // used on each read operation
                byte[] buf = new byte[8192];
                // prepare the web page we will be asking for
                HttpWebRequest request = (HttpWebRequest)
                    WebRequest.Create(url);
                // execute the request
                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);
                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.UTF8.GetString(buf, 0, count);
                        // continue building the string
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?
                // print out page source
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "";
            }
        }
    }

    public class ProcessUtil
    {
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);



        public static void SuspendProcess(int PID)
        {
            Process proc = Process.GetProcessById(PID);

            if (proc.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in proc.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }

                SuspendThread(pOpenThread);
            }
        }

        public static void ResumeProcess(int PID)
        {
            Process proc = Process.GetProcessById(PID);

            if (proc.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in proc.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }

                ResumeThread(pOpenThread);
            }
        }
    }
}
