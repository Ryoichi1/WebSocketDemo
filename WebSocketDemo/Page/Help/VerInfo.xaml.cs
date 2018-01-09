using System.Windows;

namespace WebSocketDemo
{
    /// <summary>
    /// VerInfo.xaml の相互作用ロジック
    /// </summary>
    public partial class VerInfo
    {
        public VerInfo()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbAssemblyVer.Text = "アセンブリVer " + State.AssemblyInfo;
        }
    }
}
