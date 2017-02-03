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

        public bool IsNew;
        public bool IsFullPlay;

        public string Platform;

        public int Width;
        public int Height;

        public bool IsContinuousRequest;
        public bool IsCPM;
    }

    public class AndroidAdWeightModel
    {
        public string Platform;
        public string PackageName;
        public string PubAppId;
        public int Weight;
        public double CPM;
    }

    public class IOSDeviceInfoModel
    {
        public string UserAgent;
        public string OSVersion;
        public int Width;
        public int Height;
        public string Model;
        public float Volume;
        public string IFA;
        public string Type;
        public string MinOS;
    }
}
