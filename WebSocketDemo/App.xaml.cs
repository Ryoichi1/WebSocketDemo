﻿using System.Windows;
using System.Windows.Navigation;

namespace WebSocketDemo
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static NavigationService _naviTest;
        public static NavigationService _naviConf;
        public static NavigationService _naviHelp;


        private System.Threading.Mutex mutex = new System.Threading.Mutex(false, "WebSocketDemo");
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // ミューテックスの所有権を要求
            if (!mutex.WaitOne(0, false))
            {
                // 既に起動しているため終了させる
                MessageBox.Show("WebSocketは既に起動しています", "二重起動防止", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                mutex.Close();
                mutex = null;
                this.Shutdown();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex.Close();
            }
        }


    }
}
