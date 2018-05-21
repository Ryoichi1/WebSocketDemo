
namespace WebSocketDemo
{
    public static class Constants
    {
        public static readonly string ATS_DEMO1 = @"wss://api.sakura.io/ws/v1/95c2a98b-a033-4b30-b58e-74467dd98476";
        public static readonly string ATS_DEMO2 = @"wss://api.sakura.io/ws/v1/a8bb5856-2410-435d-beae-c9e30e61ed3b";
        public static readonly string ATS_DEMO3 = @"wss://api.sakura.io/ws/v1/c81d8406-9a4f-47bd-bcd5-b9a284efc377";
        public static readonly string ATS_DEMO4 = @"wss://api.sakura.io/ws/v1/f7cbb345-dcf6-41da-8b86-5bdeca805498";

        public static readonly string filePath_Configuration = "";

        //5分
        public static readonly int Lev1_DispInterval = 60*5;
        public static readonly int Lev1_MajStep = 60*5/10;
        public static readonly int Lev1_Coefficient = 60*5/10;

        //10分
        public static readonly int Lev2_DispInterval = 60*10;
        public static readonly int Lev2_MajStep = 60*10/10;
        public static readonly int Lev2_Coefficient = 60*10/10;

        //30分
        public static readonly int Lev3_DispInterval = 60*30;
        public static readonly int Lev3_MajStep = 180;
        public static readonly int Lev3_Coefficient = 60*30/10;

        //1H
        public static readonly int Lev4_DispInterval = 60*60;
        public static readonly int Lev4_MajStep = 60*60/10;
        public static readonly int Lev4_Coefficient = 60*60/10;

        //12H
        public static readonly int Lev5_DispInterval = 60*60*12;
        public static readonly int Lev5_MajStep = 60*60*12/10;
        public static readonly int Lev5_Coefficient = 60*60*12/10;

        //24H
        public static readonly int Lev6_DispInterval = 60*60*24;
        public static readonly int Lev6_MajStep = 60*60*24/10;
        public static readonly int Lev6_Coefficient = 60*60*24/10;

    }
}
