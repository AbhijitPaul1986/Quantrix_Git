using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLog
{
    public class Error
    {
        public static void log(System.Exception ex, string functionName, int? index = null)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\errorLog_" + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine("DateTime:" + DateTime.Now + System.Environment.NewLine);
                    sw.WriteLine("File: @" + new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName() + System.Environment.NewLine);
                    sw.WriteLine("Exception:" + ex.Message + System.Environment.NewLine);
                    sw.WriteLine("Stack Trace:" + ex.StackTrace + System.Environment.NewLine);
                    sw.WriteLine("------------------------------------------------" + System.Environment.NewLine);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("DateTime:" + DateTime.Now + System.Environment.NewLine);
                    sw.WriteLine("File: @" + new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName() + System.Environment.NewLine);
                    sw.WriteLine("Exception:" + ex.Message + System.Environment.NewLine);
                    sw.WriteLine("Stack Trace:" + ex.StackTrace + System.Environment.NewLine);
                    sw.WriteLine("------------------------------------------------" + System.Environment.NewLine);
                    sw.Close();
                }
            }
            //if (index == null)
            //{ Save(ex, functionName, Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString()); }

        }

        
    }
}
