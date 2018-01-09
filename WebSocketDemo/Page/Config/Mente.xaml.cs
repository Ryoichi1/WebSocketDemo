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

        }



        private void tbCommLog_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tbCommLog.ScrollToEnd();
        }
    }
}
