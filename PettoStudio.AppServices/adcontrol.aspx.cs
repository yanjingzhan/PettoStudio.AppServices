//#define TEST
using Controller;
using PettoStudio.AppServices.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace PettoStudio.AppServices
{
    public partial class adcontrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, appversion, appname, appid, token, adname, adtype, clickcount, showcount, adindex;
                action = Request["action"] == null ? "" : Request["action"].Trim();
                appversion = Request["appversion"] == null ? "" : Request["appversion"].Trim();
                appname = Request["appname"] == null ? "" : Request["appname"].Trim();
                appid = Request["appid"] == null ? "" : Request["appid"].Trim();
                token = Request["token"] == null ? "" : Request["token"].Trim();
                adname = Request["adname"] == null ? "" : Request["adname"].Trim();
                adtype = Request["adtype"] == null ? "" : Request["adtype"].Trim();
                clickcount = Request["clickcount"] == null ? "" : Request["clickcount"].Trim();
                showcount = Request["showcount"] == null ? "" : Request["showcount"].Trim();
                adindex = Request["adindex"] == null ? "" : Request["adindex"].Trim();

                switch (action)
                {
                    case "getadinfo":
                        GetAdInfo(appname, appversion, appid, adindex, token);
                        break;

                    case "postadclickcount":
                        PostAdClickCount(appname, appid, appversion, adname, adtype, clickcount, showcount, adindex, token);
                        break;

                    case "postadshowcount":
                        PostAdShowCount(appname, appid, appversion, adname, adtype, clickcount, showcount, adindex, token);
                        break;

                    default:
                        //GetRankingsDataByMyRankingData(action, version, appname, playerid, playername, totalscore, devicetype, devicename, token);
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        public void GetAdInfo(string appname, string appversion, string appid, string adIndex, string token)
        {
#if !TEST
            string md5Sum = Encryption.Md5Sum(appname + "fuck" + appversion + "petto");
            if (md5Sum != token)
            {
                Response.Write("-102:you are shabi!");
            }
            else
#endif
            {
                string result = JsonHelper.SerializerToJson(
                    new AdsControl().GetAdInfo
                    (
                         new Models.In.AdsGetter
                            {
                                AppName = appname,
                                AppVersion = appversion,
                                AdIndex = int.Parse(adIndex)
                            }
                    ));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAdInfo");
            }
        }

        //public string AppName;
        //public string AppId;
        //public string AppVersion;
        //public string AdName;
        //public string AdType;
        //public int ClickCount;
        //public int ShowCount;

        public void PostAdClickCount(string appName, string appId, string appVersion, string adName, string adType, string clickCount, string showCount, string adIndex, string token)
        {
#if !TEST
            string md5Sum = Encryption.Md5Sum(appName + "fuck" + appVersion + "petto" + adType + adIndex + clickCount);
            if (md5Sum != token)
            {
                Response.Write("-102:you are shabi!");
            }
            else
#endif
            {
                try
                {
                    return;
                    string result = new AdsControl().PostAdClickCount
                        (
                             new Models.In.PostAdData
                             {
                                 AppName = appName,
                                 AppVersion = appVersion,
                                 AdIndex = int.Parse(adIndex),
                                 AdName = adName,
                                 AdType = adType,
                                 AppId = appId,
                                 ClickCount = int.Parse(clickCount),
                                 ShowCount = int.Parse(showCount)
                             }
                        );


                    Response.Write(result);
                    LogWriter.WriteLog(result, Page, "PostAdClickCount");
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    LogWriter.WriteLog(ex.Message, Page, "PostAdClickCount");
                }
            }
        }

        public void PostAdShowCount(string appName, string appId, string appVersion, string adName, string adType, string clickCount, string showCount, string adIndex, string token)
        {
#if !TEST
            string md5Sum = Encryption.Md5Sum(appName + "fuck" + appVersion + "petto" + adType + adIndex + showCount);
            if (md5Sum != token)
            {
                Response.Write("-102:you are shabi!");
            }
            else
#endif
            {
                try
                {
                    return;
                    string result = new AdsControl().PostAdShowCount
                        (
                             new Models.In.PostAdData
                             {
                                 AppName = appName,
                                 AppVersion = appVersion,
                                 AdIndex = int.Parse(adIndex),
                                 AdName = adName,
                                 AdType = adType,
                                 AppId = appId,
                                 ClickCount = int.Parse(clickCount),
                                 ShowCount = int.Parse(showCount)
                             }
                        );

                    Response.Write(result);
                    LogWriter.WriteLog(result, Page, "PostAdShowCount");
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    LogWriter.WriteLog(ex.Message, Page, "PostAdShowCount");
                }
            }
        }
    }
}