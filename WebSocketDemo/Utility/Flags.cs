using System.Windows.Media;

namespace WebSocketDemo
{
    public static class Flags
    {
        public static bool CanExe { get; set; }
        
        public static bool IsActiveGetData { get; set; }
        public static bool IsActiveGetDataMock { get; set; }
        public static bool IsActiveSensing { get; set; }
        public static bool IsActiveDisp { get; set; }


        public static bool OtherPage { get; set; }

        //試験開始時に初期化が必要なフラグ
        public static bool Connection { get; set; }
        public static bool Testing { get; set; }


        private static SolidColorBrush RetryPanelBrush = new SolidColorBrush();
        private static SolidColorBrush StatePanelOkBrush = new SolidColorBrush();
        private static SolidColorBrush StatePanelNgBrush = new SolidColorBrush();
        private const double StatePanelOpacity = 0.3;

        static Flags()//コンストラクタ
        {
            RetryPanelBrush.Color = Colors.DodgerBlue;
            RetryPanelBrush.Opacity = StatePanelOpacity;

            StatePanelOkBrush.Color = Colors.DodgerBlue;
            StatePanelOkBrush.Opacity = StatePanelOpacity;

            StatePanelNgBrush.Color = Colors.DeepPink;
            StatePanelNgBrush.Opacity = StatePanelOpacity;
        }

        public static bool GetActiveState()
        {
            return IsActiveGetData || IsActiveGetDataMock || IsActiveSensing || IsActiveDisp;
        }

    }
}
