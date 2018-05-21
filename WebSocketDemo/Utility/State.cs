using System;
using System.Collections.Generic;

namespace WebSocketDemo
{

    public static class State
    {
        public enum MODE { DEBUG, NORMAL }
        public enum TARGET { DEMO_01, DEMO_02, DEMO_03, DEMO_04 }

        public enum INTERVAL_LEV { LEV1, LEV2, LEV3, LEV4, LEV5, LEV6 }

        public static  INTERVAL_LEV LevState;

        //データソース（バインディング用）
        public static ViewModelMainWindow VmMainWindow = new ViewModelMainWindow();
        public static ViewModelPage VmTestStatus = new ViewModelPage();

        //パブリックメンバ

        public static MODE Mode { get; set; } = MODE.NORMAL;

        public static TARGET Target { get; set; }

        public static int TotalTime { get; set; }

        public static int DispInterval { get; set; }

        public static int MajStep { get; set; }

        public static int NecessaryDataCnt { get; set; }

        public static string CurrDir { get; set; }

        public static string AssemblyInfo { get; set; }


        //通信で取得した計測データ
        public static double TempBme280 { get; set; }
        public static double HumidBme280 { get; set; }
        public static double PressBme280 { get; set; }
        public static double TempSdc10 { get; set; }
        public static double TempSdc15 { get; set; }

    }

}
