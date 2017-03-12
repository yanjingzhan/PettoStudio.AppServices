using Models.AndroidFullInfoServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Utility;

namespace Controller
{
    public class AndroidFullInfoServicesControl
    {
        private static Random _rd = new Random();
        private static string _hexString = "0123456789abcdef";

        private static List<string> _sysUserAgentList_1 = new List<string>();
        private static List<string> _sysUserAgentList_2 = new List<string>();
        private static List<string> _sysUserAgentList_3 = new List<string>();
        private static List<string> _modelList = new List<string>();
        private static List<string> _osVersionList = new List<string>();

        private static List<string> _vulomeList = new List<string>();
        private static List<string> _networkOperatorList = new List<string>();

        private static List<string> _chinaNetworkOperatorList = new List<string>();

        private static List<AndroidAdWeightModel> _androidAdWeightModelList = new List<AndroidAdWeightModel>();

        private static List<IOSDeviceInfoModel> _iosDeviceInfoModelList = new List<IOSDeviceInfoModel>();
        private static List<string> _sysUserAgentList_IOS = new List<string>();
        private static List<double> _iosVersionDouble = new List<double>();
        private static List<string> _iosVersionStr = new List<string>();

        private static Dictionary<string,string> _iosLanguageDic = new Dictionary<string,string>();

        static AndroidFullInfoServicesControl()
        {
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "uaServer.txt"))
            {
                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] shits = line.Split('|');

                    if (shits.Length > 2)
                    {
                        _sysUserAgentList_1.Add(shits[0]);
                        _sysUserAgentList_2.Add(shits[1]);
                        _sysUserAgentList_3.Add(shits[2]);
                        _modelList.Add(shits[3]);
                        _osVersionList.Add(shits[4]);
                    }
                }
            }

            string chinaNetworkOperator = INIHelper.ReadIniData("conf", "ChinaNetworkOperatorList", "CMCC,CUCC,CTCC", AppDomain.CurrentDomain.BaseDirectory + "config.ini");
            _chinaNetworkOperatorList = new List<string>();
            _chinaNetworkOperatorList.AddRange(chinaNetworkOperator.Split(','));

            _vulomeList = new List<string>
            {
                "0.1","0.2","0.3","0.4","0.5","0.6","0.7","0.8","0.9","0.8","0.5",
            };

            string[] androidAdWeightModelList = INIHelper.ReadIniData("AdsInfo", "AndroidAdWeightModelList", "", AppDomain.CurrentDomain.BaseDirectory + "config.ini").Split(',');

            if (androidAdWeightModelList.Length > 0)
            {
                _androidAdWeightModelList = new List<AndroidAdWeightModel>();
                foreach (var info in androidAdWeightModelList)
                {
                    if (info.Contains("|"))
                    {
                        string[] ts = info.Trim().Split('|');
                        if (ts.Length > 3)
                        {
                            _androidAdWeightModelList.Add(new AndroidAdWeightModel { Platform = ts[0], PubAppId = ts[1], PackageName = ts[2], Weight = int.Parse(ts[3]),CPM = double.Parse(ts[4]) });
                        }
                    }
                }
            }

            #region IOS

            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "iosUA.txt"))
            {
                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] shits = line.Split('|');

                    if (shits.Length > 2)
                    {
                        _sysUserAgentList_IOS.Add(shits[0]);
                        _iosVersionDouble.Add(double.Parse(shits[1]));
                        _iosVersionStr.Add(shits[2]);
                    }
                }
            }

            _iosDeviceInfoModelList = JsonHelper.DeserializeObjectFromJsonFile<List<IOSDeviceInfoModel>>(AppDomain.CurrentDomain.BaseDirectory + "DevicesList_iphone.json");

            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "iosLanguage.txt"))
            {
                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] shits = line.Split('|');

                    if (shits.Length > 1)
                    {
                        _iosLanguageDic.Add(shits[0].Trim(),shits[1].Trim());
                    }
                }
            }

            #endregion
        }

        public AndroidInfo GetAndroidInfo(string networkOperator, string language, string timeZone)
        {
            int limitAlow = int.Parse(INIHelper.ReadIniData("conf", "LimitAlow", "5", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));
            int playAdLimitAlow = int.Parse(INIHelper.ReadIniData("conf", "PlayAdLimitAlow", "6", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));
            int newRequestAlow = int.Parse(INIHelper.ReadIniData("conf", "NewRequestAlow", "6", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));
            int isFullPlayAlow = int.Parse(INIHelper.ReadIniData("conf", "IsFullPlayAlow", "6", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));
            int continuousRequestAlow = int.Parse(INIHelper.ReadIniData("conf", "ContinuousRequestAlow", "2", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));  

            bool isRequestAd = limitAlow > _rd.Next(10);
            if (isRequestAd)
            {
                AndroidAdWeightModel weightInfo = GetAndroidAdWeightModelRandom(_androidAdWeightModelList);

                bool isPlayAd = playAdLimitAlow > _rd.Next(10);
                bool isNew = newRequestAlow > _rd.Next(10);
                bool isFullPlay = isFullPlayAlow > _rd.Next(10);
                bool isContinuousRequest = continuousRequestAlow > _rd.Next(10);

                int tIndex = _rd.Next(_sysUserAgentList_1.Count);
                string[] timeZones = INIHelper.ReadIniData("TimeZone", timeZone.Split(' ')[0].Trim(), "America/New_York", AppDomain.CurrentDomain.BaseDirectory + "config.ini").Split(',');

                AndroidInfo androidInfo = new AndroidInfo
                {
                    NetworkOperator = GetNetworkOperator(networkOperator),
                    Vulome = _vulomeList[_rd.Next(_vulomeList.Count)],

                    SysUserAgent = _sysUserAgentList_1[tIndex] + " " +
                    _sysUserAgentList_2[_rd.Next(_sysUserAgentList_2.Count)] + " " +
                    _sysUserAgentList_3[_rd.Next(_sysUserAgentList_3.Count)],

                    IsIFA = !(_chinaNetworkOperatorList.Contains(networkOperator) && _rd.Next(10) > 0),
                    IFA = Guid.NewGuid().ToString().ToLower(),
                    Isu = CreateAnrdoidDeviceID(),
                    Model = _modelList[tIndex],
                    OsVersion = _osVersionList[tIndex],
                    TimeZone = timeZones[_rd.Next(timeZones.Length)],
                    PackageName = weightInfo.PackageName,
                    PubAppId = weightInfo.PubAppId,
                    Platform = weightInfo.Platform,
                    Language = new CultureInfo(language, false).ThreeLetterISOLanguageName.Trim(),
                    IsRequestAd = isRequestAd,
                    IsPlayAd = isPlayAd,
                    IsNew = isNew,
                    IsFullPlay = isFullPlay,
                    Height = 1920,
                    Width = 1080,
                    IsContinuousRequest = isContinuousRequest,
                    IsCPM = weightInfo.CPM > _rd.NextDouble()
                };

                if (weightInfo.Platform.ToLower() == "ios")
                {
                    var t = _iosDeviceInfoModelList[_rd.Next(_iosDeviceInfoModelList.Count)];

                    androidInfo.Language = language;
                    androidInfo.Height = t.Height;
                    androidInfo.Width = t.Width;

                    int index_t = GetUAIndexByMinOsVersion(double.Parse(t.MinOS));
                    androidInfo.SysUserAgent = _sysUserAgentList_IOS[index_t];
                    androidInfo.OsVersion = _iosVersionStr[index_t];
                    androidInfo.Model = t.Model;
                    androidInfo.IsIFA = true;
                    androidInfo.IFA = androidInfo.IFA.ToUpper();
                    androidInfo.Isu = androidInfo.IFA;

                    androidInfo.LanguageIOS = _iosLanguageDic.ContainsKey(language.ToLower()) ? _iosLanguageDic[language.ToLower()] : language;
                }

                return androidInfo;
            }
            else
            {
                return new AndroidInfo { IsRequestAd = false };
            }
        }

        public bool GetIsRequestAd()
        {
            int limitAlow = int.Parse(INIHelper.ReadIniData("conf", "LimitAlow", "5", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));
            return limitAlow > _rd.Next(10);
        }

        public string CreateAnrdoidDeviceID()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 16; i++)
            {
                sb.Append(_hexString[_rd.Next(_hexString.Length)]);
            }

            return sb.ToString();
        }

        private int GetUAIndexByMinOsVersion(double minOsVersion)
        {
            List<int> osVersionIndexList_t = new List<int>();

            for (int i = 0; i < _iosVersionDouble.Count; i++)
            {
                if (_iosVersionDouble[i] >= minOsVersion)
                {
                    osVersionIndexList_t.Add(i);
                }
            }

            return osVersionIndexList_t[_rd.Next(osVersionIndexList_t.Count)];
        }


        private string GetNetworkOperator(string networkOPeratorName)
        {
            switch (networkOPeratorName)
            {
                case "中国移动":
                    return "CMCC";

                case "中国联通":
                    return "CUCC";

                case "中国电信":
                    return "CTCC";

                default:
                    return networkOPeratorName;
            }
        }

        private AndroidAdWeightModel GetAndroidAdWeightModelRandom(List<AndroidAdWeightModel> shitList)
        {
            List<int> weightList = new List<int>();

            for (int i = 0; i < shitList.Count; i++)
            {
                if (i == 0)
                {
                    weightList.Add(shitList[i].Weight);
                }
                else
                {
                    weightList.Add(shitList[i].Weight + weightList[i - 1]);
                }
            }

            int currentNum = _rd.Next(weightList[weightList.Count - 1]);

            for (int i = 0; i < weightList.Count; i++)
            {
                if (weightList[i] > currentNum)
                {
                    return shitList[i];
                }
            }

            return null;
        }
    }
}
