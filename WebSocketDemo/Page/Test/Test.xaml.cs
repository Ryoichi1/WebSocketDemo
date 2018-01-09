using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Threading.Thread;

namespace WebSocketDemo
{
    /// <summary>
    /// Test.xaml の相互作用ロジック
    /// </summary>
    public partial class Test
    {
        private enum INTERVAL_LEV { LEV1, LEV2, LEV3, LEV4, LEV5 }

        private INTERVAL_LEV LevState;


        Dictionary<int, double> tempList280 = new Dictionary<int, double>();
        Dictionary<int, double> tempList10 = new Dictionary<int, double>();
        Dictionary<int, double> tempList15 = new Dictionary<int, double>();
        Dictionary<int, double> humidList280 = new Dictionary<int, double>();

        bool IsSettingTimeAx;

        int DispInterval;
        int MajStep;
        int Marjin;

        double temp280Max = 0;
        double temp280Min = 0;
        double temp10Max = 0;
        double temp10Min = 0;
        double temp15Max = 0;
        double temp15Min = 0;
        double humid280Max = 0;
        double humid280Min = 0;
        double press280Max = 0;
        double press280Min = 0;


        public Test()
        {
            this.InitializeComponent();

            // オブジェクト作成に必要なコードをこの下に挿入します。
            this.DataContext = State.VmTestStatus;

            (FindResource("Blink") as Storyboard).Begin();

            //デフォルトはLEV1とする
            ChangeTimeAxLevel(INTERVAL_LEV.LEV1);
            SetTimeAxis(true);

            //フォームの初期化
            State.VmTestStatus.IsActiveRing = false;

            buttonStart.Fill = Brushes.DimGray;
            buttonStop.Fill = Brushes.DodgerBlue;
            buttonStart.IsEnabled = true;
            buttonStop.IsEnabled = false;
        }


        //private async void ButtonMeas_Click(object sender, RoutedEventArgs e)
        //{
        //    //Mキーが押されているか
        //    if (Keyboard.IsKeyDown(Key.M))
        //        State.Mode = State.MODE.DEBUG;
        //    else
        //        State.Mode = State.MODE.NORMAL;

        //    Flags.CanExe = !Flags.CanExe;
        //    if (!Flags.CanExe)
        //    {
        //        ButtonMeas.IsEnabled = false;
        //        ButtonMeas.Content = Constants.開始;
        //        //デフォルトはLEV1とする
        //        ChangeTimeAxLevel(INTERVAL_LEV.LEV1);
        //        SetTimeAxis(true);

        //        //テーマ透過度を最小にする
        //        General.SetRadius(false);
        //        ClearViewModel();
        //        while (Flags.GetActiveState())
        //            ButtonMeas.IsEnabled = true;
        //        return;

        //    }
        //    else
        //    {
        //        ButtonMeas.Content = Constants.停止;
        //        if (State.Mode == State.MODE.NORMAL)
        //            MainProgram.GetData();//非同期処理開始
        //        else
        //            MainProgram.GetDataMock();

        //        //テーマ透過度を最小にする
        //        General.SetRadius(true);
        //        tempList280.Clear();
        //        tempList10.Clear();
        //        tempList15.Clear();
        //        humidList280.Clear();

        //        State.VmTestStatus.ListTemp280 = new List<DataPoint>();
        //        State.VmTestStatus.ListTemp10 = new List<DataPoint>();
        //        State.VmTestStatus.ListTemp15 = new List<DataPoint>();
        //        State.VmTestStatus.ListHumid280 = new List<DataPoint>();

        //        SetTimeAxis(false);
        //        Sleep(500);//非同期で動いているSetTimeAxisメソッドが終了するのを待つ
        //        State.VmTestStatus.IsActiveRing = true;

        //        SensingData();

        //        int newTime = 0;
        //        int totalTime = 0;
        //        var NecessaryDataCnt = 0;
        //        Flags.IsActiveDisp = true;
        //        await Task.Run(() =>
        //        {
        //            while (Flags.CanExe)
        //            {
        //                if (!Flags.Connection) continue;//ターゲットと接続できるまで待つ

        //                try
        //                {
        //                    switch (LevState)//スイッチ文に入った直後に、Levスライドを動かしてLEVLEが変わっても大丈夫
        //                    {
        //                        case INTERVAL_LEV.LEV1:
        //                            newTime = GetCurrnetTime(INTERVAL_LEV.LEV1);//INTERVAL_LEVに応じた値が返ってくる
        //                            totalTime = newTime;
        //                            NecessaryDataCnt = 7;
        //                            DispInterval = Constants.Lev1_DispInterval;
        //                            MajStep = Constants.Lev1_MajStep;
        //                            Marjin = Constants.Lev1_Marjin;
        //                            break;
        //                        case INTERVAL_LEV.LEV2:
        //                            newTime = GetCurrnetTime(INTERVAL_LEV.LEV2);//INTERVAL_LEVに応じた値が返ってくる
        //                            totalTime = newTime;
        //                            NecessaryDataCnt = 31;
        //                            DispInterval = Constants.Lev2_DispInterval;
        //                            MajStep = Constants.Lev2_MajStep;
        //                            Marjin = Constants.Lev2_Marjin;
        //                            break;
        //                        case INTERVAL_LEV.LEV3:
        //                            newTime = GetCurrnetTime(INTERVAL_LEV.LEV3);//INTERVAL_LEVに応じた値が返ってくる
        //                            totalTime = newTime;
        //                            NecessaryDataCnt = 61;
        //                            DispInterval = Constants.Lev3_DispInterval;
        //                            MajStep = Constants.Lev3_MajStep;
        //                            Marjin = Constants.Lev3_Marjin;
        //                            break;
        //                        case INTERVAL_LEV.LEV4:
        //                            newTime = GetCurrnetTime(INTERVAL_LEV.LEV4);//INTERVAL_LEVに応じた値が返ってくる
        //                            totalTime = newTime;
        //                            NecessaryDataCnt = 181;
        //                            DispInterval = Constants.Lev4_DispInterval;
        //                            MajStep = Constants.Lev4_MajStep;
        //                            Marjin = Constants.Lev4_Marjin;
        //                            break;
        //                        case INTERVAL_LEV.LEV5:
        //                            newTime = GetCurrnetTime(INTERVAL_LEV.LEV5);//INTERVAL_LEVに応じた値が返ってくる
        //                            totalTime = newTime;
        //                            NecessaryDataCnt = 361;
        //                            DispInterval = Constants.Lev5_DispInterval;
        //                            MajStep = Constants.Lev5_MajStep;
        //                            Marjin = Constants.Lev5_Marjin;
        //                            break;
        //                    }


        //                    State.VmTestStatus.MaxTime = totalTime + Marjin;
        //                    State.VmTestStatus.MinTime = totalTime - DispInterval;
        //                    State.VmTestStatus.MajStep = MajStep;

        //                    State.VmTestStatus.IsActiveRing = false;

        //                    if (!tempList280.ContainsKey(totalTime))
        //                    {
        //                        State.VmTestStatus.ListTemp280.Clear();
        //                        State.VmTestStatus.ListTemp10.Clear();
        //                        State.VmTestStatus.ListTemp15.Clear();
        //                        State.VmTestStatus.ListHumid280.Clear();
        //                        continue;
        //                    }

        //                    /////////////////////////////////////////////////////////
        //                    var t280List = new List<double>();
        //                    var t10List = new List<double>();
        //                    var t15List = new List<double>();
        //                    var h280List = new List<double>();

        //                    foreach (var i in Enumerable.Range(0, NecessaryDataCnt))
        //                    {
        //                        var timeStamp = totalTime - (10 * i);
        //                        if (tempList280.ContainsKey(timeStamp))
        //                        {
        //                            t280List.Add(tempList280[timeStamp]);
        //                        }
        //                        if (tempList10.ContainsKey(timeStamp))
        //                        {
        //                            t10List.Add(tempList10[timeStamp]);
        //                        }
        //                        if (tempList15.ContainsKey(timeStamp))
        //                        {
        //                            t15List.Add(tempList15[timeStamp]);
        //                        }
        //                        if (humidList280.ContainsKey(timeStamp))
        //                        {
        //                            h280List.Add(humidList280[timeStamp]);
        //                        }
        //                    }

        //                    var t280Max = t280List.Max();
        //                    var t280Min = t280List.Min();
        //                    var t10Max = t10List.Max();
        //                    var t10Min = t10List.Min();
        //                    var t15Max = t15List.Max();
        //                    var t15Min = t15List.Min();
        //                    var h280Max = h280List.Max();
        //                    var h280Min = h280List.Min();

        //                    ChangeTempMaxMinRange(new List<double> { t280Max, t10Max, t15Max }, new List<double> { t280Min, t10Min, t15Min });
        //                    ChangeHumidMaxMinRange(h280Max, h280Min);
        //                    ////////////////////////////////////////////////////////////////

        //                    //表示用データリストの生成
        //                    State.VmTestStatus.ListTemp280.Clear();
        //                    State.VmTestStatus.ListTemp10.Clear();
        //                    State.VmTestStatus.ListTemp15.Clear();
        //                    State.VmTestStatus.ListHumid280.Clear();

        //                    var newTempList280 = new List<DataPoint>();
        //                    var newTempList10 = new List<DataPoint>();
        //                    var newTempList15 = new List<DataPoint>();
        //                    var newHumidList280 = new List<DataPoint>();

        //                    foreach (var i in Enumerable.Range(0, NecessaryDataCnt))
        //                    {
        //                        var timeStamp = totalTime - (10 * i);
        //                        if (tempList280.ContainsKey(timeStamp))
        //                        {
        //                            newTempList280.Add(new DataPoint(timeStamp, tempList280[timeStamp]));
        //                        }
        //                        if (tempList10.ContainsKey(timeStamp))
        //                        {
        //                            newTempList10.Add(new DataPoint(timeStamp, tempList10[timeStamp]));
        //                        }
        //                        if (tempList15.ContainsKey(timeStamp))
        //                        {
        //                            newTempList15.Add(new DataPoint(timeStamp, tempList15[timeStamp]));
        //                        }
        //                        if (humidList280.ContainsKey(timeStamp))
        //                        {
        //                            newHumidList280.Add(new DataPoint(timeStamp, ConvertHumidToTemp(humidList280[timeStamp])));
        //                        }
        //                    }

        //                    State.VmTestStatus.IsActiveRing = false;
        //                    State.VmTestStatus.ListTemp280 = newTempList280;
        //                    State.VmTestStatus.ListTemp10 = newTempList10;
        //                    State.VmTestStatus.ListTemp15 = newTempList15;
        //                    State.VmTestStatus.ListHumid280 = newHumidList280;
        //                    Sleep(200);
        //                }
        //                catch
        //                {

        //                }


        //            }

        //            State.VmTestStatus.IsActiveRing = false;
        //            State.VmTestStatus.ListTemp280 = null;
        //            State.VmTestStatus.ListTemp10 = null;
        //            State.VmTestStatus.ListTemp15 = null;
        //            State.VmTestStatus.ListHumid280 = null;
        //            Flags.IsActiveDisp = false;
        //        });


        //    }
        //}

        private async Task Start()
        {
            //Mキーが押されているか
            if (Keyboard.IsKeyDown(Key.M))
                State.Mode = State.MODE.DEBUG;
            else
                State.Mode = State.MODE.NORMAL;

            Flags.CanExe = true;

            buttonStart.Fill = Brushes.DodgerBlue;
            buttonStop.Fill = Brushes.DimGray;
            buttonStart.IsEnabled = false;
            buttonStop.IsEnabled = true;


            if (State.Mode == State.MODE.NORMAL)
                MainProgram.GetData();//非同期処理開始
            else
                MainProgram.GetDataMock();

            State.TempBme280 = 0;
            State.HumidBme280 = 0;
            State.PressBme280 = 0;
            State.TempSdc10 = 0;
            State.TempSdc15 = 0;

            tempList280.Clear();
            tempList10.Clear();
            tempList15.Clear();
            humidList280.Clear();

            State.VmTestStatus.ListTemp280 = new List<DataPoint>();
            State.VmTestStatus.ListTemp10 = new List<DataPoint>();
            State.VmTestStatus.ListTemp15 = new List<DataPoint>();
            State.VmTestStatus.ListHumid280 = new List<DataPoint>();

            SetTimeAxis(false);
            Sleep(500);//非同期で動いているSetTimeAxisメソッドが終了するのを待つ
            State.VmTestStatus.IsActiveRing = true;

            SensingData();

            int newTime = 0;
            int totalTime = 0;
            var NecessaryDataCnt = 0;
            Flags.IsActiveDisp = true;
            await Task.Run(() =>
            {
                while (Flags.CanExe)
                {
                    if (!Flags.Connection) continue;//ターゲットと接続できるまで待つ

                    try
                    {
                        switch (LevState)//スイッチ文に入った直後に、Levスライドを動かしてLEVLEが変わっても大丈夫
                        {
                            case INTERVAL_LEV.LEV1:
                                newTime = GetCurrnetTime(INTERVAL_LEV.LEV1);//INTERVAL_LEVに応じた値が返ってくる
                                totalTime = newTime;
                                NecessaryDataCnt = 7;
                                DispInterval = Constants.Lev1_DispInterval;
                                MajStep = Constants.Lev1_MajStep;
                                Marjin = Constants.Lev1_Marjin;
                                break;
                            case INTERVAL_LEV.LEV2:
                                newTime = GetCurrnetTime(INTERVAL_LEV.LEV2);//INTERVAL_LEVに応じた値が返ってくる
                                totalTime = newTime;
                                NecessaryDataCnt = 31;
                                DispInterval = Constants.Lev2_DispInterval;
                                MajStep = Constants.Lev2_MajStep;
                                Marjin = Constants.Lev2_Marjin;
                                break;
                            case INTERVAL_LEV.LEV3:
                                newTime = GetCurrnetTime(INTERVAL_LEV.LEV3);//INTERVAL_LEVに応じた値が返ってくる
                                totalTime = newTime;
                                NecessaryDataCnt = 61;
                                DispInterval = Constants.Lev3_DispInterval;
                                MajStep = Constants.Lev3_MajStep;
                                Marjin = Constants.Lev3_Marjin;
                                break;
                            case INTERVAL_LEV.LEV4:
                                newTime = GetCurrnetTime(INTERVAL_LEV.LEV4);//INTERVAL_LEVに応じた値が返ってくる
                                totalTime = newTime;
                                NecessaryDataCnt = 181;
                                DispInterval = Constants.Lev4_DispInterval;
                                MajStep = Constants.Lev4_MajStep;
                                Marjin = Constants.Lev4_Marjin;
                                break;
                            case INTERVAL_LEV.LEV5:
                                newTime = GetCurrnetTime(INTERVAL_LEV.LEV5);//INTERVAL_LEVに応じた値が返ってくる
                                totalTime = newTime;
                                NecessaryDataCnt = 361;
                                DispInterval = Constants.Lev5_DispInterval;
                                MajStep = Constants.Lev5_MajStep;
                                Marjin = Constants.Lev5_Marjin;
                                break;
                        }


                        State.VmTestStatus.MaxTime = totalTime + Marjin;
                        State.VmTestStatus.MinTime = totalTime - DispInterval;
                        State.VmTestStatus.MajStep = MajStep;

                        State.VmTestStatus.IsActiveRing = false;

                        if (!tempList280.ContainsKey(totalTime))
                        {
                            State.VmTestStatus.ListTemp280.Clear();
                            State.VmTestStatus.ListTemp10.Clear();
                            State.VmTestStatus.ListTemp15.Clear();
                            State.VmTestStatus.ListHumid280.Clear();
                            continue;
                        }

                        /////////////////////////////////////////////////////////
                        var t280List = new List<double>();
                        var t10List = new List<double>();
                        var t15List = new List<double>();
                        var h280List = new List<double>();

                        foreach (var i in Enumerable.Range(0, NecessaryDataCnt))
                        {
                            var timeStamp = totalTime - (10 * i);
                            if (tempList280.ContainsKey(timeStamp))
                            {
                                t280List.Add(tempList280[timeStamp]);
                            }
                            if (tempList10.ContainsKey(timeStamp))
                            {
                                t10List.Add(tempList10[timeStamp]);
                            }
                            if (tempList15.ContainsKey(timeStamp))
                            {
                                t15List.Add(tempList15[timeStamp]);
                            }
                            if (humidList280.ContainsKey(timeStamp))
                            {
                                h280List.Add(humidList280[timeStamp]);
                            }
                        }

                        var t280Max = t280List.Max();
                        var t280Min = t280List.Min();
                        var t10Max = t10List.Max();
                        var t10Min = t10List.Min();
                        var t15Max = t15List.Max();
                        var t15Min = t15List.Min();
                        var h280Max = h280List.Max();
                        var h280Min = h280List.Min();

                        ChangeTempMaxMinRange(new List<double> { t280Max, t10Max, t15Max }, new List<double> { t280Min, t10Min, t15Min });
                        ChangeHumidMaxMinRange(h280Max, h280Min);
                        ////////////////////////////////////////////////////////////////

                        //表示用データリストの生成
                        State.VmTestStatus.ListTemp280.Clear();
                        State.VmTestStatus.ListTemp10.Clear();
                        State.VmTestStatus.ListTemp15.Clear();
                        State.VmTestStatus.ListHumid280.Clear();

                        var newTempList280 = new List<DataPoint>();
                        var newTempList10 = new List<DataPoint>();
                        var newTempList15 = new List<DataPoint>();
                        var newHumidList280 = new List<DataPoint>();

                        foreach (var i in Enumerable.Range(0, NecessaryDataCnt))
                        {
                            var timeStamp = totalTime - (10 * i);
                            if (tempList280.ContainsKey(timeStamp))
                            {
                                newTempList280.Add(new DataPoint(timeStamp, tempList280[timeStamp]));
                            }
                            if (tempList10.ContainsKey(timeStamp))
                            {
                                newTempList10.Add(new DataPoint(timeStamp, tempList10[timeStamp]));
                            }
                            if (tempList15.ContainsKey(timeStamp))
                            {
                                newTempList15.Add(new DataPoint(timeStamp, tempList15[timeStamp]));
                            }
                            if (humidList280.ContainsKey(timeStamp))
                            {
                                newHumidList280.Add(new DataPoint(timeStamp, ConvertHumidToTemp(humidList280[timeStamp])));
                            }
                        }

                        State.VmTestStatus.IsActiveRing = false;
                        State.VmTestStatus.ListTemp280 = newTempList280;
                        State.VmTestStatus.ListTemp10 = newTempList10;
                        State.VmTestStatus.ListTemp15 = newTempList15;
                        State.VmTestStatus.ListHumid280 = newHumidList280;
                        Sleep(200);
                    }
                    catch
                    {

                    }


                }

                State.VmTestStatus.IsActiveRing = false;
                State.VmTestStatus.ListTemp280 = null;
                State.VmTestStatus.ListTemp10 = null;
                State.VmTestStatus.ListTemp15 = null;
                State.VmTestStatus.ListHumid280 = null;
                Flags.IsActiveDisp = false;
            });



        }

        private async Task Stop()
        {
            Flags.CanExe = false;
            buttonStart.Fill = Brushes.DimGray;
            buttonStop.Fill = Brushes.DodgerBlue;
            buttonStart.IsEnabled = false;
            buttonStop.IsEnabled = false;

            await Task.Run(() =>
            {
                //デフォルトはLEV1とする
                ChangeTimeAxLevel(INTERVAL_LEV.LEV1);
                SetTimeAxis(true);

                ClearViewModel();
                while (Flags.GetActiveState()) ;
            });
            buttonStart.IsEnabled = true;
        }

        private void ChangeTimeAxLevel(INTERVAL_LEV lev)
        {
            LevState = lev;
        }

        private void ChangeTempMaxMinRange(List<double> maxTemps, List<double> minTemps)
        {
            State.VmTestStatus.MaxRangeTemp = (int)maxTemps.Max() + 5;
            State.VmTestStatus.MinRangeTemp = (int)minTemps.Min() - 5;
        }

        private void ChangeHumidMaxMinRange(double humidMax, double humidMin)
        {
            State.VmTestStatus.MaxRangeHumid = (int)humidMax + 5;
            State.VmTestStatus.MinRangeHumid = (int)humidMin - 5;
        }


        private double ConvertHumidToTemp(double hData)//グラフの縦軸が温度のスケールなので湿度データを正規化する
        {
            var MaxRangeTemp = State.VmTestStatus.MaxRangeTemp;
            var MinRangeTemp = State.VmTestStatus.MinRangeTemp;
            var MaxRangeHumid = State.VmTestStatus.MaxRangeHumid;
            var MinRangeHumid = State.VmTestStatus.MinRangeHumid;

            return (MaxRangeTemp - MinRangeTemp) * (hData - MinRangeHumid) / (MaxRangeHumid - MinRangeHumid) + MinRangeTemp;
        }

        private void SensingData()//10秒間隔でデータをロギングする
        {
            Flags.IsActiveSensing = true;
            int oldS = 0;
            bool firstSensing = true;

            Task.Run(() =>
            {
                while (Flags.CanExe)
                {
                    while (!Flags.Connection) ;

                    var time = System.DateTime.Now.ToString("HH,mm,ss");
                    var tArray = time.Split(',').ToArray();
                    var newS = Int32.Parse(tArray[2]) / 10;//秒数の10の位を求める
                    if (oldS == newS)
                        continue;
                    oldS = newS;

                    var timeStamp = Int32.Parse(tArray[0]) * 3600 +
                                    Int32.Parse(tArray[1]) * 60 +
                                    newS * 10;

                    var temp280New = State.TempBme280;
                    tempList280[timeStamp] = temp280New;

                    var temp10New = State.TempSdc10;
                    tempList10[timeStamp] = temp10New;

                    var temp15New = State.TempSdc15;
                    tempList15[timeStamp] = temp15New;

                    var humid280New = State.HumidBme280;
                    humidList280[timeStamp] = humid280New;

                    var press280New = State.PressBme280;

                    if (firstSensing)
                    {
                        temp280Max = temp280New;
                        temp280Min = temp280New;
                        temp10Max = temp10New;
                        temp10Min = temp10New;
                        temp15Max = temp15New;
                        temp15Min = temp15New;
                        humid280Max = humid280New;
                        humid280Min = humid280New;
                        press280Max = press280New;
                        press280Min = press280New;
                        firstSensing = false;
                    }
                    else
                    {
                        //
                        if (temp280Max < temp280New)
                            temp280Max = temp280New;

                        if (temp280Min > temp280New)
                            temp280Min = temp280New;
                        //
                        if (temp10Max < temp10New)
                            temp10Max = temp10New;

                        if (temp10Min > temp10New)
                            temp10Min = temp10New;
                        //
                        if (temp15Max < temp15New)
                            temp15Max = temp15New;

                        if (temp15Min > temp15New)
                            temp15Min = temp15New;
                        //
                        if (humid280Max < humid280New)
                            humid280Max = humid280New;

                        if (humid280Min > humid280New)
                            humid280Min = humid280New;
                        //
                        if (press280Max < press280New)
                            press280Max = press280New;

                        if (press280Min > press280New)
                            press280Min = press280New;
                    }


                    State.VmTestStatus.CurrentTemp280 = $"{temp280New.ToString("F1")}℃";
                    State.VmTestStatus.MaxTemp280 = $"H {temp280Max.ToString("F1")}";
                    State.VmTestStatus.MinTemp280 = $"L {temp280Min.ToString("F1")}";


                    State.VmTestStatus.CurrentTemp10 = $"{temp10New.ToString("F1")}℃";
                    State.VmTestStatus.MaxTemp10 = $"H {temp10Max.ToString("F1")}";
                    State.VmTestStatus.MinTemp10 = $"L {temp10Min.ToString("F1")}";

                    State.VmTestStatus.CurrentTemp15 = $"{temp15New.ToString("F1")}℃";
                    State.VmTestStatus.MaxTemp15 = $"H {temp15Max.ToString("F1")}";
                    State.VmTestStatus.MinTemp15 = $"L {temp15Min.ToString("F1")}";

                    State.VmTestStatus.CurrentHumid280 = $"{humid280New.ToString("F1")}%";
                    State.VmTestStatus.MaxHumid280 = $"H {humid280Max.ToString("F1")}";
                    State.VmTestStatus.MinHumid280 = $"L {humid280Min.ToString("F1")}";

                    State.VmTestStatus.CurrentPress280 = $"{press280New.ToString("F1")}hPa";
                    State.VmTestStatus.MaxPress280 = $"H {press280Max.ToString("F1")}";
                    State.VmTestStatus.MinPress280 = $"L {press280Min.ToString("F1")}";

                }
                Flags.IsActiveSensing = false;
            });
        }

        private int GetCurrnetTime(INTERVAL_LEV lev)//
        {
            var time = System.DateTime.Now.ToString("HH,mm,ss");
            var tArray = time.Split(',').ToArray();
            int total = 0;
            switch (lev)
            {
                case INTERVAL_LEV.LEV1:
                case INTERVAL_LEV.LEV2:
                    var s = Int32.Parse(tArray[2]) / MajStep;//秒数の10の位を求める
                    total = Int32.Parse(tArray[0]) * 3600 +
                                Int32.Parse(tArray[1]) * 60 +
                                s * MajStep;
                    return total;
                case INTERVAL_LEV.LEV3:
                    total = Int32.Parse(tArray[0]) * 3600 +
                            Int32.Parse(tArray[1]) * 60;
                    return total;
                case INTERVAL_LEV.LEV4:
                    var m = Int32.Parse(tArray[1]) / 5;//
                    total = Int32.Parse(tArray[0]) * 3600 +
                            m * 60 * 5;
                    return total;
                case INTERVAL_LEV.LEV5:
                    var m2 = Int32.Parse(tArray[1]) / 10;//
                    total = Int32.Parse(tArray[0]) * 3600 +
                            m2 * 60 * 10;
                    return total;
                default:
                    return 0;
            }
        }

        private void SetTimeAxis(bool sw)
        {
            IsSettingTimeAx = sw;
            if (!sw) return;

            var total = 0;
            Task.Run(() =>
            {
                while (IsSettingTimeAx)
                {
                    var time = System.DateTime.Now.ToString("HH,mm,ss");
                    var tArray = time.Split(',').ToArray();

                    switch (LevState)
                    {
                        case INTERVAL_LEV.LEV1:
                            DispInterval = Constants.Lev1_DispInterval;
                            MajStep = Constants.Lev1_MajStep;
                            Marjin = Constants.Lev1_Marjin;
                            break;
                        case INTERVAL_LEV.LEV2:
                            DispInterval = Constants.Lev2_DispInterval;
                            MajStep = Constants.Lev2_MajStep;
                            Marjin = Constants.Lev2_Marjin;
                            break;
                        case INTERVAL_LEV.LEV3:
                            DispInterval = Constants.Lev3_DispInterval;
                            MajStep = Constants.Lev3_MajStep;
                            Marjin = Constants.Lev3_Marjin;
                            break;
                        case INTERVAL_LEV.LEV4:
                            DispInterval = Constants.Lev4_DispInterval;
                            MajStep = Constants.Lev4_MajStep;
                            Marjin = Constants.Lev4_Marjin;
                            break;
                        case INTERVAL_LEV.LEV5:
                            DispInterval = Constants.Lev5_DispInterval;
                            MajStep = Constants.Lev5_MajStep;
                            Marjin = Constants.Lev5_Marjin;
                            break;
                    }



                    switch (LevState)
                    {
                        case INTERVAL_LEV.LEV1:
                        case INTERVAL_LEV.LEV2:
                            var ss = Int32.Parse(tArray[2]) / MajStep;//秒数の10の位を求める
                            total = Int32.Parse(tArray[0]) * 3600 +
                                Int32.Parse(tArray[1]) * 60 +
                                ss * MajStep;
                            break;
                        case INTERVAL_LEV.LEV3:
                            total = Int32.Parse(tArray[0]) * 3600 +
                                    Int32.Parse(tArray[1]) * 60;
                            break;
                        case INTERVAL_LEV.LEV4:
                            var m = Int32.Parse(tArray[1]) / 5;//
                            total = Int32.Parse(tArray[0]) * 3600 +
                            m * 60 * 5;
                            break;
                        case INTERVAL_LEV.LEV5:
                            var m2 = Int32.Parse(tArray[1]) / 10;//
                            total = Int32.Parse(tArray[0]) * 3600 +
                            m2 * 60 * 10;
                            break;
                        default:
                            break;
                    }


                    State.VmTestStatus.MaxTime = total + Marjin;
                    State.VmTestStatus.MinTime = total - DispInterval;
                    State.VmTestStatus.MajStep = MajStep;
                    Sleep(100);
                }
            });

        }

        private void ClearViewModel()
        {
            State.VmTestStatus.CurrentTemp280 = "";
            State.VmTestStatus.MaxTemp280 = "";
            State.VmTestStatus.MinTemp280 = "";

            State.VmTestStatus.CurrentTemp10 = "";
            State.VmTestStatus.MaxTemp10 = "";
            State.VmTestStatus.MinTemp10 = "";

            State.VmTestStatus.CurrentTemp15 = "";
            State.VmTestStatus.MaxTemp15 = "";
            State.VmTestStatus.MinTemp15 = "";

            State.VmTestStatus.CurrentHumid280 = "";
            State.VmTestStatus.MaxHumid280 = "";
            State.VmTestStatus.MinHumid280 = "";

            State.VmTestStatus.CurrentPress280 = "";
            State.VmTestStatus.MaxPress280 = "";
            State.VmTestStatus.MinPress280 = "";

            State.VmTestStatus.CommLog = "";

        }

        private void SliderLev_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var lev = SliderLev.Value;
            INTERVAL_LEV LEVEL;

            if (lev < 1.5)
            {

                SliderLev.Value = 1.0;
                LEVEL = INTERVAL_LEV.LEV1;
            }
            else if (lev >= 1.5 && lev < 2.5)
            {
                SliderLev.Value = 2.0;
                LEVEL = INTERVAL_LEV.LEV2;
            }
            else if (lev >= 2.5 && lev < 3.5)
            {
                SliderLev.Value = 3.0;
                LEVEL = INTERVAL_LEV.LEV3;
            }
            else if (lev >= 3.5 && lev < 4.5)
            {
                SliderLev.Value = 4.0;
                LEVEL = INTERVAL_LEV.LEV4;
            }
            else
            {
                SliderLev.Value = 5.0;
                LEVEL = INTERVAL_LEV.LEV5;
            }



            switch (LEVEL)
            {
                case INTERVAL_LEV.LEV1:
                    ChangeTimeAxLevel(INTERVAL_LEV.LEV1);
                    break;
                case INTERVAL_LEV.LEV2:
                    ChangeTimeAxLevel(INTERVAL_LEV.LEV2);
                    break;
                case INTERVAL_LEV.LEV3:
                    ChangeTimeAxLevel(INTERVAL_LEV.LEV3);
                    break;
                case INTERVAL_LEV.LEV4:
                    ChangeTimeAxLevel(INTERVAL_LEV.LEV4);
                    break;
                case INTERVAL_LEV.LEV5:
                    ChangeTimeAxLevel(INTERVAL_LEV.LEV5);
                    break;

            }
        }

        private void SliderLev_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var lev = SliderLev.Value;

            if (lev < 1.5)
            {
                SliderLev.Value = 1.0;
            }
            else if (lev >= 1.5 && lev < 2.5)
            {
                SliderLev.Value = 2.0;
            }
            else if (lev >= 2.5 && lev < 3.5)
            {
                SliderLev.Value = 3.0;
            }
            else if (lev >= 3.5 && lev < 4.5)
            {
                SliderLev.Value = 4.0;
            }
            else
            {
                SliderLev.Value = 5.0;
            }

        }

        private async void buttonStart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Start();
        }

        private async void buttonStop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Stop();
        }

        private void buttonStart_MouseEnter(object sender, MouseEventArgs e)
        {
            if (buttonStart.Fill == Brushes.DimGray)
                buttonStart.Fill = Brushes.WhiteSmoke;
        }

        private void buttonStart_MouseLeave(object sender, MouseEventArgs e)
        {
            if (buttonStart.Fill == Brushes.WhiteSmoke)
                buttonStart.Fill = Brushes.DimGray;

        }

        private void buttonStop_MouseEnter(object sender, MouseEventArgs e)
        {
            if (buttonStop.Fill == Brushes.DimGray)
                buttonStop.Fill = Brushes.WhiteSmoke;

        }

        private void buttonStop_MouseLeave(object sender, MouseEventArgs e)
        {
            if (buttonStop.Fill == Brushes.WhiteSmoke)
                buttonStop.Fill = Brushes.DimGray;
        }
    }
}
