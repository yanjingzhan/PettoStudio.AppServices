using DataBaseLib;
using Models.IOSFullInfoServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility;

namespace Controller
{
    public class IOSFullInfoServicesControl
    {
        public AppleAccountFullInfo GetAppleAccountFullInfo()
        {
            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] a,[dbo].[ApplePersonInfo] b where  a.[State]='normal' AND a.[ApplePersonInfoID]=b.[ID] order by a.[UpdateTime]");

            DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

            if (infoTable == null || infoTable.Rows.Count == 0)
            {
                throw new Exception("无数据");
            }

            AppleAccountFullInfo t = new AppleAccountFullInfo
            {
                ID = infoTable.Rows[0][0].ToString(),
                AppleAccount = infoTable.Rows[0]["AppleAccount"].ToString(),
                ApplePassword = infoTable.Rows[0]["ApplePassword"].ToString(),
                VPNAccount = infoTable.Rows[0]["VPNAccount"].ToString(),
                VPNPassword = infoTable.Rows[0]["VPNPassword"].ToString(),
                IP = infoTable.Rows[0]["IP"].ToString(),
                VerifyMail = infoTable.Rows[0]["VerifyMail"].ToString(),
                VerifyPassword = infoTable.Rows[0]["VerifyPassword"].ToString(),
                FirstQuestion = infoTable.Rows[0]["FirstQuestion"].ToString(),
                FirstAnswer = infoTable.Rows[0]["FirstAnswer"].ToString(),
                SecondQuestion = infoTable.Rows[0]["SecondQuestion"].ToString(),
                SecondAnswer = infoTable.Rows[0]["SecondAnswer"].ToString(),
                ThirdQuestion = infoTable.Rows[0]["ThirdQuestion"].ToString(),
                ThirdAnswer = infoTable.Rows[0]["ThirdAnswer"].ToString(),
                FirstName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                SecondName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
                Address = infoTable.Rows[0]["Address"].ToString(),
                City = infoTable.Rows[0]["City"].ToString(),
                Province = infoTable.Rows[0]["Province"].ToString(),
                ZipCode = infoTable.Rows[0]["ZipCode"].ToString(),
                PhoneNumber1 = infoTable.Rows[0]["PhoneNumber1"].ToString(),
                PhoneNumber2 = infoTable.Rows[0]["PhoneNumber2"].ToString(),
                Birthday = infoTable.Rows[0]["Birthday"].ToString(),
                Country = infoTable.Rows[0]["Country"].ToString(),
            };

            sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = {2}",
                               "normal", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return t;
        }

        public AppleAccountFullInfo GetAppleAccountFullInfoByState(string state,string country="")
        {
            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] a,[dbo].[ApplePersonInfo] b where  a.[State]='{0}' AND a.[ApplePersonInfoID]=b.[ID] order by a.[GetTime], a.[UpdateTime] DESC", state);
            if(!string.IsNullOrEmpty(country))
            {
                sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] a,[dbo].[ApplePersonInfo] b where  a.[State]='{0}' AND a.[Country]='{1}' AND a.[ApplePersonInfoID]=b.[ID] order by a.[GetTime], a.[UpdateTime] DESC",
                    state, country);
            }

            DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

            if (infoTable == null || infoTable.Rows.Count == 0)
            {
                throw new Exception("无数据");
            }

            AppleAccountFullInfo t = new AppleAccountFullInfo
            {
                ID = infoTable.Rows[0][0].ToString(),
                AppleAccount = infoTable.Rows[0]["AppleAccount"].ToString(),
                ApplePassword = infoTable.Rows[0]["ApplePassword"].ToString(),
                VPNAccount = infoTable.Rows[0]["VPNAccount"].ToString(),
                VPNPassword = infoTable.Rows[0]["VPNPassword"].ToString(),
                IP = infoTable.Rows[0]["IP"].ToString(),
                VerifyMail = infoTable.Rows[0]["VerifyMail"].ToString(),
                VerifyPassword = infoTable.Rows[0]["VerifyPassword"].ToString(),
                FirstQuestion = infoTable.Rows[0]["FirstQuestion"].ToString(),
                FirstAnswer = infoTable.Rows[0]["FirstAnswer"].ToString(),
                SecondQuestion = infoTable.Rows[0]["SecondQuestion"].ToString(),
                SecondAnswer = infoTable.Rows[0]["SecondAnswer"].ToString(),
                ThirdQuestion = infoTable.Rows[0]["ThirdQuestion"].ToString(),
                ThirdAnswer = infoTable.Rows[0]["ThirdAnswer"].ToString(),
                FirstName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                SecondName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
                Address = infoTable.Rows[0]["Address"].ToString(),
                City = infoTable.Rows[0]["City"].ToString(),
                Province = infoTable.Rows[0]["Province"].ToString(),
                ZipCode = infoTable.Rows[0]["ZipCode"].ToString(),
                PhoneNumber1 = infoTable.Rows[0]["PhoneNumber1"].ToString(),
                PhoneNumber2 = infoTable.Rows[0]["PhoneNumber2"].ToString(),
                Birthday = infoTable.Rows[0]["Birthday"].ToString(),
                Country = infoTable.Rows[0]["Country"].ToString(),
            };

            sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [State] = '{0}',[UpdateTime] = '{1}',[GetTime] = '{2}' WHERE [ID] = {3}",
                               state, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return t;
        }


        public AppleAccountFullInfo GetAppleAccountFullInfoAndRefreshStateByState(string state, string newState)
        {
            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] a,[dbo].[ApplePersonInfo] b where a.[State]='{0}' AND a.[ApplePersonInfoID]=b.[ID] order by a.[UpdateTime]", state);

            DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

            if (infoTable == null || infoTable.Rows.Count == 0)
            {
                throw new Exception("无数据");
            }

            AppleAccountFullInfo t = new AppleAccountFullInfo
            {
                ID = infoTable.Rows[0][0].ToString(),
                AppleAccount = infoTable.Rows[0]["AppleAccount"].ToString(),
                ApplePassword = infoTable.Rows[0]["ApplePassword"].ToString(),
                VPNAccount = infoTable.Rows[0]["VPNAccount"].ToString(),
                VPNPassword = infoTable.Rows[0]["VPNPassword"].ToString(),
                IP = infoTable.Rows[0]["IP"].ToString(),
                VerifyMail = infoTable.Rows[0]["VerifyMail"].ToString(),
                VerifyPassword = infoTable.Rows[0]["VerifyPassword"].ToString(),
                FirstQuestion = infoTable.Rows[0]["FirstQuestion"].ToString(),
                FirstAnswer = infoTable.Rows[0]["FirstAnswer"].ToString(),
                SecondQuestion = infoTable.Rows[0]["SecondQuestion"].ToString(),
                SecondAnswer = infoTable.Rows[0]["SecondAnswer"].ToString(),
                ThirdQuestion = infoTable.Rows[0]["ThirdQuestion"].ToString(),
                ThirdAnswer = infoTable.Rows[0]["ThirdAnswer"].ToString(),
                FirstName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                SecondName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
                Address = infoTable.Rows[0]["Address"].ToString(),
                City = infoTable.Rows[0]["City"].ToString(),
                Province = infoTable.Rows[0]["Province"].ToString(),
                ZipCode = infoTable.Rows[0]["ZipCode"].ToString(),
                PhoneNumber1 = infoTable.Rows[0]["PhoneNumber1"].ToString(),
                PhoneNumber2 = infoTable.Rows[0]["PhoneNumber2"].ToString(),
                Birthday = infoTable.Rows[0]["Birthday"].ToString(),
                Country = infoTable.Rows[0]["Country"].ToString(),
            };

            sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = {2}",
                               newState, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return t;
        }

        public void UpdateAccountState(string account, string state)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [AppleAccount] = '{2}'",
                                                state, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), account);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ApplePersonInfo GetApplePersonInfoAndRefreshState(string state, string newState, string country)
        {
            try
            {
                country = string.IsNullOrEmpty(country) ? "US" : country;

                string sqlCmd = string.Format("SELECT TOP 1 * from [dbo].[ApplePersonInfo] WHERE [State] = '{0}' AND [Country] = '{1}' ORDER BY [ID]", state, country);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (infoTable == null || infoTable.Rows.Count == 0)
                {
                    throw new Exception("无数据");
                }

                ApplePersonInfo t = new ApplePersonInfo
                {
                    ID = infoTable.Rows[0][0].ToString(),
                    FirstName = country.ToLower() == "china" ? infoTable.Rows[0]["FirstName"].ToString() : CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                    SecondName = country.ToLower() == "china" ? infoTable.Rows[0]["SecondName"].ToString() : CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
                    Address = infoTable.Rows[0]["Address"].ToString(),
                    City = infoTable.Rows[0]["City"].ToString(),
                    Province = infoTable.Rows[0]["Province"].ToString(),
                    ZipCode = infoTable.Rows[0]["ZipCode"].ToString(),
                    PhoneNumber1 = infoTable.Rows[0]["PhoneNumber1"].ToString(),
                    PhoneNumber2 = infoTable.Rows[0]["PhoneNumber2"].ToString(),
                    Country = infoTable.Rows[0]["Country"].ToString(),
                };

                sqlCmd = string.Format("UPDATE [dbo].[ApplePersonInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = {2}",
                                   newState, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), t.ID);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

                return t;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateApplePersonInfoStateByID(string state, string id)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[ApplePersonInfo] SET [State] = '{0}'  WHERE [ID] = '{1}'",
                                                state, id);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void AddNewAppleAccountToDB(AppleAccountFullInfo appleAccount, string state)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.Instance.ConnectionString))
                {
                    conn.Open();

                    string sqlCmd = string.Format("SELECT [ID] FROM [dbo].[AppleAccountFullInfo] WHERE [AppleAccount] = '{0}'", appleAccount.AppleAccount);
                    SqlCommand cmd = new SqlCommand(sqlCmd, conn);

                    var t = cmd.ExecuteScalar();
                    if (t != null)
                    {
                        throw new Exception(string.Format("{0} 已经存在库中!", appleAccount.AppleAccount));
                    }

                    string updatetime = DateTime.Now.ToString();

                    sqlCmd = string.Format("INSERT INTO [dbo].[AppleAccountFullInfo] ([AppleAccount],[ApplePassword],[VPNAccount],[VPNPassword],[IP],[VerifyMail],[VerifyPassword],[FirstQuestion],[FirstAnswer],[SecondQuestion],[SecondAnswer],[ThirdQuestion],[ThirdAnswer],[FirstName],[SecondName],[Birthday],[Country],[ApplePersonInfoID],[State],[AddTime],[UpdateTime]) VALUES " +
                                            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')",
                                            appleAccount.AppleAccount, appleAccount.ApplePassword, appleAccount.VPNAccount, appleAccount.VPNPassword, appleAccount.IP, appleAccount.VerifyMail, appleAccount.VerifyPassword, appleAccount.FirstQuestion, appleAccount.FirstAnswer, appleAccount.SecondQuestion, appleAccount.SecondAnswer, appleAccount.ThirdQuestion, appleAccount.ThirdAnswer,
                                            appleAccount.FirstName, appleAccount.SecondName, appleAccount.Birthday, appleAccount.Country, appleAccount.ApplePersonInfoID, state, updatetime, updatetime);

                    cmd.CommandText = sqlCmd;
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public AppleAccountFullInfo GetAppAccountByChangeCountryState(string country, string newCountry, string state, string oldChangeCountryState, string newChangeCountryState)
        {
            ApplePersonInfo personInfo = GetApplePersonInfoAndRefreshState("tobebinding", "binding", newCountry);

            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] WHERE [State] = '{0}' AND [ChangeCountryState] = '{1}' AND [Country] = '{2}' order by [ID] DESC",
                state, oldChangeCountryState, country);


            if (string.IsNullOrEmpty(oldChangeCountryState) || oldChangeCountryState.ToLower() == "null")
            {
                sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] WHERE [State] = '{0}' AND [ChangeCountryState] is null AND [Country] = '{1}' order by [ID] DESC",
                state, country);
            }

            DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

            if (infoTable == null || infoTable.Rows.Count == 0)
            {
                throw new Exception("无数据");
            }

            AppleAccountFullInfo t = new AppleAccountFullInfo
            {
                ID = infoTable.Rows[0][0].ToString(),
                AppleAccount = infoTable.Rows[0]["AppleAccount"].ToString(),
                ApplePassword = infoTable.Rows[0]["ApplePassword"].ToString(),
                VPNAccount = infoTable.Rows[0]["VPNAccount"].ToString(),
                VPNPassword = infoTable.Rows[0]["VPNPassword"].ToString(),
                IP = infoTable.Rows[0]["IP"].ToString(),
                VerifyMail = infoTable.Rows[0]["VerifyMail"].ToString(),
                VerifyPassword = infoTable.Rows[0]["VerifyPassword"].ToString(),
                FirstQuestion = infoTable.Rows[0]["FirstQuestion"].ToString(),
                FirstAnswer = infoTable.Rows[0]["FirstAnswer"].ToString(),
                SecondQuestion = infoTable.Rows[0]["SecondQuestion"].ToString(),
                SecondAnswer = infoTable.Rows[0]["SecondAnswer"].ToString(),
                ThirdQuestion = infoTable.Rows[0]["ThirdQuestion"].ToString(),
                ThirdAnswer = infoTable.Rows[0]["ThirdAnswer"].ToString(),
                //FirstName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                //SecondName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
                Birthday = infoTable.Rows[0]["Birthday"].ToString(),
                Country = infoTable.Rows[0]["Country"].ToString(),
                ApplePersonInfoID = personInfo.ID,
                Address = personInfo.Address,
                City = personInfo.City,
                PhoneNumber1 = personInfo.PhoneNumber1,
                PhoneNumber2 = personInfo.PhoneNumber2,
                Province = personInfo.Province,
                ZipCode = personInfo.ZipCode,
                FirstName = personInfo.FirstName,
                SecondName = personInfo.SecondName,
            };

            sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [ChangeCountryState] = '{0}' WHERE [ID] = {1}",
                               newChangeCountryState, t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return t;
        }

        public void UpdateCountryAndChangeCountryStateByID(string country, string changeCountryState, string applePersonInfoID, string id)
        {
            try
            {
                string sqlCmd_GetPerson = string.Format("SELECT * from [dbo].[ApplePersonInfo] WHERE [ID] = {0}", applePersonInfoID);

                DataTable infoTable_Persion = SqlHelper.Instance.ExecuteDataTable(sqlCmd_GetPerson);

                if (infoTable_Persion == null || infoTable_Persion.Rows.Count == 0)
                {
                    throw new Exception("没查询到人物信息");
                }

                ApplePersonInfo t = new ApplePersonInfo
                {
                    ID = infoTable_Persion.Rows[0][0].ToString(),
                    FirstName = country.ToLower() == "china" ? infoTable_Persion.Rows[0]["FirstName"].ToString() : CharsHelper.ConvertToPinYin(infoTable_Persion.Rows[0]["FirstName"].ToString()),
                    SecondName = country.ToLower() == "china" ? infoTable_Persion.Rows[0]["SecondName"].ToString() : CharsHelper.ConvertToPinYin(infoTable_Persion.Rows[0]["SecondName"].ToString()),
                    Address = infoTable_Persion.Rows[0]["Address"].ToString(),
                    City = infoTable_Persion.Rows[0]["City"].ToString(),
                    Province = infoTable_Persion.Rows[0]["Province"].ToString(),
                    ZipCode = infoTable_Persion.Rows[0]["ZipCode"].ToString(),
                    PhoneNumber1 = infoTable_Persion.Rows[0]["PhoneNumber1"].ToString(),
                    PhoneNumber2 = infoTable_Persion.Rows[0]["PhoneNumber2"].ToString(),
                    Country = infoTable_Persion.Rows[0]["Country"].ToString(),
                };

                string sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [Country] = '{0}',[ChangeCountryState] = '{1}',[ApplePersonInfoID] = '{2}',[FirstName] = '{3}',[SecondName] = '{4}'  WHERE [ID] = '{5}'",
                                                country, changeCountryState, applePersonInfoID,
                                                t.FirstName, t.SecondName, id);

                if (string.IsNullOrEmpty(applePersonInfoID) || applePersonInfoID.ToLower() == "null" || applePersonInfoID.ToLower() == "-1")
                {
                    sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [Country] = '{0}',[ChangeCountryState] = '{1}'  WHERE [ID] = '{2}'",
                                                country, changeCountryState, id);
                }

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public AppleAccountFullInfo GetAppAccountByCountryAndShuaVungleState(string country, string state, string oldShuaVungleState, string newShuaVungleState)
        {
            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] WHERE [State] = '{0}' AND [ShuaVungleState] = '{1}' AND [Country] = '{2}' order by [ID] DESC",
                state, oldShuaVungleState, country);


            if (string.IsNullOrEmpty(oldShuaVungleState) || oldShuaVungleState.ToLower() == "null")
            {
                sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] WHERE [State] = '{0}' AND [ShuaVungleState] is null AND [Country] = '{1}' order by [ID] DESC",
                state, country);
            }

            DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

            if (infoTable == null || infoTable.Rows.Count == 0)
            {
                throw new Exception("无数据");
            }

            AppleAccountFullInfo t = new AppleAccountFullInfo
            {
                ID = infoTable.Rows[0][0].ToString(),
                AppleAccount = infoTable.Rows[0]["AppleAccount"].ToString(),
                ApplePassword = infoTable.Rows[0]["ApplePassword"].ToString(),
                VPNAccount = infoTable.Rows[0]["VPNAccount"].ToString(),
                VPNPassword = infoTable.Rows[0]["VPNPassword"].ToString(),
                IP = infoTable.Rows[0]["IP"].ToString(),
                VerifyMail = infoTable.Rows[0]["VerifyMail"].ToString(),
                VerifyPassword = infoTable.Rows[0]["VerifyPassword"].ToString(),
                FirstQuestion = infoTable.Rows[0]["FirstQuestion"].ToString(),
                FirstAnswer = infoTable.Rows[0]["FirstAnswer"].ToString(),
                SecondQuestion = infoTable.Rows[0]["SecondQuestion"].ToString(),
                SecondAnswer = infoTable.Rows[0]["SecondAnswer"].ToString(),
                ThirdQuestion = infoTable.Rows[0]["ThirdQuestion"].ToString(),
                ThirdAnswer = infoTable.Rows[0]["ThirdAnswer"].ToString(),
                FirstName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                SecondName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
                Birthday = infoTable.Rows[0]["Birthday"].ToString(),
                Country = infoTable.Rows[0]["Country"].ToString(),
            };

            sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [ShuaVungleState] = '{0}' WHERE [ID] = {1}",
                               newShuaVungleState, t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return t;
        }

        public void UpdateShuaVungleStateByID(string shuaVungleState, string id)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[AppleAccountFullInfo] SET [ShuaVungleState] = '{0}' WHERE [ID] = '{1}'",
                                                shuaVungleState, id);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
