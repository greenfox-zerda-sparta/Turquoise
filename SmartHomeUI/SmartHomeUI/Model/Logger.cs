using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeUI
{
    public class Logger
    {
        public void logToFile(string logmsg)
        {
            using (StreamWriter w = File.AppendText("LogFile.txt"))
            {
                Log(logmsg, w);
            }
        }

        public void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("-------------------");
            w.WriteLine("Log: {0}", logMessage);
            w.WriteLine("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToLongTimeString());
        }

        public string fileContent(string filename)
        {
            string Text = File.ReadAllText(filename);
            return Text;
        }    
    }
}
