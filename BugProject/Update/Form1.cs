using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Kiểm tra phiên bản trong máy
            var version = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\tTBugs", "tTBugs", "0");

            if (getVersiontTbugs("https://dl.dropboxusercontent.com/u/85277562/tTBugs/tTBugsVersion.txt") != version)
            {
                try
                {
                    runUpdate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Environment.Exit(0);
        }

        //Kiểm tra phiên bản trên mạng
        public string getVersiontTbugs(string url)
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

        public void runUpdate()
        {
            string pathTemptTbugsFile = Path.GetTempPath() + @"tTBugs.exe";
            string pathRootFile = "";

            //Xóa file trong temp
            File.Delete(pathTemptTbugsFile); //Trả về lỗi nếu file đã bị sử dụng.

            //Download file về temp
            var webClient = new WebClient();
            webClient.DownloadFile("https://dl.dropboxusercontent.com/u/85277562/tTBugs/tTBugs.exe", pathTemptTbugsFile);

            //Kiểm tra vị trí đặt file
            var registry = Registry.CurrentUser;
            var registrySoftware = registry.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
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

            Thread.Sleep(1000);

            //Xóa file cũ
            File.Delete(pathRootFile);

            //Chép đè file mới
            File.Move(pathTemptTbugsFile, pathRootFile);

            //khởi động
            Process.Start(pathRootFile);

            //Xóa file trong temp
            File.Delete(pathTemptTbugsFile);
        }
    }
}
