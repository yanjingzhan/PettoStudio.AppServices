using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.AndroidFullInfoServices
{
    public class AndroidInfo
    {
        public string Isu;
        public string SysUserAgent;
        public string Model;
        public string OsVersion;
        public string Vulome;
        public string NetworkOperator;
        public string PackageName;
        public string TimeZone;
        public string Language;
        public string PubAppId;

        public bool IsIFA;
        public string IFA;

        public bool IsRequestAd;
        public bool IsPlayAd;
    }

    public class AndroidAdWeightModel
    {
        public string PackageName;
        public string PubAppId;
        public int Weight;
    }
}
