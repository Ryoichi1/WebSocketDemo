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

    }

}

