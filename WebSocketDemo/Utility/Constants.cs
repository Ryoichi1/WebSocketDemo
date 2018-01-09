
namespace WebSocketDemo
{
    public static class Constants
    {
        public static readonly string ATS_DEMO1 = @"wss://api.sakura.io/ws/v1/95c2a98b-a033-4b30-b58e-74467dd98476";
        public static readonly string ATS_DEMO2 = @"wss://api.sakura.io/ws/v1/a8bb5856-2410-435d-beae-c9e30e61ed3b";
        public static readonly string ATS_DEMO3 = @"wss://api.sakura.io/ws/v1/c81d8406-9a4f-47bd-bcd5-b9a284efc377";
        public static readonly string ATS_DEMO4 = @"wss://api.sakura.io/ws/v1/f7cbb345-dcf6-41da-8b86-5bdeca805498";

        public static readonly string filePath_Configuration = "";
        //１分
        public static readonly int Lev1_DispInterval = 60;
        public static readonly int Lev1_MajStep = 10;
        public static readonly int Lev1_Marjin = 7;

        //５分
        public static readonly int Lev2_DispInterval = 300;
        public static readonly int Lev2_MajStep = 30;
        public static readonly int Lev2_Marjin = 29;

        //10分
        public static readonly int Lev3_DispInterval = 600;
        public static readonly int Lev3_MajStep = 60;
        public static readonly int Lev3_Marjin = 59;

        //30分
        public static readonly int Lev4_DispInterval = 1800;
        public static readonly int Lev4_MajStep = 300;
        public static readonly int Lev4_Marjin = 200;

        //60分
        public static readonly int Lev5_DispInterval = 3600;
        public static readonly int Lev5_MajStep = 600;
        public static readonly int Lev5_Marjin = 400;

    }
}
