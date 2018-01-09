using Example;
using System.Threading;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WebSocketSharp;
using System.Threading.Tasks;

namespace WebSocketDemo
{
    public static class MainProgram
    {
        public static void GetData()
        {
            Flags.IsActiveGetData = true;
            Task.Run(() =>
            {
                // Create a new instance of the WebSocket class.
                //
                // The WebSocket class inherits the System.IDisposable interface, so you can
                // use the using statement. And the WebSocket connection will be closed with
                // close status 1001 (going away) when the control leaves the using block.
                //
                // If you would like to connect to the server with the secure connection,
                // you should create a new instance with a wss scheme WebSocket URL.

                using (var nf = new Notifier())
                using (var ws = new WebSocketSharp.WebSocket("wss://api.sakura.io/ws/v1/14164184-dfdc-4f26-b207-477625bc7682"))

                {
                    ws.OnOpen += (sender, e) => ws.Send("Hi, there!");

                    ws.OnMessage += (sender, e) =>
                    {
                        var nf_message = new NotificationMessage
                        {
                            Summary = "WS Mes",
                            Body = !e.IsPing ? e.Data : "Received a ping.",
                            Icon = "notification-message-im"
                        };

                        //nf.Notify(nf_message);

                        State.VmTestStatus.CommLog += "\n\n\r\n";
                        //Console.Write("\n\n"); // "> > > "の後の改行と空行

                        ReceivedMessage rx_mes = new ReceivedMessage(e.Data);

                        State.VmTestStatus.CommLog += "---------- Serialization Before ----------\r\n";
                        //Console.WriteLine("---------- Serialization Before ----------");
                        State.VmTestStatus.CommLog += rx_mes.ToString() + "\r\n";
                        //Console.WriteLine(rx_mes.ToString());
                        State.VmTestStatus.CommLog += "---------- Serialization Before ----------\r\n";
                        //Console.WriteLine("---------- Serialization Before ----------");
                        State.VmTestStatus.CommLog += "\r\n";
                        //Console.WriteLine("");

                        var parsed_data = rx_mes.JsonParse(new JavaScriptSerializer());

                        State.VmTestStatus.CommLog += "---------- Serialization After ----------\r\n";
                        //Console.WriteLine("---------- Serialization After ----------");
                        if (parsed_data.type != "keepalive")
                        {
                            //Console.WriteLine(parsed_data..ToString());
                            State.VmTestStatus.CommLog += "BME280 温度:" + parsed_data.payload.channels[0].value + "\r\n";
                            State.VmTestStatus.CommLog += "BME280 湿度:" + parsed_data.payload.channels[1].value + "\r\n";
                            State.VmTestStatus.CommLog += "BME280 気圧:" + parsed_data.payload.channels[2].value + "\r\n";
                            State.VmTestStatus.CommLog += "SDC10 温度:"  + parsed_data.payload.channels[3].value + "\r\n";
                            State.VmTestStatus.CommLog += "SDC15 温度:"  + parsed_data.payload.channels[4].value + "\r\n";

                            State.TempBme280  = parsed_data.payload.channels[0].value;
                            State.HumidBme280 = parsed_data.payload.channels[1].value;
                            State.PressBme280 = parsed_data.payload.channels[2].value;
                            State.TempSdc10   = parsed_data.payload.channels[3].value;
                            State.TempSdc15   = parsed_data.payload.channels[4].value;


                            //Console.WriteLine("カウント:" + parsed_data.payload.channels[0].value);
                            //Console.WriteLine("温度:" + parsed_data.payload.channels[1].value);
                            //Console.WriteLine("湿度:" + parsed_data.payload.channels[2].value);
                            //Console.WriteLine("気圧:" + parsed_data.payload.channels[3].value);
                            //Console.WriteLine("高度:" + parsed_data.payload.channels[4].value);
                        }
                        else
                        {
                            State.VmTestStatus.CommLog += "keepalive\r\n";
                            Flags.Connection = true;
                            //State.VmTestStatus.ColorConnection = General.OnBrush;
                            //Console.WriteLine("keepalive");
                        }

                        State.VmTestStatus.CommLog += "---------- Serialization After ---------\r\n";
                        State.VmTestStatus.CommLog += "\r\n";
                        //Console.WriteLine("---------- Serialization After ----------");
                        //Console.WriteLine("");
                    };

                    ws.OnError += (sender, e) =>
                    {
                        Flags.Connection = false;
                        //State.VmTestStatus.ColorConnection = General.NgBrush;
                        nf.Notify(
                  new NotificationMessage
                  {
                      Summary = "WebSocket Error",
                      Body = e.Message,
                      Icon = "notification-message-im"
                  }
                );
                    };
                    ws.OnClose += (sender, e) =>
                    {
                        Flags.Connection = false;
                        //State.VmTestStatus.ColorConnection = General.NgBrush;
                        nf.Notify(
                  new NotificationMessage
                  {
                      Summary = string.Format("WebSocket Close ({0})", e.Code),
                      Body = e.Reason,
                      Icon = "notification-message-im"
                  }
                );
                    };
#if DEBUG
                    // To change the logging level.
                    ws.Log.Level = LogLevel.Trace;

                    // To change the wait time for the response to the Ping or Close.
                    //ws.WaitTime = TimeSpan.FromSeconds (10);

                    // To emit a WebSocket.OnMessage event when receives a ping.
                    //ws.EmitOnPing = true;
#endif
                    // To enable the Per-message Compression extension.
                    //ws.Compression = CompressionMethod.Deflate;

                    // To validate the server certificate.
                    /*
                    ws.SslConfiguration.ServerCertificateValidationCallback =
                      (sender, certificate, chain, sslPolicyErrors) => {
                        ws.Log.Debug (
                          String.Format (
                            "Certificate:\n- Issuer: {0}\n- Subject: {1}",
                            certificate.Issuer,
                            certificate.Subject
                          )
                        );

                        return true; // If the server certificate is valid.
                      };
                     */

                    // To send the credentials for the HTTP Authentication (Basic/Digest).
                    //ws.SetCredentials ("nobita", "password", false);

                    // To send the Origin header.
                    //ws.Origin = "http://localhost:4649";

                    // To send the cookies.
                    //ws.SetCookie (new Cookie ("name", "nobita"));
                    //ws.SetCookie (new Cookie ("roles", "\"idiot, gunfighter\""));

                    // To connect through the HTTP Proxy server.
                    //ws.SetProxy ("http://localhost:3128", "nobita", "password");

                    // To enable the redirection.
                    //ws.EnableRedirection = true;

                    // Connect to the server.
                    ws.Connect();

                    // Connect to the server asynchronously.
                    //ws.ConnectAsync ();

                    State.VmTestStatus.CommLog += "\nType 'exit' to exit.\n";
                    while (Flags.CanExe)
                    {
                        Thread.Sleep(100);
                        //State.VmTestStatus.CommLog += "> ";
                        //          var msg = Console.ReadLine();
                        //          if (msg == "exit")
                        //              break;

                        //          Send a text message.
                        //ws.Send(msg);
                    }
                }
                Flags.IsActiveGetData = false;
            });

        }

        public static void GetDataMock()
        {
            Flags.IsActiveGetDataMock = true;
            Task.Run(() =>
            {

                // タイマー生成
                var timer2 = new System.Timers.Timer();
                timer2.Elapsed += (sender, e) =>
                            {
                                Flags.Connection = true;
                                timer2.Stop();
                            };
                timer2.Interval = 3000;
                // タイマーを開始
                timer2.Start();


                while (Flags.CanExe)
                {
                    var random = new System.Random();
                    State.TempBme280  = random.Next(200, 300) * 0.1;
                    State.HumidBme280 = random.Next(400, 800) * 0.1;
                    State.PressBme280 = random.Next(6000, 10000) * 0.1;
                    State.TempSdc10   = random.Next(200, 400) * 0.1;
                    State.TempSdc15   = random.Next(200, 400) * 0.1;

                    Thread.Sleep(5000);//5秒毎にデータを更新する
                }

                Flags.IsActiveGetDataMock = false;
            });

        }


        public class ReceivedMessage
        {
            private string _message;

            public ReceivedMessage(string mes)
            {
                this._message = mes;
            }

            public override string ToString()
            {
                return this._message;
            }

            public JsonData JsonParse(JavaScriptSerializer jss)
            {
                return jss.Deserialize<JsonData>(this._message);
            }
        }

        public class ReceivedMessagesBuffer
        {
            private List<ReceivedMessage> _buffer;

            public ReceivedMessagesBuffer()
            {
                this._buffer = new List<ReceivedMessage>();
            }

            public void Add(ReceivedMessage mes)
            {
                if (this._buffer.Count >= 100)
                    return;

                this._buffer.Add(mes);
            }

            public override string ToString()
            {
                string ret_val = "";

                foreach (var mes in this._buffer)
                {
                    ret_val = ret_val + mes + "\n";
                }

                return ret_val;
            }
        }


    }
}
