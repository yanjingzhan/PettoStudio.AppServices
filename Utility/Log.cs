using System;
using System.IO;

namespace Utility
{
    /// <summary>
    /// 日志记录类
    /// </summary>
    public class Log
    {
        public static void Write(string Ip, string stringFrom, string stringQuery, string Result, string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string filePath = directoryPath + "\\weblog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log";
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
            using (StreamWriter sr = new StreamWriter(filePath, true))
            {
                string TimeMark = DateTime.Now.ToString();
                sr.WriteLine(Ip + "," + TimeMark + "," + stringFrom + stringQuery + "," + Result);
                sr.Close();
            }
        }

        public static void Write(string Ip, string stringFrom, string stringQuery, string Result, string directoryPath, string fileNamePre)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filePath = directoryPath + "\\" + fileNamePre + "_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log";
                if (!File.Exists(filePath))
                {
                    FileStream fs = File.Create(filePath);
                    fs.Close();
                }
                using (StreamWriter sr = new StreamWriter(filePath, true))
                {
                    string TimeMark = DateTime.Now.ToString();
                    sr.WriteLine(Ip + "," + TimeMark + "," + stringFrom + stringQuery + "," + Result);
                    sr.Close();
                }
            }
            catch { }
        }

        public static void Write(string message, string dir, string fileNamePre)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string filePath = dir + "\\" + fileNamePre + "_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log";
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ":" + message);
                sw.Close();
            }
        }
    }
}
