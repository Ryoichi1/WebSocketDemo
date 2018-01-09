using System;
using System.Windows;
using System.Windows.Navigation;

namespace WebSocketDemo
{
    /// <summary>
    /// Config.xaml の相互作用ロジック
    /// </summary>
    public partial class Conf
    {
        private NavigationService naviMente;
        Uri uriMentePage    = new Uri("Page/Config/Mente.xaml", UriKind.Relative);

        public Conf()
        {
            InitializeComponent();
            naviMente    = FrameMente.NavigationService;

            FrameMente.NavigationUIVisibility    = NavigationUIVisibility.Hidden;

            TabMenu.SelectedIndex = 0;

            // オブジェクト作成に必要なコードをこの下に挿入します。
        }

        private void TabMente_Loaded(object sender, RoutedEventArgs e)
        {
            naviMente.Navigate(uriMentePage);
        }

    }
}
