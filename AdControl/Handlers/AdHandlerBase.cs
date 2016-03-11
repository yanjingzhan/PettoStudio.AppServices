using PAdControl.Encryption;
using PAdControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PAdControl.Handlers
{
    public class BannerAdHandlerBase
    {
        private static BannerAdHandlerBase _bannerAdHandlerBase;

        private static object _locker = new object();

        public static BannerAdHandlerBase Instance
        {
            get
            {
                if (_bannerAdHandlerBase == null)
                {
                    lock (_locker)
                    {
                        _bannerAdHandlerBase = new BannerAdHandlerBase();
                    }
                }

                return _bannerAdHandlerBase;
            }
        }

        /// <summary>
        /// 获取广告信息完成
        /// </summary>
        public event EventHandler<AdEventArgs> GetAdInfoCompleted;

        public void GetAdInfoAsync(string appName, string appVersion, string appId, string adIndex)
        {
            try
            {
                string token = MD5.GetMd5String(appName + "fuck" + appVersion + "petto");
                WebClient wc = new WebClient();
                string url = string.Format("http://appservices.ad.pettostudio.net/adcontrol.aspx?action=getadinfo&appname={0}&appid={1}&appversion={2}&token={3}&adindex={4}&timestamp=" + DateTime.Now.Millisecond
                    , appName, appId, appVersion, token, adIndex);

                wc.DownloadStringAsync(new Uri(url, UriKind.Absolute));
                wc.DownloadStringCompleted += (s1, e1) =>
                {
                    if (GetAdInfoCompleted != null)
                    {
                        if (e1.Error == null)
                        {
                            List<AdInfo> adInfoList = Serialize.JsonHelper.DeSerializerFromJson<List<AdInfo>>(e1.Result);
                            GetAdInfoCompleted(this, new AdEventArgs { AdInfoList = adInfoList, ErrorMessage = e1.Result });
                        }
                        else
                        {
                            GetAdInfoCompleted(this, new AdEventArgs { AdInfoList = null, ErrorMessage = e1.Error.Message });
                        }

                    }
                };
            }
            catch (Exception ex)
            {
                GetAdInfoCompleted(this, new AdEventArgs { AdInfoList = null, ErrorMessage = ex.Message });
            }
        }

        public void PostAdClickCount(string appName, string appId, string appVersion, string adName, string adType, string clickCount, string showCount, string adIndex)
        {
            try
            {
                string token = MD5.GetMd5String(appName + "fuck" + appVersion + "petto" + adType + adIndex + clickCount);
                WebClient wc = new WebClient();
                string url = string.Format("http://appservices.ad.pettostudio.net/adcontrol.aspx?action=postadclickcount&appname={0}&appid={1}&appversion={2}&adname={3}&adtype={4}&clickcount={5}&showcount={6}&adindex={7}&token={8}&timestamp=" + DateTime.Now.Millisecond
                                             , appName, appId, appVersion, adName, adType, clickCount, showCount, adIndex, token);

                wc.DownloadStringAsync(new Uri(url, UriKind.Absolute));
            }
            catch { }
        }

        public void PostAdShowCount(string appName, string appId, string appVersion, string adName, string adType, string clickCount, string showCount, string adIndex)
        {
            try
            {
                string token = MD5.GetMd5String(appName + "fuck" + appVersion + "petto" + adType + adIndex + showCount);
                WebClient wc = new WebClient();
                string url = string.Format("http://appservices.ad.pettostudio.net/adcontrol.aspx?action=postadshowcount&appname={0}&appid={1}&appversion={2}&adname={3}&adtype={4}&clickcount={5}&showcount={6}&adindex={7}&token={8}&timestamp=" + DateTime.Now.Millisecond
                                             , appName, appId, appVersion, adName, adType, clickCount, showCount, adIndex, token);

                wc.DownloadStringAsync(new Uri(url, UriKind.Absolute));
            }
            catch { }
        }

        /// <summary>
        /// 广告今天点击了，将点击次数和日期记录 
        /// </summary>
        /// <param name="adName"></param>
        public void AdClicked(string adName)
        {
            int count_t = GetAdClickCount(adName) + 1;
            IO.AppSettingsHelper.SaveStringToAppSettings(adName, DateTime.Today.ToString() + "_" + count_t.ToString());
        }

        /// <summary>
        /// 广告今天点击的次数
        /// </summary>
        /// <param name="adName"></param>
        /// <returns></returns>
        public int GetAdClickCount(string adName)
        {
            string t = IO.AppSettingsHelper.GetStringFromAppSettings(adName);
            return string.IsNullOrWhiteSpace(t) ? 0 : (DateTime.Parse(t.Split('_')[0]) == DateTime.Today ? int.Parse(t.Split('_')[1]) : 0);
        }
    }
}
