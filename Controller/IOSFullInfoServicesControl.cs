using DataBaseLib;
using Models.IOSFullInfoServices;
using System;
using System.Collections.Generic;
using System.Data;
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
                FirstName =  CharsHelper.ConvertToPinYin(infoTable.Rows[0]["FirstName"].ToString()),
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
            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AppleAccountFullInfo] a,[dbo].[ApplePersonInfo] b where  a.[State]='{0}' AND a.[ApplePersonInfoID]=b.[ID] order by a.[UpdateTime]",state);

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
    }
}
