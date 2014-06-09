using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BugProject
{
    class BugManager
    {
        public static List<Bug> bugList = new List<Bug>();
        public static List<Bug2> bugList2 = new List<Bug2>();

        public static void NewBug()
        {
            Bug b = new Bug_Free();
            b.Show();
            bugList.Add(b);
        }

        public static void NewBugFreeTalking(int talkTopic, Boolean talkCondition)
        {
            Bug btf = new Bug_Free_Talking(talkTopic, talkCondition);
            btf.Show();
            bugList.Add(btf);
        }

        public static void NewBugFreeTalking2(int talkTopic, Boolean talkCondition)
        {
            Bug2 btf = new Bug_Free_Talking2(talkTopic, talkCondition);
            btf.Show();
            bugList2.Add(btf);
        }

        public static void NewMoreBug() {
            Bug b = new Bug_Free();
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
            bugList.RemoveAt(0);
            foreach (Bug2 b in bugList2)
            {
                b.Dispose();
                break;
            }
            bugList2.RemoveAt(0);
        }

        public static void RemoveAllBug()
        {
            foreach (Bug b in bugList)
            {
                b.Dispose();
            }
            bugList.Clear();
            foreach (Bug2 b in bugList2)
            {
                b.Dispose();
            }
            bugList2.Clear();
        }
    }
}
