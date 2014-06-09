using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BugProject
{
    class Bug_Free_Talking : Bug_Free
    {
        public string[] talkSentence = Properties.Resources.talkSentences.Split('\n');
        public string[] talkGoodNightSentence = Properties.Resources.talkGoodNight.Split('\n');
        public string[] talkDontKillMe = Properties.Resources.talkDontKill.Split('@');
        public string[] talkGoodBye = Properties.Resources.talkGoodBye.Split('@');
        public string fileNormalName = "TtBugTuanBTNormal.txt";
        public string fileGoodNightName = "TtBugTuanBTGoodNight.txt";
        private int talkRandomTimerMin = CONSTANT.talkRandomTimerMin;
        private int talkRandomTimerMax = CONSTANT.talkRandomTimerMax;
        private int talkTime = CONSTANT.talkTime;
        private int checkGoodNightTime = CONSTANT.checkGoodNightTime;
        Boolean talkRandomBug = false;
        Boolean talkConditionBug = true;
        Boolean talkGoodByeBug = false;
        private int getSentenceTime = CONSTANT.getSentenceTime;

        Random rand = new Random();

        private System.Windows.Forms.Timer tmrRandomTalk;
        private Timer tmrGoodNight;
        private Timer tmrGetSentence;
        private System.ComponentModel.IContainer components;

        public Bug_Free_Talking(int talkTopic, Boolean talkCondition)
        {
            InitializeComponent();
            tmrGetSentence.Interval = getSentenceTime;
            //tmrGetSentence.Start();
            switch (talkTopic)
            {
                case 0:
                    talkRandomBug = false;
                    break;
                case 1:
                    talkRandomBug = true;
                    break;
                case 2:
                    talkGoodByeBug = true;
                    break;
                default:
                    talkRandomBug = false;
                    break;
            }
            talkConditionBug = talkCondition;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrRandomTalk = new System.Windows.Forms.Timer(this.components);
            this.tmrGoodNight = new System.Windows.Forms.Timer(this.components);
            this.tmrGetSentence = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrRandomTalk
            // 
            this.tmrRandomTalk.Tick += new System.EventHandler(this.tmrRandomTalk_Tick);
            // 
            // tmrGoodNight
            // 
            this.tmrGoodNight.Tick += new System.EventHandler(this.tmrGoodNight_Tick);
            // 
            // tmrGetSentence
            // 
            this.tmrGetSentence.Enabled = true;
            this.tmrGetSentence.Interval = 60000;
            this.tmrGetSentence.Tick += new System.EventHandler(this.tmrGetSentence_Tick);
            // 
            // Bug_Free_Talking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(64, 39);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Bug_Free_Talking";
            this.Load += new System.EventHandler(this.Bug_Free_Talking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private string ranTalk()
        {
            if (talkRandomBug)
            {
                return talkSentence[rand.Next(0, talkSentence.Length)];
            }
            else if (talkGoodByeBug)
            {
                return talkGoodBye[rand.Next(0, talkGoodBye.Length)];
            }
            else
            {
                return "";
            }
        }

        private void tmrRandomTalk_Tick(object sender, EventArgs e)
        {
            this.StartTalk(ranTalk(), talkTime);
            tmrRandomTalk.Interval = rand.Next(talkRandomTimerMin, talkRandomTimerMax);
        }

        private void Bug_Free_Talking_Load(object sender, EventArgs e)
        {
            if (talkRandomBug || talkGoodByeBug)
            {
                tmrRandomTalk.Interval = rand.Next(talkRandomTimerMin, talkRandomTimerMax);
                tmrRandomTalk.Start();

                if (talkGoodByeBug)
                {
                    BeginTalk();
                }
            }
            if (talkConditionBug)
            {
                //Talk conditions.
                tmrGoodNight.Interval = checkGoodNightTime;
                tmrGoodNight.Start();
            }
        }

        private void BeginTalk()
        {
            this.StartTalk(talkGoodBye[0], talkTime);
        }

        public void WriteToFile(string fileName, string[] content)
        {
            try
            {
                FileInfo myfile = new FileInfo(System.IO.Path.GetTempPath() + "//" + fileName);
                StreamWriter streamWriter = myfile.CreateText();
                for (int i = 0; i < content.Length - 1; i++)
                {
                    streamWriter.Write(content[i]);
                    streamWriter.Write(streamWriter.NewLine);
                }
                streamWriter.Write(talkSentence[content.Length - 1]);
                streamWriter.Close();
            }
            catch (Exception)
            {
            }

        }

        public string[] ReadFromFile(string fileName)
        {
            try
            {
                StreamReader streamReader = File.OpenText(System.IO.Path.GetTempPath() + "//" + fileName);
                string input = null;
                List<string> list = new List<string>();
                while ((input = streamReader.ReadLine()) != null)
                {
                    list.Add(input);
                }
                string[] result = new string[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    result[i] = list[i];
                }
                streamReader.Close();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void tmrGoodNight_Tick(object sender, EventArgs e)
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour > 22 || nowHour < 4)
            {
                this.StartTalk(talkGoodNightSentence[rand.Next(0, talkGoodNightSentence.Length)], talkTime);
                tmrGoodNight.Stop();
            }
        }

        private void tmrGetSentence_Tick(object sender, EventArgs e)
        {
            tmrGetSentence.Enabled = false;
            SentenceDB sentenceDb = new SentenceDB();
            talkSentence = sentenceDb.GetSentence(1, 1);
            if (talkSentence != null)
            {
                WriteToFile(fileNormalName, talkSentence);

            }
            else
            {
                talkSentence = ReadFromFile(fileNormalName);
                if (talkSentence == null)
                {
                    talkSentence = Properties.Resources.talkSentences.Split('\n');
                }
            }
            talkGoodNightSentence = sentenceDb.GetSentence(1, 2);
            if (talkGoodNightSentence != null)
            {
                WriteToFile(fileGoodNightName, talkGoodNightSentence);
            }
            else
            {
                talkGoodNightSentence = ReadFromFile(fileGoodNightName);
                if (talkGoodNightSentence == null)
                {
                    talkGoodNightSentence = Properties.Resources.talkGoodNight.Split('\n');
                }
            }
            tmrGetSentence.Enabled = true;
        }
    }
}
