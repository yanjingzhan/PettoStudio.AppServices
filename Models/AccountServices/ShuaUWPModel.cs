using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.AccountServices
{
    public class ShuaUWPModel
    {
        public string account;
        public string password;

        public List<UWP> UWPInfoList;
    }

    public class UWP
    {
        public string AppID;
        public string ProtocolLink;
    }
}
