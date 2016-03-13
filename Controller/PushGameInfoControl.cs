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
    public class PushGameInfoControl
    {
        public List<PushGameInfoModel> GetPushGameInfoModelListByCount(PushGameInfoModel pushGameInfoModel, int count)
        {
            try
            {
                string gamename = string.IsNullOrEmpty(pushGameInfoModel.GameName) ? "[GameName]" : "'" + pushGameInfoModel.GameName + "'";
                string version = string.IsNullOrEmpty(pushGameInfoModel.Version) ? "[Version]" : "'" + pushGameInfoModel.Version + "'";
                string state = string.IsNullOrEmpty(pushGameInfoModel.State) ? "[State]" : "'" + pushGameInfoModel.State + "'";
                string gameid = string.IsNullOrEmpty(pushGameInfoModel.GameID) ? "[GameID]" : "'" + pushGameInfoModel.GameID + "'";
                string pushername = string.IsNullOrEmpty(pushGameInfoModel.PusherName) ? "[PusherName]" : "'" + pushGameInfoModel.PusherName + "'";
                string surfaceaccountid = string.IsNullOrEmpty(pushGameInfoModel.SurfaceAccountID) ? "[SurfaceAccountID]" : "'" + pushGameInfoModel.SurfaceAccountID + "'";
                string surfaceadid = string.IsNullOrEmpty(pushGameInfoModel.SurfaceAdID) ? "[SurfaceAdID]" : "'" + pushGameInfoModel.SurfaceAdID + "'";
                string googlebanner = string.IsNullOrEmpty(pushGameInfoModel.GoogleBanner) ? "[GoogleBanner]" : "'" + pushGameInfoModel.GoogleBanner + "'";
                string googlechaping = string.IsNullOrEmpty(pushGameInfoModel.GoogleChaping) ? "[GoogleChaping]" : "'" + pushGameInfoModel.GoogleChaping + "'";
                string pubcenterappid = string.IsNullOrEmpty(pushGameInfoModel.PubcenterAppID) ? "[PubcenterAppID]" : "'" + pushGameInfoModel.PubcenterAppID + "'";
                string pubcenteradid = string.IsNullOrEmpty(pushGameInfoModel.PubcenterAdID) ? "[PubcenterAdID]" : "'" + pushGameInfoModel.PubcenterAdID + "'";
                string addtime = string.IsNullOrEmpty(pushGameInfoModel.AddTime) ? "[AddTime]" : "'" + pushGameInfoModel.AddTime + "'";
                string updatetime = string.IsNullOrEmpty(pushGameInfoModel.UpdateTime) ? "[UpdateTime]" : "'" + pushGameInfoModel.UpdateTime + "'";
                string devaccount = string.IsNullOrEmpty(pushGameInfoModel.DevAccount) ? "[DevAccount]" : "'" + pushGameInfoModel.DevAccount + "'";
                string devpassword = string.IsNullOrEmpty(pushGameInfoModel.DevPassword) ? "[DevPassword]" : "'" + pushGameInfoModel.DevPassword + "'";

                string id = string.IsNullOrEmpty(pushGameInfoModel.ID) ? "[ID]" : "'" + pushGameInfoModel.ID + "'";
                string gameDetails = string.IsNullOrEmpty(pushGameInfoModel.GameDetails) ? "[GameDetails]" : "'" + pushGameInfoModel.GameDetails + "'";
                string logoPath = string.IsNullOrEmpty(pushGameInfoModel.LogoPath) ? "[LogoPath]" : "'" + pushGameInfoModel.LogoPath + "'";
                string backImagePath = string.IsNullOrEmpty(pushGameInfoModel.BackImagePath) ? "[BackImagePath]" : "'" + pushGameInfoModel.BackImagePath + "'";
                string sourceType = string.IsNullOrEmpty(pushGameInfoModel.SourceType) ? "[SourceType]" : "'" + pushGameInfoModel.SourceType + "'";
                string fileName = string.IsNullOrEmpty(pushGameInfoModel.FileName) ? "[FileName]" : "'" + pushGameInfoModel.FileName + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[PushGameInfo] WHERE " +
                                              "[GameName] = {1} AND [Version] = {2} AND [State] = {3} AND [GameID] = {4} AND [PusherName] = {5} " +
                                              "AND [SurfaceAccountID] = {6} AND [SurfaceAdID] = {7} AND [GoogleBanner] = {8} AND [GoogleChaping] = {9} " +
                                              "AND [PubcenterAppID] = {10} AND [PubcenterAdID] = {11} AND [AddTime] = {12} AND [UpdateTime] = {13} " +
                                              "AND [DevAccount] = {14} AND [DevPassword] = {15} AND [ID]= {16} AND [GameDetails]= {17} AND [LogoPath]= {18} AND [BackImagePath]= {19} AND [SourceType] = {20} AND [FileName] = {21}  ORDER BY [Version] DESC",
                                              count == 0 ? "" : "TOP " + count.ToString(),
                                              gamename, version, state, gameid, pushername,
                                              surfaceaccountid, surfaceadid, googlebanner, googlechaping,
                                              pubcenterappid, pubcenteradid, addtime, updatetime,
                                              devaccount, devpassword, id, gameDetails, logoPath, backImagePath, sourceType, fileName);

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<PushGameInfoModel> pushGameInfoModelList = new List<PushGameInfoModel>();
                for (int i = 0; i < pushGameInfoTable.Rows.Count; i++)
                {
                    PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                    {
                        AddTime = pushGameInfoTable.Rows[i]["AddTime"].ToString(),
                        DevAccount = pushGameInfoTable.Rows[i]["DevAccount"].ToString(),
                        DevPassword = pushGameInfoTable.Rows[i]["DevPassword"].ToString(),
                        GameID = pushGameInfoTable.Rows[i]["GameID"].ToString(),
                        GameName = pushGameInfoTable.Rows[i]["GameName"].ToString(),
                        GoogleBanner = pushGameInfoTable.Rows[i]["GoogleBanner"].ToString(),
                        GoogleChaping = pushGameInfoTable.Rows[i]["GoogleChaping"].ToString(),
                        PubcenterAdID = pushGameInfoTable.Rows[i]["PubcenterAdID"].ToString(),
                        PubcenterAppID = pushGameInfoTable.Rows[i]["PubcenterAppID"].ToString(),
                        PusherName = pushGameInfoTable.Rows[i]["PusherName"].ToString(),
                        State = pushGameInfoTable.Rows[i]["State"].ToString(),
                        SurfaceAccountID = pushGameInfoTable.Rows[i]["SurfaceAccountID"].ToString(),
                        SurfaceAdID = pushGameInfoTable.Rows[i]["SurfaceAdID"].ToString(),
                        UpdateTime = pushGameInfoTable.Rows[i]["UpdateTime"].ToString(),
                        Version = pushGameInfoTable.Rows[i]["Version"].ToString(),
                        ID = pushGameInfoTable.Rows[i]["ID"].ToString(),
                        GameDetails = pushGameInfoTable.Rows[i]["GameDetails"].ToString(),
                        LogoPath = pushGameInfoTable.Rows[i]["LogoPath"].ToString(),
                        BackImagePath = pushGameInfoTable.Rows[i]["BackImagePath"].ToString(),
                        SourceType = pushGameInfoTable.Rows[i]["SourceType"].ToString(),
                        FileName = pushGameInfoTable.Rows[i]["FileName"].ToString(),
                        AdName = pushGameInfoTable.Rows[i]["AdName"].ToString(),
                        FixedGameName = pushGameInfoTable.Rows[i]["FixedGameName"].ToString(),
                    };

                    pushGameInfoModelList.Add(pushGameInfoModel_t);
                }

                return pushGameInfoModelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PushGameInfoModel GetOneGameInfoByStateRandom(string jpstate, string newjpState)
        {
            try
            {
                string sqlCmd = string.Format("SELECT Top 1 * FROM [dbo].[PushGameInfo] WHERE [JPState] = '{0}' ORDER BY NEWID()", jpstate);

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                {
                    AddTime = pushGameInfoTable.Rows[0]["AddTime"].ToString(),
                    DevAccount = pushGameInfoTable.Rows[0]["DevAccount"].ToString(),
                    DevPassword = pushGameInfoTable.Rows[0]["DevPassword"].ToString(),
                    GameID = pushGameInfoTable.Rows[0]["GameID"].ToString(),
                    GameName = pushGameInfoTable.Rows[0]["GameName"].ToString(),
                    GoogleBanner = pushGameInfoTable.Rows[0]["GoogleBanner"].ToString(),
                    GoogleChaping = pushGameInfoTable.Rows[0]["GoogleChaping"].ToString(),
                    PubcenterAdID = pushGameInfoTable.Rows[0]["PubcenterAdID"].ToString(),
                    PubcenterAppID = pushGameInfoTable.Rows[0]["PubcenterAppID"].ToString(),
                    PusherName = pushGameInfoTable.Rows[0]["PusherName"].ToString(),
                    State = pushGameInfoTable.Rows[0]["State"].ToString(),
                    SurfaceAccountID = pushGameInfoTable.Rows[0]["SurfaceAccountID"].ToString(),
                    SurfaceAdID = pushGameInfoTable.Rows[0]["SurfaceAdID"].ToString(),
                    UpdateTime = pushGameInfoTable.Rows[0]["UpdateTime"].ToString(),
                    Version = pushGameInfoTable.Rows[0]["Version"].ToString(),
                    ID = pushGameInfoTable.Rows[0]["ID"].ToString(),
                    GameDetails = pushGameInfoTable.Rows[0]["GameDetails"].ToString(),
                    LogoPath = pushGameInfoTable.Rows[0]["LogoPath"].ToString(),
                    BackImagePath = pushGameInfoTable.Rows[0]["BackImagePath"].ToString(),
                    SourceType = pushGameInfoTable.Rows[0]["SourceType"].ToString(),
                    FileName = pushGameInfoTable.Rows[0]["FileName"].ToString(),
                };

                sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [JPState] = '{0}' WHERE [ID] = {1}", newjpState, pushGameInfoModel_t.ID);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return (pushGameInfoModel_t);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PushGameInfoModel GetOneGameInfoByRealStateRandom(string state, string newState, string devPusher)
        {
            try
            {
                if (string.IsNullOrEmpty(devPusher))
                {
                    devPusher = "[PusherUser]";
                }
                else
                {
                    devPusher = "'" + devPusher + "'";
                }

                string sqlCmd_t = string.Format("SELECT [Account] FROM [dbo].[WindowsDevAccounts] WHERE [PusherUser]={0} AND [State]='可用'", devPusher);
                object ttt = SqlHelper.Instance.ExecuteScalar(sqlCmd_t);

                if (ttt == null)
                {
                    throw new Exception("没有获取到您关联的可以使用的开发者账号");
                }

                string devAccount_t = ttt.ToString();

                //string sqlCmd = string.Format("SELECT Top 1 * FROM [dbo].[PushGameInfo] WHERE [State] = '{0}' AND [DevAccount] = '{1}' ORDER BY NEWID()",
                //                              state, devAccount_t);

                string sqlCmd = string.Format("SELECT Top 1 * FROM [dbo].[PushGameInfo] WHERE [State] = '{0}' AND [DevAccount] = '{1}'",
                              state, devAccount_t);

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                {
                    AddTime = pushGameInfoTable.Rows[0]["AddTime"].ToString(),
                    DevAccount = pushGameInfoTable.Rows[0]["DevAccount"].ToString(),
                    DevPassword = pushGameInfoTable.Rows[0]["DevPassword"].ToString(),
                    GameID = pushGameInfoTable.Rows[0]["GameID"].ToString(),
                    GameName = pushGameInfoTable.Rows[0]["GameName"].ToString(),
                    GoogleBanner = pushGameInfoTable.Rows[0]["GoogleBanner"].ToString(),
                    GoogleChaping = pushGameInfoTable.Rows[0]["GoogleChaping"].ToString(),
                    PubcenterAdID = pushGameInfoTable.Rows[0]["PubcenterAdID"].ToString(),
                    PubcenterAppID = pushGameInfoTable.Rows[0]["PubcenterAppID"].ToString(),
                    PusherName = pushGameInfoTable.Rows[0]["PusherName"].ToString(),
                    State = pushGameInfoTable.Rows[0]["State"].ToString(),
                    SurfaceAccountID = pushGameInfoTable.Rows[0]["SurfaceAccountID"].ToString(),
                    SurfaceAdID = pushGameInfoTable.Rows[0]["SurfaceAdID"].ToString(),
                    UpdateTime = pushGameInfoTable.Rows[0]["UpdateTime"].ToString(),
                    Version = pushGameInfoTable.Rows[0]["Version"].ToString(),
                    ID = pushGameInfoTable.Rows[0]["ID"].ToString(),
                    GameDetails = pushGameInfoTable.Rows[0]["GameDetails"].ToString(),
                    LogoPath = pushGameInfoTable.Rows[0]["LogoPath"].ToString(),
                    BackImagePath = pushGameInfoTable.Rows[0]["BackImagePath"].ToString(),
                    SourceType = pushGameInfoTable.Rows[0]["SourceType"].ToString(),
                    FileName = pushGameInfoTable.Rows[0]["FileName"].ToString(),
                    AdName = pushGameInfoTable.Rows[0]["AdName"].ToString(),
                    FixedGameName = pushGameInfoTable.Rows[0]["FixedGameName"].ToString(),
                };

                sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = '{2}'", newState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pushGameInfoModel_t.ID);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return (pushGameInfoModel_t);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PushGameInfoModel GetOneGameInfoAndChangeStateRandom(string state, string newState)
        {
            try
            {
                string sqlCmd = string.Format("SELECT Top 1 * FROM [dbo].[PushGameInfo] WHERE [State] = '{0}' ORDER BY NEWID()",
                              state);

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                {
                    AddTime = pushGameInfoTable.Rows[0]["AddTime"].ToString(),
                    DevAccount = pushGameInfoTable.Rows[0]["DevAccount"].ToString(),
                    DevPassword = pushGameInfoTable.Rows[0]["DevPassword"].ToString(),
                    GameID = pushGameInfoTable.Rows[0]["GameID"].ToString(),
                    GameName = pushGameInfoTable.Rows[0]["GameName"].ToString(),
                    GoogleBanner = pushGameInfoTable.Rows[0]["GoogleBanner"].ToString(),
                    GoogleChaping = pushGameInfoTable.Rows[0]["GoogleChaping"].ToString(),
                    PubcenterAdID = pushGameInfoTable.Rows[0]["PubcenterAdID"].ToString(),
                    PubcenterAppID = pushGameInfoTable.Rows[0]["PubcenterAppID"].ToString(),
                    PusherName = pushGameInfoTable.Rows[0]["PusherName"].ToString(),
                    State = pushGameInfoTable.Rows[0]["State"].ToString(),
                    SurfaceAccountID = pushGameInfoTable.Rows[0]["SurfaceAccountID"].ToString(),
                    SurfaceAdID = pushGameInfoTable.Rows[0]["SurfaceAdID"].ToString(),
                    UpdateTime = pushGameInfoTable.Rows[0]["UpdateTime"].ToString(),
                    Version = pushGameInfoTable.Rows[0]["Version"].ToString(),
                    ID = pushGameInfoTable.Rows[0]["ID"].ToString(),
                    GameDetails = pushGameInfoTable.Rows[0]["GameDetails"].ToString(),
                    LogoPath = pushGameInfoTable.Rows[0]["LogoPath"].ToString(),
                    BackImagePath = pushGameInfoTable.Rows[0]["BackImagePath"].ToString(),
                    SourceType = pushGameInfoTable.Rows[0]["SourceType"].ToString(),
                    FileName = pushGameInfoTable.Rows[0]["FileName"].ToString(),
                    AdName = pushGameInfoTable.Rows[0]["AdName"].ToString(),
                    FixedGameName = pushGameInfoTable.Rows[0]["FixedGameName"].ToString(),
                    RealDevAccount = pushGameInfoTable.Rows[0]["RealDevAccount"].ToString(),
                    RealDevPassword = pushGameInfoTable.Rows[0]["RealDevPassword"].ToString(),
                };

                sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = '{2}'", newState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pushGameInfoModel_t.ID);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return (pushGameInfoModel_t);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public PushGameInfoModel GetOneGameInfoAndChangeStateRandomForDev(string state, string newState)
        {
            try
            {

                string sqlCmd = string.Format("SELECT * FROM (SELECT TOP 1 'f' flag,[DevAccount] as DA,[DevPassword] as DP FROM [dbo].[Edumail] WHERE [State]='已激活' AND [PushCount] = 0) A JOIN (SELECT TOP 1 'f' flag,* FROM [dbo].[PushGameInfo] WHERE [State]='待提交' ORDER BY NEWID()) B ON A.flag=B.flag");

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                {
                    AddTime = pushGameInfoTable.Rows[0]["AddTime"].ToString(),
                    DevAccount = pushGameInfoTable.Rows[0]["DevAccount"].ToString(),
                    DevPassword = pushGameInfoTable.Rows[0]["DevPassword"].ToString(),
                    GameID = pushGameInfoTable.Rows[0]["GameID"].ToString(),
                    GameName = pushGameInfoTable.Rows[0]["GameName"].ToString(),
                    GoogleBanner = pushGameInfoTable.Rows[0]["GoogleBanner"].ToString(),
                    GoogleChaping = pushGameInfoTable.Rows[0]["GoogleChaping"].ToString(),
                    PubcenterAdID = pushGameInfoTable.Rows[0]["PubcenterAdID"].ToString(),
                    PubcenterAppID = pushGameInfoTable.Rows[0]["PubcenterAppID"].ToString(),
                    PusherName = pushGameInfoTable.Rows[0]["PusherName"].ToString(),
                    State = pushGameInfoTable.Rows[0]["State"].ToString(),
                    SurfaceAccountID = pushGameInfoTable.Rows[0]["SurfaceAccountID"].ToString(),
                    SurfaceAdID = pushGameInfoTable.Rows[0]["SurfaceAdID"].ToString(),
                    UpdateTime = pushGameInfoTable.Rows[0]["UpdateTime"].ToString(),
                    Version = pushGameInfoTable.Rows[0]["Version"].ToString(),
                    ID = pushGameInfoTable.Rows[0]["ID"].ToString(),
                    GameDetails = pushGameInfoTable.Rows[0]["GameDetails"].ToString(),
                    LogoPath = pushGameInfoTable.Rows[0]["LogoPath"].ToString(),
                    BackImagePath = pushGameInfoTable.Rows[0]["BackImagePath"].ToString(),
                    SourceType = pushGameInfoTable.Rows[0]["SourceType"].ToString(),
                    FileName = pushGameInfoTable.Rows[0]["FileName"].ToString(),
                    AdName = pushGameInfoTable.Rows[0]["AdName"].ToString(),
                    FixedGameName = pushGameInfoTable.Rows[0]["FixedGameName"].ToString(),
                    RealDevAccount = pushGameInfoTable.Rows[0]["DA"].ToString(),
                    RealDevPassword = pushGameInfoTable.Rows[0]["DP"].ToString(),
                };

                sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = '{2}'", newState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pushGameInfoModel_t.ID);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                sqlCmd = string.Format("UPDATE [dbo].[Edumail] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [DevAccount] = '{2}'", newState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pushGameInfoModel_t.RealDevAccount);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return (pushGameInfoModel_t);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void DevSuccessedByDreamSpark(string id, string realDevAccount, string realDevPassword, string ip)
        {
            try
            {
                string sqlCmd1 = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}',[RealDevAccount] = '{2}',[RealDevPassword] = '{3}',[PushIP] = '{4}' WHERE [ID] = '{5}'",
                                                "待审核", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), realDevAccount, realDevPassword, ip, id);
                SqlHelper.Instance.ExecuteCommand(sqlCmd1);

                string sqlCmd2 = string.Format("SELECT [GameName] FROM [dbo].[PushGameInfo] WHERE [ID]={0}", id);
                string gameName = SqlHelper.Instance.ExecuteScalar(sqlCmd2).ToString();

                string sqlCmd3 = string.Format("UPDATE [dbo].[Edumail] SET [State] = '{0}',[UpdateTime] = '{1}',[PushCount] = [PushCount] + 1,[PushIP] = '{2}',[LastPushedGame] = '{3}' WHERE [DevAccount] = '{4}'",
                                "已激活", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ip, gameName, realDevAccount);
                SqlHelper.Instance.ExecuteCommand(sqlCmd3);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public PushGameInfoModel GetOneGameInfoAndChangeStateRandomForDevAmazon(string state, string newState)
        {
            try
            {

                string sqlCmd = string.Format("SELECT * FROM (SELECT TOP 1 'f' flag,[DevAccount] as DA,[DevPassword] as DP FROM [dbo].[Edumail] WHERE [State]='amazon已激活' AND [PushCount] = 0) A JOIN (SELECT TOP 1 'f' flag,* FROM [dbo].[PushGameInfo] WHERE [State]='安卓未就绪' ORDER BY NEWID()) B ON A.flag=B.flag");

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                {
                    AddTime = pushGameInfoTable.Rows[0]["AddTime"].ToString(),
                    DevAccount = pushGameInfoTable.Rows[0]["DevAccount"].ToString(),
                    DevPassword = pushGameInfoTable.Rows[0]["DevPassword"].ToString(),
                    GameID = pushGameInfoTable.Rows[0]["GameID"].ToString(),
                    GameName = pushGameInfoTable.Rows[0]["GameName"].ToString(),
                    GoogleBanner = pushGameInfoTable.Rows[0]["GoogleBanner"].ToString(),
                    GoogleChaping = pushGameInfoTable.Rows[0]["GoogleChaping"].ToString(),
                    PubcenterAdID = pushGameInfoTable.Rows[0]["PubcenterAdID"].ToString(),
                    PubcenterAppID = pushGameInfoTable.Rows[0]["PubcenterAppID"].ToString(),
                    PusherName = pushGameInfoTable.Rows[0]["PusherName"].ToString(),
                    State = pushGameInfoTable.Rows[0]["State"].ToString(),
                    SurfaceAccountID = pushGameInfoTable.Rows[0]["SurfaceAccountID"].ToString(),
                    SurfaceAdID = pushGameInfoTable.Rows[0]["SurfaceAdID"].ToString(),
                    UpdateTime = pushGameInfoTable.Rows[0]["UpdateTime"].ToString(),
                    Version = pushGameInfoTable.Rows[0]["Version"].ToString(),
                    ID = pushGameInfoTable.Rows[0]["ID"].ToString(),
                    GameDetails = pushGameInfoTable.Rows[0]["GameDetails"].ToString(),
                    LogoPath = pushGameInfoTable.Rows[0]["LogoPath"].ToString(),
                    BackImagePath = pushGameInfoTable.Rows[0]["BackImagePath"].ToString(),
                    SourceType = pushGameInfoTable.Rows[0]["SourceType"].ToString(),
                    FileName = pushGameInfoTable.Rows[0]["FileName"].ToString(),
                    AdName = pushGameInfoTable.Rows[0]["AdName"].ToString(),
                    FixedGameName = pushGameInfoTable.Rows[0]["FixedGameName"].ToString(),
                    RealDevAccount = pushGameInfoTable.Rows[0]["DA"].ToString(),
                    RealDevPassword = pushGameInfoTable.Rows[0]["DP"].ToString(),
                    GameClassify = pushGameInfoTable.Rows[0]["GameClassify"].ToString(),
                    UnityVersion = pushGameInfoTable.Rows[0]["UnityVersion"].ToString()
                };

                sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = '{2}'", newState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pushGameInfoModel_t.ID);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                sqlCmd = string.Format("UPDATE [dbo].[Edumail] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [DevAccount] = '{2}'", newState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pushGameInfoModel_t.RealDevAccount);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return (pushGameInfoModel_t);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void InputInfoSuccessedByDreamSparkAmazon(string id, string realDevAccount, string realDevPassword, string ip)
        {
            try
            {
                string sqlCmd1 = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}',[RealDevAccount] = '{2}',[RealDevPassword] = '{3}',[PushIP] = '{4}' WHERE [ID] = '{5}'",
                                                "安卓已填写", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), realDevAccount, realDevPassword, ip, id);
                SqlHelper.Instance.ExecuteCommand(sqlCmd1);

                string sqlCmd2 = string.Format("SELECT [GameName] FROM [dbo].[PushGameInfo] WHERE [ID]={0}", id);
                string gameName = SqlHelper.Instance.ExecuteScalar(sqlCmd2).ToString();

                string sqlCmd3 = string.Format("UPDATE [dbo].[Edumail] SET [State] = '{0}',[UpdateTime] = '{1}',[PushCount] = [PushCount] + 1,[PushIP] = '{2}',[LastPushedGame] = '{3}' WHERE [DevAccount] = '{4}'",
                                "amazon已填写", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ip, gameName, realDevAccount);
                SqlHelper.Instance.ExecuteCommand(sqlCmd3);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DevSuccessedByDreamSparkAmazon(string id, string realDevAccount, string realDevPassword, string ip)
        {
            try
            {
                string sqlCmd1 = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = '{0}',[UpdateTime] = '{1}',[RealDevAccount] = '{2}',[RealDevPassword] = '{3}',[PushIP] = '{4}' WHERE [ID] = '{5}'",
                                                "安卓待审核", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), realDevAccount, realDevPassword, ip, id);
                SqlHelper.Instance.ExecuteCommand(sqlCmd1);

                string sqlCmd2 = string.Format("SELECT [GameName] FROM [dbo].[PushGameInfo] WHERE [ID]={0}", id);
                string gameName = SqlHelper.Instance.ExecuteScalar(sqlCmd2).ToString();

                string sqlCmd3 = string.Format("UPDATE [dbo].[Edumail] SET [State] = '{0}',[UpdateTime] = '{1}',[PushCount] = [PushCount] + 1,[PushIP] = '{2}',[LastPushedGame] = '{3}' WHERE [DevAccount] = '{4}'",
                                "amazon待审核", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ip, gameName, realDevAccount);
                SqlHelper.Instance.ExecuteCommand(sqlCmd3);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PushGameInfoModel> GetNoGameDetailsGameList()
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[PushGameInfo] WHERE [GameDetails]='' OR [GameDetails]=NULL");

                DataTable pushGameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pushGameInfoTable == null || pushGameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<PushGameInfoModel> pushGameInfoModelList = new List<PushGameInfoModel>();
                for (int i = 0; i < pushGameInfoTable.Rows.Count; i++)
                {
                    PushGameInfoModel pushGameInfoModel_t = new PushGameInfoModel
                    {
                        AddTime = pushGameInfoTable.Rows[i]["AddTime"].ToString(),
                        DevAccount = pushGameInfoTable.Rows[i]["DevAccount"].ToString(),
                        DevPassword = pushGameInfoTable.Rows[i]["DevPassword"].ToString(),
                        GameID = pushGameInfoTable.Rows[i]["GameID"].ToString(),
                        GameName = pushGameInfoTable.Rows[i]["GameName"].ToString(),
                        GoogleBanner = pushGameInfoTable.Rows[i]["GoogleBanner"].ToString(),
                        GoogleChaping = pushGameInfoTable.Rows[i]["GoogleChaping"].ToString(),
                        PubcenterAdID = pushGameInfoTable.Rows[i]["PubcenterAdID"].ToString(),
                        PubcenterAppID = pushGameInfoTable.Rows[i]["PubcenterAppID"].ToString(),
                        PusherName = pushGameInfoTable.Rows[i]["PusherName"].ToString(),
                        State = pushGameInfoTable.Rows[i]["State"].ToString(),
                        SurfaceAccountID = pushGameInfoTable.Rows[i]["SurfaceAccountID"].ToString(),
                        SurfaceAdID = pushGameInfoTable.Rows[i]["SurfaceAdID"].ToString(),
                        UpdateTime = pushGameInfoTable.Rows[i]["UpdateTime"].ToString(),
                        Version = pushGameInfoTable.Rows[i]["Version"].ToString(),
                        ID = pushGameInfoTable.Rows[i]["ID"].ToString(),
                        GameDetails = pushGameInfoTable.Rows[i]["GameDetails"].ToString(),
                        LogoPath = pushGameInfoTable.Rows[i]["LogoPath"].ToString(),
                        BackImagePath = pushGameInfoTable.Rows[i]["BackImagePath"].ToString(),
                        SourceType = pushGameInfoTable.Rows[i]["SourceType"].ToString(),
                        FileName = pushGameInfoTable.Rows[i]["FileName"].ToString(),
                    };

                    pushGameInfoModelList.Add(pushGameInfoModel_t);
                }

                return pushGameInfoModelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddPushGameInfo(PushGameInfoModel pushGameInfoModel)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[PushGameInfo] WHERE [GameName] = '{0}' AND [Version] = '{1}' AND [SourceType] = '{2}'",
                                                  pushGameInfoModel.GameName, pushGameInfoModel.Version, pushGameInfoModel.SourceType);

                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该游戏版本已经提交过了!");
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[PushGameInfo] ([GameName],[Version],[State],[GameID],[PusherName],[SurfaceAccountID],[SurfaceAdID],[GoogleBanner],[GoogleChaping],[PubcenterAppID],[PubcenterAdID],[AddTime],[UpdateTime],[DevAccount],[DevPassword],[GameDetails],[LogoPath],[BackImagePath],[SourceType],[FileName]) " +
                                              " VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                                              pushGameInfoModel.GameName, pushGameInfoModel.Version, pushGameInfoModel.State, pushGameInfoModel.GameID, pushGameInfoModel.PusherName,
                                              pushGameInfoModel.SurfaceAccountID, pushGameInfoModel.SurfaceAdID, pushGameInfoModel.GoogleBanner, pushGameInfoModel.GoogleChaping,
                                              pushGameInfoModel.PubcenterAppID, pushGameInfoModel.PubcenterAdID, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                              pushGameInfoModel.DevAccount, pushGameInfoModel.DevPassword, pushGameInfoModel.GameDetails, pushGameInfoModel.LogoPath, pushGameInfoModel.BackImagePath, pushGameInfoModel.SourceType, pushGameInfoModel.FileName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdatePushGameInfo(PushGameInfoModel pushGameInfoModel)
        {
            try
            {
                string gamename = string.IsNullOrEmpty(pushGameInfoModel.GameName) ? "[GameName]" : "'" + pushGameInfoModel.GameName + "'";
                string version = string.IsNullOrEmpty(pushGameInfoModel.Version) ? "[Version]" : "'" + pushGameInfoModel.Version + "'";
                string state = string.IsNullOrEmpty(pushGameInfoModel.State) ? "[State]" : "'" + pushGameInfoModel.State + "'";
                string gameid = string.IsNullOrEmpty(pushGameInfoModel.GameID) ? "[GameID]" : "'" + pushGameInfoModel.GameID + "'";
                string pushername = string.IsNullOrEmpty(pushGameInfoModel.PusherName) ? "[PusherName]" : "'" + pushGameInfoModel.PusherName + "'";
                string surfaceaccountid = string.IsNullOrEmpty(pushGameInfoModel.SurfaceAccountID) ? "[SurfaceAccountID]" : "'" + pushGameInfoModel.SurfaceAccountID + "'";
                string surfaceadid = string.IsNullOrEmpty(pushGameInfoModel.SurfaceAdID) ? "[SurfaceAdID]" : "'" + pushGameInfoModel.SurfaceAdID + "'";
                string googlebanner = string.IsNullOrEmpty(pushGameInfoModel.GoogleBanner) ? "[GoogleBanner]" : "'" + pushGameInfoModel.GoogleBanner + "'";
                string googlechaping = string.IsNullOrEmpty(pushGameInfoModel.GoogleChaping) ? "[GoogleChaping]" : "'" + pushGameInfoModel.GoogleChaping + "'";
                string pubcenterappid = string.IsNullOrEmpty(pushGameInfoModel.PubcenterAppID) ? "[PubcenterAppID]" : "'" + pushGameInfoModel.PubcenterAppID + "'";
                string pubcenteradid = string.IsNullOrEmpty(pushGameInfoModel.PubcenterAdID) ? "[PubcenterAdID]" : "'" + pushGameInfoModel.PubcenterAdID + "'";
                string addtime = string.IsNullOrEmpty(pushGameInfoModel.AddTime) ? "[AddTime]" : "'" + pushGameInfoModel.AddTime + "'";
                string updatetime = string.IsNullOrEmpty(pushGameInfoModel.UpdateTime) ? "[UpdateTime]" : "'" + pushGameInfoModel.UpdateTime + "'";
                string devaccount = string.IsNullOrEmpty(pushGameInfoModel.DevAccount) ? "[DevAccount]" : "'" + pushGameInfoModel.DevAccount + "'";
                string devpassword = string.IsNullOrEmpty(pushGameInfoModel.DevPassword) ? "[DevPassword]" : "'" + pushGameInfoModel.DevPassword + "'";

                string id = string.IsNullOrEmpty(pushGameInfoModel.ID) ? "[ID]" : "'" + pushGameInfoModel.ID + "'";
                string gameDetails = string.IsNullOrEmpty(pushGameInfoModel.GameDetails) ? "[GameDetails]" : "'" + pushGameInfoModel.GameDetails + "'";
                string logoPath = string.IsNullOrEmpty(pushGameInfoModel.LogoPath) ? "[LogoPath]" : "'" + pushGameInfoModel.LogoPath + "'";
                string backImagePath = string.IsNullOrEmpty(pushGameInfoModel.BackImagePath) ? "[BackImagePath]" : "'" + pushGameInfoModel.BackImagePath + "'";
                string sourceType = string.IsNullOrEmpty(pushGameInfoModel.SourceType) ? "[SourceType]" : "'" + pushGameInfoModel.SourceType + "'";
                string fileName = string.IsNullOrEmpty(pushGameInfoModel.FileName) ? "[FileName]" : "'" + pushGameInfoModel.FileName + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = {1},[GameID] = {2},[PusherName] = {3},[SurfaceAccountID] = {4}," +
                                              "[SurfaceAdID] = {5},[GoogleBanner] = {6},[GoogleChaping] = {7},[PubcenterAppID] = {8},[PubcenterAdID] = {9},[AddTime] = {10}," +
                                              "[UpdateTime] = '{11}',[DevAccount] = {12},[DevPassword] = {13},[GameDetails] = {14},[LogoPath] = {15},[BackImagePath] = {16},[SourceType] = {17},[FileName] = {18} WHERE [GameName] = {19} AND [Version] = {0}",
                                              version, state, gameid, pushername, surfaceaccountid,
                                              surfaceadid, googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime,
                                              DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), devaccount, devpassword, gameDetails, logoPath, backImagePath, sourceType, fileName, gamename);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateJpState(string jpState, string id)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [JPState] = '{0}' WHERE [ID] = '{1}'",
                                              jpState, id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdatePushGameInfoByID(PushGameInfoModel pushGameInfoModel)
        {
            try
            {
                string gamename = string.IsNullOrEmpty(pushGameInfoModel.GameName) ? "[GameName]" : "'" + pushGameInfoModel.GameName + "'";
                string version = string.IsNullOrEmpty(pushGameInfoModel.Version) ? "[Version]" : "'" + pushGameInfoModel.Version + "'";
                string state = string.IsNullOrEmpty(pushGameInfoModel.State) ? "[State]" : "'" + pushGameInfoModel.State + "'";
                string gameid = string.IsNullOrEmpty(pushGameInfoModel.GameID) ? "[GameID]" : "'" + pushGameInfoModel.GameID + "'";
                string pushername = string.IsNullOrEmpty(pushGameInfoModel.PusherName) ? "[PusherName]" : "'" + pushGameInfoModel.PusherName + "'";
                string surfaceaccountid = string.IsNullOrEmpty(pushGameInfoModel.SurfaceAccountID) ? "[SurfaceAccountID]" : "'" + pushGameInfoModel.SurfaceAccountID + "'";
                string surfaceadid = string.IsNullOrEmpty(pushGameInfoModel.SurfaceAdID) ? "[SurfaceAdID]" : "'" + pushGameInfoModel.SurfaceAdID + "'";
                string googlebanner = string.IsNullOrEmpty(pushGameInfoModel.GoogleBanner) ? "[GoogleBanner]" : "'" + pushGameInfoModel.GoogleBanner + "'";
                string googlechaping = string.IsNullOrEmpty(pushGameInfoModel.GoogleChaping) ? "[GoogleChaping]" : "'" + pushGameInfoModel.GoogleChaping + "'";
                string pubcenterappid = string.IsNullOrEmpty(pushGameInfoModel.PubcenterAppID) ? "[PubcenterAppID]" : "'" + pushGameInfoModel.PubcenterAppID + "'";
                string pubcenteradid = string.IsNullOrEmpty(pushGameInfoModel.PubcenterAdID) ? "[PubcenterAdID]" : "'" + pushGameInfoModel.PubcenterAdID + "'";
                string addtime = string.IsNullOrEmpty(pushGameInfoModel.AddTime) ? "[AddTime]" : "'" + pushGameInfoModel.AddTime + "'";
                string updatetime = string.IsNullOrEmpty(pushGameInfoModel.UpdateTime) ? "[UpdateTime]" : "'" + pushGameInfoModel.UpdateTime + "'";
                string devaccount = string.IsNullOrEmpty(pushGameInfoModel.DevAccount) ? "[DevAccount]" : "'" + pushGameInfoModel.DevAccount + "'";
                string devpassword = string.IsNullOrEmpty(pushGameInfoModel.DevPassword) ? "[DevPassword]" : "'" + pushGameInfoModel.DevPassword + "'";

                string id = string.IsNullOrEmpty(pushGameInfoModel.ID) ? "[ID]" : "'" + pushGameInfoModel.ID + "'";
                string gameDetails = string.IsNullOrEmpty(pushGameInfoModel.GameDetails) ? "[GameDetails]" : "'" + pushGameInfoModel.GameDetails + "'";
                string logoPath = string.IsNullOrEmpty(pushGameInfoModel.LogoPath) ? "[LogoPath]" : "'" + pushGameInfoModel.LogoPath + "'";
                string backImagePath = string.IsNullOrEmpty(pushGameInfoModel.BackImagePath) ? "[BackImagePath]" : "'" + pushGameInfoModel.BackImagePath + "'";
                string sourceType = string.IsNullOrEmpty(pushGameInfoModel.SourceType) ? "[SourceType]" : "'" + pushGameInfoModel.SourceType + "'";
                string fileName = string.IsNullOrEmpty(pushGameInfoModel.FileName) ? "[FileName]" : "'" + pushGameInfoModel.FileName + "'";
                string adName = string.IsNullOrEmpty(pushGameInfoModel.AdName) ? "[AdName]" : "'" + pushGameInfoModel.AdName + "'";
                string realDevAccount = string.IsNullOrEmpty(pushGameInfoModel.RealDevAccount) ? "[RealDevAccount]" : "'" + pushGameInfoModel.RealDevAccount + "'";
                string realDevPassword = string.IsNullOrEmpty(pushGameInfoModel.RealDevPassword) ? "[RealDevPassword]" : "'" + pushGameInfoModel.RealDevPassword + "'";

                if (surfaceaccountid.ToLower() == "'random'" && surfaceadid.ToLower() == "'random'")
                {
                    gamename = "[GameName]";

                    string sqlCmd_t = string.Format("SELECT TOP 1 [SurfaceAccountID],[SurfaceAdID] FROM [dbo].[PushGameInfo] WHERE [SurfaceAdID] != '' ORDER BY NEWID()");

                    DataTable surfaceTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd_t);

                    if (surfaceTable == null || surfaceTable.Rows.Count == 0)
                    {
                        throw new Exception("没有获取到SurfaceAd的随机信息");
                    }
                    else
                    {
                        surfaceaccountid = "'" + surfaceTable.Rows[0]["SurfaceAccountID"].ToString() + "'";
                        surfaceadid = "'" + surfaceTable.Rows[0]["SurfaceAdID"].ToString() + "'";
                    }
                }

                if (state == "'待提交'" && sourceType.ToLower() == "'unity'")
                {
                    state = "'unity待提交'";
                }

                string sqlCmd = string.Format("UPDATE [dbo].[PushGameInfo] SET [State] = {1},[GameID] = {2},[PusherName] = {3},[SurfaceAccountID] = {4}," +
                                              "[SurfaceAdID] = {5},[GoogleBanner] = {6},[GoogleChaping] = {7},[PubcenterAppID] = {8},[PubcenterAdID] = {9},[AddTime] = {10}," +
                                              "[UpdateTime] = '{11}',[DevAccount] = {12},[DevPassword] = {13},[GameDetails] = {14},[LogoPath] = {15},[BackImagePath] = {16},[SourceType] = {17},[FileName] = {18},[GameName] = {19},[AdName] = {20},[RealDevAccount] = {21},[RealDevPassword] = {22},[Version] = {0} WHERE [ID]={23}",
                                              version, state, gameid, pushername, surfaceaccountid,
                                              surfaceadid, googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime,
                                              DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), devaccount, devpassword, gameDetails,
                                              logoPath, backImagePath, sourceType, fileName, gamename, adName, realDevAccount, realDevPassword, id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WordsModel GetWords()
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[Words]");

                DataTable wordsTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (wordsTable == null || wordsTable.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    WordsModel wordsModel = new WordsModel();

                    wordsModel.FirstWords = wordsTable.Rows[0]["FirstWords"].ToString();
                    wordsModel.SecondWords = wordsTable.Rows[0]["SecondWords"].ToString();
                    wordsModel.ThirdWords = wordsTable.Rows[0]["ThirdWords"].ToString();

                    return wordsModel;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteGameInfoByNameAndVersion(string gameName, string version)
        {
            try
            {
                string sqlCmd = string.Format("DELETE FROM [dbo].[PushGameInfo] WHERE [GameName] = '{0}' AND [Version] = '{1}'",
                                            gameName, version);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PusherUserModel> GetUserListByCount(PusherUserModel pusherUserModel, int count)
        {
            try
            {
                string userName = string.IsNullOrEmpty(pusherUserModel.Name) ? "[Name]" : "'" + pusherUserModel.Name + "'";
                string role = string.IsNullOrEmpty(pusherUserModel.Role) ? "[Role]" : "'" + pusherUserModel.Role + "'";
                string password = string.IsNullOrEmpty(pusherUserModel.Password) ? "[Password]" : "'" + pusherUserModel.Password + "'";
                string addTime = string.IsNullOrEmpty(pusherUserModel.AddTime) ? "[AddTime]" : "'" + pusherUserModel.AddTime + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[PusherUser] WHERE " +
                                               "[Name] = {1} AND [AddTime] = {2} AND [Role] = {3} AND [Password] = {4}",
                                               count == 0 ? "" : "Top " + count.ToString(),
                                               userName, addTime, role, password);

                DataTable pusherUserTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pusherUserTable == null || pusherUserTable.Rows.Count == 0)
                {
                    return null;
                }

                List<PusherUserModel> pusherUserModelList = new List<PusherUserModel>();
                for (int i = 0; i < pusherUserTable.Rows.Count; i++)
                {
                    PusherUserModel pusherUserModel_t = new PusherUserModel
                    {
                        AddTime = pusherUserTable.Rows[i]["AddTime"].ToString(),
                        Name = pusherUserTable.Rows[i]["Name"].ToString(),
                        Password = pusherUserTable.Rows[i]["Password"].ToString(),
                        Role = pusherUserTable.Rows[i]["Role"].ToString(),
                    };

                    pusherUserModelList.Add(pusherUserModel_t);
                }

                return pusherUserModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddPusherUser(PusherUserModel pusherUserModel)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT　COUNT(*) FROM [dbo].[PusherUser] WHERE [Name] = '{0}'", pusherUserModel.Name);

                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());
                if (count > 0)
                {
                    throw new Exception("这个人已经存在于数据库中了");
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[PusherUser] ([Name],[AddTime],[Role],[Password]) " +
                                               "VALUES ('{0}','{1}','{2}','{3}')",
                                               pusherUserModel.Name, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), pusherUserModel.Role, pusherUserModel.Password);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdatePusherUser(PusherUserModel pusherUserModel)
        {
            try
            {
                string userName = string.IsNullOrEmpty(pusherUserModel.Name) ? "[Name]" : "'" + pusherUserModel.Name + "'";
                string role = string.IsNullOrEmpty(pusherUserModel.Role) ? "[Role]" : "'" + pusherUserModel.Role + "'";
                string password = string.IsNullOrEmpty(pusherUserModel.Password) ? "[Password]" : "'" + pusherUserModel.Password + "'";
                string addTime = string.IsNullOrEmpty(pusherUserModel.AddTime) ? "[AddTime]" : "'" + pusherUserModel.AddTime + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[PusherUser] SET [Role] = {0},[Password] = {1} WHERE [Name] = {2}",
                                               role, password, userName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletePusherUser(string pusherName)
        {
            try
            {
                string sqlCmd = string.Format("DELETE FROM [dbo].[PusherUser] WHERE [Name] = '{0}'", pusherName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WindowsDevAccounts> GetWindowsDevAccountsByGameState(string gameState)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[WindowsDevAccounts] WHERE [State] = '可用'");

                DataTable devAccountTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (devAccountTable == null || devAccountTable.Rows.Count == 0)
                {
                    return null;
                }

                List<WindowsDevAccounts> windowsDevAccountsList = new List<WindowsDevAccounts>();
                for (int i = 0; i < devAccountTable.Rows.Count; i++)
                {
                    string sql_t = string.Format("SELECT COUNT(*) FROM [dbo].[PushGameInfo] WHERE [DevAccount] = '{0}' AND [State] = '{1}'",
                                                devAccountTable.Rows[i]["Account"].ToString(), gameState);

                    WindowsDevAccounts windowsDevAccounts_t = new WindowsDevAccounts
                    {
                        Account = devAccountTable.Rows[i]["Account"].ToString(),
                        ID = devAccountTable.Rows[i]["ID"].ToString(),

                        Password = devAccountTable.Rows[i]["Password"].ToString(),
                        PusherUser = devAccountTable.Rows[i]["PusherUser"].ToString(),
                        State = devAccountTable.Rows[i]["State"].ToString(),

                        GameCount = SqlHelper.Instance.ExecuteScalar(sql_t).ToString()
                    };

                    windowsDevAccountsList.Add(windowsDevAccounts_t);
                }

                return windowsDevAccountsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetKeywords(int count)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP {0} [GameName]  FROM [dbo].[PushGameInfo] WHERE LEN([GameName]) < 20 ORDER BY NEWID()", count);

                DataTable pusherUserTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pusherUserTable == null || pusherUserTable.Rows.Count == 0)
                {
                    return null;
                }

                List<string> pusherUserModelList = new List<string>();
                for (int i = 0; i < pusherUserTable.Rows.Count; i++)
                {
                    pusherUserModelList.Add(pusherUserTable.Rows[i]["GameName"].ToString());
                }

                return pusherUserModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WindowsDevAccounts GetDevAccountByAccountName(string account)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[WindowsDevAccounts] WHERE [Account] = '{0}'", account);

                DataTable pusherUserTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (pusherUserTable == null || pusherUserTable.Rows.Count == 0)
                {
                    return null;
                }

                WindowsDevAccounts windowsDevAccounts = new WindowsDevAccounts();
                for (int i = 0; i < pusherUserTable.Rows.Count; i++)
                {
                    windowsDevAccounts.Account = pusherUserTable.Rows[i]["Account"].ToString();
                    windowsDevAccounts.Country = pusherUserTable.Rows[i]["Country"].ToString();
                    windowsDevAccounts.Email = pusherUserTable.Rows[i]["Email"].ToString();
                    windowsDevAccounts.FirstName = pusherUserTable.Rows[i]["FirstName"].ToString();
                    windowsDevAccounts.ID = pusherUserTable.Rows[i]["ID"].ToString();
                    windowsDevAccounts.LastName = pusherUserTable.Rows[i]["LastName"].ToString();
                    windowsDevAccounts.Password = pusherUserTable.Rows[i]["Password"].ToString();
                    windowsDevAccounts.PhoneNumber = pusherUserTable.Rows[i]["PhoneNumber"].ToString();
                    windowsDevAccounts.PublisherName = pusherUserTable.Rows[i]["PublisherName"].ToString();
                    windowsDevAccounts.PusherUser = pusherUserTable.Rows[i]["PusherUser"].ToString();
                    windowsDevAccounts.State = pusherUserTable.Rows[i]["State"].ToString();
                }

                return windowsDevAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
