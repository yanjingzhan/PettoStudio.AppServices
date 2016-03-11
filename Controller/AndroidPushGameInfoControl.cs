using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using Models.GameManager;
using DataBaseLib;
using System.Data;

namespace Controller
{
    public class AndroidPushGameInfoControl
    {
        public List<AndroidPushGameInfoModel> GetAndroidPushGameInfoModelListByCount(AndroidPushGameInfoModel androidPushGameInfoModel, int count)
        {
            try
            {
                string gamename = string.IsNullOrEmpty(androidPushGameInfoModel.GameName) ? "[GameName]" : "'" + androidPushGameInfoModel.GameName + "'";
                string version = string.IsNullOrEmpty(androidPushGameInfoModel.Version) ? "[Version]" : "'" + androidPushGameInfoModel.Version + "'";
                string state = string.IsNullOrEmpty(androidPushGameInfoModel.State) ? "[State]" : "'" + androidPushGameInfoModel.State + "'";
                string gameid = string.IsNullOrEmpty(androidPushGameInfoModel.GameID) ? "[GameID]" : "'" + androidPushGameInfoModel.GameID + "'";
                string pushername = string.IsNullOrEmpty(androidPushGameInfoModel.PusherName) ? "[PusherName]" : "'" + androidPushGameInfoModel.PusherName + "'";

                string youmiappid = string.IsNullOrEmpty(androidPushGameInfoModel.YouMiAppID) ? "[YouMiAppID]" : "'" + androidPushGameInfoModel.YouMiAppID + "'";
                string youmiid = string.IsNullOrEmpty(androidPushGameInfoModel.YouMiID) ? "[YouMiID]" : "'" + androidPushGameInfoModel.YouMiID + "'";

                string googlebanner = string.IsNullOrEmpty(androidPushGameInfoModel.GoogleBanner) ? "[GoogleBanner]" : "'" + androidPushGameInfoModel.GoogleBanner + "'";
                string googlechaping = string.IsNullOrEmpty(androidPushGameInfoModel.GoogleChaping) ? "[GoogleChaping]" : "'" + androidPushGameInfoModel.GoogleChaping + "'";

                string duomengappid = string.IsNullOrEmpty(androidPushGameInfoModel.DuoMengAppID) ? "[DuoMengAppID]" : "'" + androidPushGameInfoModel.DuoMengAppID + "'";
                string duomengbannerid = string.IsNullOrEmpty(androidPushGameInfoModel.DuoMengBannerID) ? "[DuoMengBannerID]" : "'" + androidPushGameInfoModel.DuoMengBannerID + "'";
                string duomengchapingid = string.IsNullOrEmpty(androidPushGameInfoModel.DuoMengChaPingID) ? "[DuoMengChaPingID]" : "'" + androidPushGameInfoModel.DuoMengChaPingID + "'";

                string baiduappid = string.IsNullOrEmpty(androidPushGameInfoModel.BaiDuAppID) ? "[BaiDuAppID]" : "'" + androidPushGameInfoModel.BaiDuAppID + "'";

                string sanliulingappid = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingAppID) ? "[SanLiuLingAppID]" : "'" + androidPushGameInfoModel.SanLiuLingAppID + "'";
                string sanliulingbannerid = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingBannerID) ? "[SanLiuLingBannerID]" : "'" + androidPushGameInfoModel.SanLiuLingBannerID + "'";
                string sanliulingchapingid = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingChaPingID) ? "[SanLiuLingChaPingID]" : "'" + androidPushGameInfoModel.SanLiuLingChaPingID + "'";

                string baidustorestatus = string.IsNullOrEmpty(androidPushGameInfoModel.BaiduStoreStatus) ? "[BaiduStoreStatus]" : "'" + androidPushGameInfoModel.BaiduStoreStatus + "'";
                string sanliulingstorestatus = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingStoreStatus) ? "[SanLiuLingStoreStatus]" : "'" + androidPushGameInfoModel.SanLiuLingStoreStatus + "'";
                string xiaomistorestatus = string.IsNullOrEmpty(androidPushGameInfoModel.XiaomiStoreStatus) ? "[XiaomiStoreStatus]" : "'" + androidPushGameInfoModel.XiaomiStoreStatus + "'";

                string sanliulingstoredevaccount = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingStoreDevAccount) ? "[SanLiuLingStoreDevAccount]" : "'" + androidPushGameInfoModel.SanLiuLingStoreDevAccount + "'";
                string sanliulingstoredevpassword = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingStoreDevPassword) ? "[SanLiuLingStoreDevPassword]" : "'" + androidPushGameInfoModel.SanLiuLingStoreDevPassword + "'";
                string baidustoredevaccount = string.IsNullOrEmpty(androidPushGameInfoModel.BaiduStoreDevAccount) ? "[BaiduStoreDevAccount]" : "'" + androidPushGameInfoModel.BaiduStoreDevAccount + "'";
                string baidustoredevpassword = string.IsNullOrEmpty(androidPushGameInfoModel.BaiduStoreDevPassword) ? "[BaiduStoreDevPassword]" : "'" + androidPushGameInfoModel.BaiduStoreDevPassword + "'";
                string xiaomistoredevaccount = string.IsNullOrEmpty(androidPushGameInfoModel.XiaomiStoreDevAccount) ? "[XiaomiStoreDevAccount]" : "'" + androidPushGameInfoModel.XiaomiStoreDevAccount + "'";
                string xiaomistoredevpassword = string.IsNullOrEmpty(androidPushGameInfoModel.XiaomiStoreDevPassword) ? "[XiaomiStoreDevPassword]" : "'" + androidPushGameInfoModel.XiaomiStoreDevPassword + "'";

                string addtime = string.IsNullOrEmpty(androidPushGameInfoModel.AddTime) ? "[AddTime]" : "'" + androidPushGameInfoModel.AddTime + "'";
                string updatetime = string.IsNullOrEmpty(androidPushGameInfoModel.UpdateTime) ? "[UpdateTime]" : "'" + androidPushGameInfoModel.UpdateTime + "'";
                string devaccount = string.IsNullOrEmpty(androidPushGameInfoModel.DevAccount) ? "[DevAccount]" : "'" + androidPushGameInfoModel.DevAccount + "'";
                string devpassword = string.IsNullOrEmpty(androidPushGameInfoModel.DevPassword) ? "[DevPassword]" : "'" + androidPushGameInfoModel.DevPassword + "'";

                string filename = string.IsNullOrEmpty(androidPushGameInfoModel.FileName) ? "[FileName]" : "'" + androidPushGameInfoModel.FileName + "'";
                string packagename = string.IsNullOrEmpty(androidPushGameInfoModel.PackageName) ? "[PackageName]" : "'" + androidPushGameInfoModel.PackageName + "'";

                string jingzhongappid = string.IsNullOrEmpty(androidPushGameInfoModel.JingZhongAppId) ? "[JingZhongAppId]" : "'" + androidPushGameInfoModel.JingZhongAppId + "'";
                string iAdPushAppKey = string.IsNullOrEmpty(androidPushGameInfoModel.IAdPushAppKey) ? "[IAdPushAppKey]" : "'" + androidPushGameInfoModel.IAdPushAppKey + "'";
                string downloadAddress = string.IsNullOrEmpty(androidPushGameInfoModel.DownloadAddress) ? "[DownloadAddress]" : "'" + androidPushGameInfoModel.DownloadAddress + "'";
                string appType = string.IsNullOrEmpty(androidPushGameInfoModel.AppType) ? "[AppType]" : "'" + androidPushGameInfoModel.AppType + "'";


                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[AndroidPushGameInfo] WHERE " +
                                              "[GameName] = {1} AND [Version] = {2} AND [State] = {3} AND [GameID] = {4} AND [PusherName] = {5} " +
                                              "AND [YouMiAppID] = {6} AND [YouMiID] = {7} AND [GoogleBanner] = {8} AND [GoogleChaping] = {9} " +
                                              "AND [DuoMengAppID] = {10} AND [DuoMengBannerID] = {11} AND [DuoMengChaPingID] = {12} AND [BaiDuAppID] = {13} " +
                                              "AND [AddTime] = {14} AND [UpdateTime] = {15} AND [DevAccount] = {16} AND [DevPassword] = {17} " +
                                              "AND [BaiduStoreStatus] = {18} AND [XiaomiStoreStatus] = {19} AND [SanLiuLingAppID] = {20} AND [SanLiuLingBannerID] = {21} " +
                                              "AND [SanLiuLingStoreStatus] = {22} AND [SanLiuLingChaPingID] = {23} AND [SanLiuLingStoreDevAccount] = {24} AND [SanLiuLingStoreDevPassword] = {25} " +
                                              "AND [BaiduStoreDevAccount] = {26} AND [BaiduStoreDevPassword] = {27} AND [XiaomiStoreDevAccount] = {28} AND [XiaomiStoreDevPassword] = {29} " +
                                              "AND [FileName] = {30} AND [PackageName] = {31} AND [JingZhongAppId] = {32} AND [IAdPushAppKey] = {33} AND [DownloadAddress] = {34} AND [AppType] = {35} ORDER BY [Version] DESC",
                                              count == 0 ? "" : "TOP " + count.ToString(),
                                              gamename, version, state, gameid, pushername,
                                              youmiappid, youmiid, googlebanner, googlechaping,
                                              duomengappid, duomengbannerid, duomengchapingid, baiduappid,
                                              addtime, updatetime, devaccount, devpassword,
                                              baidustorestatus, xiaomistorestatus, sanliulingappid, sanliulingbannerid,
                                              sanliulingstorestatus, sanliulingchapingid, sanliulingstoredevaccount, sanliulingstoredevpassword,
                                              baidustoredevaccount, baidustoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword,
                                              filename, packagename, jingzhongappid, iAdPushAppKey, downloadAddress, appType);

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<AndroidPushGameInfoModel> androidPushGameInfoModelList = new List<AndroidPushGameInfoModel>();
                for (int i = 0; i < pushGameInfoTable.Rows.Count; i++)
                {
                    AndroidPushGameInfoModel pushGameInfoModel_t = new AndroidPushGameInfoModel
                    {
                        AddTime = pushGameInfoTable.Rows[i]["AddTime"].ToString(),
                        DevAccount = pushGameInfoTable.Rows[i]["DevAccount"].ToString(),
                        DevPassword = pushGameInfoTable.Rows[i]["DevPassword"].ToString(),
                        GameID = pushGameInfoTable.Rows[i]["GameID"].ToString(),
                        GameName = pushGameInfoTable.Rows[i]["GameName"].ToString(),
                        GoogleBanner = pushGameInfoTable.Rows[i]["GoogleBanner"].ToString(),
                        GoogleChaping = pushGameInfoTable.Rows[i]["GoogleChaping"].ToString(),
                        PusherName = pushGameInfoTable.Rows[i]["PusherName"].ToString(),
                        State = pushGameInfoTable.Rows[i]["State"].ToString(),
                        UpdateTime = pushGameInfoTable.Rows[i]["UpdateTime"].ToString(),
                        Version = pushGameInfoTable.Rows[i]["Version"].ToString(),


                        BaiDuAppID = pushGameInfoTable.Rows[i]["BaiDuAppID"].ToString(),
                        BaiduStoreDevAccount = pushGameInfoTable.Rows[i]["BaiduStoreDevAccount"].ToString(),
                        BaiduStoreDevPassword = pushGameInfoTable.Rows[i]["BaiduStoreDevPassword"].ToString(),
                        BaiduStoreStatus = pushGameInfoTable.Rows[i]["BaiduStoreStatus"].ToString(),

                        DuoMengAppID = pushGameInfoTable.Rows[i]["DuoMengAppID"].ToString(),
                        DuoMengBannerID = pushGameInfoTable.Rows[i]["DuoMengBannerID"].ToString(),
                        DuoMengChaPingID = pushGameInfoTable.Rows[i]["DuoMengChaPingID"].ToString(),

                        FileName = pushGameInfoTable.Rows[i]["FileName"].ToString(),
                        PackageName = pushGameInfoTable.Rows[i]["PackageName"].ToString(),

                        SanLiuLingAppID = pushGameInfoTable.Rows[i]["SanLiuLingAppID"].ToString(),
                        SanLiuLingBannerID = pushGameInfoTable.Rows[i]["SanLiuLingBannerID"].ToString(),
                        SanLiuLingChaPingID = pushGameInfoTable.Rows[i]["SanLiuLingChaPingID"].ToString(),
                        SanLiuLingStoreDevAccount = pushGameInfoTable.Rows[i]["SanLiuLingStoreDevAccount"].ToString(),
                        SanLiuLingStoreDevPassword = pushGameInfoTable.Rows[i]["SanLiuLingStoreDevPassword"].ToString(),
                        SanLiuLingStoreStatus = pushGameInfoTable.Rows[i]["SanLiuLingStoreStatus"].ToString(),

                        XiaomiStoreDevAccount = pushGameInfoTable.Rows[i]["XiaomiStoreDevAccount"].ToString(),
                        XiaomiStoreDevPassword = pushGameInfoTable.Rows[i]["XiaomiStoreDevPassword"].ToString(),
                        XiaomiStoreStatus = pushGameInfoTable.Rows[i]["XiaomiStoreStatus"].ToString(),

                        YouMiAppID = pushGameInfoTable.Rows[i]["YouMiAppID"].ToString(),
                        YouMiID = pushGameInfoTable.Rows[i]["YouMiID"].ToString(),

                        JingZhongAppId = pushGameInfoTable.Rows[i]["JingZhongAppId"].ToString(),
                        IAdPushAppKey = pushGameInfoTable.Rows[i]["IAdPushAppKey"].ToString(),
                        DownloadAddress = pushGameInfoTable.Rows[i]["DownloadAddress"].ToString(),
                        AppType = pushGameInfoTable.Rows[i]["AppType"].ToString()
                    };

                    androidPushGameInfoModelList.Add(pushGameInfoModel_t);
                }

                return androidPushGameInfoModelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<AndroidPushGameInfoModel> GetAndroidNotCompletedPushGameInfoModelListByPusherNameAndCount(string pusherName, int count)
        {
            try
            {
                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[AndroidPushGameInfo] WHERE [PusherName] = '{1}' AND " +
                                              "([BaiduStoreStatus] = '待提交' OR [BaiduStoreStatus] = '审核失败' OR [SanLiuLingStoreStatus] = '待提交' OR [SanLiuLingStoreStatus] = '审核失败' OR [XiaomiStoreStatus] = '待提交' OR [XiaomiStoreStatus] = '审核失败')",
                                              count == 0 ? "" : "TOP " + count.ToString(), pusherName);
                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<AndroidPushGameInfoModel> androidPushGameInfoModelList = new List<AndroidPushGameInfoModel>();
                for (int i = 0; i < pushGameInfoTable.Rows.Count; i++)
                {
                    AndroidPushGameInfoModel pushGameInfoModel_t = new AndroidPushGameInfoModel
                    {
                        AddTime = pushGameInfoTable.Rows[i]["AddTime"].ToString(),
                        DevAccount = pushGameInfoTable.Rows[i]["DevAccount"].ToString(),
                        DevPassword = pushGameInfoTable.Rows[i]["DevPassword"].ToString(),
                        GameID = pushGameInfoTable.Rows[i]["GameID"].ToString(),
                        GameName = pushGameInfoTable.Rows[i]["GameName"].ToString(),
                        GoogleBanner = pushGameInfoTable.Rows[i]["GoogleBanner"].ToString(),
                        GoogleChaping = pushGameInfoTable.Rows[i]["GoogleChaping"].ToString(),
                        PusherName = pushGameInfoTable.Rows[i]["PusherName"].ToString(),
                        State = pushGameInfoTable.Rows[i]["State"].ToString(),
                        UpdateTime = pushGameInfoTable.Rows[i]["UpdateTime"].ToString(),
                        Version = pushGameInfoTable.Rows[i]["Version"].ToString(),


                        BaiDuAppID = pushGameInfoTable.Rows[i]["BaiDuAppID"].ToString(),
                        BaiduStoreDevAccount = pushGameInfoTable.Rows[i]["BaiduStoreDevAccount"].ToString(),
                        BaiduStoreDevPassword = pushGameInfoTable.Rows[i]["BaiduStoreDevPassword"].ToString(),
                        BaiduStoreStatus = pushGameInfoTable.Rows[i]["BaiduStoreStatus"].ToString(),

                        DuoMengAppID = pushGameInfoTable.Rows[i]["DuoMengAppID"].ToString(),
                        DuoMengBannerID = pushGameInfoTable.Rows[i]["DuoMengBannerID"].ToString(),
                        DuoMengChaPingID = pushGameInfoTable.Rows[i]["DuoMengChaPingID"].ToString(),

                        FileName = pushGameInfoTable.Rows[i]["FileName"].ToString(),
                        PackageName = pushGameInfoTable.Rows[i]["PackageName"].ToString(),

                        SanLiuLingAppID = pushGameInfoTable.Rows[i]["SanLiuLingAppID"].ToString(),
                        SanLiuLingBannerID = pushGameInfoTable.Rows[i]["SanLiuLingBannerID"].ToString(),
                        SanLiuLingChaPingID = pushGameInfoTable.Rows[i]["SanLiuLingChaPingID"].ToString(),
                        SanLiuLingStoreDevAccount = pushGameInfoTable.Rows[i]["SanLiuLingStoreDevAccount"].ToString(),
                        SanLiuLingStoreDevPassword = pushGameInfoTable.Rows[i]["SanLiuLingStoreDevPassword"].ToString(),
                        SanLiuLingStoreStatus = pushGameInfoTable.Rows[i]["SanLiuLingStoreStatus"].ToString(),

                        XiaomiStoreDevAccount = pushGameInfoTable.Rows[i]["XiaomiStoreDevAccount"].ToString(),
                        XiaomiStoreDevPassword = pushGameInfoTable.Rows[i]["XiaomiStoreDevPassword"].ToString(),
                        XiaomiStoreStatus = pushGameInfoTable.Rows[i]["XiaomiStoreStatus"].ToString(),

                        YouMiAppID = pushGameInfoTable.Rows[i]["YouMiAppID"].ToString(),
                        YouMiID = pushGameInfoTable.Rows[i]["YouMiID"].ToString(),

                        JingZhongAppId = pushGameInfoTable.Rows[i]["JingZhongAppId"].ToString(),
                        IAdPushAppKey = pushGameInfoTable.Rows[i]["IAdPushAppKey"].ToString(),
                        DownloadAddress = pushGameInfoTable.Rows[i]["DownloadAddress"].ToString(),
                        AppType = pushGameInfoTable.Rows[i]["AppType"].ToString()
                    };

                    androidPushGameInfoModelList.Add(pushGameInfoModel_t);
                }

                return androidPushGameInfoModelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public void AddAndroidPushGameInfo(AndroidPushGameInfoModel androidPushGameInfoModel)
        {
            try
            {
                //string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[AndroidPushGameInfo] WHERE [GameName] = '{0}' AND [Version] = '{1}' AND [PackageName] = '{2}'",
                //                                  androidPushGameInfoModel.GameName, androidPushGameInfoModel.Version,androidPushGameInfoModel.PackageName);

                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[AndroidPushGameInfo] WHERE [PackageName] = '{0}'",
                                                  androidPushGameInfoModel.PackageName);


                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该游戏版本已经提交过了!");
                }

                sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[AndroidPushGameInfo] WHERE [PackageName] = '{0}'", androidPushGameInfoModel.PackageName);

                int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("这个包名已经用过了,请修改包名");
                }

                if (string.IsNullOrEmpty(androidPushGameInfoModel.IAdPushAppKey) || string.IsNullOrEmpty(androidPushGameInfoModel.JingZhongAppId))
                {
                    sqlCmd_Get = string.Format("SELECT Top 1 * FROM [dbo].[LiuMangAds] WHERE [Status] = '空闲'");

                    DataTable liuMangAdsList = SqlHelper.Instance.ExecuteDataTable(sqlCmd_Get);

                    if (liuMangAdsList == null || liuMangAdsList.Rows.Count == 0)
                    {
                        throw new Exception("库中已经没有空闲的广告ID了");
                    }

                    androidPushGameInfoModel.IAdPushAppKey = liuMangAdsList.Rows[0]["IadKey"].ToString();
                    androidPushGameInfoModel.JingZhongAppId = liuMangAdsList.Rows[0]["JingZhongKey"].ToString();

                    string liuMangAdId_t = liuMangAdsList.Rows[0]["ID"].ToString();

                    sqlCmd_Get = string.Format("UPDATE　[dbo].[LiuMangAds]　SET [Status] = '已用' WHERE [ID] = '{0}'", liuMangAdId_t);

                    SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[AndroidPushGameInfo] ([GameName],[Version],[State],[GameID],[PusherName],[YouMiAppID],[YouMiID],[GoogleBanner],[GoogleChaping],[DuoMengAppID],[DuoMengBannerID],[DuoMengChaPingID],[BaiDuAppID],[AddTime],[UpdateTime],[DevAccount],[DevPassword],[BaiduStoreStatus],[XiaomiStoreStatus],[SanLiuLingAppID],[SanLiuLingBannerID],[SanLiuLingStoreStatus],[SanLiuLingChaPingID],[SanLiuLingStoreDevAccount],[SanLiuLingStoreDevPassword],[BaiduStoreDevAccount],[BaiduStoreDevPassword],[XiaomiStoreDevAccount],[XiaomiStoreDevPassword],[FileName],[PackageName],[JingZhongAppId],[IAdPushAppKey],[DownloadAddress],[AppType]) " +
                                              " VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}')",
                                              androidPushGameInfoModel.GameName, androidPushGameInfoModel.Version, androidPushGameInfoModel.State, androidPushGameInfoModel.GameID, androidPushGameInfoModel.PusherName,
                                              androidPushGameInfoModel.YouMiAppID, androidPushGameInfoModel.YouMiID, androidPushGameInfoModel.GoogleBanner, androidPushGameInfoModel.GoogleChaping, androidPushGameInfoModel.DuoMengAppID, androidPushGameInfoModel.DuoMengBannerID, androidPushGameInfoModel.DuoMengChaPingID,
                                              androidPushGameInfoModel.BaiDuAppID, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), androidPushGameInfoModel.DevAccount, androidPushGameInfoModel.DevPassword,
                                              androidPushGameInfoModel.BaiduStoreStatus, androidPushGameInfoModel.XiaomiStoreStatus, androidPushGameInfoModel.SanLiuLingAppID, androidPushGameInfoModel.SanLiuLingBannerID, androidPushGameInfoModel.SanLiuLingStoreStatus, androidPushGameInfoModel.SanLiuLingChaPingID,
                                              androidPushGameInfoModel.SanLiuLingStoreDevAccount, androidPushGameInfoModel.SanLiuLingStoreDevPassword, androidPushGameInfoModel.BaiduStoreDevAccount, androidPushGameInfoModel.BaiduStoreDevPassword, androidPushGameInfoModel.XiaomiStoreDevAccount,
                                              androidPushGameInfoModel.XiaomiStoreDevPassword, androidPushGameInfoModel.FileName, androidPushGameInfoModel.PackageName, androidPushGameInfoModel.JingZhongAppId, androidPushGameInfoModel.IAdPushAppKey, androidPushGameInfoModel.DownloadAddress, androidPushGameInfoModel.AppType);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateAndroidPushGameInfo(AndroidPushGameInfoModel androidPushGameInfoModel)
        {
            try
            {
                if (androidPushGameInfoModel.State == "被拒绝" || androidPushGameInfoModel.State == "不可用")
                {
                    string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[LiuMangAds] WHERE [IadKey]='{0}' AND [JingZhongKey] = '{1}'",
                                                  androidPushGameInfoModel.IAdPushAppKey, androidPushGameInfoModel.JingZhongAppId);

                    if (Convert.ToInt32(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get)) > 0)
                    {
                        sqlCmd_Get = string.Format("UPDATE [dbo].[LiuMangAds] SET [Status] = '空闲',[Time] = '{0}'" +
                              " WHERE [IadKey] = '{1}'", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), androidPushGameInfoModel.IAdPushAppKey.ToString());

                        SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);
                    }
                }

                string gamename = string.IsNullOrEmpty(androidPushGameInfoModel.GameName) ? "[GameName]" : "'" + androidPushGameInfoModel.GameName + "'";
                string version = string.IsNullOrEmpty(androidPushGameInfoModel.Version) ? "[Version]" : "'" + androidPushGameInfoModel.Version + "'";
                string state = string.IsNullOrEmpty(androidPushGameInfoModel.State) ? "[State]" : "'" + androidPushGameInfoModel.State + "'";
                string gameid = string.IsNullOrEmpty(androidPushGameInfoModel.GameID) ? "[GameID]" : "'" + androidPushGameInfoModel.GameID + "'";
                string pushername = string.IsNullOrEmpty(androidPushGameInfoModel.PusherName) ? "[PusherName]" : "'" + androidPushGameInfoModel.PusherName + "'";

                string youmiappid = string.IsNullOrEmpty(androidPushGameInfoModel.YouMiAppID) ? "[YouMiAppID]" : "'" + androidPushGameInfoModel.YouMiAppID + "'";
                string youmiid = string.IsNullOrEmpty(androidPushGameInfoModel.YouMiID) ? "[YouMiID]" : "'" + androidPushGameInfoModel.YouMiID + "'";

                string googlebanner = string.IsNullOrEmpty(androidPushGameInfoModel.GoogleBanner) ? "[GoogleBanner]" : "'" + androidPushGameInfoModel.GoogleBanner + "'";
                string googlechaping = string.IsNullOrEmpty(androidPushGameInfoModel.GoogleChaping) ? "[GoogleChaping]" : "'" + androidPushGameInfoModel.GoogleChaping + "'";

                string duomengappid = string.IsNullOrEmpty(androidPushGameInfoModel.DuoMengAppID) ? "[DuoMengAppID]" : "'" + androidPushGameInfoModel.DuoMengAppID + "'";
                string duomengbannerid = string.IsNullOrEmpty(androidPushGameInfoModel.DuoMengBannerID) ? "[DuoMengBannerID]" : "'" + androidPushGameInfoModel.DuoMengBannerID + "'";
                string duomengchapingid = string.IsNullOrEmpty(androidPushGameInfoModel.DuoMengChaPingID) ? "[DuoMengChaPingID]" : "'" + androidPushGameInfoModel.DuoMengChaPingID + "'";

                string baiduappid = string.IsNullOrEmpty(androidPushGameInfoModel.BaiDuAppID) ? "[BaiDuAppID]" : "'" + androidPushGameInfoModel.BaiDuAppID + "'";

                string sanliulingappid = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingAppID) ? "[SanLiuLingAppID]" : "'" + androidPushGameInfoModel.SanLiuLingAppID + "'";
                string sanliulingbannerid = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingBannerID) ? "[SanLiuLingBannerID]" : "'" + androidPushGameInfoModel.SanLiuLingBannerID + "'";
                string sanliulingchapingid = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingChaPingID) ? "[SanLiuLingChaPingID]" : "'" + androidPushGameInfoModel.SanLiuLingChaPingID + "'";

                string baidustorestatus = string.IsNullOrEmpty(androidPushGameInfoModel.BaiduStoreStatus) ? "[BaiduStoreStatus]" : "'" + androidPushGameInfoModel.BaiduStoreStatus + "'";
                string sanliulingstorestatus = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingStoreStatus) ? "[SanLiuLingStoreStatus]" : "'" + androidPushGameInfoModel.SanLiuLingStoreStatus + "'";
                string xiaomistorestatus = string.IsNullOrEmpty(androidPushGameInfoModel.XiaomiStoreStatus) ? "[XiaomiStoreStatus]" : "'" + androidPushGameInfoModel.XiaomiStoreStatus + "'";

                string sanliulingstoredevaccount = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingStoreDevAccount) ? "[SanLiuLingStoreDevAccount]" : "'" + androidPushGameInfoModel.SanLiuLingStoreDevAccount + "'";
                string sanliulingstoredevpassword = string.IsNullOrEmpty(androidPushGameInfoModel.SanLiuLingStoreDevPassword) ? "[SanLiuLingStoreDevPassword]" : "'" + androidPushGameInfoModel.SanLiuLingStoreDevPassword + "'";
                string baidustoredevaccount = string.IsNullOrEmpty(androidPushGameInfoModel.BaiduStoreDevAccount) ? "[BaiduStoreDevAccount]" : "'" + androidPushGameInfoModel.BaiduStoreDevAccount + "'";
                string baidustoredevpassword = string.IsNullOrEmpty(androidPushGameInfoModel.BaiduStoreDevPassword) ? "[BaiduStoreDevPassword]" : "'" + androidPushGameInfoModel.BaiduStoreDevPassword + "'";
                string xiaomistoredevaccount = string.IsNullOrEmpty(androidPushGameInfoModel.XiaomiStoreDevAccount) ? "[XiaomiStoreDevAccount]" : "'" + androidPushGameInfoModel.XiaomiStoreDevAccount + "'";
                string xiaomistoredevpassword = string.IsNullOrEmpty(androidPushGameInfoModel.XiaomiStoreDevPassword) ? "[XiaomiStoreDevPassword]" : "'" + androidPushGameInfoModel.XiaomiStoreDevPassword + "'";

                string addtime = string.IsNullOrEmpty(androidPushGameInfoModel.AddTime) ? "[AddTime]" : "'" + androidPushGameInfoModel.AddTime + "'";
                string updatetime = string.IsNullOrEmpty(androidPushGameInfoModel.UpdateTime) ? "[UpdateTime]" : "'" + androidPushGameInfoModel.UpdateTime + "'";
                string devaccount = string.IsNullOrEmpty(androidPushGameInfoModel.DevAccount) ? "[DevAccount]" : "'" + androidPushGameInfoModel.DevAccount + "'";
                string devpassword = string.IsNullOrEmpty(androidPushGameInfoModel.DevPassword) ? "[DevPassword]" : "'" + androidPushGameInfoModel.DevPassword + "'";

                string filename = string.IsNullOrEmpty(androidPushGameInfoModel.FileName) ? "[FileName]" : "'" + androidPushGameInfoModel.FileName + "'";
                string packagename = string.IsNullOrEmpty(androidPushGameInfoModel.PackageName) ? "[PackageName]" : "'" + androidPushGameInfoModel.PackageName + "'";

                string jingzhongappid = string.IsNullOrEmpty(androidPushGameInfoModel.JingZhongAppId) ? "[JingZhongAppId]" : "'" + androidPushGameInfoModel.JingZhongAppId + "'";
                string iAdPushAppKey = string.IsNullOrEmpty(androidPushGameInfoModel.IAdPushAppKey) ? "[IAdPushAppKey]" : "'" + androidPushGameInfoModel.IAdPushAppKey + "'";
                string downloadAddress = string.IsNullOrEmpty(androidPushGameInfoModel.DownloadAddress) ? "[DownloadAddress]" : "'" + androidPushGameInfoModel.DownloadAddress + "'";
                string appType = string.IsNullOrEmpty(androidPushGameInfoModel.AppType) ? "[AppType]" : "'" + androidPushGameInfoModel.AppType + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[AndroidPushGameInfo] SET [State] = {0},[GameID] = {1},[PusherName] = {2},[YouMiAppID] = {3}," +
                                              "[YouMiID] = {4},[GoogleBanner] = {5},[GoogleChaping] = {6},[DuoMengAppID] = {7},[DuoMengBannerID] = {8},[DuoMengChaPingID] = {9}," +
                                              "[BaiDuAppID] = {10},[AddTime] = {11},[UpdateTime] = '{12}',[DevAccount] = {13},[DevPassword] = {14},[BaiduStoreStatus] = {15}," +
                                              "[XiaomiStoreStatus] = {16},[SanLiuLingAppID] = {17},[SanLiuLingBannerID] = {18},[SanLiuLingStoreStatus] = {19},[SanLiuLingChaPingID] = {20},[SanLiuLingStoreDevAccount] = {21}," +
                                              "[SanLiuLingStoreDevPassword] = {22},[BaiduStoreDevAccount] = {23},[BaiduStoreDevPassword] = {24},[XiaomiStoreDevAccount] = {25},[XiaomiStoreDevPassword] = {26},[FileName] = {27},[JingZhongAppId] = {31},[IAdPushAppKey] = {32},[DownloadAddress] = {33},[AppType] = {34}" +
                                              " WHERE [GameName] = {28} AND [Version] = {29} AND [PackageName] = {30}",
                                              state, gameid, pushername, youmiappid,
                                              youmiid, googlebanner, googlechaping, duomengappid, duomengbannerid, duomengchapingid,
                                              baiduappid, addtime, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), devaccount, devpassword, baidustorestatus,
                                              xiaomistorestatus, sanliulingappid, sanliulingbannerid, sanliulingstorestatus, sanliulingchapingid, sanliulingstoredevaccount,
                                              sanliulingstoredevpassword, baidustoredevaccount, baidustoredevpassword, xiaomistoredevaccount, xiaomistoredevpassword, filename,
                                              gamename, version, packagename, jingzhongappid, iAdPushAppKey, downloadAddress, appType);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void DeleteGameInfoByNameAndVersionAndPackageName(string gameName, string version, string pachageName)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT [IAdPushAppKey],[JingZhongAppId] FROM [dbo].[AndroidPushGameInfo] WHERE [GameName] = '{0}' AND [PackageName] = '{1}'",
                                                    gameName, pachageName);

                DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlCmd_Get);

                string iadKey = table.Rows[0]["IAdPushAppKey"].ToString();
                string jingZhongKey = table.Rows[0]["JingZhongAppId"].ToString();

                sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[LiuMangAds] WHERE [IadKey]='{0}' AND [JingZhongKey] = '{1}'",
                                              iadKey, jingZhongKey);

                if (Convert.ToInt32(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get)) > 0)
                {
                    sqlCmd_Get = string.Format("UPDATE [dbo].[LiuMangAds] SET [Status] = '空闲',[Time] = '{0}'" +
                          " WHERE [IadKey] = '{1}'", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), iadKey.ToString());

                    SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);
                }
                else
                {
                    sqlCmd_Get = string.Format("INSERT INTO [dbo].[LiuMangAds] ([IadKey],[IadAppName],[JingZhongKey],[JingZhongAppName],[Status],[Time]) " +
                                                               " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                               iadKey, pachageName, jingZhongKey, pachageName,
                                                               "空闲", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                    SqlHelper.Instance.ExecuteCommand(sqlCmd_Get);
                }


                string sqlCmd = string.Format("DELETE FROM [dbo].[AndroidPushGameInfo] WHERE [GameName] = '{0}' AND [Version] = '{1}' AND [PackageName] = '{2}'",
                                            gameName, version, pachageName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DevAccounts GetAndroidDevAccountList(string baiduDevAccount, string baiduDevPassword,
                                                            string sanLiuLingDevAccount, string saLiuLingDevPassword,
                                                            string xiaoMiDevAccount, string xiaoMiDevPassword,
                                                            int count)
        {
            try
            {
                baiduDevAccount = string.IsNullOrEmpty(baiduDevAccount) ? "[BaiduStoreDevAccount]" : "'" + baiduDevAccount + "'";
                baiduDevPassword = string.IsNullOrEmpty(baiduDevPassword) ? "[BaiduStoreDevPassword]" : "'" + baiduDevPassword + "'";
                sanLiuLingDevAccount = string.IsNullOrEmpty(sanLiuLingDevAccount) ? "[SanLiuLingStoreDevAccount]" : "'" + sanLiuLingDevAccount + "'";
                saLiuLingDevPassword = string.IsNullOrEmpty(saLiuLingDevPassword) ? "[SanLiuLingStoreDevPassword]" : "'" + saLiuLingDevPassword + "'";
                xiaoMiDevAccount = string.IsNullOrEmpty(xiaoMiDevAccount) ? "[XiaomiStoreDevAccount]" : "'" + xiaoMiDevAccount + "'";
                xiaoMiDevPassword = string.IsNullOrEmpty(xiaoMiDevPassword) ? "[XiaomiStoreDevPassword]" : "'" + xiaoMiDevPassword + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[BaiDuDevAccounts],[dbo].[SanLiuLingDevAccounts],[dbo].[XiaoMiDevAccounts] WHERE " +
                              "[BaiduStoreDevAccount] = {1} AND [BaiduStoreDevPassword] = {2} AND [SanLiuLingStoreDevAccount] = {3} AND [SanLiuLingStoreDevPassword] = {4} " +
                              "AND [XiaomiStoreDevAccount] = {5} AND [XiaomiStoreDevPassword] = {6}",
                              count == 0 ? "" : "TOP " + count.ToString(),
                              baiduDevAccount, baiduDevPassword, sanLiuLingDevAccount, saLiuLingDevPassword,
                              xiaoMiDevAccount, xiaoMiDevPassword);

                DataTable devInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (devInfoTable == null || devInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                DevAccounts devAccounts = new DevAccounts();

                for (int i = 0; i < devInfoTable.Rows.Count; i++)
                {
                    devAccounts.AddBaiduDevAccout(devInfoTable.Rows[i]["BaiduStoreDevAccount"].ToString(), devInfoTable.Rows[i]["BaiduStoreDevPassword"].ToString());
                    devAccounts.AddSanLiuLingDevAccout(devInfoTable.Rows[i]["SanLiuLingStoreDevAccount"].ToString(), devInfoTable.Rows[i]["SanLiuLingStoreDevPassword"].ToString());
                    devAccounts.AddXiaoMiDevAccount(devInfoTable.Rows[i]["XiaomiStoreDevAccount"].ToString(), devInfoTable.Rows[i]["XiaomiStoreDevPassword"].ToString());
                }

                return devAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetGameState(string gameName, string version, string pachageName)
        {
            try
            {
                string sqlCmd = string.Format("SELECT [State] FROM [dbo].[AndroidPushGameInfo] WHERE [GameName] = '{0}' AND [Version] = '{1}' AND [PackageName] = '{2}'",
                                            gameName, version, pachageName);

                return SqlHelper.Instance.ExecuteScalar(sqlCmd) == null ? "" : SqlHelper.Instance.ExecuteScalar(sqlCmd).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GetGameIsDone(string pachageName)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[AndroidPushGameInfo] WHERE [PackageName] = '{0}'",
                                            pachageName);

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return pushGameInfoTable.Rows[0]["BaiduStoreStatus"].ToString() == "已发布" &&
                        pushGameInfoTable.Rows[0]["BaiduStoreStatus"].ToString() == "已发布" &&
                        pushGameInfoTable.Rows[0]["XiaomiStoreStatus"].ToString() == "已发布";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AndroidPushGameInfoModel GetOneFreeLiuMangGameInfo()
        {
            try
            {
                string sqlCmd_GetOne = string.Format("SELECT Top 1 * FROM [dbo].[AndroidPushGameInfo] WHERE " +
                                                      "[State]= '待提交' ORDER BY NEWID()");

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd_GetOne);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                AndroidPushGameInfoModel pushGameInfoModel_t = new AndroidPushGameInfoModel
                {
                    AddTime = pushGameInfoTable.Rows[0]["AddTime"].ToString(),
                    DevAccount = pushGameInfoTable.Rows[0]["DevAccount"].ToString(),
                    DevPassword = pushGameInfoTable.Rows[0]["DevPassword"].ToString(),
                    GameID = pushGameInfoTable.Rows[0]["GameID"].ToString(),
                    GameName = pushGameInfoTable.Rows[0]["GameName"].ToString(),
                    GoogleBanner = pushGameInfoTable.Rows[0]["GoogleBanner"].ToString(),
                    GoogleChaping = pushGameInfoTable.Rows[0]["GoogleChaping"].ToString(),
                    PusherName = pushGameInfoTable.Rows[0]["PusherName"].ToString(),
                    State = pushGameInfoTable.Rows[0]["State"].ToString(),
                    UpdateTime = pushGameInfoTable.Rows[0]["UpdateTime"].ToString(),
                    Version = pushGameInfoTable.Rows[0]["Version"].ToString(),

                    BaiDuAppID = pushGameInfoTable.Rows[0]["BaiDuAppID"].ToString(),
                    BaiduStoreDevAccount = pushGameInfoTable.Rows[0]["BaiduStoreDevAccount"].ToString(),
                    BaiduStoreDevPassword = pushGameInfoTable.Rows[0]["BaiduStoreDevPassword"].ToString(),
                    BaiduStoreStatus = pushGameInfoTable.Rows[0]["BaiduStoreStatus"].ToString(),

                    DuoMengAppID = pushGameInfoTable.Rows[0]["DuoMengAppID"].ToString(),
                    DuoMengBannerID = pushGameInfoTable.Rows[0]["DuoMengBannerID"].ToString(),
                    DuoMengChaPingID = pushGameInfoTable.Rows[0]["DuoMengChaPingID"].ToString(),

                    FileName = pushGameInfoTable.Rows[0]["FileName"].ToString(),
                    PackageName = pushGameInfoTable.Rows[0]["PackageName"].ToString(),

                    SanLiuLingAppID = pushGameInfoTable.Rows[0]["SanLiuLingAppID"].ToString(),
                    SanLiuLingBannerID = pushGameInfoTable.Rows[0]["SanLiuLingBannerID"].ToString(),
                    SanLiuLingChaPingID = pushGameInfoTable.Rows[0]["SanLiuLingChaPingID"].ToString(),
                    SanLiuLingStoreDevAccount = pushGameInfoTable.Rows[0]["SanLiuLingStoreDevAccount"].ToString(),
                    SanLiuLingStoreDevPassword = pushGameInfoTable.Rows[0]["SanLiuLingStoreDevPassword"].ToString(),
                    SanLiuLingStoreStatus = pushGameInfoTable.Rows[0]["SanLiuLingStoreStatus"].ToString(),

                    XiaomiStoreDevAccount = pushGameInfoTable.Rows[0]["XiaomiStoreDevAccount"].ToString(),
                    XiaomiStoreDevPassword = pushGameInfoTable.Rows[0]["XiaomiStoreDevPassword"].ToString(),
                    XiaomiStoreStatus = pushGameInfoTable.Rows[0]["XiaomiStoreStatus"].ToString(),

                    YouMiAppID = pushGameInfoTable.Rows[0]["YouMiAppID"].ToString(),
                    YouMiID = pushGameInfoTable.Rows[0]["YouMiID"].ToString(),

                    JingZhongAppId = pushGameInfoTable.Rows[0]["JingZhongAppId"].ToString(),
                    IAdPushAppKey = pushGameInfoTable.Rows[0]["IAdPushAppKey"].ToString(),
                    DownloadAddress = pushGameInfoTable.Rows[0]["DownloadAddress"].ToString(),
                    AppType = pushGameInfoTable.Rows[0]["AppType"].ToString()
                };

                Dictionary<string, string> baiDuDev = GetFreeBaiDuDev();
                Dictionary<string, string> sanLiuLingDev = GetFreeSanLiuLingDev();
                Dictionary<string, string> xiaoMiDev = GetFreeXiaoMiDev();

                pushGameInfoModel_t.BaiduStoreDevAccount = baiDuDev.Keys.ToList()[0];
                pushGameInfoModel_t.BaiduStoreDevPassword = baiDuDev.Values.ToList()[0];

                pushGameInfoModel_t.SanLiuLingStoreDevAccount = sanLiuLingDev.Keys.ToList()[0];
                pushGameInfoModel_t.SanLiuLingStoreDevPassword = sanLiuLingDev.Values.ToList()[0];

                pushGameInfoModel_t.XiaomiStoreDevAccount = xiaoMiDev.Keys.ToList()[0];
                pushGameInfoModel_t.XiaomiStoreDevPassword = xiaoMiDev.Values.ToList()[0];

                string sqlCmd_Update = string.Format("UPDATE [dbo].[AndroidPushGameInfo] SET [State]='开发中',[BaiduStoreDevAccount]='{0}',[BaiduStoreDevPassword]='{1}',[SanLiuLingStoreDevAccount]='{2}',[SanLiuLingStoreDevPassword]='{3}',[XiaomiStoreDevAccount]='{4}',[XiaomiStoreDevPassword]='{5}' " +
                                                     "WHERE [PackageName] = '{6}'",
                                       pushGameInfoModel_t.BaiduStoreDevAccount, pushGameInfoModel_t.BaiduStoreDevPassword,
                                       pushGameInfoModel_t.SanLiuLingStoreDevAccount, pushGameInfoModel_t.SanLiuLingStoreDevPassword,
                                       pushGameInfoModel_t.XiaomiStoreDevAccount, pushGameInfoModel_t.XiaomiStoreDevPassword,
                                       pushGameInfoModel_t.PackageName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd_Update);

                return pushGameInfoModel_t;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取小米账号
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetFreeXiaoMiDev()
        {
            try
            {
                //string sqlCmd = "SELECT * FROM [dbo].[XiaoMiDevAccounts] WHERE [XiaomiStoreDevAccount] Not IN " +
                //                "(SELECT [XiaomiStoreDevAccount] FROM [dbo].[AndroidPushGameInfo] WHERE [State]='待提交' OR [State]='开发中')";

                //DataTable devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                //if (devInfo == null || devInfo.Rows.Count == 0)
                //{
                //    sqlCmd = "SELECT TOP 1 [XiaomiStoreDevAccount],[XiaomiStoreDevPassword],COUNT([XiaomiStoreDevAccount]) as DevCount FROM [dbo].[AndroidPushGameInfo] " +
                //             "WHERE ([State]='待提交' OR [State]='开发中') AND [XiaomiStoreDevAccount] !='' AND [XiaomiStoreDevPassword] !='' " +
                //             "GROUP BY [XiaomiStoreDevAccount],[XiaomiStoreDevPassword] " +
                //             "ORDER BY DevCount ASC";

                //    devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);
                //}


                string sqlCmd = string.Format("SELECT TOP 1 * FROM [dbo].[XiaoMiDevAccounts] ORDER BY NEWID()");

                DataTable devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (devInfo == null || devInfo.Rows.Count == 0)
                {
                    throw new Exception("获取小米账号失败！");
                }

                var result = new Dictionary<string, string>();

                result.Add(devInfo.Rows[0]["XiaomiStoreDevAccount"].ToString(), devInfo.Rows[0]["XiaomiStoreDevPassword"].ToString());

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取百度账号
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetFreeBaiDuDev()
        {
            try
            {
                //string sqlCmd = "SELECT * FROM [dbo].[BaiDuDevAccounts] WHERE [BaiduStoreDevAccount] Not IN " +
                //                "(SELECT [BaiduStoreDevAccount] FROM [dbo].[AndroidPushGameInfo] WHERE [State]='待提交' OR [State]='开发中')";

                //DataTable devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                //if (devInfo == null || devInfo.Rows.Count == 0)
                //{
                //    sqlCmd = "SELECT TOP 1 [BaiduStoreDevAccount],[BaiduStoreDevPassword],COUNT([BaiduStoreDevAccount]) as DevCount FROM [dbo].[AndroidPushGameInfo] " +
                //             "WHERE ([State]='待提交' OR [State]='开发中') AND [BaiduStoreDevAccount] !='' AND [BaiduStoreDevPassword] !='' " +
                //             "GROUP BY [BaiduStoreDevAccount],[BaiduStoreDevPassword] " +
                //             "ORDER BY DevCount ASC";

                //    devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);
                //}

                string sqlCmd = string.Format("SELECT TOP 1 * FROM [dbo].[BaiDuDevAccounts] ORDER BY NEWID()");

                DataTable devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (devInfo == null || devInfo.Rows.Count == 0)
                {
                    throw new Exception("获取百度账号失败！");
                }

                var result = new Dictionary<string, string>();

                result.Add(devInfo.Rows[0]["BaiduStoreDevAccount"].ToString(), devInfo.Rows[0]["BaiduStoreDevPassword"].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取三六零账号
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetFreeSanLiuLingDev()
        {
            try
            {
                //string sqlCmd = "SELECT * FROM [dbo].[SanLiuLingDevAccounts] WHERE [SanLiuLingStoreDevAccount] Not IN " +
                //                "(SELECT [SanLiuLingStoreDevAccount] FROM [dbo].[AndroidPushGameInfo] WHERE [State]='待提交' OR [State]='开发中')";

                //DataTable devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                //if (devInfo == null || devInfo.Rows.Count == 0)
                //{
                //    sqlCmd = "SELECT TOP 1 [SanLiuLingStoreDevAccount],[SanLiuLingStoreDevPassword],COUNT([SanLiuLingStoreDevAccount]) as DevCount FROM [dbo].[AndroidPushGameInfo] " +
                //             "WHERE ([State]='待提交' OR [State]='开发中') AND [SanLiuLingStoreDevAccount] !='' AND [SanLiuLingStoreDevPassword] !='' " +
                //             "GROUP BY [SanLiuLingStoreDevAccount],[SanLiuLingStoreDevPassword] " +
                //             "ORDER BY DevCount ASC";

                //    devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);
                //}

                string sqlCmd = string.Format("SELECT TOP 1 * FROM [dbo].[SanLiuLingDevAccounts] ORDER BY NEWID()");

                DataTable devInfo = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (devInfo == null || devInfo.Rows.Count == 0)
                {
                    throw new Exception("获取360账号失败！");
                }

                var result = new Dictionary<string, string>();

                result.Add(devInfo.Rows[0]["SanLiuLingStoreDevAccount"].ToString(), devInfo.Rows[0]["SanLiuLingStoreDevPassword"].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新游戏名称和游戏状态
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="state"></param>
        /// <param name="packageName"></param>
        public void UpdateGameNameAndState(string gameName, string state, string packageName)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[AndroidPushGameInfo] SET [State] = '{0}',[GameName] = '{1}' WHERE [PackageName] = '{2}'",
                                            state, gameName, packageName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }





        #region AppInfoTemp

        public void AddAppInfoTemp(AppInfoTempModel appInfoTempModel)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[AppInfoTemp] WHERE [DetailAddress] = '{0}'",
                                               appInfoTempModel.DetailAddress);


                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该应用已经提交过了!");
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[AppInfoTemp] ([AppName],[DetailAddress],[DownloadAddress],[AppType],[Rate],[State],[Time]) " +
                                              " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                              appInfoTempModel.AppName, appInfoTempModel.DetailAddress, appInfoTempModel.DownloadAddress,
                                              appInfoTempModel.AppType, appInfoTempModel.Rate, appInfoTempModel.State, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAppInfoTemp(AppInfoTempModel appInfoTempModel)
        {
            try
            {
                string id = string.IsNullOrEmpty(appInfoTempModel.ID) ? "[ID]" : "'" + appInfoTempModel.ID + "'";
                string appName = string.IsNullOrEmpty(appInfoTempModel.AppName) ? "[AppName]" : "'" + appInfoTempModel.AppName + "'";
                string detailAddress = string.IsNullOrEmpty(appInfoTempModel.DetailAddress) ? "[DetailAddress]" : "'" + appInfoTempModel.DetailAddress + "'";
                string downloadAddress = string.IsNullOrEmpty(appInfoTempModel.DownloadAddress) ? "[DownloadAddress]" : "'" + appInfoTempModel.DownloadAddress + "'";
                string appType = string.IsNullOrEmpty(appInfoTempModel.AppType) ? "[AppType]" : "'" + appInfoTempModel.AppType + "'";
                string rate = string.IsNullOrEmpty(appInfoTempModel.Rate) ? "[Rate]" : "'" + appInfoTempModel.Rate + "'";
                string state = string.IsNullOrEmpty(appInfoTempModel.State) ? "[State]" : "'" + appInfoTempModel.State + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[AppInfoTemp] SET [AppName] = {0},[DetailAddress] = {1},[DownloadAddress] = {2},[AppType] = {3},[Rate] = {4},[State] = {5},[Time] = '{6}'" +
                                              " WHERE [ID] = {7}",
                                              appName, detailAddress, downloadAddress, appType, rate, state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AppInfoTempModel> GetAppInfoTempList(AppInfoTempModel appInfoTempModel, int count)
        {
            try
            {
                string id = string.IsNullOrEmpty(appInfoTempModel.ID) ? "[ID]" : "'" + appInfoTempModel.ID + "'";
                string appName = string.IsNullOrEmpty(appInfoTempModel.AppName) ? "[AppName]" : "'" + appInfoTempModel.AppName + "'";
                string detailAddress = string.IsNullOrEmpty(appInfoTempModel.DetailAddress) ? "[DetailAddress]" : "'" + appInfoTempModel.DetailAddress + "'";
                string downloadAddress = string.IsNullOrEmpty(appInfoTempModel.DownloadAddress) ? "[DownloadAddress]" : "'" + appInfoTempModel.DownloadAddress + "'";
                string appType = string.IsNullOrEmpty(appInfoTempModel.AppType) ? "[AppType]" : "'" + appInfoTempModel.AppType + "'";
                string rate = string.IsNullOrEmpty(appInfoTempModel.Rate) ? "[Rate]" : "'" + appInfoTempModel.Rate + "'";
                string state = string.IsNullOrEmpty(appInfoTempModel.State) ? "[State]" : "'" + appInfoTempModel.State + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[AppInfoTemp] WHERE " +
                                             "[AppName] = {1} AND [DetailAddress] = {2} AND [DownloadAddress] = {3} AND [AppType] = {4} AND [Rate] = {5} AND [State] = {6} ",
                                             count == 0 ? "" : "TOP " + count.ToString(),
                                             appName, detailAddress, downloadAddress, appType, rate, state);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                DataTable appInfoTempTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (appInfoTempTable == null || appInfoTempTable.Rows.Count == 0)
                {
                    return null;
                }

                List<AppInfoTempModel> appInfoTempModelList = new List<AppInfoTempModel>();
                for (int i = 0; i < appInfoTempTable.Rows.Count; i++)
                {
                    AppInfoTempModel appInfoTempModel_t = new AppInfoTempModel
                    {
                        AppName = appInfoTempTable.Rows[i]["AppName"].ToString(),
                        AppType = appInfoTempTable.Rows[i]["AppType"].ToString(),
                        DetailAddress = appInfoTempTable.Rows[i]["DetailAddress"].ToString(),
                        DownloadAddress = appInfoTempTable.Rows[i]["DownloadAddress"].ToString(),
                        ID = appInfoTempTable.Rows[i]["ID"].ToString(),
                        Rate = appInfoTempTable.Rows[i]["Rate"].ToString(),
                        State = appInfoTempTable.Rows[i]["State"].ToString(),
                        Time = appInfoTempTable.Rows[i]["Time"].ToString()
                    };

                    appInfoTempModelList.Add(appInfoTempModel_t);
                }

                return appInfoTempModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAppInfoTempByID(string id)
        {
            try
            {
                string sqlCmd = string.Format("DELETE [dbo].[AppInfoTemp] WHERE [ID]='{0}'", id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region LiuMangAds

        public void AddLiuMangAds(LiuMangAds liuMangAds)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[LiuMangAds] WHERE [IadKey] = '{0}' OR [JingZhongKey] = '{1}'",
                                               liuMangAds.IadKey, liuMangAds.JingZhongKey);


                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("IadKey或精众Key已经存在库中了!");
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[LiuMangAds] ([IadKey],[IadAppName],[JingZhongKey],[JingZhongAppName],[Status],[Time]) " +
                                              " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                              liuMangAds.IadKey, liuMangAds.IadAppName, liuMangAds.JingZhongKey, liuMangAds.JingZhongAppName,
                                              liuMangAds.Status, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateLiuMangAds(LiuMangAds liuMangAds)
        {
            try
            {
                string id = string.IsNullOrEmpty(liuMangAds.ID) ? "[ID]" : "'" + liuMangAds.ID + "'";
                string iadKey = string.IsNullOrEmpty(liuMangAds.IadKey) ? "[IadKey]" : "'" + liuMangAds.IadKey + "'";
                string iadAppName = string.IsNullOrEmpty(liuMangAds.IadAppName) ? "[IadAppName]" : "'" + liuMangAds.IadAppName + "'";
                string jingZhongKey = string.IsNullOrEmpty(liuMangAds.JingZhongKey) ? "[JingZhongKey]" : "'" + liuMangAds.JingZhongKey + "'";
                string jingZhongAppName = string.IsNullOrEmpty(liuMangAds.JingZhongAppName) ? "[JingZhongAppName]" : "'" + liuMangAds.JingZhongAppName + "'";
                string status = string.IsNullOrEmpty(liuMangAds.Status) ? "[Status]" : "'" + liuMangAds.Status + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[LiuMangAds] SET [IadKey] = {0},[IadAppName] = {1},[JingZhongKey] = {2},[JingZhongAppName] = {3},[Status] = {4},[Time] = '{5}'" +
                                              " WHERE [ID] = {6}",
                                              iadKey, iadAppName, jingZhongKey, jingZhongAppName, status, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LiuMangAds> GetLiuMangAdsList(LiuMangAds liuMangAds, int count)
        {
            try
            {
                string id = string.IsNullOrEmpty(liuMangAds.ID) ? "[ID]" : "'" + liuMangAds.ID + "'";
                string iadKey = string.IsNullOrEmpty(liuMangAds.IadKey) ? "[IadKey]" : "'" + liuMangAds.IadKey + "'";
                string iadAppName = string.IsNullOrEmpty(liuMangAds.IadAppName) ? "[IadAppName]" : "'" + liuMangAds.IadAppName + "'";
                string jingZhongKey = string.IsNullOrEmpty(liuMangAds.JingZhongKey) ? "[JingZhongKey]" : "'" + liuMangAds.JingZhongKey + "'";
                string jingZhongAppName = string.IsNullOrEmpty(liuMangAds.JingZhongAppName) ? "[JingZhongAppName]" : "'" + liuMangAds.JingZhongAppName + "'";
                string status = string.IsNullOrEmpty(liuMangAds.Status) ? "[Status]" : "'" + liuMangAds.Status + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[LiuMangAds] WHERE " +
                                             "[IadKey] = {1} AND [IadAppName] = {2} AND [JingZhongKey] = {3} AND [JingZhongAppName] = {4} AND [Status] = {5} AND [ID] = {6} ",
                                             count == 0 ? "" : "TOP " + count.ToString(),
                                             iadKey, iadAppName, jingZhongKey, jingZhongAppName, status, id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                DataTable liuMangAdsTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (liuMangAdsTable == null || liuMangAdsTable.Rows.Count == 0)
                {
                    return null;
                }

                List<LiuMangAds> liuMangAdsList = new List<LiuMangAds>();
                for (int i = 0; i < liuMangAdsTable.Rows.Count; i++)
                {
                    LiuMangAds liuMangAds_t = new LiuMangAds
                    {
                        IadKey = liuMangAdsTable.Rows[i]["IadKey"].ToString(),
                        IadAppName = liuMangAdsTable.Rows[i]["IadAppName"].ToString(),
                        JingZhongKey = liuMangAdsTable.Rows[i]["jingZhongKey"].ToString(),
                        JingZhongAppName = liuMangAdsTable.Rows[i]["JingZhongAppName"].ToString(),
                        Status = liuMangAdsTable.Rows[i]["Status"].ToString(),
                        ID = liuMangAdsTable.Rows[i]["ID"].ToString(),
                        Time = liuMangAdsTable.Rows[i]["Time"].ToString()
                    };

                    liuMangAdsList.Add(liuMangAds_t);
                }

                return liuMangAdsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLiuMangAdsByID(string id)
        {
            try
            {
                string sqlCmd = string.Format("DELETE [dbo].[LiuMangAds] WHERE [ID]='{0}'", id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

    }
}
