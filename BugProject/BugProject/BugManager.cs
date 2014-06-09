using System.Drawing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BugProject
{
    class BugManager
    {
        public static List<Bug> bugList = new List<Bug>();

        public static void NewBug()
        {
            Bug b = new Bug_Free();
            b.Show();
            bugList.Add(b);
        }

        public static void NewBugFreeTalking(int talkTopic, Boolean talkCondition)
        {
            var btf = new Bug_Free_Talking(talkTopic, talkCondition);
            btf.Show();
            bugList.Add(btf);
        }

        public static void NewMoreBug() {
            var b = new Bug_Free();
            b.Show();
            bugList.Add(b);
        }

        public static void RemoveBug()
        {
            foreach (Bug b in bugList)
            {
                b.Dispose();
                break;
            }
        }

        public static void RemoveAllBug()
        {
            foreach (Bug b in bugList)
            {
                b.Dispose();
            }
            bugList.Clear();
        }
    }
}
