using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BugProject
{
    public class CONSTANT
    {
        public static int talkRandomTimerMin = 20 *60* 1000; //20 minutes
        public static int talkRandomTimerMax = 30 *60 * 1000; //30 minutes
        //public static int talkRandomTimerMin = 5 * 1000; //10 sec--------
        //public static int talkRandomTimerMax = 10 * 1000; //15 sec-----------
        public static int talkTime = 10 * 1000; //10 seconds
        //public static int talkTime = 3 * 1000; //10 seconds----------------
        public static int checkGoodNightTime = 20 * 60 * 1000; //20 minutes
        //public static int checkGoodNightTime = 10 * 1000; //20 minutes
        //public static int getSentenceTime = 60 * 60 * 1000; //60 minutes

        public static int range = 300;
        public static int appr = 50;
        public static int standWaitingTimeMin = 1000; //Thời gian nhỏ nhất TheBug dừng suy nghĩ tìm hướng chạy
        public static int standWaitingTimeMax = 4000;
        public static int randomRotateMin = 700; //
        public static int randomRotateMax = 6000;
        public static int protectedRange = 100; //Vùng xung quanh chuột mà TheBug tránh xa
        public static double opacityBug = 0.3; //Độ mờ mặc định của Bug

        public static int timeMouseOn = 300; //Thời gian phản ứng khi có chuột đụng vào TheBug

        public static int timeShowHeart = 2 * 1000; //Thời gian hiện trái tim
        public static int timeEvent = 5 * 60 * 1000; // 5m Thời gian check sự kiện
        //public static int timeEvent = 45 * 1000; // 10s Thời gian check sự kiện--------------

        public static Image normalImage; //HÌnh mặc định của Bug
        public static Image specialImage; //Hình đặc biệt hơn của Bug như nói, love...
        public static string[] normalTalk; //List các câu nói bình thường
        public static string[] goodnightTalk; //List các câu goodnight

        public static int updateTime = 3*60*60*1000; //Thời gian check update

        
        public static int waitMeetTime = 10 * 1000; // 10s Số giây tối thiểu giữa 2 lần gặp nhau


    }
}
