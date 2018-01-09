using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Threading.Thread;

namespace WebSocketDemo
{


    public static class General
    {
        public static SolidColorBrush DialogOnBrush = new SolidColorBrush();
        public static SolidColorBrush OnBrush = new SolidColorBrush();
        public static SolidColorBrush OffBrush = new SolidColorBrush();
        public static SolidColorBrush NgBrush = new SolidColorBrush();


        static General()
        {
            OffBrush.Color = Colors.Transparent;

            DialogOnBrush.Color = Colors.DodgerBlue;
            DialogOnBrush.Opacity = 0.6;

            OnBrush.Color = Colors.DodgerBlue;
            OnBrush.Opacity = 0.4;

            NgBrush.Color = Colors.HotPink;
            NgBrush.Opacity = 0.4;
        }

        public static void ShowTargetAdr()
        {
            var adr = "";
            switch (State.Target)
            {
                case State.TARGET.DEMO_01:
                    adr = $"ATS DEMO 01    {Constants.ATS_DEMO1}";
                    break;
                case State.TARGET.DEMO_02:
                    adr = $"ATS DEMO 02    {Constants.ATS_DEMO2}";
                    break;
                case State.TARGET.DEMO_03:
                    adr = $"ATS DEMO 03    {Constants.ATS_DEMO3}";
                    break;
                case State.TARGET.DEMO_04:
                    adr = $"ATS DEMO 04    {Constants.ATS_DEMO4}";
                    break;
            }
            State.VmMainWindow.TargetAdr = adr;
        }


    }

}

