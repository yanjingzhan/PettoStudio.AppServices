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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, gamename, version, state, gameid, pushername, surfaceaccountid, surfaceadid,
                    googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime, updatetime, devaccount, devpassword, count,
                    password, role;

                string id, gamedetails, logopath, backimagepath, sourcetype, filename,
                       newstate, jpstate, newjpstate, gameState, devPusher, account, adname, realdevaccount, realdevpassword;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                gamename = Request["gamename"] == null ? "" : Request["gamename"].Trim();
                version = Request["version"] == null ? "" : Request["version"].Trim();
                state = Request["state"] == null ? "" : Request["state"].Trim();
                gameid = Request["gameid"] == null ? "" : Request["gameid"].Trim();
                pushername = Request["pushername"] == null ? "" : Request["pushername"].Trim();
                surfaceaccountid = Request["surfaceaccountid"] == null ? "" : Request["surfaceaccountid"].Trim();
                surfaceadid = Request["surfaceadid"] == null ? "" : Request["surfaceadid"].Trim();
                googlebanner = Request["googlebanner"] == null ? "" : Request["googlebanner"].Trim();
                googlechaping = Request["googlechaping"] == null ? "" : Request["googlechaping"].Trim();
                pubcenterappid = Request["pubcenterappid"] == null ? "" : Request["pubcenterappid"].Trim();
                pubcenteradid = Request["pubcenteradid"] == null ? "" : Request["pubcenteradid"].Trim();
                addtime = Request["addtime"] == null ? "" : Request["addtime"].Trim();
                updatetime = Request["updatetime"] == null ? "" : Request["updatetime"].Trim();
                devaccount = Request["devaccount"] == null ? "" : Request["devaccount"].Trim();
                devpassword = Request["devpassword"] == null ? "" : Request["devpassword"].Trim();
                count = Request["count"] == null ? "" : Request["count"].Trim();
                password = Request["password"] == null ? "" : Request["password"].Trim();
                role = Request["role"] == null ? "" : Request["role"].Trim();

                id = Request["id"] == null ? "" : Request["id"].Trim();
                gamedetails = Request["gamedetails"] == null ? "" : Request["gamedetails"].Trim();
                logopath = Request["logopath"] == null ? "" : Request["logopath"].Trim();
                backimagepath = Request["backimagepath"] == null ? "" : Request["backimagepath"].Trim();
                sourcetype = Request["sourcetype"] == null ? "" : Request["sourcetype"].Trim();
                filename = Request["filename"] == null ? "" : Request["filename"].Trim();
                newstate = Request["newstate"] == null ? "" : Request["newstate"].Trim();
                jpstate = Request["jpstate"] == null ? "" : Request["jpstate"].Trim();
                newjpstate = Request["newjpstate"] == null ? "" : Request["newjpstate"].Trim();

                gameState = Request["gamestate"] == null ? "" : Request["gamestate"].Trim();
                devPusher = Request["devpusher"] == null ? "" : Request["devpusher"].Trim();
                account = Request["account"] == null ? "" : Request["account"].Trim();
                adname = Request["adname"] == null ? "" : Request["adname"].Trim();
                realdevaccount = Request["realdevaccount"] == null ? "" : Request["realdevaccount"].Trim();
                realdevpassword = Request["realdevpassword"] == null ? "" : Request["realdevpassword"].Trim();

                switch (action.ToLower())
                {
                    case "addpushgameinfo":
                        AddPushGameInfo(gamename, version, state, gameid, pushername, surfaceaccountid, surfaceadid,
                                googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime, updatetime, devaccount, devpassword, gamedetails,
                                logopath, backimagepath, sourcetype, filename);
                        break;

                    case "getpushgameinfomodellistbycount":
                        GetPushGameInfoModelListByCount(gamename, version, state, gameid, pushername, surfaceaccountid, surfaceadid,
                                googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime, updatetime, devaccount, devpassword,
                                id, gamedetails, logopath, backimagepath, sourcetype, filename, count);
                        break;

                    case "updatepushgameinfo":
                        UpdatePushGameInfo(gamename, version, state, gameid, pushername, surfaceaccountid, surfaceadid,
                                googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime, updatetime, devaccount, devpassword,
                                id, gamedetails, logopath, backimagepath, sourcetype, filename);
                        break;

                    case "getuserlistbycount":
                        GetUserListByCount(pushername, role, password, count);
                        break;

                    case "addpusheruser":
                        AddPusherUser(pushername, role, password);
                        break;

                    case "updatepusheruser":
                        UpdatePusherUser(pushername, role, password);
                        break;

                    case "deletegameinfobynameandversion":
                        DeleteGameInfoByNameAndVersion(gamename, version);
                        break;

                    case "deletepusheruser":
                        DeletePusherUser(pushername);
                        break;

                    case "getnogamedetailsgamelist":
                        GetNoGameDetailsGameList();
                        break;

                    case "updatepushgameinfobyid":
                        UpdatePushGameInfoByID(gamename, version, state, gameid, pushername, surfaceaccountid, surfaceadid,
                                googlebanner, googlechaping, pubcenterappid, pubcenteradid, addtime, updatetime, devaccount, devpassword,
                                id, gamedetails, logopath, backimagepath, sourcetype, filename, adname, realdevaccount, realdevpassword);
                        break;

                    case "getonegameinfobystaterandom":
                        GetOneGameInfoByStateRandom(jpstate, newjpstate);
                        break;

                    case "updatejpstate":
                        UpdateJpState(jpstate, id);
                        break;

                    case "getwords":
                        GetWords();
                        break;

                    case "getonegameinfobyrealstaterandom":
                        GetOneGameInfoByRealStateRandom(state, newstate, devPusher);
                        break;

                    case "getwindowsdevaccountsbygamestate":
                        GetWindowsDevAccountsByGameState(gameState);
                        break;

                    case "getkeywords":
                        GetKeywords(count);
                        break;

                    case "getdevaccountbyaccountname":
                        GetDevAccountByAccountName(account);
                        break;

                    case "getonegameinfoandchangestaterandom":
                        GetOneGameInfoAndChangeStateRandom(state, newstate);
                        break;

                    case "getonegameinfoandchangestaterandomfordev":
                        GetOneGameInfoAndChangeStateRandomForDev(state, newstate);
                        break;

                    case "devsuccessedbydreamspark":
                        DevSuccessedByDreamSpark(id, realdevaccount, realdevpassword);
                        break;

                    #region Amazon

                    case "getonegameinfoandchangestaterandomfordevamazon":
                        GetOneGameInfoAndChangeStateRandomForDevAmazon(state, newstate);
                        break;

                    case "inputinfosuccessedbydreamsparkamazon":
                        InputInfoSuccessedByDreamSparkAmazon(id, realdevaccount, realdevpassword);
                        break;

                    #endregion

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }

            }
        }

        #region Amazon

        private void GetOneGameInfoAndChangeStateRandomForDevAmazon(string state, string newstate)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetOneGameInfoAndChangeStateRandomForDevAmazon(state, newstate));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void InputInfoSuccessedByDreamSparkAmazon(string id, string realDevAccount, string realDevPassword)
        {
            try
            {
                new PushGameInfoControl().InputInfoSuccessedByDreamSparkAmazon(id, realDevAccount, realDevPassword, Page.Request.ServerVariables["REMOTE_ADDR"].ToString());

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        #endregion

        #region 2.0

        private void GetOneGameInfoAndChangeStateRandom(string state, string newstate)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetOneGameInfoAndChangeStateRandom(state, newstate));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void GetOneGameInfoAndChangeStateRandomForDev(string state, string newstate)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetOneGameInfoAndChangeStateRandomForDev(state, newstate));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void DevSuccessedByDreamSpark(string id, string realDevAccount, string realDevPassword)
        {
            try
            {
                new PushGameInfoControl().DevSuccessedByDreamSpark(id, realDevAccount, realDevPassword, Page.Request.ServerVariables["REMOTE_ADDR"].ToString());

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        #endregion

        private void GetDevAccountByAccountName(string account)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetDevAccountByAccountName(account));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }


        private void GetWindowsDevAccountsByGameState(string gameState)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetWindowsDevAccountsByGameState(gameState));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void GetWords()
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetWords());

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void UpdateJpState(string jpState, string id)
        {
            try
            {
                new PushGameInfoControl().UpdateJpState(jpState, id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }


        private void DeletePusherUser(string pusherName)
        {
            try
            {
                new PushGameInfoControl().DeletePusherUser(pusherName);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void DeleteGameInfoByNameAndVersion(string gamename, string version)
        {
            try
            {
                new PushGameInfoControl().DeleteGameInfoByNameAndVersion(gamename, version);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void UpdatePusherUser(string name, string role, string password)
        {
            try
            {
                PusherUserModel pusherUserModel = new PusherUserModel
                {
                    Name = name,
                    Role = role,
                    Password = password
                };

                new PushGameInfoControl().UpdatePusherUser(pusherUserModel);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void AddPusherUser(string name, string role, string password)
        {
            try
            {
                PusherUserModel pusherUserModel = new PusherUserModel
                {
                    Name = name,
                    Role = role,
                    Password = password
                };

                new PushGameInfoControl().AddPusherUser(pusherUserModel);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void GetUserListByCount(string name, string role, string password, string count)
        {
            try
            {
                PusherUserModel pusherUserModel = new PusherUserModel
                {
                    Name = name,
                    Role = role,
                    Password = password
                };

                string result = JsonHelper.SerializerToJson(
                        new PushGameInfoControl().GetUserListByCount(pusherUserModel, int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void UpdatePushGameInfo(string gamename, string version, string state, string gameid,
                                                    string pushername, string surfaceaccountid, string surfaceadid,
                                                    string googlebanner, string googlechaping, string pubcenterappid,
                                                    string pubcenteradid, string addtime, string updatetime, string devaccount,
                                                    string devpassword, string id, string gameDetails, string logoPath, string backImagePath, string sourceType, string filename)
        {
            try
            {
                PushGameInfoModel pushGameInfoModel = new PushGameInfoModel
                {
                    AddTime = addtime,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PubcenterAdID = pubcenteradid,
                    PubcenterAppID = pubcenterappid,
                    PusherName = pushername,
                    State = state,
                    SurfaceAccountID = surfaceaccountid,
                    SurfaceAdID = surfaceadid,
                    UpdateTime = updatetime,
                    Version = version,
                    ID = id,
                    GameDetails = gameDetails,
                    BackImagePath = backImagePath,
                    LogoPath = logoPath,
                    SourceType = sourceType,
                    FileName = filename
                };

                new PushGameInfoControl().UpdatePushGameInfo(pushGameInfoModel);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void UpdatePushGameInfoByID(string gamename, string version, string state, string gameid,
                                            string pushername, string surfaceaccountid, string surfaceadid,
                                            string googlebanner, string googlechaping, string pubcenterappid,
                                            string pubcenteradid, string addtime, string updatetime, string devaccount,
                                            string devpassword, string id, string gameDetails, string logoPath,
                                            string backImagePath, string sourceType, string filename, string adname,
                                            string realDevAccount, string realDevPassword)
        {
            try
            {
                PushGameInfoModel pushGameInfoModel = new PushGameInfoModel
                {
                    AddTime = addtime,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PubcenterAdID = pubcenteradid,
                    PubcenterAppID = pubcenterappid,
                    PusherName = pushername,
                    State = state,
                    SurfaceAccountID = surfaceaccountid,
                    SurfaceAdID = surfaceadid,
                    UpdateTime = updatetime,
                    Version = version,
                    ID = id,
                    GameDetails = gameDetails,
                    BackImagePath = backImagePath,
                    LogoPath = logoPath,
                    SourceType = sourceType,
                    FileName = filename,
                    AdName = adname,
                    RealDevAccount = realDevAccount,
                    RealDevPassword = realDevPassword
                };

                new PushGameInfoControl().UpdatePushGameInfoByID(pushGameInfoModel);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void AddPushGameInfo(string gamename, string version, string state, string gameid,
                                                    string pushername, string surfaceaccountid, string surfaceadid,
                                                    string googlebanner, string googlechaping, string pubcenterappid,
                                                    string pubcenteradid, string addtime, string updatetime, string devaccount,
                                                    string devpassword, string gameDetails, string logoPath, string backImagePath, string sourceType, string filename)
        {
            try
            {
                PushGameInfoModel pushGameInfoModel = new PushGameInfoModel
                {
                    AddTime = addtime,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PubcenterAdID = pubcenteradid,
                    PubcenterAppID = pubcenterappid,
                    PusherName = pushername,
                    State = state,
                    SurfaceAccountID = surfaceaccountid,
                    SurfaceAdID = surfaceadid,
                    UpdateTime = updatetime,
                    Version = version,
                    BackImagePath = backImagePath,
                    GameDetails = gameDetails,
                    LogoPath = logoPath,
                    SourceType = sourceType,
                    FileName = filename
                };

                new PushGameInfoControl().AddPushGameInfo(pushGameInfoModel);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void GetPushGameInfoModelListByCount(string gamename, string version, string state, string gameid,
                                                    string pushername, string surfaceaccountid, string surfaceadid,
                                                    string googlebanner, string googlechaping, string pubcenterappid,
                                                    string pubcenteradid, string addtime, string updatetime, string devaccount,
                                                    string devpassword, string id, string gameDetails, string logoPath, string backImagePath, string sourceType, string filename, string count)
        {
            try
            {
                PushGameInfoModel pushGameInfoModel = new PushGameInfoModel
                {
                    AddTime = addtime,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    GameID = gameid,
                    GameName = gamename,
                    GoogleBanner = googlebanner,
                    GoogleChaping = googlechaping,
                    PubcenterAdID = pubcenteradid,
                    PubcenterAppID = pubcenterappid,
                    PusherName = pushername,
                    State = state,
                    SurfaceAccountID = surfaceaccountid,
                    SurfaceAdID = surfaceadid,
                    UpdateTime = updatetime,
                    Version = version,
                    FileName = filename,
                    GameDetails = gameDetails,
                    BackImagePath = backImagePath,
                    ID = id,
                    LogoPath = logoPath,
                    SourceType = sourceType
                };

                string result = JsonHelper.SerializerToJson(
                    new PushGameInfoControl().GetPushGameInfoModelListByCount(pushGameInfoModel, int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void GetNoGameDetailsGameList()
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                      new PushGameInfoControl().GetNoGameDetailsGameList());

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void GetOneGameInfoByStateRandom(string jpstate, string newjpState)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                      new PushGameInfoControl().GetOneGameInfoByStateRandom(jpstate, newjpState));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void GetOneGameInfoByRealStateRandom(string state, string newState, string devPusher)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                      new PushGameInfoControl().GetOneGameInfoByRealStateRandom(state, newState, devPusher));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        public void GetKeywords(string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                      new PushGameInfoControl().GetKeywords(int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }


    }


}