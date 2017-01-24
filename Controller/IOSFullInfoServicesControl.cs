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

        public AppleAccountFullInfo GetAppleAccountFullInfoByState(string state)
        {
            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] a,[dbo].[ApplePersonInfo] b where  a.[State]='{0}' AND a.[ApplePersonInfoID]=b.[ID] order by a.[UpdateTime]", state);

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
                               state, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return t;
        }

        public AppleAccountFullInfo GetAppleAccountFullInfoAndRefreshStateByState(string state,string newState)
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

        public ApplePersonInfo GetApplePersonInfoAndRefreshState(string state, string newState)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP 1 * from [dbo].[ApplePersonInfo] WHERE [State] = '{0}' ORDER BY [ID]", state);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (infoTable == null || infoTable.Rows.Count == 0)
                {
                    throw new Exception("无数据");
                }

                ApplePersonInfo t = new ApplePersonInfo
                {
                    ID = infoTable.Rows[0][0].ToString(),
                    FirstName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
                    SecondName = CharsHelper.ConvertToPinYin(infoTable.Rows[0]["SecondName"].ToString()),
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
    }
}
