using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace WebSocketDemo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow
    {

        Uri uriTestPage = new Uri("Page/Test/Test.xaml", UriKind.Relative);
        Uri uriConfPage = new Uri("Page/Config/Conf.xaml", UriKind.Relative);
        Uri uriHelpPage = new Uri("Page/Help/Help.xaml", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();
            App._naviTest = FrameTest.NavigationService;
            App._naviConf = FrameConf.NavigationService;
            App._naviHelp = FrameHelp.NavigationService;

            this.MouseLeftButtonDown += (sender, e) => this.DragMove();//ウィンドウ全体でドラッグ可能にする

            this.DataContext = State.VmMainWindow;

            GetInfo();

            //カレントディレクトリの取得
            State.CurrDir = Directory.GetCurrentDirectory();

            State.Target = State.TARGET.DEMO_01;
            General.ShowTargetWithoutAdr();

            InitMainForm();//メインフォーム初期

        }


        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Flags.Testing)
            {
                e.Cancel = true;
            }

        }



        //アセンブリ情報の取得
        private void GetInfo()
        {
            //アセンブリバージョンの取得
            var asm = Assembly.GetExecutingAssembly();
            var M = asm.GetName().Version.Major.ToString();
            var N = asm.GetName().Version.Minor.ToString();
            var B = asm.GetName().Version.Build.ToString();
            State.AssemblyInfo = M + "." + N + "." + B;

        }

        //フォームのイニシャライズ
        private void InitMainForm()
        {
            State.VmMainWindow.EnableOtherButton = true;
        }


        private async void TabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = TabMenu.SelectedIndex;
            if (index == 0)
            {
                Flags.OtherPage = false;//フラグを初期化しておく

                App._naviConf.Refresh();
                App._naviHelp.Refresh();
                App._naviTest.Navigate(uriTestPage);

                //if (Flags.Testing)
                //    return;

                //高速にページ切り替えボタンを押すと異常動作する場合があるので、ページが遷移してから500msec間は、他のページに遷移できないようにする
                State.VmMainWindow.EnableOtherButton = false;
                await Task.Delay(500);
                State.VmMainWindow.EnableOtherButton = true;
            }
            else if (index == 1)
            {
                Flags.OtherPage = true;
                App._naviConf.Navigate(uriConfPage);
                App._naviHelp.Refresh();
                //高速にページ切り替えボタンを押すと異常動作する場合があるので、ページが遷移してから500msec間は、他のページに遷移できないようにする
                State.VmMainWindow.EnableOtherButton = false;
                await Task.Delay(500);
                State.VmMainWindow.EnableOtherButton = true;
            }
            else if (index == 2)
            {
                Flags.OtherPage = true;
                App._naviHelp.Navigate(uriHelpPage);
                App._naviConf.Refresh();
                //高速にページ切り替えボタンを押すと異常動作する場合があるので、ページが遷移してから500msec間は、他のページに遷移できないようにする
                State.VmMainWindow.EnableOtherButton = false;
                await Task.Delay(500);
                State.VmMainWindow.EnableOtherButton = true;

            }

        }

    }
}
