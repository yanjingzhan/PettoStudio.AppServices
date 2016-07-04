using DataBaseLib;
using Models.AccountServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Utility;

namespace Controller
{
    public class PlayControl
    {
        public void AddAppsToAllCountryIntoDataBase(string appId, string appName, string owner)
        {
            try
            {
                //获取有账号的国家

                string sqlCmd = string.Format("SELECT DISTINCT [Country] FROM [dbo].[CountryGroup]");

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    throw new Exception("没有获取到国家列表");
                }

                List<string> countryList = new List<string>();

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    countryList.Add(accountInfoTable.Rows[i][0].ToString());
                }

                StringBuilder failInfo = new StringBuilder();
                foreach (var country in countryList)
                {
                    int count_t = GetAppCountByCountry(country, appId);

                    if (count_t > 0)
                    {
                        failInfo.Append(country);
                        failInfo.Append(",");

                        continue;
                    }

                    string sqlCmdGetCurrentGroupNumber = string.Format("SELECT [CurrentGroupNumber] FROM [dbo].[CountryGroup] WHERE [Country]='{0}' ", country);
                    int currentGroupNumber = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmdGetCurrentGroupNumber).ToString());


                    string sqlCmdInsert = string.Format("INSERT INTO [dbo].[Apps] ([Country],[AppId],[AppName],[MyGroupNumber],[AddTime],[PlayTime],[PlayAccountCount],[CouldBePlayed],[Owner]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','1','{7}')",
                                                        country, appId, appName, currentGroupNumber.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "", "0", owner);
                    SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
                }

                if (failInfo.Length > 0)
                {
                    throw new Exception(string.Format("{0} has the app been", failInfo.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void AddAppsToSomeCountryIntoDataBase(string appId, string appName, string owner, string[] countryList)
        {
            try
            {
                StringBuilder failInfo = new StringBuilder();
                foreach (var country in countryList)
                {
                    int count_t = GetAppCountByCountry(country, appId);

                    if (count_t > 0)
                    {
                        failInfo.Append(country);
                        failInfo.Append(",");

                        continue;
                    }

                    string sqlCmdGetCurrentGroupNumber = string.Format("SELECT [CurrentGroupNumber] FROM [dbo].[CountryGroup] WHERE [Country]='{0}' ", country);
                    int currentGroupNumber = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmdGetCurrentGroupNumber).ToString());


                    string sqlCmdInsert = string.Format("INSERT INTO [dbo].[Apps] ([Country],[AppId],[AppName],[MyGroupNumber],[AddTime],[PlayTime],[PlayAccountCount],[CouldBePlayed],[Owner]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','true','{7}')",
                                                        country, appId, appName, currentGroupNumber.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "", "0", owner);
                    SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
                }

                if (failInfo.Length > 0)
                {
                    throw new Exception(string.Format("{0} has the app been", failInfo.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        /// <summary>
        /// 添加手动要刷的应用
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appName"></param>
        /// <param name="owner"></param>
        /// <param name="countryList"></param>
        /// <param name="ShouDongGroupNumber"></param>
        public void AddAppsToSomeCountryIntoDataBaseShouDong(string appId, string appName, string owner, string[] countryList, string ShouDongGroupNumber)
        {
            try
            {
                StringBuilder failInfo = new StringBuilder();
                foreach (var country in countryList)
                {
                    int count_t = GetAppCountByCountry(country, appId);

                    if (count_t > 0)
                    {
                        failInfo.Append(country);
                        failInfo.Append(",");

                        continue;
                    }

                    string sqlCmdGetCurrentGroupNumber = string.Format("SELECT [CurrentGroupNumber] FROM [dbo].[CountryGroup] WHERE [Country]='{0}' ", country);
                    object t = SqlHelper.Instance.ExecuteScalar(sqlCmdGetCurrentGroupNumber);
                    int currentGroupNumber = t == null ? 0 : int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmdGetCurrentGroupNumber).ToString());


                    string sqlCmdInsert = string.Format("INSERT INTO [dbo].[Apps] ([Country],[AppId],[AppName],[MyGroupNumber],[AddTime],[PlayTime],[PlayAccountCount],[CouldBePlayed],[Owner],[ShouDongGroupNumber]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','true','{7}','{8}')",
                                                        country, appId, appName, currentGroupNumber.ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "", "0", owner, ShouDongGroupNumber);
                    SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
                }

                if (failInfo.Length > 0)
                {
                    throw new Exception(string.Format("{0} has the app been", failInfo.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        /// <summary>
        /// 获取当前组
        /// </summary>
        /// <returns></returns>
        public int GetShouDongCurrentGroupNumber()
        {
            try
            {
                string sqlCmd = string.Format("SELECT ShouDongCurrentNumber FROM [dbo].[ShouDongNumber]");
                return int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 等新当前组号
        /// </summary>
        /// <param name="newNumber"></param>
        public void UpdateShouDongCurrentGroupNumber(string newNumber)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[ShouDongNumber] SET [ShouDongCurrentNumber]={0}", newNumber);
                SqlHelper.Instance.ExecuteScalar(sqlCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取当前手动的国家
        /// </summary>
        /// <returns></returns>
        public string GetShouDongCurrentCountry()
        {
            try
            {
                string sqlCmd = string.Format("SELECT [ShouDongCountry] FROM [dbo].[ShouDongNumber]");
                return SqlHelper.Instance.ExecuteScalar(sqlCmd).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 更新当前手动的国家
        /// </summary>
        /// <param name="country"></param>
        public void UpdateShouDoneCurrentCountry(string country)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[ShouDongNumber] SET [ShouDongCountry]='{0}'", country);
                SqlHelper.Instance.ExecuteScalar(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 获取手动刷当前组的应用（by 国家)
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public List<AppModel> GetCouldBePlayedAppListByCountryShouDong(string country)
        {
            try
            {
                int currentShouDongGrupoNumber = GetShouDongCurrentGroupNumber();

                //country = GetShouDongCurrentCountry();

                string sqlCmd = string.Format("SELECT * FROM [dbo].[Apps] WHERE [Country]='{0}' AND [CouldBePlayed]='1' AND [ShouDongGroupNumber]={1} ",
                                                country, currentShouDongGrupoNumber);

                List<AppModel> AppModelList = new List<AppModel>();

                DataTable appListTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (appListTable == null || appListTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < appListTable.Rows.Count; i++)
                {
                    AppModel appModel_t = new AppModel
                    {
                        AddTime = appListTable.Rows[i]["AddTime"].ToString(),
                        AppId = appListTable.Rows[i]["AppId"].ToString(),
                        AppName = appListTable.Rows[i]["AppName"].ToString(),
                        CouldBePlayed = (bool)appListTable.Rows[i]["CouldBePlayed"],
                        Country = appListTable.Rows[i]["Country"].ToString(),
                        MyGroupNumber = appListTable.Rows[i]["MyGroupNumber"].ToString(),
                        PlayAccountCount = appListTable.Rows[i]["PlayAccountCount"].ToString(),
                        PlayTime = appListTable.Rows[i]["PlayTime"].ToString(),
                        Owner = appListTable.Rows[i]["Owner"].ToString()
                    };

                    AppModelList.Add(appModel_t);
                }

                return AppModelList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw;
            }
        }

        /// <summary>
        /// 修改应用手动组号
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="shouDongGroupNumber"></param>
        public void ChangeAppGroupNumberShouDong(string appId, string shouDongGroupNumber)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[Apps] SET [ShouDongGroupNumber]={0} WHERE [AppId]='{1}'",
                    shouDongGroupNumber, appId);
                SqlHelper.Instance.ExecuteScalar(sqlCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除应用
        /// </summary>
        /// <param name="appId"></param>
        public void DeleteAppFromDB(string appId)
        {
            try
            {
                string sqlCmd = string.Format("DELETE FROM [dbo].[Apps] WHERE [AppId]='{0}'",
                                            appId);
                SqlHelper.Instance.ExecuteScalar(sqlCmd);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private int GetAppCountByCountry(string country, string appId)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [dbo].[Apps] WHERE [Country]='{0}' AND [AppId]='{1}' ", country, appId);
                return int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateAppsPlayAccountCountByIdAndCountry(string appId, string country, string addedPlayAccountCount)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[Apps] SET [PlayAccountCount]=[PlayAccountCount] + '{0}',[PlayTime]='{1}' WHERE [AppId]='{2}' AND [Country]='{3}' ",
                                                addedPlayAccountCount, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), appId, country);

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAppsCouldBePlayedByIdAndCountry(string appId, string country, bool couldBePlayed)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[Apps] SET [CouldBePlayed] = '{0}' WHERE [AppId]='{1}' AND [Country]='{2}' ",
                                                couldBePlayed, appId, country);

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAppsCouldBePlayedForAllCountryById(string appId, bool couldBePlayed)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[Apps] SET [CouldBePlayed] = '{0}' WHERE [AppId]='{1}' ",
                                                couldBePlayed, appId);

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public List<AppModel> GetCouldBePlayedAppListByCountry(string country)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[Apps] WHERE [Country]='{0}' AND [CouldBePlayed]='1' ",
                                                country);

                List<AppModel> AppModelList = new List<AppModel>();

                DataTable appListTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (appListTable == null || appListTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < appListTable.Rows.Count; i++)
                {
                    AppModel appModel_t = new AppModel
                    {
                        AddTime = appListTable.Rows[i]["AddTime"].ToString(),
                        AppId = appListTable.Rows[i]["AppId"].ToString(),
                        AppName = appListTable.Rows[i]["AppName"].ToString(),
                        CouldBePlayed = (bool)appListTable.Rows[i]["CouldBePlayed"],
                        Country = appListTable.Rows[i]["Country"].ToString(),
                        MyGroupNumber = appListTable.Rows[i]["MyGroupNumber"].ToString(),
                        PlayAccountCount = appListTable.Rows[i]["PlayAccountCount"].ToString(),
                        PlayTime = appListTable.Rows[i]["PlayTime"].ToString(),
                        Owner = appListTable.Rows[i]["Owner"].ToString()
                    };

                    AppModelList.Add(appModel_t);
                }

                return AppModelList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw;
            }
        }

        public void UpdateCurrentGroupNumberToCountryGroupTable(string currentGroupNumber, string country)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[CountryGroup] SET [CurrentGroupNumber] = '{0}',[CurrentGroupSyncTime] = '{1}' WHERE [Country]='{2}' ",
                         currentGroupNumber, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), country);
                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public List<CountryGroupInfo> GetCountryGroupInfoListFromDb()
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[CountryGroup]");

                List<CountryGroupInfo> countryGroupInfoList = new List<CountryGroupInfo>();

                DataTable countryGroupInfoListTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (countryGroupInfoListTable == null || countryGroupInfoListTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < countryGroupInfoListTable.Rows.Count; i++)
                {
                    CountryGroupInfo countryGroupInfo_t = new CountryGroupInfo
                    {
                        AccountCount = (long)countryGroupInfoListTable.Rows[i]["AccountCount"],
                        Country = countryGroupInfoListTable.Rows[i]["Country"].ToString(),
                        CurrentGroupNumber = countryGroupInfoListTable.Rows[i]["CurrentGroupNumber"].ToString(),
                        CurrentGroupSyncTime = countryGroupInfoListTable.Rows[i]["CurrentGroupSyncTime"].ToString(),
                        MaxGroupNumber = countryGroupInfoListTable.Rows[i]["MaxGroupNumber"].ToString(),
                        MaxGroupSyncTime = countryGroupInfoListTable.Rows[i]["MaxGroupSyncTime"].ToString()
                    };

                    countryGroupInfoList.Add(countryGroupInfo_t);
                }

                return countryGroupInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw;
            }
        }

        public List<AccountInfo> GetAccountInfoListByCountryAndGroupNumber(string country, string groupNumber)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[Accounts] WHERE [Country] = '{0}' AND [Group] = '{1}' ",
                                                country, groupNumber);

                List<AccountInfo> AccountInfoList = new List<AccountInfo>();

                DataTable accountInfoListTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoListTable == null || accountInfoListTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoListTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoListTable.Rows[i]["Account"].ToString(),
                        BindingTime = accountInfoListTable.Rows[i]["BindingTime"].ToString(),
                        Country = accountInfoListTable.Rows[i]["Country"].ToString(),
                        Group = accountInfoListTable.Rows[i]["Group"].ToString(),
                        Password = accountInfoListTable.Rows[i]["Password"].ToString(),
                        PhoneType = accountInfoListTable.Rows[i]["PhoneType"].ToString(),
                        State = accountInfoListTable.Rows[i]["State"].ToString(),
                        UpdateTime = accountInfoListTable.Rows[i]["UpdateTime"].ToString(),
                        UserName = accountInfoListTable.Rows[i]["UserName"].ToString()
                    };

                    AccountInfoList.Add(accountInfo_t);
                }

                return AccountInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw;
            }
        }
    }
}
