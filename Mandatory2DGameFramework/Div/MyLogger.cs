﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Div
{
     public class MyLogger
    {
        private const string logname = "Mylog.txt";

        //public MyLogger()
        //{
        //    // Create a file to write to.
            
        //}
        private MyLogger()
        {
            // Create a file to write to.
        }

        private static MyLogger instance = new MyLogger();

        private static MyLogger _instance = null;
       

        public static MyLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MyLogger();
                }
                return _instance;
            }
        }

        public void Start()
        {
            TraceSource ts = new TraceSource(logname);
            ts.Switch = new SourceSwitch(logname, SourceLevels.Information.ToString());

            ts.Listeners.Add(new ConsoleTraceListener());

            ts.Listeners.Add(
                new TextWriterTraceListener($"{logname}.txt")
                { Filter = new EventTypeFilter(SourceLevels.Error) }
                );

            ts.Listeners.Add(new XmlWriterTraceListener($"{logname}.xml"));



            ts.TraceEvent(TraceEventType.Information, 700, "Message: Information");
            ts.TraceEvent(TraceEventType.Warning, 700, "Message: Warning");
            ts.TraceEvent(TraceEventType.Error, 700, "Message: Error");
            ts.TraceEvent(TraceEventType.Critical, 700, "Message: Critical");
            ts.Close();
        }

    }
}
