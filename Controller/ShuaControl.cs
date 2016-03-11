using DataBaseLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utility;
using System.Collections.Generic;
using Models.ShuaRecord;
using System.Data;

namespace Controller
{
    public class ShuaControl
    {
        public void AddShuaRecordToDataBase(string country, string shuaSucCount, string shuaFailCount)
        {
            try
            {
                string sqlCmdSelect = string.Format("SELECT COUNT(*) FROM [dbo].[ShuaRecord] WHERE [Date]='{0}' AND [Country]='{1}'",
                                            DateTime.Now.Date.ToString("yyyy/MM/dd"), country);

                string sqlCmdAddRecord = string.Format("INSERT INTO [dbo].[ShuaRecord] ([Date],[ShuaSucCount],[ShuaFailCount],[Country],[UpdateTime]) VALUES ('{0}',{1},{2},'{3}','{4}')",
                                            DateTime.Now.Date.ToString("yyyy/MM/dd"), shuaSucCount, shuaFailCount, country, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                var c = SqlHelper.Instance.ExecuteScalar(sqlCmdSelect);
                if (c != null && c.ToString() != "0")
                {
                    sqlCmdAddRecord = string.Format("Update [dbo].[ShuaRecord] SET [ShuaSucCount]=[ShuaSucCount]+{0},[ShuaFailCount]=[ShuaFailCount]+{1},[UpdateTime]='{2}' WHERE [Date]='{3}'AND [Country]='{4}'",
                                            shuaSucCount, shuaFailCount, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.Date.ToString("yyyy/MM/dd"), country);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmdAddRecord);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                throw ex;
            }
        }

        public List<ShuaRecordModel> GetShuaRecordFromDataBase(string startDate, string endDate)
        {
            try
            {
                string sqlCmdSelect = string.Format("SELECT * FROM [dbo].[ShuaRecord] WHERE [Date]>='{0}' AND [Date]<='{1}'",
                                        startDate, endDate);


                DataTable accountInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmdSelect);

                if (accountInfoTable == null || accountInfoTable.Rows.Count == 0)
                {
                    return null;
                }

                List<ShuaRecordModel> shuaRecordModelList = new List<ShuaRecordModel>();
                for (int i = 0; i < accountInfoTable.Rows.Count; i++)
                {
                    ShuaRecordModel shuaRecordModel_t = new ShuaRecordModel
                    {
                        Country = accountInfoTable.Rows[i]["Country"].ToString(),
                        UpdateTime = accountInfoTable.Rows[i]["UpdateTime"].ToString(),
                        Date = accountInfoTable.Rows[i]["Date"].ToString(),
                        ShuaFailCount = accountInfoTable.Rows[i]["ShuaFailCount"].ToString(),
                        ShuaSucCount = accountInfoTable.Rows[i]["ShuaSucCount"].ToString()
                    };

                    shuaRecordModelList.Add(shuaRecordModel_t);
                }

                return shuaRecordModelList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

    }
}
