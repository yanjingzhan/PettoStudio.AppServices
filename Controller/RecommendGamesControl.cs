using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.RecommendGames;
using Utility;
using DataBaseLib;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Controller
{
    public class RecommendGamesControl
    {
        public void AddGames(GameModel gameModel)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[RecommendGames] WHERE [GameID] = '{0}' AND [SourceType] = '{1}'", gameModel.GameID, gameModel.SourceType);

                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该游戏已经存在于库中!");
                }

                string sqlCmd_MaxOrder = "SELECT MAX([ORDER]) FROM [dbo].[RecommendGames]";
                object maxOrder = SqlHelper.Instance.ExecuteScalar(sqlCmd_MaxOrder);

                int maxOrderInt = 0;
                if (sqlCmd_MaxOrder != null)
                {
                    int.TryParse(maxOrder.ToString(), out maxOrderInt);
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[RecommendGames] ([GameType],[GameName],[Version],[GameID],[PusherName],[UpdateTime],[GameDetails],[LogoPath],[SourceType],[DownloadCount],[Price],[FileSize],[Starts],[HeadImage],[Rating],[Images1],[Images2],[Images3],[Images4],[Images5],[Images6],[Images7],[Images8],[PhoneVersion],[AddTime],[Order],[IsTopmost],[RealDownCount])" +
                                              " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','0')",
                                              gameModel.GameType, gameModel.GameName, gameModel.Version, gameModel.GameID, gameModel.PusherName, gameModel.UpdateTime, gameModel.GameDetails, gameModel.LogoPath,
                                              gameModel.SourceType, gameModel.DownloadCount, gameModel.Price, gameModel.FileSize, gameModel.Starts, gameModel.HeadImage, gameModel.Rating,
                                              gameModel.Images1, gameModel.Images2, gameModel.Images3, gameModel.Images4, gameModel.Images5, gameModel.Images6, gameModel.Images7, gameModel.Images8,
                                              gameModel.PhoneVersion, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), maxOrderInt + 1, gameModel.IsTopmost);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.AddGames");
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber">从0开始</param>
        public List<GameModel> GetGameList(int getCount, int pageNumber, string phoneVersion = "")
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[RecommendGames] w1,(SELECT TOP {0} ID FROM (SELECT TOP {1} [ID], [AddTime],[Order],[IsTopmost] FROM [RecommendGames] WHERE [SourceType] != 'header' ORDER BY [IsTopmost] DESC, [Order] DESC,[AddTime] DESC, ID DESC) w ORDER BY w.[IsTopmost] ASC, w.[Order] ASC, w.[AddTime] ASC, w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.[IsTopmost] DESC, w1.[Order] DESC, w1.[AddTime] DESC, w1.ID DESC",
                                              getCount, pageNumber * getCount + getCount);

                if (!string.IsNullOrEmpty(phoneVersion))
                {
                    sqlCmd = string.Format("SELECT * FROM [dbo].[RecommendGames] w1,(SELECT TOP {0} ID FROM (SELECT TOP {1} [ID], [AddTime],[Order],[IsTopmost] FROM [RecommendGames] WHERE [SourceType] != 'header' AND [PhoneVersion] = '{2}' ORDER BY [IsTopmost] DESC, [Order] DESC,[AddTime] DESC, ID DESC) w ORDER BY  w.[IsTopmost] ASC,w.[Order] ASC, w.[AddTime] ASC, w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.[IsTopmost] DESC, w1.[Order] DESC, w1.[AddTime] DESC, w1.ID DESC",
                                              getCount, pageNumber * getCount + getCount, phoneVersion);
                }

                DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (table == null || table.Rows.Count == 0)
                {
                    return null;
                }

                List<GameModel> result = new List<GameModel>();

                int order_t = -1;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    GameModel r_t = new GameModel
                    {
                        DownloadCount = table.Rows[i]["DownloadCount"].ToString(),
                        FileSize = table.Rows[i]["FileSize"].ToString(),
                        GameDetails = table.Rows[i]["GameDetails"].ToString(),
                        GameID = table.Rows[i]["GameID"].ToString(),
                        GameName = table.Rows[i]["GameName"].ToString(),
                        GameType = table.Rows[i]["GameType"].ToString(),
                        HeadImage = table.Rows[i]["HeadImage"].ToString(),
                        Images1 = table.Rows[i]["Images1"].ToString(),
                        Images2 = table.Rows[i]["Images2"].ToString(),
                        Images3 = table.Rows[i]["Images3"].ToString(),
                        Images4 = table.Rows[i]["Images4"].ToString(),
                        Images5 = table.Rows[i]["Images5"].ToString(),
                        Images6 = table.Rows[i]["Images6"].ToString(),
                        Images7 = table.Rows[i]["Images7"].ToString(),
                        Images8 = table.Rows[i]["Images8"].ToString(),
                        LogoPath = table.Rows[i]["LogoPath"].ToString(),
                        PhoneVersion = table.Rows[i]["PhoneVersion"].ToString(),
                        Price = table.Rows[i]["Price"].ToString(),
                        PusherName = table.Rows[i]["PusherName"].ToString(),
                        Rating = table.Rows[i]["Rating"].ToString(),
                        SourceType = table.Rows[i]["SourceType"].ToString(),
                        Starts = table.Rows[i]["Starts"].ToString(),
                        UpdateTime = ((DateTime)table.Rows[i]["UpdateTime"]).ToString("yyyy-MM-dd"),
                        Version = table.Rows[i]["Version"].ToString(),
                        ID = table.Rows[i]["ID"].ToString(),
                        Order = int.TryParse(table.Rows[i]["Order"].ToString(), out order_t) ? order_t : order_t,
                        IsTopmost = (bool)table.Rows[i]["IsTopmost"],
                        RealDownCount = (int)table.Rows[i]["RealDownCount"],
                    };

                    result.Add(r_t);
                }

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber">从0开始</param>
        public List<GameModel> GetHeaderGameList(int getCount, string phoneVersion = "")
        {
            try
            {
                string sqlCmd = string.Format("SELECT Top {0} * FROM [dbo].[RecommendGames] WHERE [SourceType] = 'header' ORDER BY [AddTime] DESC",
                                              getCount);

                if (!string.IsNullOrEmpty(phoneVersion))
                {
                    sqlCmd = string.Format("SELECT Top {0} * FROM [dbo].[RecommendGames] WHERE [SourceType] = 'header' AND [PhoneVersion] = '{1}' ORDER BY [AddTime] DESC",
                                              getCount, phoneVersion);
                }


                DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (table == null || table.Rows.Count == 0)
                {
                    return null;
                }

                List<GameModel> result = new List<GameModel>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    GameModel r_t = new GameModel
                    {
                        DownloadCount = table.Rows[i]["DownloadCount"].ToString(),
                        FileSize = table.Rows[i]["FileSize"].ToString(),
                        GameDetails = table.Rows[i]["GameDetails"].ToString(),
                        GameID = table.Rows[i]["GameID"].ToString(),
                        GameName = table.Rows[i]["GameName"].ToString(),
                        GameType = table.Rows[i]["GameType"].ToString(),
                        HeadImage = table.Rows[i]["HeadImage"].ToString(),
                        Images1 = table.Rows[i]["Images1"].ToString(),
                        Images2 = table.Rows[i]["Images2"].ToString(),
                        Images3 = table.Rows[i]["Images3"].ToString(),
                        Images4 = table.Rows[i]["Images4"].ToString(),
                        Images5 = table.Rows[i]["Images5"].ToString(),
                        Images6 = table.Rows[i]["Images6"].ToString(),
                        Images7 = table.Rows[i]["Images7"].ToString(),
                        Images8 = table.Rows[i]["Images8"].ToString(),
                        LogoPath = table.Rows[i]["LogoPath"].ToString(),
                        PhoneVersion = table.Rows[i]["PhoneVersion"].ToString(),
                        Price = table.Rows[i]["Price"].ToString(),
                        PusherName = table.Rows[i]["PusherName"].ToString(),
                        Rating = table.Rows[i]["Rating"].ToString(),
                        SourceType = table.Rows[i]["SourceType"].ToString(),
                        Starts = table.Rows[i]["Starts"].ToString(),
                        UpdateTime = ((DateTime)table.Rows[i]["UpdateTime"]).ToString("yyyy-MM-dd"),
                        Version = table.Rows[i]["Version"].ToString(),
                        ID = table.Rows[i]["ID"].ToString(),
                        IsTopmost = (bool)table.Rows[i]["IsTopmost"],
                        RealDownCount = (int)table.Rows[i]["RealDownCount"],
                    };

                    result.Add(r_t);
                }

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public void UpdateGameById(GameModel gameModel)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE　[dbo].[RecommendGames]　SET [GameType] = '{0}',[GameName] = '{1}',[Version] = '{2}',[GameID] = '{3}',[PusherName] = '{4}',[UpdateTime] = '{5}',"
                    + "[GameDetails] = '{6}',[LogoPath] = '{7}',[SourceType] = '{8}',[DownloadCount] = '{9}',[Price] = '{10}',[FileSize] = '{11}',[Starts] = '{12}',[HeadImage] = '{13}',[Rating] = '{14}',"
                    + "[Images1] = '{15}',[Images2] = '{16}',[Images3] = '{17}',[Images4] = '{18}',[Images5] = '{19}',[Images6] = '{20}',[Images7] = '{21}',[Images8] = '{22}',[PhoneVersion] = '{23}' WHERE [ID]= '{24}'",
                    gameModel.GameType, gameModel.GameName, gameModel.Version, gameModel.GameID, gameModel.PusherName, gameModel.UpdateTime,
                    gameModel.GameDetails, gameModel.LogoPath, gameModel.SourceType, gameModel.DownloadCount, gameModel.Price, gameModel.FileSize, gameModel.Starts, gameModel.HeadImage, gameModel.Rating,
                    gameModel.Images1, gameModel.Images2, gameModel.Images3, gameModel.Images4, gameModel.Images5, gameModel.Images6, gameModel.Images7, gameModel.Images8, gameModel.PhoneVersion, gameModel.ID);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {

                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.UpdateGameById");
                throw ex;
            }
        }

        public void AddDownloadCountById(int id)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[RecommendGames] SET [DownloadCount] = [DownloadCount] + 1,[RealDownCount] = [RealDownCount] + 1 WHERE [ID] = '{0}'", id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {

                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.AddDownloadCountById");
            }
        }

        public void AddNews(NewsInfoForJson newsInfoForJson)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[NewsInfoForJson] WHERE [befrom] = '{0}' ", newsInfoForJson.befrom);

                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该新闻已经存在于库中!");
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[NewsInfoForJson] ([Titlepic],[Title],[NewsForm],[NewsTime],[Onclick],[ClassName],[Filename],[Classid],[IsHearder],[newstext],[befrom],[isbottom],[AddTime])" +
                                              " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                                             newsInfoForJson.Titlepic, newsInfoForJson.Title, newsInfoForJson.NewsForm, newsInfoForJson.NewsTime, newsInfoForJson.Onclick, newsInfoForJson.ClassName, newsInfoForJson.Filename, newsInfoForJson.Classid,
                                             newsInfoForJson.IsHearder, newsInfoForJson.newstext, newsInfoForJson.befrom, newsInfoForJson.isbottom, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.AddNews");
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getCount"></param>
        /// <param name="pageNumber"></param>
        /// <param name="newsForm">新闻或者评测</param>
        /// <returns></returns>
        public List<NewsInfoForJson> GetNewsInfoForJsonList(int getCount, int pageNumber, string newsForm)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[NewsInfoForJson] w1,(SELECT TOP {0} ID FROM (SELECT TOP {1} [ID], [NewsTime] FROM [NewsInfoForJson] WHERE [NewsForm] = '{2}' ORDER BY [NewsTime] DESC, ID DESC) w ORDER BY w.[NewsTime] ASC, w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.[NewsTime] DESC, w1.ID DESC",
                                              getCount, pageNumber * getCount + getCount, newsForm);

                DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (table == null || table.Rows.Count == 0)
                {
                    return null;
                }

                List<NewsInfoForJson> result = new List<NewsInfoForJson>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    NewsInfoForJson r_t = new NewsInfoForJson
                    {
                        befrom = table.Rows[i]["befrom"].ToString(),
                        Classid = table.Rows[i]["Classid"].ToString(),
                        ClassName = table.Rows[i]["ClassName"].ToString(),
                        Filename = table.Rows[i]["Filename"].ToString(),
                        Id = table.Rows[i]["Id"].ToString(),
                        IsHearder = table.Rows[i]["IsHearder"].ToString(),
                        NewsForm = table.Rows[i]["NewsForm"].ToString(),
                        newstext = table.Rows[i]["newstext"].ToString(),
                        NewsTime = table.Rows[i]["NewsTime"].ToString(),
                        Onclick = table.Rows[i]["Onclick"].ToString(),
                        Title = table.Rows[i]["Title"].ToString(),
                        Titlepic = table.Rows[i]["Titlepic"].ToString()
                    };

                    result.Add(r_t);
                }

                return result;

            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.GetNewsInfoForJsonList");

                return null;
            }
        }

        public void UpdateNewsById(NewsInfoForJson newsInfoForJson)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE　[dbo].[NewsInfoForJson]　SET [Titlepic] = '{0}',[Title] = '{1}',[NewsForm] = '{2}',[NewsTime] = '{3}',[Onclick] = '{4}',[ClassName] = '{5}',"
                    + "[Filename] = '{6}',[Classid] = '{7}',[IsHearder] = '{8}',[befrom] = '{9}',[isbottom] = '{10}' WHERE [ID]= '{11}'",
                    newsInfoForJson.Titlepic, newsInfoForJson.Title, newsInfoForJson.NewsForm, newsInfoForJson.NewsTime, newsInfoForJson.Onclick, newsInfoForJson.ClassName, newsInfoForJson.Filename, newsInfoForJson.Classid,
                    newsInfoForJson.IsHearder, newsInfoForJson.befrom, newsInfoForJson.isbottom, newsInfoForJson.Id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {

                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.UpdateNewsById");
                throw ex;
            }
        }

        public void AddNewsClickCountById(int id)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[NewsInfoForJson] SET [Onclick] = [Onclick] + 1 WHERE [ID] = '{0}'", id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {

                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.AddNewsClickCountById");
                throw ex;
            }
        }


        public void UpdateOrderForGame(List<GameModel> gameList_t)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.Instance.ConnectionString))
                {
                    conn.Open();
                    foreach (var item in gameList_t)
                    {
                        string command = string.Format("UPDATE [dbo].[RecommendGames] SET [Order] = '{0}',[IsTopmost] = '{1}' WHERE [ID] = '{2}'", item.Order, item.IsTopmost, item.ID);
                        using (SqlCommand cmd = new SqlCommand(command, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "RecommendGamesControl.UpdateOrderForGame");
                throw ex;
            }
        }
    }
}
