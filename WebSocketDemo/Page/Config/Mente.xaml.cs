using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Threading;

namespace WebSocketDemo
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Mente
    {
        private SolidColorBrush ButtonOnBrush = new SolidColorBrush();
        private SolidColorBrush ButtonOffBrush = new SolidColorBrush();
        private const double ButtonOpacity = 0.4;

        public Mente()
        {
            InitializeComponent();
            this.DataContext = State.VmTestStatus;
            SetTarget();
            canvasSelectTarget.IsEnabled = !Flags.GetActiveState();
        }

        private void SetTarget()
        {
            switch (State.Target)
            {
                case State.TARGET.DEMO_01:
                    rb01.IsChecked = true;
                    break;
                case State.TARGET.DEMO_02:
                    rb02.IsChecked = true;
                    break;
                case State.TARGET.DEMO_03:
                    rb03.IsChecked = true;
                    break;
                case State.TARGET.DEMO_04:
                    rb04.IsChecked = true;
                    break;
            }
        }

        private void tbCommLog_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tbCommLog.ScrollToEnd();
        }

        private void rb01_Checked(object sender, RoutedEventArgs e)
        {
            State.Target = State.TARGET.DEMO_01;
            General.ShowTargetAdr();
        }

        private void rb02_Checked(object sender, RoutedEventArgs e)
        {
            State.Target = State.TARGET.DEMO_02;
            General.ShowTargetAdr();
        }

        private void rb03_Checked(object sender, RoutedEventArgs e)
        {
            State.Target = State.TARGET.DEMO_03;
            General.ShowTargetAdr();
        }

        private void rb04_Checked(object sender, RoutedEventArgs e)
        {
            State.Target = State.TARGET.DEMO_04;
            General.ShowTargetAdr();
        }
    }
}
