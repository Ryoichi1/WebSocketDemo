using Microsoft.Practices.Prism.Mvvm;
using OxyPlot;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;


namespace WebSocketDemo
{
    public class ViewModelPage : BindableBase
    {

        //For Test.xaml■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private bool _IsActiveRing;
        public bool IsActiveRing { get { return _IsActiveRing; } set { SetProperty(ref _IsActiveRing, value); } }


        private List<DataPoint> _ListTemp280;
        public List<DataPoint> ListTemp280 { get { return _ListTemp280; } set { this.SetProperty(ref this._ListTemp280, value); } }

        private List<DataPoint> _ListTemp10;
        public List<DataPoint> ListTemp10 { get { return _ListTemp10; } set { this.SetProperty(ref this._ListTemp10, value); } }

        private List<DataPoint> _ListTemp15;
        public List<DataPoint> ListTemp15 { get { return _ListTemp15; } set { this.SetProperty(ref this._ListTemp15, value); } }

        private List<DataPoint> _ListHumid280;
        public List<DataPoint> ListHumid280 { get { return _ListHumid280; } set { this.SetProperty(ref this._ListHumid280, value); } }


        private int _MaxTime;
        public int MaxTime { get { return _MaxTime; } set { SetProperty(ref _MaxTime, value); } }

        private int _MinTime;
        public int MinTime { get { return _MinTime; } set { SetProperty(ref _MinTime, value); } }

        private int _MajStep;
        public int MajStep { get { return _MajStep; } set { SetProperty(ref _MajStep, value); } }


        private string _CurrentTemp280;
        public string CurrentTemp280 { get { return _CurrentTemp280; } set { SetProperty(ref _CurrentTemp280, value); } }

        private string _MaxTemp280;
        public string MaxTemp280 { get { return _MaxTemp280; } set { SetProperty(ref _MaxTemp280, value); } }

        private string _MinTemp280;
        public string MinTemp280 { get { return _MinTemp280; } set { SetProperty(ref _MinTemp280, value); } }

        private string _CurrentTemp10;
        public string CurrentTemp10 { get { return _CurrentTemp10; } set { SetProperty(ref _CurrentTemp10, value); } }

        private string _MaxTemp10;
        public string MaxTemp10 { get { return _MaxTemp10; } set { SetProperty(ref _MaxTemp10, value); } }

        private string _MinTemp10;
        public string MinTemp10 { get { return _MinTemp10; } set { SetProperty(ref _MinTemp10, value); } }

        private string _CurrentTemp15;
        public string CurrentTemp15 { get { return _CurrentTemp15; } set { SetProperty(ref _CurrentTemp15, value); } }

        private string _MaxTemp15;
        public string MaxTemp15 { get { return _MaxTemp15; } set { SetProperty(ref _MaxTemp15, value); } }

        private string _MinTemp15;
        public string MinTemp15 { get { return _MinTemp15; } set { SetProperty(ref _MinTemp15, value); } }

        private string _CurrentHumid280;
        public string CurrentHumid280 { get { return _CurrentHumid280; } set { SetProperty(ref _CurrentHumid280, value); } }

        private string _MaxHumid280;
        public string MaxHumid280 { get { return _MaxHumid280; } set { SetProperty(ref _MaxHumid280, value); } }

        private string _MinHumid280;
        public string MinHumid280 { get { return _MinHumid280; } set { SetProperty(ref _MinHumid280, value); } }

        private string _CurrentPress280;
        public string CurrentPress280 { get { return _CurrentPress280; } set { SetProperty(ref _CurrentPress280, value); } }

        private string _MaxPress280;
        public string MaxPress280 { get { return _MaxPress280; } set { SetProperty(ref _MaxPress280, value); } }

        private string _MinPress280;
        public string MinPress280 { get { return _MinPress280; } set { SetProperty(ref _MinPress280, value); } }




        private int _MaxRangeTemp;
        public int MaxRangeTemp { get { return _MaxRangeTemp; } set { SetProperty(ref _MaxRangeTemp, value); } }

        private int _MinRangeTemp;
        public int MinRangeTemp { get { return _MinRangeTemp; } set { SetProperty(ref _MinRangeTemp, value); } }

        private int _MaxRangeHumid;
        public int MaxRangeHumid { get { return _MaxRangeHumid; } set { SetProperty(ref _MaxRangeHumid, value); } }

        private int _MinRangeHumid;
        public int MinRangeHumid { get { return _MinRangeHumid; } set { SetProperty(ref _MinRangeHumid, value); } }


        private string _time0;
        public string time0 { get { return _time0; } set { SetProperty(ref _time0, value); } }

        private string _time1;
        public string time1 { get { return _time1; } set { SetProperty(ref _time1, value); } }

        private string _time2;
        public string time2 { get { return _time2; } set { SetProperty(ref _time2, value); } }

        private string _time3;
        public string time3 { get { return _time3; } set { SetProperty(ref _time3, value); } }

        private string _time4;
        public string time4 { get { return _time4; } set { SetProperty(ref _time4, value); } }

        private string _time5;
        public string time5 { get { return _time5; } set { SetProperty(ref _time5, value); } }

        private string _time6;
        public string time6 { get { return _time6; } set { SetProperty(ref _time6, value); } }

        private string _time7;
        public string time7 { get { return _time7; } set { SetProperty(ref _time7, value); } }

        private string _time8;
        public string time8 { get { return _time8; } set { SetProperty(ref _time8, value); } }

        private string _time9;
        public string time9 { get { return _time9; } set { SetProperty(ref _time9, value); } }

        private string _time10;
        public string time10 { get { return _time10; } set { SetProperty(ref _time10, value); } }

        //
        private Visibility _VisT280;
        public Visibility VisT280 { get { return _VisT280; } set { SetProperty(ref _VisT280, value); } }

        private Visibility _VisT10;
        public Visibility VisT10 { get { return _VisT10; } set { SetProperty(ref _VisT10, value); } }

        private Visibility _VisT15;
        public Visibility VisT15 { get { return _VisT15; } set { SetProperty(ref _VisT15, value); } }

        private Visibility _VisH280;
        public Visibility VisH280 { get { return _VisH280; } set { SetProperty(ref _VisH280, value); } }

        //For Mente.xaml■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private string _CommLog;
        public string CommLog { get { return _CommLog; } set { SetProperty(ref _CommLog, value); } }

    }
}
