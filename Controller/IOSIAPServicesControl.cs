using DataBaseLib;
using Models.IOSFullInfoServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Controller
{
    public class IOSIAPServicesControl
    {
        public void InsertIAPRecord(AppleIAPRecord appleIAPRecord)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [AppleIAPUser] WHERE [Account] = '{0}' AND [Password] = '{1}' AND State = '{2}'", appleIAPRecord.Account, appleIAPRecord.Password, "normal");

                object t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                if (t == null || t.ToString() == "0")
                {
                    throw new Exception("身份验证失败！");
                }


                sqlCmd = string.Format("SELECT COUNT(*) FROM [AppleIAPRecord] WHERE [Guid] = '{0}'", appleIAPRecord.GUID);

                t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                if (t != null && t.ToString() != "0")
                {
                    throw new Exception("已存在该数据");
                }


                sqlCmd = string.Format("INSERT INTO [dbo].[AppleIAPRecord] ([Account],[Password],[GameName],[Score],[GUID],[State],[AddTime],[UpdateTime],[Date]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                                    appleIAPRecord.Account, appleIAPRecord.Password, appleIAPRecord.GameName, appleIAPRecord.Score, appleIAPRecord.GUID, "normal", DateTime.Now.ToString(), DateTime.Now.ToString(), DateTime.Today.ToString("yyyy-MM-dd"));
                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch
            {
                throw;
            }
        }

        public void Login(string account, string password)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [AppleIAPUser] WHERE [Account] = '{0}' AND [Password] = '{1}' AND State = '{2}'", account, password, "normal");

                object t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                if (t == null || t.ToString() == "0")
                {
                    throw new Exception("身份验证失败！");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetSumScoreByAccount(string account, string password, string gameName)
        {
            try
            {
                Login(account, password);

                string sqlCmd = string.Format("SELECT Sum(convert(int,[Score]))FROM [dbo].[AppleIAPRecord] WHERE [Account] = '{0}' AND [GameName] = '{1}'", account, gameName);

                object t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                return t.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //SELECT Sum(convert(int,[Score])) as [Sum] ,[Date] FROM [dbo].[AppleIAPRecord] WHERE [Account] = 'Accountshit' AND DATEDIFF(Day,[Date],getdate())<1  GROUP BY [Date]

        public List<IAPRecordItemModel> GetIAPRecordItemModelLstByAccount(string account, string password, string gameName, string daysCount)
        {
            try
            {
                Login(account, password);
                List<IAPRecordItemModel> result = new List<IAPRecordItemModel>();

                string sqlCmd = string.Format("SELECT Sum(convert(int,[Score])) as [Sum],[Date] FROM [dbo].[AppleIAPRecord] WHERE [Account] = '{0}' AND [GameName] = '{1}' AND DATEDIFF(Day,[Date],getdate())< {2} GROUP BY [Date] ORDER BY [Date] DESC",
                                 account, gameName, daysCount);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (infoTable == null || infoTable.Rows.Count == 0)
                {
                    throw new Exception("无数据");
                }

                for (int i = 0; i < infoTable.Rows.Count; i++)
                {
                    IAPRecordItemModel item_t = new IAPRecordItemModel
                    {
                        ID = (i + 1).ToString(),
                        Date = infoTable.Rows[i]["Date"].ToString(),
                        TotalScore = infoTable.Rows[i]["Sum"].ToString(),
                    };

                    result.Add(item_t);
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
