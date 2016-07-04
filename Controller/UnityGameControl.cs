using DataBaseLib;
using Models.GameManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Controller
{
    public class UnityGameControl
    {
        public List<GameInfoEntity> GetUnityGameInfoEntityList(GameInfoEntity gameInfoEntity, int count)
        {
            try
            {
                string name = string.IsNullOrEmpty(gameInfoEntity.Name) ? "[Name]" : "'" + gameInfoEntity.Name + "'";
                string guid = string.IsNullOrEmpty(gameInfoEntity.Guid) ? "[Guid]" : "'" + gameInfoEntity.Guid + "'";
                string Version = string.IsNullOrEmpty(gameInfoEntity.Version) ? "[Version]" : "'" + gameInfoEntity.Version + "'";
                string Icon = string.IsNullOrEmpty(gameInfoEntity.Icon) ? "[Icon]" : "'" + gameInfoEntity.Icon + "'";
                string Size = string.IsNullOrEmpty(gameInfoEntity.Size) ? "[Size]" : "'" + gameInfoEntity.Size + "'";
                string Level = string.IsNullOrEmpty(gameInfoEntity.Level) ? "[Level]" : "'" + gameInfoEntity.Level + "'";
                string Url = string.IsNullOrEmpty(gameInfoEntity.Url) ? "[Url]" : "'" + gameInfoEntity.Url + "'";
                string DownloadType = string.IsNullOrEmpty(gameInfoEntity.DownloadType) ? "[DownloadType]" : "'" + gameInfoEntity.DownloadType + "'";
                string ActionType = string.IsNullOrEmpty(gameInfoEntity.ActionType) ? "[ActionType]" : "'" + gameInfoEntity.ActionType + "'";
                string Ispc = string.IsNullOrEmpty(gameInfoEntity.Ispc) ? "[Ispc]" : "'" + gameInfoEntity.Ispc + "'";
                string Iszhuanshu = string.IsNullOrEmpty(gameInfoEntity.Iszhuanshu) ? "[Iszhuanshu]" : "'" + gameInfoEntity.Iszhuanshu + "'";
                string GameProfileInfo = string.IsNullOrEmpty(gameInfoEntity.GameProfileInfo) ? "[GameProfileInfo]" : "'" + gameInfoEntity.GameProfileInfo + "'";
                string GameClassify = string.IsNullOrEmpty(gameInfoEntity.GameClassify) ? "[GameClassify]" : "'" + gameInfoEntity.GameClassify + "'";
                string GameProfileUrl = string.IsNullOrEmpty(gameInfoEntity.GameProfileUrl) ? "[GameProfileUrl]" : "'" + gameInfoEntity.GameProfileUrl + "'";
                string GameSourceType = string.IsNullOrEmpty(gameInfoEntity.GameSourceType) ? "[GameSourceType]" : "'" + gameInfoEntity.GameSourceType + "'";
                string ID = string.IsNullOrEmpty(gameInfoEntity.ID) ? "[ID]" : "'" + gameInfoEntity.ID + "'";
                string DownloadState = string.IsNullOrEmpty(gameInfoEntity.DownloadState) ? "[DownloadState]" : "'" + gameInfoEntity.DownloadState + "'";
                string OriginalName = string.IsNullOrEmpty(gameInfoEntity.OriginalName) ? "[OriginalName]" : "'" + gameInfoEntity.OriginalName + "'";
                string FileName = string.IsNullOrEmpty(gameInfoEntity.FileName) ? "[FileName]" : "'" + gameInfoEntity.FileName + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[AYYGames] WHERE " +
                                          "[ID] = {1} AND [Name] = {2} AND [Guid] = {3} AND [Icon] = {4} AND [Size] = {5} " +
                                          "AND [Level] = {6} AND [Url] = {7} AND [DownloadType] = {8} AND [ActionType] = {9} " +
                                          "AND [Ispc] = {10} AND [Iszhuanshu] = {11} AND [GameProfileInfo] = {12} AND [GameClassify] = {13} " +
                                          "AND [GameProfileUrl] = {14} AND [GameSourceType] = {15} AND [DownloadState] = {16} AND [Version] = {17} AND [OriginalName] = {18} AND [FileName] = {19}",
                                          count == 0 ? "" : "TOP " + count.ToString(),
                                          ID, name, guid, Icon, Size,
                                          Level, Url, DownloadType, ActionType,
                                          Ispc, Iszhuanshu, GameProfileInfo, GameClassify,
                                          GameProfileUrl, GameSourceType, DownloadState, Version, OriginalName, FileName);


                DataTable gameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (gameInfoTable == null || gameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<GameInfoEntity> result = new List<GameInfoEntity>();
                for (int i = 0; i < gameInfoTable.Rows.Count; i++)
                {
                    GameInfoEntity gameInfoEntity_t = new GameInfoEntity
                    {
                        ActionType = gameInfoTable.Rows[i]["ActionType"].ToString(),
                        DownloadState = gameInfoTable.Rows[i]["DownloadState"].ToString(),
                        DownloadType = gameInfoTable.Rows[i]["DownloadType"].ToString(),
                        GameClassify = gameInfoTable.Rows[i]["GameClassify"].ToString(),
                        GameProfileInfo = gameInfoTable.Rows[i]["GameProfileInfo"].ToString(),
                        GameProfileUrl = gameInfoTable.Rows[i]["GameProfileUrl"].ToString(),
                        GameSourceType = gameInfoTable.Rows[i]["GameSourceType"].ToString(),
                        Guid = gameInfoTable.Rows[i]["Guid"].ToString(),
                        Icon = gameInfoTable.Rows[i]["Icon"].ToString(),
                        ID = gameInfoTable.Rows[i]["ID"].ToString(),
                        Ispc = gameInfoTable.Rows[i]["Ispc"].ToString(),
                        Iszhuanshu = gameInfoTable.Rows[i]["Iszhuanshu"].ToString(),
                        Level = gameInfoTable.Rows[i]["Level"].ToString(),
                        Name = gameInfoTable.Rows[i]["Name"].ToString(),
                        Size = gameInfoTable.Rows[i]["Size"].ToString(),
                        Url = gameInfoTable.Rows[i]["Url"].ToString(),
                        Version = gameInfoTable.Rows[i]["Version"].ToString(),
                        NumSize = string.IsNullOrEmpty(gameInfoTable.Rows[0]["NumSize"].ToString()) ? -1.0f : float.Parse(gameInfoTable.Rows[0]["NumSize"].ToString()),
                        FileName = gameInfoTable.Rows[i]["FileName"].ToString(),
                        OriginalName = gameInfoTable.Rows[i]["OriginalName"].ToString(),
                    };

                    result.Add(gameInfoEntity_t);
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<GameInfoEntity> GetUnityGameInfoEntityListByDownload(string downloadType, string downloadState, int count)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[AYYGames] WHERE [DownloadType] = '{1}' AND [DownloadState] = '{2}'", count, downloadType, downloadState);
                DataTable gameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (gameInfoTable == null || gameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<GameInfoEntity> result = new List<GameInfoEntity>();
                for (int i = 0; i < gameInfoTable.Rows.Count; i++)
                {
                    GameInfoEntity gameInfoEntity_t = new GameInfoEntity
                    {
                        ActionType = gameInfoTable.Rows[i]["ActionType"].ToString(),
                        DownloadState = gameInfoTable.Rows[i]["DownloadState"].ToString(),
                        DownloadType = gameInfoTable.Rows[i]["DownloadType"].ToString(),
                        GameClassify = gameInfoTable.Rows[i]["GameClassify"].ToString(),
                        GameProfileInfo = gameInfoTable.Rows[i]["GameProfileInfo"].ToString(),
                        GameProfileUrl = gameInfoTable.Rows[i]["GameProfileUrl"].ToString(),
                        GameSourceType = gameInfoTable.Rows[i]["GameSourceType"].ToString(),
                        Guid = gameInfoTable.Rows[i]["Guid"].ToString(),
                        Icon = gameInfoTable.Rows[i]["Icon"].ToString(),
                        ID = gameInfoTable.Rows[i]["ID"].ToString(),
                        Ispc = gameInfoTable.Rows[i]["Ispc"].ToString(),
                        Iszhuanshu = gameInfoTable.Rows[i]["Iszhuanshu"].ToString(),
                        Level = gameInfoTable.Rows[i]["Level"].ToString(),
                        Name = gameInfoTable.Rows[i]["Name"].ToString(),
                        Size = gameInfoTable.Rows[i]["Size"].ToString(),
                        Url = gameInfoTable.Rows[i]["Url"].ToString(),
                        Version = gameInfoTable.Rows[i]["Version"].ToString(),
                        NumSize = string.IsNullOrEmpty(gameInfoTable.Rows[0]["NumSize"].ToString()) ? -1.0f : float.Parse(gameInfoTable.Rows[0]["NumSize"].ToString()),
                        FileName = gameInfoTable.Rows[i]["FileName"].ToString(),
                        OriginalName = gameInfoTable.Rows[i]["OriginalName"].ToString(),
                    };

                    result.Add(gameInfoEntity_t);
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GameInfoEntity> GetUnityGameInfoEntityListByFileName(string fileName, int count)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[AYYGames] WHERE [FileName] = '{1}' ", count, fileName);
                DataTable gameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (gameInfoTable == null || gameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<GameInfoEntity> result = new List<GameInfoEntity>();
                for (int i = 0; i < gameInfoTable.Rows.Count; i++)
                {
                    GameInfoEntity gameInfoEntity_t = new GameInfoEntity
                    {
                        ActionType = gameInfoTable.Rows[i]["ActionType"].ToString(),
                        DownloadState = gameInfoTable.Rows[i]["DownloadState"].ToString(),
                        DownloadType = gameInfoTable.Rows[i]["DownloadType"].ToString(),
                        GameClassify = gameInfoTable.Rows[i]["GameClassify"].ToString(),
                        GameProfileInfo = gameInfoTable.Rows[i]["GameProfileInfo"].ToString(),
                        GameProfileUrl = gameInfoTable.Rows[i]["GameProfileUrl"].ToString(),
                        GameSourceType = gameInfoTable.Rows[i]["GameSourceType"].ToString(),
                        Guid = gameInfoTable.Rows[i]["Guid"].ToString(),
                        Icon = gameInfoTable.Rows[i]["Icon"].ToString(),
                        ID = gameInfoTable.Rows[i]["ID"].ToString(),
                        Ispc = gameInfoTable.Rows[i]["Ispc"].ToString(),
                        Iszhuanshu = gameInfoTable.Rows[i]["Iszhuanshu"].ToString(),
                        Level = gameInfoTable.Rows[i]["Level"].ToString(),
                        Name = gameInfoTable.Rows[i]["Name"].ToString(),
                        Size = gameInfoTable.Rows[i]["Size"].ToString(),
                        Url = gameInfoTable.Rows[i]["Url"].ToString(),
                        Version = gameInfoTable.Rows[i]["Version"].ToString(),
                        NumSize = string.IsNullOrEmpty(gameInfoTable.Rows[0]["NumSize"].ToString()) ? -1.0f : float.Parse(gameInfoTable.Rows[0]["NumSize"].ToString()),
                        FileName = gameInfoTable.Rows[i]["FileName"].ToString(),
                        OriginalName = gameInfoTable.Rows[i]["OriginalName"].ToString(),
                    };

                    result.Add(gameInfoEntity_t);
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
 

        public List<GameInfoEntity> GetUnityGameInfoEntityListByNullState(string downloadType, int count)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[AYYGames] WHERE [DownloadType] = '{1}' AND [State] is NULL", count, downloadType);
                DataTable gameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (gameInfoTable == null || gameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<GameInfoEntity> result = new List<GameInfoEntity>();
                for (int i = 0; i < gameInfoTable.Rows.Count; i++)
                {
                    GameInfoEntity gameInfoEntity_t = new GameInfoEntity
                    {
                        ActionType = gameInfoTable.Rows[i]["ActionType"].ToString(),
                        DownloadState = gameInfoTable.Rows[i]["DownloadState"].ToString(),
                        DownloadType = gameInfoTable.Rows[i]["DownloadType"].ToString(),
                        GameClassify = gameInfoTable.Rows[i]["GameClassify"].ToString(),
                        GameProfileInfo = gameInfoTable.Rows[i]["GameProfileInfo"].ToString(),
                        GameProfileUrl = gameInfoTable.Rows[i]["GameProfileUrl"].ToString(),
                        GameSourceType = gameInfoTable.Rows[i]["GameSourceType"].ToString(),
                        Guid = gameInfoTable.Rows[i]["Guid"].ToString(),
                        Icon = gameInfoTable.Rows[i]["Icon"].ToString(),
                        ID = gameInfoTable.Rows[i]["ID"].ToString(),
                        Ispc = gameInfoTable.Rows[i]["Ispc"].ToString(),
                        Iszhuanshu = gameInfoTable.Rows[i]["Iszhuanshu"].ToString(),
                        Level = gameInfoTable.Rows[i]["Level"].ToString(),
                        Name = gameInfoTable.Rows[i]["Name"].ToString(),
                        Size = gameInfoTable.Rows[i]["Size"].ToString(),
                        Url = gameInfoTable.Rows[i]["Url"].ToString(),
                        Version = gameInfoTable.Rows[i]["Version"].ToString(),
                        NumSize = string.IsNullOrEmpty(gameInfoTable.Rows[0]["NumSize"].ToString()) ? -1.0f : float.Parse(gameInfoTable.Rows[0]["NumSize"].ToString()),
                        FileName = gameInfoTable.Rows[i]["FileName"].ToString(),
                        OriginalName = gameInfoTable.Rows[i]["OriginalName"].ToString(),
                    };

                    result.Add(gameInfoEntity_t);
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddUnityGameInfoEntity(GameInfoEntity gameInfoEntity)
        {
            try
            {
                gameInfoEntity.ActionType = string.IsNullOrEmpty(gameInfoEntity.ActionType) ? "" : gameInfoEntity.ActionType;
                gameInfoEntity.DownloadState = string.IsNullOrEmpty(gameInfoEntity.DownloadState) ? "" : gameInfoEntity.DownloadState;
                gameInfoEntity.DownloadType = string.IsNullOrEmpty(gameInfoEntity.DownloadType) ? "" : gameInfoEntity.DownloadType;
                gameInfoEntity.FileName = string.IsNullOrEmpty(gameInfoEntity.FileName) ? "" : gameInfoEntity.FileName;
                gameInfoEntity.GameClassify = string.IsNullOrEmpty(gameInfoEntity.GameClassify) ? "" : gameInfoEntity.GameClassify;
                gameInfoEntity.GameProfileInfo = string.IsNullOrEmpty(gameInfoEntity.GameProfileInfo) ? "" : gameInfoEntity.GameProfileInfo;
                gameInfoEntity.GameProfileUrl = string.IsNullOrEmpty(gameInfoEntity.GameProfileUrl) ? "" : gameInfoEntity.GameProfileUrl;
                gameInfoEntity.GameSourceType = string.IsNullOrEmpty(gameInfoEntity.GameSourceType) ? "" : gameInfoEntity.GameSourceType;
                gameInfoEntity.Guid = string.IsNullOrEmpty(gameInfoEntity.Guid) ? "" : gameInfoEntity.Guid;
                gameInfoEntity.Icon = string.IsNullOrEmpty(gameInfoEntity.Icon) ? "" : gameInfoEntity.Icon;
                gameInfoEntity.ID = string.IsNullOrEmpty(gameInfoEntity.ID) ? "" : gameInfoEntity.ID;
                gameInfoEntity.Ispc = string.IsNullOrEmpty(gameInfoEntity.Ispc) ? "" : gameInfoEntity.Ispc;
                gameInfoEntity.Iszhuanshu = string.IsNullOrEmpty(gameInfoEntity.Iszhuanshu) ? "" : gameInfoEntity.Iszhuanshu;
                gameInfoEntity.Level = string.IsNullOrEmpty(gameInfoEntity.Level) ? "" : gameInfoEntity.Level;
                gameInfoEntity.Name = string.IsNullOrEmpty(gameInfoEntity.Name) ? "" : gameInfoEntity.Name;
                //gameInfoEntity.NumSize = gameInfoEntity.NumSize = null ? 0.0f : gameInfoEntity.NumSize;
                gameInfoEntity.OriginalName = string.IsNullOrEmpty(gameInfoEntity.OriginalName) ? "" : gameInfoEntity.OriginalName;
                gameInfoEntity.RealDownloadUrl = string.IsNullOrEmpty(gameInfoEntity.RealDownloadUrl) ? "" : gameInfoEntity.RealDownloadUrl;
                gameInfoEntity.Size = string.IsNullOrEmpty(gameInfoEntity.Size) ? "" : gameInfoEntity.Size;
                gameInfoEntity.Url = string.IsNullOrEmpty(gameInfoEntity.Url) ? "" : gameInfoEntity.Url;
                gameInfoEntity.Version = string.IsNullOrEmpty(gameInfoEntity.Version) ? "" : gameInfoEntity.Version;


                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[AYYGames] WHERE [GameProfileUrl] = '{0}'",
                                                  gameInfoEntity.GameProfileUrl);

                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该游戏已存在!");
                }


                float sizeM = 0.0f;
                //if (gameInfoEntity.Size.ToLower().Contains("k"))
                //{
                //    sizeM = float.Parse(gameInfoEntity.Size.Replace("k", "").Replace("K", "").Replace("b", "").Replace("B", "")) / 1024.0f;
                //}
                //else if (gameInfoEntity.Size.ToLower().Contains("m"))
                //{
                //    sizeM = float.Parse(gameInfoEntity.Size.Replace("m", "").Replace("M", "").Replace("b", "").Replace("B", ""));
                //}

                string sqlCmd = string.Format("INSERT INTO [dbo].[AYYGames] ([Name],[Guid],[Icon],[Size],[Level],[Url],[DownloadType],[ActionType],[Ispc],[Iszhuanshu],[GameProfileInfo],[GameClassify],[GameProfileUrl],[GameSourceType],[DownloadState],[AddTime],[UpdateTime],[Version],[NumSize],[FileName]) " +
                                              " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                                              gameInfoEntity.Name, gameInfoEntity.Guid, gameInfoEntity.Icon, gameInfoEntity.Size, gameInfoEntity.Level,
                                              gameInfoEntity.Url, gameInfoEntity.DownloadType, gameInfoEntity.ActionType, gameInfoEntity.Ispc,
                                              gameInfoEntity.Iszhuanshu, gameInfoEntity.GameProfileInfo, gameInfoEntity.GameClassify, gameInfoEntity.GameProfileUrl,
                                              gameInfoEntity.GameSourceType, gameInfoEntity.DownloadState, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                              gameInfoEntity.Version, gameInfoEntity.NumSize, gameInfoEntity.FileName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateUnityGameInfoEntity(GameInfoEntity gameInfoEntity)
        {
            try
            {
                string name = string.IsNullOrEmpty(gameInfoEntity.Name) ? "[Name]" : "'" + gameInfoEntity.Name + "'";
                string guid = string.IsNullOrEmpty(gameInfoEntity.Guid) ? "[Guid]" : "'" + gameInfoEntity.Guid + "'";
                string Version = string.IsNullOrEmpty(gameInfoEntity.Version) ? "[Version]" : "'" + gameInfoEntity.Version + "'";
                string Icon = string.IsNullOrEmpty(gameInfoEntity.Icon) ? "[Icon]" : "'" + gameInfoEntity.Icon + "'";
                string Size = string.IsNullOrEmpty(gameInfoEntity.Size) ? "[Size]" : "'" + gameInfoEntity.Size + "'";
                string Level = string.IsNullOrEmpty(gameInfoEntity.Level) ? "[Level]" : "'" + gameInfoEntity.Level + "'";
                string Url = string.IsNullOrEmpty(gameInfoEntity.Url) ? "[Url]" : "'" + gameInfoEntity.Url + "'";
                string DownloadType = string.IsNullOrEmpty(gameInfoEntity.DownloadType) ? "[DownloadType]" : "'" + gameInfoEntity.DownloadType + "'";
                string ActionType = string.IsNullOrEmpty(gameInfoEntity.ActionType) ? "[ActionType]" : "'" + gameInfoEntity.ActionType + "'";
                string Ispc = string.IsNullOrEmpty(gameInfoEntity.Ispc) ? "[Ispc]" : "'" + gameInfoEntity.Ispc + "'";
                string Iszhuanshu = string.IsNullOrEmpty(gameInfoEntity.Iszhuanshu) ? "[Iszhuanshu]" : "'" + gameInfoEntity.Iszhuanshu + "'";
                string GameProfileInfo = string.IsNullOrEmpty(gameInfoEntity.GameProfileInfo) ? "[GameProfileInfo]" : "'" + gameInfoEntity.GameProfileInfo + "'";
                string GameClassify = string.IsNullOrEmpty(gameInfoEntity.GameClassify) ? "[GameClassify]" : "'" + gameInfoEntity.GameClassify + "'";
                string GameProfileUrl = string.IsNullOrEmpty(gameInfoEntity.GameProfileUrl) ? "[GameProfileUrl]" : "'" + gameInfoEntity.GameProfileUrl + "'";
                string GameSourceType = string.IsNullOrEmpty(gameInfoEntity.GameSourceType) ? "[GameSourceType]" : "'" + gameInfoEntity.GameSourceType + "'";
                string ID = string.IsNullOrEmpty(gameInfoEntity.ID) ? "[ID]" : "'" + gameInfoEntity.ID + "'";
                string DownloadState = string.IsNullOrEmpty(gameInfoEntity.DownloadState) ? "[DownloadState]" : "'" + gameInfoEntity.DownloadState + "'";
                string FileName = string.IsNullOrEmpty(gameInfoEntity.FileName) ? "[FileName]" : "'" + gameInfoEntity.FileName + "'";
                string NumSize = gameInfoEntity.NumSize == -1.0f ? "[NumSize]" : gameInfoEntity.NumSize.ToString();
                string OriginalName = string.IsNullOrEmpty(gameInfoEntity.OriginalName) ? "[OriginalName]" : "'" + gameInfoEntity.OriginalName + "'";


                string sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [Name] = {1},[Guid] = {2},[Version] = {3},[Icon] = {4}," +
                                                "[Size] = {5},[Level] = {6},[Url] = {7},[DownloadType] = {8},[ActionType] = {9},[Ispc] = {10}," +
                                                "[Iszhuanshu] = {11},[GameProfileInfo] = {12},[GameClassify] = {13},[GameProfileUrl] = {14},[GameSourceType] = {15},[DownloadState] = {16},[NumSize] = {17},[UpdateTime] = '{18}',[FileName] = {19},[OriginalName] = {20} WHERE [ID] = {0}",
                                                ID, name, guid, Version, Icon, Size, Level, Url, DownloadType, ActionType, Ispc,
                                                Iszhuanshu, GameProfileInfo, GameClassify, GameProfileUrl, GameSourceType, DownloadState, NumSize, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), FileName, OriginalName);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDownloadStateAndFileNameByFileName(string oldFileName, string newFileName, string downloadState, string gameSourceType)
        {
            try
            {
                string DownloadState = string.IsNullOrEmpty(downloadState) ? "[DownloadState]" : "'" + downloadState + "'";
                string FileName = string.IsNullOrEmpty(newFileName) ? "[FileName]" : "'" + newFileName + "'";
                string GameSourceType = string.IsNullOrEmpty(gameSourceType) ? "[GameSourceType]" : "'" + gameSourceType + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [DownloadState] = {1},[FileName] = {2},[UpdateTime] = '{3}',[GameSourceType] = {4} WHERE [FileName] = '{0}'",
                                                oldFileName, DownloadState, FileName, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), GameSourceType);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDownloadStateAndFileNameByGuid(string fileName, string downloadState, string gameSourceType, string guid)
        {
            try
            {
                string DownloadState = string.IsNullOrEmpty(downloadState) ? "[DownloadState]" : "'" + downloadState + "'";
                string FileName = string.IsNullOrEmpty(fileName) ? "[FileName]" : "'" + fileName + "'";
                string GameSourceType = string.IsNullOrEmpty(gameSourceType) ? "[GameSourceType]" : "'" + gameSourceType + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [DownloadState] = {1},[FileName] = {2},[UpdateTime] = '{3}',[GameSourceType] = {4} WHERE [Guid] = '{0}'",
                                                guid, DownloadState, FileName, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), GameSourceType);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateOriginalNameByGuid(string originalName, string guid)
        {
            try
            {
                string OriginalName = string.IsNullOrEmpty(originalName) ? "[OriginalName]" : "'" + originalName + "'";

                string sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [OriginalName] = {1},[UpdateTime] = '{2}' WHERE [Guid] = '{0}'",
                                                guid, OriginalName, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateFileNameAndVersionByFileNameLike(string fileName, string version)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [FileName] = '{1}',[Version] = '{2}',[UpdateTime] = '{3}' WHERE [Url] Like '%{0}%'",
                                fileName, fileName, version, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateStateById(string id, string state)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = '{2}'",
                                state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void DeleteUnityGameInfoEntity(string id)
        {
            try
            {
                string sqlCmd = string.Format("DELETE FROM [dbo].[AYYGames] WHERE [ID] =  '{0}'",
                                            id);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GameInfoEntity GetOneUnityGameInfoEntityRandomWithDownloadState(string downloadState, string newDownloadState)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP 1 * FROM [dbo].[AYYGames] WHERE " +
                                         "[downloadState] = '{0}' ORDER BY NEWID()", downloadState);


                DataTable gameInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (gameInfoTable == null || gameInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                GameInfoEntity result = new GameInfoEntity
                    {
                        ActionType = gameInfoTable.Rows[0]["ActionType"].ToString(),
                        DownloadState = gameInfoTable.Rows[0]["DownloadState"].ToString(),
                        DownloadType = gameInfoTable.Rows[0]["DownloadType"].ToString(),
                        GameClassify = gameInfoTable.Rows[0]["GameClassify"].ToString(),
                        GameProfileInfo = gameInfoTable.Rows[0]["GameProfileInfo"].ToString(),
                        GameProfileUrl = gameInfoTable.Rows[0]["GameProfileUrl"].ToString(),
                        GameSourceType = gameInfoTable.Rows[0]["GameSourceType"].ToString(),
                        Guid = gameInfoTable.Rows[0]["Guid"].ToString(),
                        Icon = gameInfoTable.Rows[0]["Icon"].ToString(),
                        ID = gameInfoTable.Rows[0]["ID"].ToString(),
                        Ispc = gameInfoTable.Rows[0]["Ispc"].ToString(),
                        Iszhuanshu = gameInfoTable.Rows[0]["Iszhuanshu"].ToString(),
                        Level = gameInfoTable.Rows[0]["Level"].ToString(),
                        Name = gameInfoTable.Rows[0]["Name"].ToString(),
                        Size = gameInfoTable.Rows[0]["Size"].ToString(),
                        Url = gameInfoTable.Rows[0]["Url"].ToString(),
                        Version = gameInfoTable.Rows[0]["Version"].ToString(),
                        NumSize = string.IsNullOrEmpty(gameInfoTable.Rows[0]["NumSize"].ToString()) ? -1.0f : float.Parse(gameInfoTable.Rows[0]["NumSize"].ToString()),
                        FileName = gameInfoTable.Rows[0]["FileName"].ToString(),
                    };

                sqlCmd = string.Format("UPDATE [dbo].[AYYGames] SET [downloadState] = '{0}' WHERE [ID] = {1}", newDownloadState, result.ID);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

