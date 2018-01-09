using System;
using System.Collections.Generic;

namespace WebSocketDemo
{

    public static class State
    {
        public enum MODE { DEBUG, NORMAL }
        public enum TARGET { DEMO_01, DEMO_02, DEMO_03, DEMO_04 }

        //データソース（バインディング用）
        public static ViewModelMainWindow VmMainWindow = new ViewModelMainWindow();
        public static ViewModelPage VmTestStatus = new ViewModelPage();

        //パブリックメンバ
        public static Configuration Setting { get; set; }

        public static MODE Mode { get; set; } = MODE.NORMAL;

        public static TARGET Target { get; set; }

        public static string CurrDir { get; set; }

        public static string AssemblyInfo { get; set; }


        //通信で取得した計測データ
        public static double TempBme280 { get; set; }
        public static double HumidBme280 { get; set; }
        public static double PressBme280 { get; set; }
        public static double TempSdc10 { get; set; }
        public static double TempSdc15 { get; set; }

        //個別設定のロード
        public static void LoadConfData()
        {
            //Configファイルのロード
            Setting = Deserialize<Configuration>(Constants.filePath_Configuration);

            VmMainWindow.Theme = Setting.PathTheme;
            VmMainWindow.ThemeOpacity = Setting.OpacityTheme;

        }


        //インスタンスをXMLデータに変換する
        public static bool Serialization<T>(T obj, string xmlFilePath)
        {
            try
            {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlFilePath, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, obj);
                //ファイルを閉じる
                sw.Close();

                return true;

            }
            catch
            {
                return false;
            }

        }

        //XMLデータからインスタンスを生成する
        public static T Deserialize<T>(string xmlFilePath)
        {
            System.Xml.Serialization.XmlSerializer serializer;
            using (var sr = new System.IO.StreamReader(xmlFilePath, new System.Text.UTF8Encoding(false)))
            {
                serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        //********************************************************
        //個別設定データの保存
        //********************************************************
        public static bool SaveConfData()
        {
            try
            {
                //Configファイルの保存
                Setting.PathTheme = VmMainWindow.Theme;
                Setting.OpacityTheme = VmMainWindow.ThemeOpacity;

                Serialization<Configuration>(Setting, Constants.filePath_Configuration);

                return true;
            }
            catch
            {
                return false;

            }

        }

    

    }

}
