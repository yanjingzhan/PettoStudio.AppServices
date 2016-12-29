using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Utility
{
    public class CmdHelper
    {
        public static void ExecWithArgs(string exePath,string arg)
        {
            Process p2 = new Process();
            p2.StartInfo.FileName = exePath;
            p2.StartInfo.Arguments = arg;
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            p2.WaitForExit();
        }
    }
}
