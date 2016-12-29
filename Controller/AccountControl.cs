using DataBaseLib;
using Models.AccountServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Utility;

namespace Controller
{
    public class AccountControl
    {
        public List<AccountInfo> GetXboxStateAccountInfoList(string userName, int accountCount)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                //string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [UserName]='{1}' AND [State]='xbox' ORDER BY [AddTime],[UpdateTime]",
                //                              accountCount.ToString(), userName);

                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [UserName]='{1}' AND [State]='xbox' ORDER BY [Country], NEWID()",
                                              accountCount.ToString(), userName);


                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> GetAccountInfoListByState(string userName, string state, int accountCount)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                //随机取
                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [UserName]='{1}' AND [State]='{2}' ORDER BY NEWID()",
                                              accountCount.ToString(), userName, state);

                //string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [UserName]='{1}' AND [State]='{2}' ORDER BY [AddTime],[UpdateTime]",
                //                              accountCount.ToString(), userName, state);


                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> GetAccountInfoListByStateWithOutName(string state, int accountCount)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State]='{1}' ORDER BY NEWID()",
                                              accountCount.ToString(), state);

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> GetAccountInfoListByStateWithOutNameButCountry(string state, int accountCount, string Country)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State]='{1}' AND [Country]='{2}' ORDER BY [AddTime],[UpdateTime]",
                                              accountCount.ToString(), state, Country);

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }


        public List<AccountInfo> GetAccountInfoListForShouDong(int accountCount, string country, string userName, string person)
        {
            try
            {
                //Log.Write("开始" + DateTime.Now.ToString(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "test");

                using (SqlConnection conn = new SqlConnection(SqlHelper.Instance.ConnectionString))
                {
                    conn.Open();

                    string sqlCmd_t = string.Format("SELECT [ShouDongCountry] FROM [dbo].[ShouDongNumber]");

                    SqlCommand cmd = new SqlCommand(sqlCmd_t, conn);
                    string country_t = cmd.ExecuteScalar().ToString();

                    string sqlCmd = string.Format("SELECT ShouDongCurrentNumber FROM [dbo].[ShouDongNumber]");
                    cmd.CommandText = sqlCmd;
                    int currentGroupNumber = int.Parse(cmd.ExecuteScalar().ToString());

                    List<AccountInfo> AdInfoList = new List<AccountInfo>();

                    sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] ='binding' AND [Country]='{1}' AND [ShouDongGroupDone]<{2} AND ([UserName]='{3}' OR [UserName]='{3}.d') ORDER BY [ID] DESC",
                                  accountCount.ToString(), country_t, currentGroupNumber, userName);

                    //用username区分手机版本。1为wp8，7为wp7（库中的username依然为1）
                    if (userName == "1")
                    {
                        sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] !='die' AND [ShouDongGroupDone]<{2} AND ([UserName]='{3}' OR [UserName]='{3}.d') ORDER BY [ID] DESC",
                                  accountCount.ToString(), country, currentGroupNumber, userName);
                    }

                    if (userName == "7")
                    {
                        sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] ='xboxed' AND [ShouDongGroupDone]<{2} AND ([UserName]='1' OR [UserName]='1.d') ORDER BY [ID] DESC",
                                  accountCount.ToString(), country, currentGroupNumber, userName);
                    }

                    SqlDataAdapter da = new SqlDataAdapter("sp_GetGetAccountInfoListForShouDong", conn);

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@currentGroupNumber", currentGroupNumber);
                    da.SelectCommand.Parameters.AddWithValue("@userName", userName);
                    da.SelectCommand.Parameters.AddWithValue("@updateTime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    da.SelectCommand.Parameters.AddWithValue("@country", country);

                    DataTable accountInfoTable = new DataTable();
                    da.Fill(accountInfoTable);

                    if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                    {
                        return null;
                    }

                    for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                    {
                        AccountInfo accountInfo_t = new AccountInfo
                        {
                            Account = accountInfoTable.Rows[i]["Account"].ToString(),
                            Password = accountInfoTable.Rows[i]["Password"].ToString(),
                            UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                            Country = accountInfoTable.Rows[i]["Country"].ToString(),
                            State = accountInfoTable.Rows[i]["State"].ToString(),
                            PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                            Group = accountInfoTable.Rows[i]["Group"].ToString(),
                            UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                            BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                        };

                        AdInfoList.Add(accountInfo_t);
                    }

                    if (AdInfoList.Count > 0)
                    {
                        string sqlCmdSelect = string.Format("SELECT COUNT(*) FROM [dbo].[ShuaRecord] WHERE [Date]='{0}' AND [Country]='{1}'",
                                                                   DateTime.Now.Date.ToString("yyyy/MM/dd"), country);

                        string sqlCmdAddRecord = string.Format("INSERT INTO [dbo].[ShuaRecord] ([Date],[ShuaSucCount],[ShuaFailCount],[Country],[UpdateTime]) VALUES ('{0}',{1},{2},'{3}','{4}')",
                                                    DateTime.Now.Date.ToString("yyyy/MM/dd"), AdInfoList.Count, "0", country, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                        cmd.CommandText = sqlCmdSelect;
                        var c = cmd.ExecuteScalar();
                        if (c != null && c.ToString() != "0")
                        {
                            sqlCmdAddRecord = string.Format("Update [dbo].[ShuaRecord] SET [ShuaSucCount]=[ShuaSucCount]+{0},[ShuaFailCount]=[ShuaFailCount]+{1},[UpdateTime]='{2}' WHERE [Date]='{3}'AND [Country]='{4}'",
                                                    AdInfoList.Count, "0", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.Date.ToString("yyyy/MM/dd"), country);
                        }

                        cmd.CommandText = sqlCmdAddRecord;
                        cmd.ExecuteNonQuery();
                    }

                    //Dictionary<string, string> dt = new Dictionary<string, string>();
                    //dt.Add("@person", person);
                    //dt.Add("@today", DateTime.Now.ToString("yyyy-MM-dd"));
                    //dt.Add("@updatetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd"));

                    //SqlHelper.Instance.ExecuteProcedure("sp_AddShuaCount", dt);

                    cmd.CommandText = "sp_AddShuaCount";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@person", person);
                    cmd.Parameters.AddWithValue("@today", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@updatetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd"));

                    cmd.ExecuteNonQuery();

                    //Log.Write("结束" + DateTime.Now.ToString(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "test");

                    return AdInfoList;
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> GetAccountInfoListForShuaJi(int accountCount)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] !='die' AND [IsDevAccount] is NULL ORDER BY [ID] DESC",
                              accountCount.ToString());

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                if (AdInfoList.Count > 0)
                {
                    foreach (var ai in AdInfoList)
                    {
                        string sql_t = string.Format("UPDATE [dbo].[Accounts] SET [IsDevAccount] = 0,[ShouDongTime]='{0}' WHERE [Account] = '{1}'",
                                                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ai.Account);
                        SqlHelper.Instance.ExecuteScalar(sql_t);
                    }
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> GetAccountListByStateAndRefreshState(int count, string state, string newState)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] ='{1}' ORDER BY [ID] DESC",
                                                 count.ToString(), state);

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                if (AdInfoList.Count > 0)
                {
                    foreach (var ai in AdInfoList)
                    {
                        string sql_t = string.Format("UPDATE [dbo].[Accounts] SET [State]= '{0}' WHERE [Account] = '{1}'",
                                                    newState, ai.Account);
                        SqlHelper.Instance.ExecuteScalar(sql_t);
                    }
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }


        public List<AccountInfo> GetAccountListByStateCountryAndRefreshState(int count, string country, string state, string newState)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                string time_t = DateTime.Now.Subtract(TimeSpan.FromMinutes(10)).ToString("yyyy/MM/dd HH:mm:ss");
                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] ='{1}' AND [Country] = '{2}' AND [AddTime] < '{3}' ORDER BY [ID] DESC",
                    //"ORDER BY NEWID()",
                                                 count.ToString(), state, country, time_t);

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                if (AdInfoList.Count > 0)
                {
                    foreach (var ai in AdInfoList)
                    {
                        string sql_t = string.Format("UPDATE [dbo].[Accounts] SET [State]= '{0}' WHERE [Account] = '{1}'",
                                                    newState, ai.Account);
                        SqlHelper.Instance.ExecuteScalar(sql_t);
                    }

                    if (state == "xboxed")
                    {
                        new ShuaControl().AddShuaRecordToDataBase(country + "_7", AdInfoList.Count.ToString(), "0");
                    }
                    else
                    {
                        new ShuaControl().AddShuaRecordToDataBase(country, AdInfoList.Count.ToString(), "0");
                    }
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> CheckAccount(string accountCount)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State] !='die' ORDER BY [CheckTime]",
                                              accountCount);

                List<AccountInfo> AdInfoList = new List<AccountInfo>();
                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                if (AdInfoList.Count > 0)
                {
                    foreach (var ai in AdInfoList)
                    {
                        string sql_t = string.Format("UPDATE [dbo].[Accounts] SET [CheckTime]='{0}' WHERE [Account] = '{1}'",
                                                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ai.Account);
                        SqlHelper.Instance.ExecuteScalar(sql_t);
                    }
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public List<AccountInfo> GetAccountInfoListByStateAndAddTime(string state, int accountCount, string addTime)
        {
            try
            {
                List<AccountInfo> AdInfoList = new List<AccountInfo>();

                string sqlCmd = string.Format("SELECT TOP {0} * FROM [dbo].[Accounts] WHERE [State]='{1}' AND [AddTime] < '{2}' ORDER BY [AddTime],[UpdateTime]",
                                              accountCount.ToString(), state, addTime);
                if (accountCount == 0)
                {
                    sqlCmd = string.Format("SELECT * FROM [dbo].[Accounts] WHERE [State]='{1}' AND [AddTime] < '{2}' ORDER BY [AddTime],[UpdateTime]",
                                              accountCount.ToString(), state, addTime);
                }

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    AccountInfo accountInfo_t = new AccountInfo
                    {
                        Account = accountInfoTable.Rows[i]["Account"].ToString(),
                        Password = accountInfoTable.Rows[i]["Password"].ToString(),
                        UserName = accountInfoTable.Rows[i]["UserName"].ToString(),
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        State = accountInfoTable.Rows[i]["State"].ToString(),
                        PhoneType = accountInfoTable.Rows[i]["PhoneType"].ToString(),
                        Group = accountInfoTable.Rows[i]["Group"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        BindingTime = accountInfoTable.Rows[i]["BindingTime"].ToString()
                    };

                    AdInfoList.Add(accountInfo_t);
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }


        public void UpdateAccountState(string userName, string account, string state)
        {
            try
            {
                string sqlCmdUpdate = string.Empty;
                if (state == "tubevia")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[BindingTime] = '{2}' WHERE [UserName]= '{3}' AND [Account]= '{4}' ",
                                           state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), userName, account);
                }
                else if (state == "die")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[Group]= '' WHERE [UserName]='{2}' AND [Account]='{3}' ",
                         state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), userName, account);
                }
                else
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [UserName]='{2}' AND [Account]='{3}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), userName, account);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAccountStateWithoutUserName(string account, string state)
        {
            try
            {
                string sqlCmdUpdate = string.Empty;
                if (state == "tubevia")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[BindingTime] = '{2}' WHERE [Account]= '{3}' ",
                                           state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account);
                }
                else if (state == "die")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[Group]= '' WHERE [Account]='{2}' ",
                         state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account);
                }
                else
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [Account]='{2}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAccountStateAndUserName(string account, string state, string userName)
        {
            try
            {
                string sqlCmdUpdate = string.Empty;
                if (state == "tubevia")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[BindingTime] = '{2}',[UserName]='{4}' WHERE [Account]= '{3}' ",
                                           state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account, userName);
                }
                else if (state == "die")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[Group]= '',[UserName]='{3}' WHERE [Account]='{2}' ",
                         state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account, userName);
                }
                else
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[UserName]='{3}' WHERE [Account]='{2}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account, userName);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAccountStatePhoneType(string userName, string account, string state, string phoneType)
        {
            try
            {
                string sqlCmdUpdate = string.Empty;

                if (state == "tubevia")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[BindingTime] = '{3}' WHERE [UserName]='{4}' AND [Account]='{5}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), userName, account);
                }
                else if (state == "die")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[Group]= '' WHERE [UserName]='{3}' AND [Account]='{4}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, userName, account);

                }
                else if (state == "binding")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[Group]= '',[UserName]='{3}.d' WHERE [UserName]='{3}' AND [Account]='{4}' ",
                         state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, userName, account);
                }
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[Group]= '' WHERE [UserName]='{3}' AND [Account]='{4}' ",
                         state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, userName, account);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAccountStatePhoneTypeCountry(string userName, string account, string state, string phoneType, string country)
        {
            try
            {
                string sqlCmdUpdate = string.Empty;

                if (state == "tubevia")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[BindingTime] = '{3}',[Country]= '{4}' WHERE [UserName]='{5}' AND [Account]='{6}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), country, userName, account);
                }
                else if (state == "die")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[Group]= '',[Country]= '{3}' WHERE [UserName]='{4}' AND [Account]='{5}' ",
                                             state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, country, userName, account);

                }
                else if (state == "binding")
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[Group]= '',[Country]= '{3}',[UserName]='{4}.d' WHERE [UserName]='{4}' AND [Account]='{5}' ",
                        state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, country, userName, account);
                }
                else
                {
                    sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [State] = '{0}',[UpdateTime] = '{1}',[PhoneType] = '{2}',[Group]= '',[Country]= '{3}' WHERE [UserName]='{4}' AND [Account]='{5}' ",
                         state, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), phoneType, country, userName, account);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void UpdateAccountCountryAndGroup(string account, string country, string group)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[Accounts] SET [Country]= '{0}',[Group]= '{1}',[UpdateTime] = '{2}' WHERE [Account]='{3}' ",
                                                country, group, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), account);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public void InsertAccount(AccountInfo accountInfo, string ip = "0.0.0.0", string computerName = "")
        {
            try
            {
                string sqlCmdSelect = string.Format("SELECT COUNT(*) FROM [dbo].[Accounts] WHERE [Account]= '{0}'", accountInfo.Account);
                var c = SqlHelper.Instance.ExecuteScalar(sqlCmdSelect);
                if (c != null && c.ToString() != "0")
                {
                    throw new Exception(string.Format("{0} has been is DB!", accountInfo.Account));
                }

                string sqlCmdInsert = string.Format("INSERT INTO [dbo].[Accounts] ([Account],[Password],[UserName],[Country],[State],[Group],[PhoneType],[UpdateTime],[AddTime],[ShouDongGroupDone],[IP],[Computername]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                    accountInfo.Account, accountInfo.Password, accountInfo.UserName, accountInfo.Country, accountInfo.State, accountInfo.Group, accountInfo.PhoneType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "0", ip, computerName);
                SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        #region 账号归组

        public List<string> GetCountryList()
        {
            try
            {
                string sqlCmd = string.Format("SELECT DISTINCT [Country] FROM [dbo].[Accounts]");

                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<string> countryList = new List<string>();
                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    countryList.Add(accountInfoTable.Rows[i][0].ToString());
                }

                return countryList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public int GetBindingAccountCountByCountry(string country)
        {
            try
            {
                string sqlCmd = string.Format("SELECT Count(*) FROM [dbo].[Accounts] WHERE [Country]='{0}' AND [State]='binding' AND [Group]=''",
                                                country);

                return Convert.ToInt32(SqlHelper.Instance.ExecuteScalar(sqlCmd));
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return 0;
            }
        }

        public int GetMaxGroupNumberByCountry(string country)
        {
            try
            {
                string sqlCmd = string.Format("SELECT Max(convert(int,[Group])) FROM [dbo].[Accounts] WHERE [Country]='{0}'",
                                                country);

                return Convert.ToInt32(SqlHelper.Instance.ExecuteScalar(sqlCmd));
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return 0;
            }
        }

        public void GroupAccountByContry(string country, string groupNumber, string accountCount)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [Group]='{0}' WHERE [Account] in "
                                            + "(SELECT Top {1} [Account] FROM [dbo].[Accounts] WHERE [Group]='' AND [Country]='{2}' AND [State]='binding' ORDER by [AddTime],[UpdateTime])",
                                                groupNumber, accountCount, country);

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
            }
        }

        public void KillUpperThanMaxGroupNumber(string country, int maxGroupNumber)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[Accounts] SET [Group]='' WHERE [Country]='{0}' AND [Group]>{1}",
                                                country, maxGroupNumber);

                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
            }
        }

        public int GetGroupAccountCountByContry(string country, string groupNumber)
        {
            try
            {
                string sqlCmd = string.Format("SELECT Count([ID]) FROM [dbo].[Accounts] WHERE [Country]='{0}' AND [Group]='{1}'",
                                                country, groupNumber);

                return Convert.ToInt32(SqlHelper.Instance.ExecuteScalar(sqlCmd));
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return -1;
            }
        }


        public CountryGroupInfo GetCountryGroupInfoByContryName(string country)
        {
            try
            {
                string sqlCmd = string.Format("SELECT * FROM [dbo].[CountryGroup] WHERE [Country]='{0}' ",
                                                country);

                DataTable countryGroupInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (countryGroupInfoTable == null || countryGroupInfoTable.Rows.Count == 0)
                {
                    return new CountryGroupInfo { AccountCount = -1 };
                }

                CountryGroupInfo cgi = new CountryGroupInfo();
                cgi.Country = countryGroupInfoTable.Rows[0]["Country"].ToString();
                cgi.CurrentGroupNumber = countryGroupInfoTable.Rows[0]["CurrentGroupNumber"].ToString();
                cgi.MaxGroupNumber = countryGroupInfoTable.Rows[0]["MaxGroupNumber"].ToString();
                cgi.CurrentGroupSyncTime = countryGroupInfoTable.Rows[0]["CurrentGroupSyncTime"].ToString();
                cgi.MaxGroupSyncTime = countryGroupInfoTable.Rows[0]["MaxGroupSyncTime"].ToString();
                cgi.AccountCount = int.Parse(countryGroupInfoTable.Rows[0]["AccountCount"].ToString());


                return cgi;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        public void InsertInfoIntoCountryGroupTable(CountryGroupInfo cgi)
        {
            try
            {

                string sqlCmdInsert = string.Format("INSERT INTO [dbo].[CountryGroup] ([Country],[CurrentGroupNumber],[MaxGroupNumber],[CurrentGroupSyncTime],[AccountCount],[MaxGroupSyncTime]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                   cgi.Country, cgi.CurrentGroupNumber, cgi.MaxGroupNumber, cgi.CurrentGroupSyncTime, cgi.AccountCount, cgi.MaxGroupSyncTime);
                SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
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
            }
        }

        public void UpdateMaxGroupNumberAndAccountCountToCountryGroupTable(string MaxGroupNumber, string accountCount, string country)
        {
            try
            {
                string sqlCmdUpdate = string.Format("UPDATE [dbo].[CountryGroup] SET [MaxGroupNumber] = '{0}',[MaxGroupSyncTime] = '{1}',[AccountCount] = '{2}' WHERE [Country]='{3}' ",
                         MaxGroupNumber, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), accountCount, country);
                SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
            }
        }

        public int GetBindingAccountCountInGroupByCountry(string country)
        {
            try
            {
                string sqlCmd = string.Format("SELECT Count(*) FROM [dbo].[Accounts] WHERE [Country]='{0}' AND [State]='binding' AND [Group]<>''",
                                                country);

                return Convert.ToInt32(SqlHelper.Instance.ExecuteScalar(sqlCmd));
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return 0;
            }
        }


        #endregion

    }
}
