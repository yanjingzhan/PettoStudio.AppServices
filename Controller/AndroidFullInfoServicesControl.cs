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
                        if (ts.Length > 2)
                        {
                            _androidAdWeightModelList.Add(new AndroidAdWeightModel { PubAppId = ts[0], PackageName = ts[1], Weight = int.Parse(ts[2]) });
                        }
                    }
                }
            }
        }

        public AndroidInfo GetAndroidInfo(string networkOperator, string language, string timeZone)
        {
            int limitAlow = int.Parse(INIHelper.ReadIniData("conf", "LimitAlow", "5", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));
            int playAdLimitAlow = int.Parse(INIHelper.ReadIniData("conf", "playAdLimitAlow", "6", AppDomain.CurrentDomain.BaseDirectory + "config.ini"));

            bool isRequestAd = limitAlow > _rd.Next(10);
            if (isRequestAd)
            {
                AndroidAdWeightModel weightInfo = GetAndroidAdWeightModelRandom(_androidAdWeightModelList);

                bool isPlayAd = playAdLimitAlow > _rd.Next(10);
                
                int tIndex = _rd.Next(_sysUserAgentList_1.Count);
                string[] timeZones = INIHelper.ReadIniData("TimeZone", timeZone.Split(' ')[0].Trim(), "America/New_York", AppDomain.CurrentDomain.BaseDirectory + "config.ini").Split(',');

                return new AndroidInfo
              {
                  NetworkOperator = networkOperator,
                  Vulome = _vulomeList[_rd.Next(_vulomeList.Count)],

                  SysUserAgent = _sysUserAgentList_1[tIndex] + " " +
                  _sysUserAgentList_2[_rd.Next(_sysUserAgentList_2.Count)] + " " +
                  _sysUserAgentList_3[_rd.Next(_sysUserAgentList_3.Count)],

                  IsIFA = !(_chinaNetworkOperatorList.Contains(networkOperator) && _rd.Next(10) > 0),
                  IFA = Guid.NewGuid().ToString().ToLower(),
                  Isu = CreateAnrdoidDeviceID(),
                  Language = new CultureInfo(language, false).ThreeLetterISOLanguageName.Trim(),
                  Model = _modelList[tIndex],
                  OsVersion = _osVersionList[tIndex],
                  TimeZone = timeZones[_rd.Next(timeZones.Length)],
                  PackageName = weightInfo.PackageName,
                  PubAppId = weightInfo.PubAppId,
                  IsRequestAd = isRequestAd,
                  IsPlayAd = isPlayAd
              };
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
