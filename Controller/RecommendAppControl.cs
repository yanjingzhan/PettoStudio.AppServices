using DataBaseLib;
using Models.In;
using Models.Out;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Utility;

namespace Controller
{
    public class RecommendAppControl
    {
        public List<RecommendAppModel> GetRecommendAppList(RecommendAppGetter getter)
        {
            try
            {
                List<RecommendAppModel> recommendAppList = new List<RecommendAppModel>();

                string sqlCmd = string.Format("SELECT * FROM [dbo].[RecommendAppList] WHERE [RecommendAppListId]='{0}'",
                                            getter.RecommendAppListId);

                DataTable recommendAppListTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (recommendAppListTable == null || recommendAppListTable.Rows.Count == 0)
                {
                    throw new Exception("无数据");
                }


                for (int i = 0; i < recommendAppListTable.Rows.Count; i++)
                {
                    RecommendAppModel recommendApp_t = new RecommendAppModel
                    {
                        AppImageUri = recommendAppListTable.Rows[i]["AppImageUri"].ToString(),
                        AppInfo = recommendAppListTable.Rows[i]["AppInfo"].ToString(),
                        AppName = recommendAppListTable.Rows[i]["AppName"].ToString(),
                        AppUri = recommendAppListTable.Rows[i]["AppUri"].ToString(),

                        PRI = -1,
                    };

                    if (recommendAppListTable.Rows[i]["PRI"] != null && !string.IsNullOrEmpty(recommendAppListTable.Rows[i]["PRI"].ToString()))
                    {
                        int.TryParse(recommendAppListTable.Rows[i]["PRI"].ToString(), out recommendApp_t.PRI);
                    }

                    recommendAppList.Add(recommendApp_t);
                }

                return recommendAppList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }
    }
}
