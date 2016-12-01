using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Baseball.Models.Enums;

namespace Baseball.Data
{
    public class DataLogger
    {
        public DataLogger(string message, LogMessage messageType)
        {
            if (HttpContext.Current == null) return;

            string filePath = HttpContext.Current.Server.MapPath("~/" + $@"Data/Log/{DateTime.Today.ToShortDateString()}.log");
            switch (messageType)
            {
                case LogMessage.Event:
                    File.AppendAllText(filePath, $"{DateTime.Now.ToShortTimeString()} Event - {message}");
                    return;
                case LogMessage.Error:
                    File.AppendAllText(filePath, $"{DateTime.Now.ToShortTimeString()} Event - {message}");
                    return;
                case LogMessage.Other:
                    File.AppendAllText(filePath, $"{DateTime.Now.ToShortTimeString()} Event - {message}");
                    return;
            }
        }  
    }
}
