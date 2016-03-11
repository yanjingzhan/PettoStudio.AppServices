using Controller;
using GamesManager.Utility;
using Models.GameManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace GamesManager
{
    public partial class UnityGameManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action;
                string name, guid, version, icon, size, level, url, newDownloadState,originalName,
                    downloadType, actionType, ispc, iszhuanshu, gameProfileInfo, fileName, oldFileName, newFileName,
                    gameClassify, gameProfileUrl, gameSourceType, id, downloadState, count, numSize;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                guid = Request["guid"] == null ? "" : Request["guid"].Trim();
                version = Request["version"] == null ? "" : Request["version"].Trim();
                icon = Request["icon"] == null ? "" : Request["icon"].Trim();
                size = Request["size"] == null ? "" : Request["size"].Trim();
                level = Request["level"] == null ? "" : Request["level"].Trim();
                url = Request["downloadurl"] == null ? "" : Request["downloadurl"].Trim();
                name = Request["name"] == null ? "" : Request["name"].Trim();
                downloadType = Request["downloadtype"] == null ? "" : Request["downloadtype"].Trim();
                actionType = Request["actiontype"] == null ? "" : Request["actiontype"].Trim();
                ispc = Request["ispc"] == null ? "" : Request["ispc"].Trim();
                iszhuanshu = Request["iszhuanshu"] == null ? "" : Request["iszhuanshu"].Trim();
                gameProfileInfo = Request["gameprofileinfo"] == null ? "" : Request["gameprofileinfo"].Trim();
                gameClassify = Request["gameclassify"] == null ? "" : Request["gameclassify"].Trim();
                gameProfileUrl = Request["gameprofileurl"] == null ? "" : Request["gameprofileurl"].Trim();
                gameSourceType = Request["gamesourcetype"] == null ? "" : Request["gamesourcetype"].Trim();
                id = Request["id"] == null ? "" : Request["id"].Trim();
                downloadState = Request["downloadstate"] == null ? "" : Request["downloadstate"].Trim();
                count = Request["count"] == null ? "" : Request["count"].Trim();
                numSize = Request["numsize"] == null ? "" : Request["numsize"].Trim();
                newDownloadState = Request["newdownloadstate"] == null ? "" : Request["newdownloadstate"].Trim();
                fileName = Request["filename"] == null ? "" : Request["filename"].Trim();
                oldFileName = Request["oldfilename"] == null ? "" : Request["oldfilename"].Trim();
                newFileName = Request["newfilename"] == null ? "" : Request["newfilename"].Trim();
                guid = Request["guid"] == null ? "" : Request["guid"].Trim();
                originalName = Request["originalname"] == null ? "" : Request["originalname"].Trim();

                switch (action.ToLower())
                {
                    case "getunitygameinfoentitylist":
                        GetUnityGameInfoEntityList(name, guid, version, icon, size, level, url,
                            downloadType, actionType, ispc, iszhuanshu, gameProfileInfo, gameClassify,
                            gameProfileUrl, gameSourceType, id, downloadState, count);
                        break;

                    case "addunitygameinfoentity":
                        AddUnityGameInfoEntity(name, guid, version, icon, size, level, url,
                            downloadType, actionType, ispc, iszhuanshu, gameProfileInfo, gameClassify,
                            gameProfileUrl, gameSourceType, downloadState);
                        break;

                    case "updateunitygameinfoentity":
                        UpdateUnityGameInfoEntity(name, guid, version, icon, size, level, url,
                            downloadType, actionType, ispc, iszhuanshu, gameProfileInfo, gameClassify,
                            gameProfileUrl, gameSourceType, id, downloadState, numSize, fileName);
                        break;

                    case "deleteunitygameinfoentity":
                        DeleteUnityGameInfoEntity(id);
                        break;


                    case "getoneunitygameinfoentityrandomwithdownloadstate":
                        GetOneUnityGameInfoEntityRandomWithDownloadState(downloadState, newDownloadState);
                        break;

                    case "updatedownloadstateandfilenamebyfilename":
                        UpdateDownloadStateAndFileNameByFileName(oldFileName, newFileName, downloadState, gameSourceType);
                        break;

                    case "updatedownloadstateandfilenamebyguid":
                        UpdateDownloadStateAndFileNameByGuid(fileName, downloadState, gameSourceType, guid);
                        break;

                    case "updateoriginalnamebyguid":
                        UpdateOriginalNameByGuid(originalName, guid);
                        break;

                    case "updatefilenameandversionbyfilenamelike":
                        UpdateFileNameAndVersionByFileNameLike(fileName, version);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        private void UpdateFileNameAndVersionByFileNameLike(string fileName, string version)
        {
            try
            {
                new UnityGameControl().UpdateFileNameAndVersionByFileNameLike(fileName, version);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void UpdateOriginalNameByGuid(string originalName, string guid)
        {
            try
            {
                new UnityGameControl().UpdateOriginalNameByGuid(originalName, guid);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }


        private void UpdateDownloadStateAndFileNameByGuid(string fileName, string downloadState, string gameSourceType, string guid)
        {
            try
            {
                new UnityGameControl().UpdateDownloadStateAndFileNameByGuid(fileName, downloadState, gameSourceType, guid);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void UpdateDownloadStateAndFileNameByFileName(string oldFileName, string newFileName, string downloadState, string gameSourceType)
        {
            try
            {
                new UnityGameControl().UpdateDownloadStateAndFileNameByFileName(oldFileName, newFileName, downloadState, gameSourceType);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void GetUnityGameInfoEntityList(string name, string guid, string version, string icon,
            string size, string level, string url, string downloadType, string actionType, string ispc, string iszhuanshu,
            string gameProfileInfo, string gameClassify, string gameProfileUrl, string gameSourceType, string id, string downloadState, string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new UnityGameControl().GetUnityGameInfoEntityList(
                        new GameInfoEntity
                        {
                            ActionType = actionType,
                            DownloadState = downloadState,
                            DownloadType = downloadType,
                            GameClassify = gameClassify,
                            ID = id,
                            GameProfileInfo = gameProfileInfo,
                            GameProfileUrl = gameProfileUrl,
                            GameSourceType = gameSourceType,
                            Guid = guid,
                            Icon = icon,
                            Ispc = ispc,
                            Iszhuanshu = iszhuanshu,
                            Level = level,
                            Name = name,
                            Size = size,
                            Url = url,
                            Version = version
                        }, int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void GetOneUnityGameInfoEntityRandomWithDownloadState(string downloadState, string newDownloadState)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new UnityGameControl().GetOneUnityGameInfoEntityRandomWithDownloadState(downloadState, newDownloadState));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void AddUnityGameInfoEntity(string name, string guid, string version, string icon,
            string size, string level, string url, string downloadType, string actionType, string ispc, string iszhuanshu,
            string gameProfileInfo, string gameClassify, string gameProfileUrl, string gameSourceType, string downloadState)
        {
            try
            {
                new UnityGameControl().AddUnityGameInfoEntity(
                new GameInfoEntity
                {
                    ActionType = actionType,
                    DownloadState = downloadState,
                    DownloadType = downloadType,
                    GameClassify = gameClassify,
                    GameProfileInfo = gameProfileInfo,
                    GameProfileUrl = gameProfileUrl,
                    GameSourceType = gameSourceType,
                    Guid = guid,
                    Icon = icon,
                    Ispc = ispc,
                    Iszhuanshu = iszhuanshu,
                    Level = level,
                    Name = name,
                    Size = size,
                    Url = url,
                    Version = version
                });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void UpdateUnityGameInfoEntity(string name, string guid, string version, string icon,
            string size, string level, string url, string downloadType, string actionType, string ispc, string iszhuanshu,
            string gameProfileInfo, string gameClassify, string gameProfileUrl, string gameSourceType, string id, string downloadState, string numSize, string fileName)
        {
            try
            {
                GameInfoEntity g = new GameInfoEntity();
                g.ActionType = actionType;
                g.DownloadState = downloadState;
                g.DownloadType = downloadType;
                g.GameClassify = gameClassify;
                g.ID = id;
                g.GameProfileInfo = gameProfileInfo;
                g.GameProfileUrl = gameProfileUrl;
                g.GameSourceType = gameSourceType;
                g.Guid = guid;
                g.Icon = icon;
                g.Ispc = ispc;
                g.Iszhuanshu = iszhuanshu;
                g.Level = level;
                g.Name = name;
                g.Size = size;
                g.Url = url;
                g.Version = version;
                g.NumSize = string.IsNullOrEmpty(numSize) ? -1.0f : (float)Convert.ToDouble(numSize);
                g.FileName = fileName;

                new UnityGameControl().UpdateUnityGameInfoEntity(g);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }

        private void DeleteUnityGameInfoEntity(string id)
        {
            try
            {
                new UnityGameControl().DeleteUnityGameInfoEntity(id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "GamesManager");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GamesManager");
            }
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="LogMessage">日志内容</param>
        public static void WriteLog(string LogMessage, System.Web.UI.Page page, string fileNamePre)
        {
            string IP = page.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string stringFrom = string.Empty;
            string stringQuery = string.Empty;
            System.Collections.Specialized.NameValueCollection NameValues = page.Request.Form;
            if (NameValues.Count > 0)
            {
                string[] AllKeys = NameValues.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringFrom.Length == 0)
                    {
                        stringFrom += tepKey + "=" + NameValues[tepKey];
                    }
                    else
                    {
                        stringFrom += "&" + tepKey + "=" + NameValues[tepKey];
                    }
                }
            }

            System.Collections.Specialized.NameValueCollection NameVlaues1 = page.Request.QueryString;

            if (NameVlaues1.Count > 0)
            {
                string[] AllKeys = NameVlaues1.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringQuery.Length == 0)
                    {
                        stringQuery += tepKey + "=" + NameVlaues1[tepKey];
                    }
                    else
                    {
                        stringQuery += "&" + tepKey + "=" + NameVlaues1[tepKey];
                    }
                }
            }
            Log.Write(IP, stringFrom, stringQuery, LogMessage, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), fileNamePre);
        }
    }
}