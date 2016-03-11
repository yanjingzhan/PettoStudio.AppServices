using Controller;
using GamesManager.Utility;
using Models.GameManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace GamesManager
{
    public partial class AndroidGamePusher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action;

                string filename;
                string packagename;

                string gamename;
                string version;
                string state;
                string gameid;
                string pushername;

                string youmiappid;
                string youmiid;

                string googlebanner;
                string googlechaping;

                string duomengappid;
                string duomengbannerid;
                string duomengchapingid;

                string baiduappid;

                string sanliulingappid;
                string sanliulingbannerid;
                string sanliulingchapingid;

                string baidustorestatus;

                string sanliulingstorestatus;

                string xiaomistorestatus;

                string addtime;
                string updatetime;
                string devaccount;
                string devpassword;


                string sanliulingstoredevaccount;
                string sanliulingstoredevpassword;
                string baidustoredevaccount;
                string baidustoredevpassword;
                string xiaomistoredevaccount;
                string xiaomistoredevpassword;

                string jingzhongappid;
                string iadpushappkey;
                string downloadaddress;
                string apptype;

                string count;

                string appname;
                string detailaddress;
                string rate;
                string id;

                string iadkey, iadappname, jingzhongkey, jingzhongappname, status;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                filename = Request["filename"] == null ? "" : Request["filename"].Trim();
                packagename = Request["packagename"] == null ? "" : Request["packagename"].Trim();
                gamename = Request["gamename"] == null ? "" : Request["gamename"].Trim();
                version = Request["version"] == null ? "" : Request["version"].Trim();
                state = Request["state"] == null ? "" : Request["state"].Trim();
                gameid = Request["gameid"] == null ? "" : Request["gameid"].Trim();
                pushername = Request["pushername"] == null ? "" : Request["pushername"].Trim();
                youmiappid = Request["youmiappid"] == null ? "" : Request["youmiappid"].Trim();
                youmiid = Request["youmiid"] == null ? "" : Request["youmiid"].Trim();
                googlebanner = Request["googlebanner"] == null ? "" : Request["googlebanner"].Trim();
                googlechaping = Request["googlechaping"] == null ? "" : Request["googlechaping"].Trim();
                duomengappid = Request["duomengappid"] == null ? "" : Request["duomengappid"].Trim();
                duomengbannerid = Request["duomengbannerid"] == null ? "" : Request["duomengbannerid"].Trim();
                duomengchapingid = Request["duomengchapingid"] == null ? "" : Request["duomengchapingid"].Trim();
                baiduappid = Request["baiduappid"] == null ? "" : Request["baiduappid"].Trim();
                sanliulingappid = Request["sanliulingappid"] == null ? "" : Request["sanliulingappid"].Trim();
                sanliulingbannerid = Request["sanliulingbannerid"] == null ? "" : Request["sanliulingbannerid"].Trim();
                sanliulingchapingid = Request["sanliulingchapingid"] == null ? "" : Request["sanliulingchapingid"].Trim();
                baidustorestatus = Request["baidustorestatus"] == null ? "" : Request["baidustorestatus"].Trim();
                sanliulingstorestatus = Request["sanliulingstorestatus"] == null ? "" : Request["sanliulingstorestatus"].Trim();
                xiaomistorestatus = Request["xiaomistorestatus"] == null ? "" : Request["xiaomistorestatus"].Trim();
                addtime = Request["addtime"] == null ? "" : Request["addtime"].Trim();
                updatetime = Request["updatetime"] == null ? "" : Request["updatetime"].Trim();
                devaccount = Request["devaccount"] == null ? "" : Request["devaccount"].Trim();
                devpassword = Request["devpassword"] == null ? "" : Request["devpassword"].Trim();

                sanliulingstoredevaccount = Request["sanliulingstoredevaccount"] == null ? "" : Request["sanliulingstoredevaccount"].Trim();
                sanliulingstoredevpassword = Request["sanliulingstoredevpassword"] == null ? "" : Request["sanliulingstoredevpassword"].Trim();
                baidustoredevaccount = Request["baidustoredevaccount"] == null ? "" : Request["baidustoredevaccount"].Trim();
                baidustoredevpassword = Request["baidustoredevpassword"] == null ? "" : Request["baidustoredevpassword"].Trim();
                xiaomistoredevaccount = Request["xiaomistoredevaccount"] == null ? "" : Request["xiaomistoredevaccount"].Trim();
                xiaomistoredevpassword = Request["xiaomistoredevpassword"] == null ? "" : Request["xiaomistoredevpassword"].Trim();

                jingzhongappid = Request["jingzhongappid"] == null ? "" : Request["jingzhongappid"].Trim();
                iadpushappkey = Request["iadpushappkey"] == null ? "" : Request["iadpushappkey"].Trim();

                baidustoredevaccount = Request["baidustoredevaccount"] == null ? "" : Request["baidustoredevaccount"].Trim();
                baidustoredevpassword = Request["baidustoredevpassword"] == null ? "" : Request["baidustoredevpassword"].Trim();
                sanliulingstoredevaccount = Request["sanliulingstoredevaccount"] == null ? "" : Request["sanliulingstoredevaccount"].Trim();
                sanliulingstoredevpassword = Request["sanliulingstoredevpassword"] == null ? "" : Request["sanliulingstoredevpassword"].Trim();
                xiaomistoredevaccount = Request["xiaomistoredevaccount"] == null ? "" : Request["xiaomistoredevaccount"].Trim();
                xiaomistoredevpassword = Request["xiaomistoredevpassword"] == null ? "" : Request["xiaomistoredevpassword"].Trim();
                downloadaddress = Request["downloadaddress"] == null ? "" : Request["downloadaddress"].Trim();
                apptype = Request["apptype"] == null ? "" : Request["apptype"].Trim();

                appname = Request["appname"] == null ? "" : Request["appname"].Trim();
                detailaddress = Request["detailaddress"] == null ? "" : Request["detailaddress"].Trim();
                rate = Request["rate"] == null ? "" : Request["rate"].Trim();
                id = Request["id"] == null ? "" : Request["id"].Trim();

                count = Request["count"] == null ? "" : Request["count"].Trim();

                iadkey = Request["iadkey"] == null ? "" : Request["iadkey"].Trim();
                iadappname = Request["iadappname"] == null ? "" : Request["iadappname"].Trim();
                jingzhongkey = Request["jingzhongkey"] == null ? "" : Request["jingzhongkey"].Trim();
                jingzhongappname = Request["jingzhongappname"] == null ? "" : Request["jingzhongappname"].Trim();
                status = Request["status"] == null ? "" : Request["status"].Trim();


                switch (action.ToLower())
                {
                    case "addandroidpushgameinfo":
                        AddAndroidPushGameInfo(filename, packagename, gamename, version, state,
                                            gameid, pushername, youmiappid, youmiid, googlebanner,
                                            googlechaping, duomengappid, duomengbannerid, duomengchapingid,
                                            baiduappid, sanliulingappid, sanliulingbannerid, sanliulingchapingid,
                                            baidustorestatus, sanliulingstorestatus, xiaomistorestatus, addtime, updatetime,
                                            devaccount, devpassword, sanliulingstoredevaccount, sanliulingstoredevpassword,
                                            baidustoredevaccount, baidustoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword,
                                            jingzhongappid, iadpushappkey, downloadaddress, apptype);
                        break;

                    case "updateandroidpushgameinfo":
                        UpdateAndroidPushGameInfo(filename, packagename, gamename, version, state,
                                            gameid, pushername, youmiappid, youmiid, googlebanner,
                                            googlechaping, duomengappid, duomengbannerid, duomengchapingid,
                                            baiduappid, sanliulingappid, sanliulingbannerid, sanliulingchapingid,
                                            baidustorestatus, sanliulingstorestatus, xiaomistorestatus, addtime, updatetime,
                                            devaccount, devpassword, sanliulingstoredevaccount, sanliulingstoredevpassword,
                                            baidustoredevaccount, baidustoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword,
                                            jingzhongappid, iadpushappkey, downloadaddress, apptype);
                        break;

                    case "getandroidpushgameinfo":
                        GetAndroidPushGameInfo(filename, packagename, gamename, version, state,
                                            gameid, pushername, youmiappid, youmiid, googlebanner,
                                            googlechaping, duomengappid, duomengbannerid, duomengchapingid,
                                            baiduappid, sanliulingappid, sanliulingbannerid, sanliulingchapingid,
                                            baidustorestatus, sanliulingstorestatus, xiaomistorestatus, addtime, updatetime,
                                            devaccount, devpassword, sanliulingstoredevaccount, sanliulingstoredevpassword,
                                            baidustoredevaccount, baidustoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword,
                                            count, jingzhongappid, iadpushappkey, downloadaddress, apptype);
                        break;

                    case "deletegameinfobynameandversionandpackagename":
                        DeleteGameInfoByNameAndVersionAndPackageName(gamename, version, packagename);
                        break;

                    case "getdevaccounts":
                        GetDevAccounts(baidustoredevaccount, baidustoredevpassword, sanliulingstoredevaccount, sanliulingstoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword, count);
                        break;

                    case "getandroidnotcompletedpushgameinfomodellistbypushernameandcount":
                        GetAndroidNotCompletedPushGameInfoModelListByPusherNameAndCount(pushername, count);
                        break;

                    case "getgamestate":
                        GetGameState(gamename, version, packagename);
                        break;

                    case "getgameisdone":
                        GetGameIsDone(packagename);
                        break;

                    case "getonefreeliumanggameinfo":
                        GetOneFreeLiuMangGameInfo();
                        break;

                    case "updategamenameandstate":
                        UpdateGameNameAndState(gamename, state, packagename);
                        break;

                    case "addappinfotemp":
                        AddAppInfoTemp(appname, detailaddress, downloadaddress, apptype, rate, state);
                        break;

                    case "updateappinfotemp":
                        UpdateAppInfoTemp(appname, detailaddress, downloadaddress, apptype, rate, state, id);
                        break;

                    case "getappinfotemplist":
                        GetAppInfoTempList(appname, detailaddress, downloadaddress, apptype, rate, state, count);
                        break;

                    case "deleteappinfotempbyid":
                        DeleteAppInfoTempByID(id);
                        break;

                    case "addliumangads":
                        AddLiuMangAds(iadkey, iadappname, jingzhongkey, jingzhongappname, status);
                        break;

                    case "updateliumangads":
                        UpdateLiuMangAds(iadkey, iadappname, jingzhongkey, jingzhongappname, status, id);
                        break;

                    case "getliumangadslist":
                        GetLiuMangAdsList(iadkey, iadappname, jingzhongkey, jingzhongappname, status, id, count);
                        break;

                    case "deleteliumangadsbyid":
                        DeleteLiuMangAdsByID(id);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }

            }
        }

        #region LiuMangAds

        public void AddLiuMangAds(string iadkey, string iadappname, string jingzhongkey, string jingzhongappname, string status)
        {
            try
            {
                new AndroidPushGameInfoControl().AddLiuMangAds(
                    new LiuMangAds
                    {
                        IadKey = iadkey,
                        IadAppName = iadappname,
                        JingZhongKey = jingzhongkey,
                        JingZhongAppName = jingzhongappname,
                        Status = status
                    });


                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void UpdateLiuMangAds(string iadkey, string iadappname, string jingzhongkey, string jingzhongappname, string status,string id)
        {
            try
            {
                new AndroidPushGameInfoControl().UpdateLiuMangAds(
                    new LiuMangAds
                    {
                        IadKey = iadkey,
                        IadAppName = iadappname,
                        JingZhongKey = jingzhongkey,
                        JingZhongAppName = jingzhongappname,
                        Status = status,
                        ID = id
                    });


                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void GetLiuMangAdsList(string iadkey, string iadappname, string jingzhongkey, string jingzhongappname, string status, string id, string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AndroidPushGameInfoControl().GetLiuMangAdsList(
                    new LiuMangAds
                    {
                        IadKey = iadkey,
                        IadAppName = iadappname,
                        JingZhongKey = jingzhongkey,
                        JingZhongAppName = jingzhongappname,
                        Status = status,
                        ID = id
                    },
                    int.Parse(count)));
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void DeleteLiuMangAdsByID(string id)
        {
            try
            {
                new AndroidPushGameInfoControl().DeleteLiuMangAdsByID(id);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }


        #endregion


        #region AppInfoTemp

        public void AddAppInfoTemp(string appname, string detailaddress, string downloadaddress, string apptype, string rate, string state)
        {
            try
            {
                new AndroidPushGameInfoControl().AddAppInfoTemp(
                    new AppInfoTempModel
                    {
                        AppName = appname,
                        AppType = apptype,
                        DetailAddress = detailaddress,
                        DownloadAddress = downloadaddress,
                        Rate = rate,
                        State = state
                    });


                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void UpdateAppInfoTemp(string appname, string detailaddress, string downloadaddress, string apptype, string rate, string state, string id)
        {
            try
            {
                new AndroidPushGameInfoControl().UpdateAppInfoTemp(
                    new AppInfoTempModel
                    {
                        AppName = appname,
                        AppType = apptype,
                        DetailAddress = detailaddress,
                        DownloadAddress = downloadaddress,
                        Rate = rate,
                        ID = id,
                        State = state
                    });


                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }

        }

        public void GetAppInfoTempList(string appname, string detailaddress, string downloadaddress, string apptype, string rate, string state, string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AndroidPushGameInfoControl().GetAppInfoTempList(
                    new AppInfoTempModel
                    {
                        AppName = appname,
                        AppType = apptype,
                        DetailAddress = detailaddress,
                        DownloadAddress = downloadaddress,
                        Rate = rate,
                        State = state
                    },
                    int.Parse(count)));
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void DeleteAppInfoTempByID(string id)
        {
            try
            {
                new AndroidPushGameInfoControl().DeleteAppInfoTempByID(id);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        #endregion

        public void UpdateGameNameAndState(string gameName, string state, string packageName)
        {
            try
            {
                new AndroidPushGameInfoControl().UpdateGameNameAndState(gameName, state, packageName);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void GetOneFreeLiuMangGameInfo()
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new AndroidPushGameInfoControl().GetOneFreeLiuMangGameInfo());
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void GetGameState(string gameName, string version, string pachageName)
        {
            try
            {
                string result = new AndroidPushGameInfoControl().GetGameState(gameName, version, pachageName);

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void GetGameIsDone(string pachageName)
        {
            try
            {
                string result = new AndroidPushGameInfoControl().GetGameIsDone(pachageName).ToString();

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void GetAndroidNotCompletedPushGameInfoModelListByPusherNameAndCount(string pusherName, string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new AndroidPushGameInfoControl().GetAndroidNotCompletedPushGameInfoModelListByPusherNameAndCount(
                    pusherName, int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }

        }


        public void GetDevAccounts(string baidustoredevaccount, string baidustoredevpassword,
                                   string sanliulingstoredevaccount, string sanliulingstoredevpassword,
                                   string xiaomistoredevaccount, string xiaomistoredevpassword, string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new AndroidPushGameInfoControl().GetAndroidDevAccountList(baidustoredevaccount, baidustoredevpassword,
                    sanliulingstoredevaccount, sanliulingstoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword, int.Parse(count)));
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void AddAndroidPushGameInfo(string filename, string packagename, string gamename, string version, string state,
                                           string gameid, string pushername, string youmiappid, string youmiid, string googlebanner,
                                           string googlechaping, string duomengappid, string duomengbannerid, string duomengchapingid,
                                           string baiduappid, string sanliulingappid, string sanliulingbannerid, string sanliulingchapingid,
                                           string baidustorestatus, string sanliulingstorestatus, string xiaomistorestatus, string addtime, string updatetime,
                                           string devaccount, string devpassword, string sanliulingstoredevaccount, string sanliulingstoredevpassword,
                                           string baidustoredevaccount, string baidustoredevpassword, string xiaomistoredevaccount, string xiaomistoredevpassword,
                                           string jingzhongappid, string iadpushappkey, string downloadAddress, string apptype)
        {
            try
            {
                AndroidPushGameInfoModel pushGameInfoModel = new AndroidPushGameInfoModel
                {
                    AddTime = addtime,
                    BaiDuAppID = baiduappid,
                    BaiduStoreDevAccount = baidustoredevaccount,
                    BaiduStoreDevPassword = baidustoredevpassword,
                    BaiduStoreStatus = baidustorestatus,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    DuoMengAppID = duomengappid,
                    DuoMengBannerID = duomengbannerid,
                    DuoMengChaPingID = duomengchapingid,
                    FileName = filename,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PackageName = packagename,
                    PusherName = pushername,
                    SanLiuLingAppID = sanliulingappid,
                    SanLiuLingBannerID = sanliulingbannerid,
                    SanLiuLingChaPingID = sanliulingchapingid,
                    SanLiuLingStoreDevAccount = sanliulingstoredevaccount,
                    SanLiuLingStoreDevPassword = sanliulingstoredevpassword,
                    SanLiuLingStoreStatus = sanliulingstorestatus,
                    State = state,
                    UpdateTime = updatetime,
                    Version = version,
                    XiaomiStoreDevAccount = xiaomistoredevaccount,
                    XiaomiStoreDevPassword = xiaomistoredevpassword,
                    XiaomiStoreStatus = xiaomistorestatus,
                    YouMiAppID = youmiappid,
                    YouMiID = youmiid,
                    JingZhongAppId = jingzhongappid,
                    IAdPushAppKey = iadpushappkey,
                    DownloadAddress = downloadAddress,
                    AppType = apptype
                };

                new AndroidPushGameInfoControl().AddAndroidPushGameInfo(pushGameInfoModel);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void UpdateAndroidPushGameInfo(string filename, string packagename, string gamename, string version, string state,
                                   string gameid, string pushername, string youmiappid, string youmiid, string googlebanner,
                                   string googlechaping, string duomengappid, string duomengbannerid, string duomengchapingid,
                                   string baiduappid, string sanliulingappid, string sanliulingbannerid, string sanliulingchapingid,
                                   string baidustorestatus, string sanliulingstorestatus, string xiaomistorestatus, string addtime, string updatetime,
                                   string devaccount, string devpassword, string sanliulingstoredevaccount, string sanliulingstoredevpassword,
                                   string baidustoredevaccount, string baidustoredevpassword, string xiaomistoredevaccount, string xiaomistoredevpassword,
                                   string jingzhongappid, string iadpushappkey, string downloadAddress, string apptype)
        {
            try
            {
                AndroidPushGameInfoModel pushGameInfoModel = new AndroidPushGameInfoModel
                {
                    AddTime = addtime,
                    BaiDuAppID = baiduappid,
                    BaiduStoreDevAccount = baidustoredevaccount,
                    BaiduStoreDevPassword = baidustoredevpassword,
                    BaiduStoreStatus = baidustorestatus,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    DuoMengAppID = duomengappid,
                    DuoMengBannerID = duomengbannerid,
                    DuoMengChaPingID = duomengchapingid,
                    FileName = filename,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PackageName = packagename,
                    PusherName = pushername,
                    SanLiuLingAppID = sanliulingappid,
                    SanLiuLingBannerID = sanliulingbannerid,
                    SanLiuLingChaPingID = sanliulingchapingid,
                    SanLiuLingStoreDevAccount = sanliulingstoredevaccount,
                    SanLiuLingStoreDevPassword = sanliulingstoredevpassword,
                    SanLiuLingStoreStatus = sanliulingstorestatus,
                    State = state,
                    UpdateTime = updatetime,
                    Version = version,
                    XiaomiStoreDevAccount = xiaomistoredevaccount,
                    XiaomiStoreDevPassword = xiaomistoredevpassword,
                    XiaomiStoreStatus = xiaomistorestatus,
                    YouMiAppID = youmiappid,
                    YouMiID = youmiid,
                    JingZhongAppId = jingzhongappid,
                    IAdPushAppKey = iadpushappkey,
                    DownloadAddress = downloadAddress,
                    AppType = apptype
                };

                new AndroidPushGameInfoControl().UpdateAndroidPushGameInfo(pushGameInfoModel);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        public void GetAndroidPushGameInfo(string filename, string packagename, string gamename, string version, string state,
                                  string gameid, string pushername, string youmiappid, string youmiid, string googlebanner,
                                  string googlechaping, string duomengappid, string duomengbannerid, string duomengchapingid,
                                  string baiduappid, string sanliulingappid, string sanliulingbannerid, string sanliulingchapingid,
                                  string baidustorestatus, string sanliulingstorestatus, string xiaomistorestatus, string addtime, string updatetime,
                                  string devaccount, string devpassword, string sanliulingstoredevaccount, string sanliulingstoredevpassword,
                                  string baidustoredevaccount, string baidustoredevpassword, string xiaomistoredevaccount, string xiaomistoredevpassword,
                                  string count, string jingzhongappid, string iAdPushAppKey, string downloadAddress, string apptype)
        {
            try
            {
                AndroidPushGameInfoModel pushGameInfoModel = new AndroidPushGameInfoModel
                {
                    AddTime = addtime,
                    BaiDuAppID = baiduappid,
                    BaiduStoreDevAccount = baidustoredevaccount,
                    BaiduStoreDevPassword = baidustoredevpassword,
                    BaiduStoreStatus = baidustorestatus,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    DuoMengAppID = duomengappid,
                    DuoMengBannerID = duomengbannerid,
                    DuoMengChaPingID = duomengchapingid,
                    FileName = filename,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PackageName = packagename,
                    PusherName = pushername,
                    SanLiuLingAppID = sanliulingappid,
                    SanLiuLingBannerID = sanliulingbannerid,
                    SanLiuLingChaPingID = sanliulingchapingid,
                    SanLiuLingStoreDevAccount = sanliulingstoredevaccount,
                    SanLiuLingStoreDevPassword = sanliulingstoredevpassword,
                    SanLiuLingStoreStatus = sanliulingstorestatus,
                    State = state,
                    UpdateTime = updatetime,
                    Version = version,
                    XiaomiStoreDevAccount = xiaomistoredevaccount,
                    XiaomiStoreDevPassword = xiaomistoredevpassword,
                    XiaomiStoreStatus = xiaomistorestatus,
                    YouMiAppID = youmiappid,
                    YouMiID = youmiid,
                    JingZhongAppId = jingzhongappid,
                    IAdPushAppKey = iAdPushAppKey,
                    DownloadAddress = downloadAddress,
                    AppType = apptype
                };

                string result = JsonHelper.SerializerToJson(
                    new AndroidPushGameInfoControl().GetAndroidPushGameInfoModelListByCount(pushGameInfoModel, int.Parse(count)));
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }

        private void DeleteGameInfoByNameAndVersionAndPackageName(string gamename, string version, string pachageName)
        {
            try
            {
                new AndroidPushGameInfoControl().DeleteGameInfoByNameAndVersionAndPackageName(gamename, version, pachageName);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AndroidGamePusher");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AndroidGamePusher");
            }
        }
    }
}