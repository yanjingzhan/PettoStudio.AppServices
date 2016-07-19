using Controller;
using Models.RecommendGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace RecommendGamesServices
{
    public partial class RecommendGames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, gametype, gamename, version, gameid, pushername,
                    updatetime, gamedetails, logopath,
                    sourcetype, downloadcount, price, filesize, starts, headimage, rating,
                    images1, images2, images3, images4,
                    images5, images6, images7, images8, phoneversion;

                string id, titlepic, title, newsform, newstime, onclick, classname, filename, classid, ishearder, newstext, befrom, isbottom;

                string getcount, pagenumber;
                string gameListJson;

                string timeAuth, cryptStr;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                gametype = Request["gametype"] == null ? "" : Request["gametype"].Trim();
                gamename = Request["gamename"] == null ? "" : Request["gamename"].Trim();
                version = Request["version"] == null ? "" : Request["version"].Trim();
                gameid = Request["gameid"] == null ? "" : Request["gameid"].Trim();
                pushername = Request["pushername"] == null ? "" : Request["pushername"].Trim();
                updatetime = Request["updatetime"] == null ? "" : Request["updatetime"].Trim();
                gamedetails = Request["gamedetails"] == null ? "" : Request["gamedetails"].Trim();
                logopath = Request["logopath"] == null ? "" : Request["logopath"].Trim();
                sourcetype = Request["sourcetype"] == null ? "" : Request["sourcetype"].Trim();
                downloadcount = Request["downloadcount"] == null ? "" : Request["downloadcount"].Trim();
                price = Request["price"] == null ? "" : Request["price"].Trim();
                filesize = Request["filesize"] == null ? "" : Request["filesize"].Trim();
                starts = Request["starts"] == null ? "" : Request["starts"].Trim();
                headimage = Request["headimage"] == null ? "" : Request["headimage"].Trim();
                rating = Request["rating"] == null ? "" : Request["rating"].Trim();
                images1 = Request["images1"] == null ? "" : Request["images1"].Trim();
                images2 = Request["images2"] == null ? "" : Request["images2"].Trim();
                images3 = Request["images3"] == null ? "" : Request["images3"].Trim();
                images4 = Request["images4"] == null ? "" : Request["images4"].Trim();
                images5 = Request["images5"] == null ? "" : Request["images5"].Trim();
                images6 = Request["images6"] == null ? "" : Request["images6"].Trim();
                images7 = Request["images7"] == null ? "" : Request["images7"].Trim();
                images8 = Request["images8"] == null ? "" : Request["images8"].Trim();
                phoneversion = Request["phoneversion"] == null ? "" : Request["phoneversion"].Trim();


                id = Request["id"] == null ? "" : Request["id"].Trim();
                titlepic = Request["titlepic"] == null ? "" : Request["titlepic"].Trim();
                title = Request["title"] == null ? "" : Request["title"].Trim();
                newsform = Request["newsform"] == null ? "" : Request["newsform"].Trim();
                newstime = Request["newstime"] == null ? "" : Request["newstime"].Trim();
                onclick = Request["onclick"] == null ? "" : Request["onclick"].Trim();
                classname = Request["classname"] == null ? "" : Request["classname"].Trim();
                filename = Request["filename"] == null ? "" : Request["filename"].Trim();
                classid = Request["classid"] == null ? "" : Request["classid"].Trim();
                ishearder = Request["ishearder"] == null ? "" : Request["ishearder"].Trim();
                newstext = Request["newstext"] == null ? "" : Request["newstext"].Trim();
                befrom = Request["befrom"] == null ? "" : Request["befrom"].Trim();
                isbottom = Request["isbottom"] == null ? "" : Request["isbottom"].Trim();

                getcount = Request["getcount"] == null ? "" : Request["getcount"].Trim();
                pagenumber = Request["pagenumber"] == null ? "" : Request["pagenumber"].Trim();

                gameListJson = Request["gamelistjson"] == null ? "" : Request["gamelistjson"].Trim();

                timeAuth = Request["rd"] == null ? "" : Request["rd"].Trim();
                cryptStr = Request["auth"] == null ? "" : Request["auth"].Trim();

                if(!IsAuthSuccess(action,timeAuth,cryptStr))
                {
                    Response.Write("Server ERROR!");
                    return;
                }

                switch (action.ToLower())
                {

                    case "addgames":
                        AddGames(gametype, gamename, version, gameid, pushername,
                                updatetime, gamedetails, logopath, sourcetype, downloadcount,
                                price, filesize, starts, headimage, rating,
                                images1, images2, images3, images4,
                                images5, images6, images7, images8, phoneversion);
                        break;

                    case "getgamelist":
                        GetGameList(getcount, pagenumber);
                        break;

                    case "getheadergamelist":
                        GetHeaderGameList(getcount);
                        break;

                    case "updategamebyid":
                        UpdateGameById(id, gametype, gamename, version, gameid, pushername,
                             updatetime, gamedetails, logopath, sourcetype, downloadcount,
                             price, filesize, starts, headimage, rating,
                             images1, images2, images3, images4,
                             images5, images6, images7, images8, phoneversion);
                        break;

                    case "adddownloadcountbyid":
                        AddDownloadCountById(id);
                        break;

                    case "addnews":
                        AddNews(titlepic, title, newsform, newstime, onclick, classname, filename,
                                 classid, ishearder, newstext, befrom, isbottom);
                        break;

                    case "getnewsinfoforjsonlist":
                        GetNewsInfoForJsonList(getcount, pagenumber, newsform);
                        break;

                    case "updatenewsbyid":
                        UpdateNewsById(id, titlepic, title, newsform, newstime, onclick, classname, filename,
                                        classid, ishearder, newstext, befrom, isbottom);
                        break;

                    case "addnewsclickcountbyid":
                        AddNewsClickCountById(id);
                        break;

                    case "updateorderforgame":
                        UpdateOrderForGame(gameListJson);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        public void AddGames(string gametype, string gamename, string version, string gameid, string pushername,
                            string updatetime, string gamedetails, string logopath, string sourcetype, string downloadcount,
                            string price, string filesize, string starts, string headimage, string rating,
                            string images1, string images2, string images3, string images4,
                            string images5, string images6, string images7, string images8, string phoneversion)
        {

            try
            {
                new RecommendGamesControl().AddGames(new Models.RecommendGames.GameModel
                    {
                        DownloadCount = string.IsNullOrEmpty(downloadcount) ? "0" : downloadcount,
                        FileSize = filesize,
                        GameDetails = HttpUtility.UrlEncode(gamedetails),
                        GameID = gameid,
                        GameName = HttpUtility.UrlEncode(gamename),
                        GameType = HttpUtility.UrlEncode(gametype),
                        HeadImage = HttpUtility.UrlEncode(headimage),
                        Images1 = HttpUtility.UrlEncode(images1),
                        Images2 = HttpUtility.UrlEncode(images2),
                        Images3 = HttpUtility.UrlEncode(images3),
                        Images4 = HttpUtility.UrlEncode(images4),
                        Images5 = HttpUtility.UrlEncode(images5),
                        Images6 = HttpUtility.UrlEncode(images6),
                        Images7 = HttpUtility.UrlEncode(images7),
                        Images8 = HttpUtility.UrlEncode(images8),
                        LogoPath = HttpUtility.UrlEncode(logopath),
                        PhoneVersion = phoneversion,
                        Price = price,
                        PusherName = pushername,
                        Rating = rating,
                        SourceType = sourcetype,
                        Starts = starts,
                        UpdateTime = updatetime,
                        Version = version
                    });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AddGames");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AddGames");
            }
        }

        public void GetGameList(string getCount, string pageNumber)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new RecommendGamesControl().GetGameList(int.Parse(getCount), int.Parse(pageNumber)));

                Response.Write(Encryption.Encrypt(result));
                LogWriter.WriteLog(result, Page, "GetGameList");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetGameList");
            }
        }

        public void GetHeaderGameList(string getCount)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new RecommendGamesControl().GetHeaderGameList(int.Parse(getCount)));

                Response.Write(Encryption.Encrypt(result));
                LogWriter.WriteLog(result, Page, "GetHeaderGameList");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetHeaderGameList");
            }
        }

        public void UpdateGameById(string id, string gametype, string gamename, string version, string gameid, string pushername,
                            string updatetime, string gamedetails, string logopath, string sourcetype, string downloadcount,
                            string price, string filesize, string starts, string headimage, string rating,
                            string images1, string images2, string images3, string images4,
                            string images5, string images6, string images7, string images8, string phoneversion)
        {

            try
            {
                new RecommendGamesControl().UpdateGameById(new Models.RecommendGames.GameModel
                    {
                        DownloadCount = downloadcount,
                        FileSize = filesize,
                        GameDetails = HttpUtility.UrlEncode(gamedetails),
                        GameID = gameid,
                        GameName = gamename,
                        GameType = HttpUtility.UrlEncode(gametype),
                        HeadImage = HttpUtility.UrlEncode(headimage),
                        Images1 = HttpUtility.UrlEncode(images1),
                        Images2 = HttpUtility.UrlEncode(images2),
                        Images3 = HttpUtility.UrlEncode(images3),
                        Images4 = HttpUtility.UrlEncode(images4),
                        Images5 = HttpUtility.UrlEncode(images5),
                        Images6 = HttpUtility.UrlEncode(images6),
                        Images7 = HttpUtility.UrlEncode(images7),
                        Images8 = HttpUtility.UrlEncode(images8),
                        LogoPath = HttpUtility.UrlEncode(logopath),
                        PhoneVersion = phoneversion,
                        Price = price,
                        PusherName = pushername,
                        Rating = rating,
                        SourceType = sourcetype,
                        Starts = starts,
                        UpdateTime = updatetime,
                        Version = version,
                        ID = id
                    });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateGameById");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateGameById");
            }
        }

        public void AddDownloadCountById(string id)
        {
            try
            {
                new RecommendGamesControl().AddDownloadCountById(int.Parse(id));

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AddDownloadCountById");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AddDownloadCountById");
            }
        }

        public void AddNews(string titlepic, string title, string newsform, string newstime, string onclick, string classname, string filename,
            string classid, string ishearder, string newstext, string befrom, string isbottom)
        {
            try
            {
                new RecommendGamesControl().AddNews(new Models.RecommendGames.NewsInfoForJson
                    {
                        befrom = HttpUtility.UrlEncode(befrom),
                        Classid = classid,
                        ClassName = classname,
                        Filename = HttpUtility.UrlEncode(filename),
                        isbottom = string.IsNullOrEmpty(isbottom) ? "0" : isbottom,
                        IsHearder = ishearder,
                        NewsForm = newsform,
                        newstext = HttpUtility.UrlEncode(newstext),
                        NewsTime = newstime,
                        Onclick = string.IsNullOrEmpty(onclick) ? "0" : onclick,
                        Title = HttpUtility.UrlEncode(title),
                        Titlepic = HttpUtility.UrlEncode(titlepic),
                    });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AddNews");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AddNews");
            }
        }

        public void GetNewsInfoForJsonList(string getCount, string pageNumber, string newsForm)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new RecommendGamesControl().GetNewsInfoForJsonList(int.Parse(getCount), int.Parse(pageNumber), newsForm));

                Response.Write(Encryption.Encrypt(result));
                LogWriter.WriteLog(result, Page, "GetNewsInfoForJsonList");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetNewsInfoForJsonList");
            }
        }

        public void UpdateNewsById(string id, string titlepic, string title, string newsform, string newstime, string onclick, string classname, string filename,
            string classid, string ishearder, string newstext, string befrom, string isbottom)
        {
            try
            {
                new RecommendGamesControl().UpdateNewsById(new Models.RecommendGames.NewsInfoForJson
                {
                    befrom = HttpUtility.UrlEncode(befrom),
                    Classid = classid,
                    ClassName = classname,
                    Filename = HttpUtility.UrlEncode(filename),
                    isbottom = string.IsNullOrEmpty(isbottom) ? "0" : isbottom,
                    IsHearder = ishearder,
                    NewsForm = newsform,
                    newstext = HttpUtility.UrlEncode(newstext),
                    NewsTime = newstime,
                    Onclick = string.IsNullOrEmpty(onclick) ? "0" : onclick,
                    Title = HttpUtility.UrlEncode(title),
                    Titlepic = HttpUtility.UrlEncode(titlepic),
                    Id = id
                });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateNewsById");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateNewsById");
            }
        }

        public void AddNewsClickCountById(string id)
        {
            try
            {
                new RecommendGamesControl().AddNewsClickCountById(int.Parse(id));

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AddNewsClickCountById");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AddNewsClickCountById");
            }
        }

        public void UpdateOrderForGame(string gameListJson)
        {
            try
            {
                List<GameModel> gameList = JsonHelper.DeserializeObjectFromJson<List<GameModel>>(gameListJson);

                new RecommendGamesControl().UpdateOrderForGame(gameList);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateOrderForGame");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateOrderForGame");
            }
        }

        private bool IsAuthSuccess(string action, string timeAuth, string crpyStr)
        {
            //LogWriter.WriteLog(action + "," + timeAuth + "," + HttpUtility.UrlDecode(Encryption.Encrypt(action + timeAuth)) + "," + crpyStr,
            //    Page, "IsAuthSuccess");
            return  HttpUtility.UrlDecode(Encryption.Encrypt(action + timeAuth)) == crpyStr;
        }
    }
}