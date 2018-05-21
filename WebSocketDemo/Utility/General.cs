using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Threading.Thread;
using static WebSocketDemo.State;

namespace WebSocketDemo
{


    public static class General
    {

        public static void ShowTarget()
        {
            var adr = "";
            switch (State.Target)
            {
                case State.TARGET.DEMO_01:
                    adr = $"ATS DEMO 01    {Constants.ATS_DEMO1}";
                    break;
                case State.TARGET.DEMO_02:
                    adr = $"ATS DEMO 02    {Constants.ATS_DEMO2}";
                    break;
                case State.TARGET.DEMO_03:
                    adr = $"ATS DEMO 03    {Constants.ATS_DEMO3}";
                    break;
                case State.TARGET.DEMO_04:
                    adr = $"ATS DEMO 04    {Constants.ATS_DEMO4}";
                    break;
            }
            State.VmMainWindow.TargetAdr = adr;
        }

        public static void ShowTargetWithoutAdr()
        {
            var adr = "";
            switch (State.Target)
            {
                case State.TARGET.DEMO_01:
                    adr = $"ATS DEMO 01";
                    break;
                case State.TARGET.DEMO_02:
                    adr = $"ATS DEMO 02";
                    break;
                case State.TARGET.DEMO_03:
                    adr = $"ATS DEMO 03";
                    break;
                case State.TARGET.DEMO_04:
                    adr = $"ATS DEMO 04";
                    break;
            }
            State.VmMainWindow.TargetAdr = adr;
        }


    }

}

