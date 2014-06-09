using System;
using System.Collections.Generic;
using System.Text;

namespace BugProject
{
    public class CONSTANT
    {
        public static int talkRandomTimerMin = 10 *60* 1000; //10 minutes
        public static int talkRandomTimerMax = 15 *60 * 1000; //15 minutes
        public static int talkTime = 10 * 1000; //10 seconds
        public static int checkGoodNightTime = 20 * 60 * 1000; //20 minutes
        public static int getSentenceTime = 60 * 60 * 1000; //60 minutes

        public static int range = 300;
        public static int appr = 50;
        public static int standWaitingTimeMin = 1000; //Thời gian nhỏ nhất TheBug dừng suy nghĩ tìm hướng chạy
        public static int standWaitingTimeMax = 4000;
        public static int randomRotateMin = 700; //
        public static int randomRotateMax = 6000;
        public static int protectedRange = 100; //Vùng xung quanh chuột mà TheBug tránh xa

        public static int timeMouseOn = 500; //Thời gian phản ứng khi có chuột đụng vào TheBug

        public static int timeShowHeart = 2*1000; //Thời gian hiện trái tim
    }
}
