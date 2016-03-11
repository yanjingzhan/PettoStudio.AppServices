using AccountServices.Utility;
using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace AccountServices
{
    public partial class play : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, appid, appname, owner, countrylist, country, addedplayaccountcount, couldbeplayed, currentgroupnumber, groupnumber,
                    shuaSucCount, shuaFailCount, startDate, endDate, shoudonggroupnumber, newnumber;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                appid = Request["appid"] == null ? "" : Request["appid"].Trim();
                appname = Request["appname"] == null ? "" : Request["appname"].Trim();
                owner = Request["owner"] == null ? "" : Request["owner"].Trim();
                countrylist = Request["countrylist"] == null ? "" : Request["countrylist"].Trim();
                country = Request["country"] == null ? "" : Request["country"].Trim();
                addedplayaccountcount = Request["addedplayaccountcount"] == null ? "" : Request["addedplayaccountcount"].Trim();
                couldbeplayed = Request["couldbeplayed"] == null ? "" : Request["couldbeplayed"].Trim();
                currentgroupnumber = Request["currentgroupnumber"] == null ? "" : Request["currentgroupnumber"].Trim();
                groupnumber = Request["groupnumber"] == null ? "" : Request["groupnumber"].Trim();

                shuaSucCount = Request["shuaSucCount"] == null ? "" : Request["shuaSucCount"].Trim();
                shuaFailCount = Request["shuaFailCount"] == null ? "" : Request["shuaFailCount"].Trim();
                startDate = Request["startDate"] == null ? "" : Request["startDate"].Trim();
                endDate = Request["endDate"] == null ? "" : Request["endDate"].Trim();

                shoudonggroupnumber = Request["shoudonggroupnumber"] == null ? "" : Request["shoudonggroupnumber"].Trim();
                newnumber = Request["newnumber"] == null ? "" : Request["newnumber"].Trim();

                switch (action.ToLower())
                {
                    case "addappstoallcountryintodatabase":
                        AddAppsToAllCountryIntoDataBase(appid, appname, owner);
                        break;

                    case "addappstosomecountryintodatabase":
                        AddAppsToSomeCountryIntoDataBase(appid, appname, owner, countrylist);
                        break;

                    case "updateappsplayaccountcountbyidandcountry":
                        UpdateAppsPlayAccountCountByIdAndCountry(appid, country, addedplayaccountcount);
                        break;

                    case "updateappscouldbeplayedforallcountrybyid":
                        UpdateAppsCouldBePlayedForAllCountryById(appid, couldbeplayed);
                        break;

                    case "updateappscouldbeplayedbyidandcountry":
                        UpdateAppsCouldBePlayedByIdAndCountry(appid, country, couldbeplayed);
                        break;

                    case "updatecurrentgroupnumbertocountrygrouptable":
                        UpdateCurrentGroupNumberToCountryGroupTable(currentgroupnumber, country);
                        break;

                    case "getcouldbeplayedapplistbycountry":
                        GetCouldBePlayedAppListByCountry(country);
                        break;

                    case "getcountrygroupinfolistfromdb":
                        GetCountryGroupInfoListFromDb();
                        break;

                    case "getaccountinfolistbycountryandgroupnumber":
                        GetAccountInfoListByCountryAndGroupNumber(country, groupnumber);
                        break;

                    case "addshuarecordtodatabase":
                        AddShuaRecordToDataBase(country, shuaSucCount, shuaFailCount);
                        break;

                    case "getshuarecordfromdatabase":
                        GetShuaRecordFromDataBase(startDate, endDate);
                        break;

                    case "addappstosomecountryintodatabaseshoudong":
                        AddAppsToSomeCountryIntoDataBaseShouDong(appid, appname, owner, countrylist, shoudonggroupnumber);
                        break;

                    case "getshoudongcurrentgroupnumber":
                        GetShouDongCurrentGroupNumber();
                        break;

                    case "updateshoudongcurrentgroupnumber":
                        UpdateShouDongCurrentGroupNumber(newnumber);
                        break;

                    case "getcouldbeplayedapplistbycountryshoudong":
                        GetCouldBePlayedAppListByCountryShouDong(country);
                        break;

                    case "changeappgroupnumbershoudong":
                        ChangeAppGroupNumberShouDong(appid, shoudonggroupnumber);
                        break;

                    case "deleteappfromdb":
                        DeleteAppFromDB(appid);
                        break;

                    case "getshoudongcurrentcountry":
                        GetShouDongCurrentCountry();
                        break;

                    case "updateshoudonecurrentcountry":
                        UpdateShouDoneCurrentCountry(country);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        private void GetShouDongCurrentCountry()
        {
            try
            {
                string result = new PlayControl().GetShouDongCurrentCountry().ToString();
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void UpdateShouDoneCurrentCountry(string country)
        {
            try
            {
                new PlayControl().UpdateShouDoneCurrentCountry(country);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void AddAppsToSomeCountryIntoDataBaseShouDong(string appId, string appName, string owner, string countryList, string ShouDongGroupNumber)
        {
            try
            {
                string[] contryArray = countryList.Split(',');

                new PlayControl().AddAppsToSomeCountryIntoDataBaseShouDong(appId, appName, owner, contryArray, ShouDongGroupNumber);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }

        }

        private void GetShouDongCurrentGroupNumber()
        {
            try
            {
                string result = new PlayControl().GetShouDongCurrentGroupNumber().ToString();
                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void UpdateShouDongCurrentGroupNumber(string newNumber)
        {
            try
            {
                new PlayControl().UpdateShouDongCurrentGroupNumber(newNumber);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void GetCouldBePlayedAppListByCountryShouDong(string country)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                new PlayControl().GetCouldBePlayedAppListByCountryShouDong(country));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void ChangeAppGroupNumberShouDong(string appId, string shouDongGroupNumber)
        {
            try
            {
                new PlayControl().ChangeAppGroupNumberShouDong(appId, shouDongGroupNumber);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void DeleteAppFromDB(string appId)
        {
            try
            {
                new PlayControl().DeleteAppFromDB(appId);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        //-----

        private void AddShuaRecordToDataBase(string country, string shuaSucCount, string shuaFailCount)
        {
            try
            {
                new ShuaControl().AddShuaRecordToDataBase(country, shuaSucCount, shuaFailCount);
                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        private void GetShuaRecordFromDataBase(string startDate, string endDate)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new ShuaControl().GetShuaRecordFromDataBase(startDate, endDate));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }

        }

        /// <summary>
        /// 添加应用，并且在所有国家都添加上
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appName"></param>
        /// <param name="owner"></param>
        private void AddAppsToAllCountryIntoDataBase(string appId, string appName, string owner)
        {
            try
            {
                new PlayControl().AddAppsToAllCountryIntoDataBase(appId, appName, owner);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 添加应用，指定国家
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appName"></param>
        /// <param name="owner"></param>
        /// <param name="countryList"></param>
        private void AddAppsToSomeCountryIntoDataBase(string appId, string appName, string owner, string countryList)
        {
            try
            {
                string[] contryArray = countryList.Split(',');

                new PlayControl().AddAppsToSomeCountryIntoDataBase(appId, appName, owner, contryArray);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 更新应用被Play的数量
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="country"></param>
        /// <param name="addedPlayAccountCount"></param>
        private void UpdateAppsPlayAccountCountByIdAndCountry(string appId, string country, string addedPlayAccountCount)
        {
            try
            {
                new PlayControl().UpdateAppsPlayAccountCountByIdAndCountry(appId, country, addedPlayAccountCount);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 更新应用是否还能被Play
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="country"></param>
        /// <param name="couldBePlayed"></param>
        private void UpdateAppsCouldBePlayedByIdAndCountry(string appId, string country, string couldBePlayed)
        {
            try
            {
                new PlayControl().UpdateAppsCouldBePlayedByIdAndCountry(appId, country, bool.Parse(couldBePlayed));

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 更新应用是否还能被Play，给所有国家
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="country"></param>
        /// <param name="couldBePlayed"></param>
        private void UpdateAppsCouldBePlayedForAllCountryById(string appId, string couldBePlayed)
        {
            try
            {
                new PlayControl().UpdateAppsCouldBePlayedForAllCountryById(appId, bool.Parse(couldBePlayed));

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 更新当前下次刷到的组号
        /// </summary>
        /// <param name="currentGroupNumber"></param>
        /// <param name="country"></param>
        private void UpdateCurrentGroupNumberToCountryGroupTable(string currentGroupNumber, string country)
        {
            try
            {
                new PlayControl().UpdateCurrentGroupNumberToCountryGroupTable(currentGroupNumber, country);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 获取指定可以被Play 的应用
        /// </summary>
        /// <param name="country"></param>
        private void GetCouldBePlayedAppListByCountry(string country)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                            new PlayControl().GetCouldBePlayedAppListByCountry(country));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 获取所有国家组信息
        /// </summary>
        private void GetCountryGroupInfoListFromDb()
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                            new PlayControl().GetCountryGroupInfoListFromDb());

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

        /// <summary>
        /// 获取指定国家和组号的账号
        /// </summary>
        /// <param name="country"></param>
        /// <param name="groupNumber"></param>
        private void GetAccountInfoListByCountryAndGroupNumber(string country, string groupNumber)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                            new PlayControl().GetAccountInfoListByCountryAndGroupNumber(country, groupNumber));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "play");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                LogWriter.WriteLog(ex.Message, Page, "play");
            }
        }

    }
}