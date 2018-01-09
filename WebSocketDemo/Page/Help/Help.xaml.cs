using System;
using System.Windows;
using System.Windows.Navigation;

namespace WebSocketDemo
{
    /// <summary>
    /// Help.xaml の相互作用ロジック
    /// </summary>
    public partial class Help
    {
        private NavigationService naviVerInfo;
        Uri uriVerInfoPage = new Uri("Page/Help/VerInfo.xaml", UriKind.Relative);

        public Help()
        {
            InitializeComponent();
            naviVerInfo = FrameVerInfo.NavigationService;

            FrameVerInfo.NavigationUIVisibility = NavigationUIVisibility.Hidden;

        }

        private void TabVerInfo_Loaded(object sender, RoutedEventArgs e)
        {
            naviVerInfo.Navigate(uriVerInfoPage);
        }


    }
}
