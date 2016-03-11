using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemTimePlayer
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }

        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime sysTime);
        // 用于获得系统时间
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SystemTime sysTime);

        static void Main(string[] args)
        {
            if (DateTime.Now.Year != 2099)
            {
                SystemTime systemTime = new SystemTime();
                systemTime.wYear = (ushort)2099;
                systemTime.wMonth = (ushort)DateTime.Now.Month;
                systemTime.wDay = (ushort)DateTime.Now.Day;
                systemTime.wHour = (ushort)DateTime.Now.Hour;
                systemTime.wMinute = (ushort)DateTime.Now.Minute;
                systemTime.wSecond = (ushort)DateTime.Now.Second;
                // 将系统的时间设置为用户指定的时间
                SetLocalTime(ref systemTime);
            }
            else
            {
                WebClient wc = new WebClient();
                string[] contents = wc.DownloadString("http://www.beijing-time.org/time.asp").Split(';');

                if (contents.Length == 9)
                {
                    int index_t = -1;
                    SystemTime systemTime = new SystemTime();

                    index_t = contents[1].IndexOf("=");
                    systemTime.wYear = (ushort)int.Parse(contents[1].Substring(index_t + 1));

                    index_t = contents[2].IndexOf("=");
                    systemTime.wMonth = (ushort)int.Parse(contents[2].Substring(index_t + 1));

                    index_t = contents[3].IndexOf("=");
                    systemTime.wDay = (ushort)int.Parse(contents[3].Substring(index_t + 1));

                    index_t = contents[5].IndexOf("=");
                    systemTime.wHour = (ushort)int.Parse(contents[5].Substring(index_t + 1));

                    index_t = contents[6].IndexOf("=");
                    systemTime.wMinute = (ushort)int.Parse(contents[6].Substring(index_t + 1));

                    index_t = contents[7].IndexOf("=");
                    systemTime.wSecond = (ushort)int.Parse(contents[7].Substring(index_t + 1));

                    SetLocalTime(ref systemTime);
                }
            }
        }

    }
}
