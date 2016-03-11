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
    public class AdsControl
    {
        /// <summary>
        /// 获取广告数据
        /// </summary>
        /// <param name="adsGetter"></param>
        /// <returns></returns>
        public List<AdInfo> GetAdInfo(AdsGetter adsGetter)
        {
            try
            {
                List<AdInfo> AdInfoList = new List<AdInfo>();

                string sqlCmd = string.Format("SELECT [AdTpye],[AdName],[AdId1],[AdId2],[AdId3],[ClickCountToHide],[PRI],[Position],[ImageUrl],[ClickUrl],[AdIndex],[LowLimit],[HighLimit],[ShowFullAdTime],[ShowFullAdCount],[RefreshBannersInterval],[CarouselBannersInterval] FROM [dbo].[AdInfo] WHERE [AppName]='{0}' AND [AppVersion]='{1}' AND [AdIndex]='{2}'",
                                            adsGetter.AppName, adsGetter.AppVersion, adsGetter.AdIndex);

                DataTable adInfoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (adInfoTable == null || adInfoTable.Rows.Count == 0)
                {
                    throw new Exception("无数据");
                }

                for (int i = 0; i < adInfoTable.Rows.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine(adInfoTable.Rows[i]["AdIndex"]);
                    System.Diagnostics.Debug.WriteLine(adInfoTable.Rows[i]["ShowFullAdTime"]);
                    System.Diagnostics.Debug.WriteLine(adInfoTable.Rows[i]["ShowFullAdTime"]);
                    AdInfo adInfo_t = new AdInfo
                    {
                        AdTpye = adInfoTable.Rows[i]["AdTpye"].ToString(),
                        AdName = adInfoTable.Rows[i]["AdName"].ToString(),
                        AdId1 = adInfoTable.Rows[i]["AdId1"].ToString(),
                        AdId2 = adInfoTable.Rows[i]["AdId2"].ToString(),
                        AdId3 = adInfoTable.Rows[i]["AdId3"].ToString(),
                        Position = adInfoTable.Rows[i]["Position"].ToString(),
                        ClickUrl = adInfoTable.Rows[i]["ClickUrl"].ToString(),
                        ImageUrl = adInfoTable.Rows[i]["ImageUrl"].ToString(),

                        PRI = 100,
                        ClickCountToHide = -1,
                        AdIndex = -1,
                        ShowFullAdTime = 3600,
                        ShowFullAdCount = -1,
                        RefreshBannersInterval = 27,
                        CarouselBannersInterval = 20
                    };

                    if (adInfoTable.Rows[i]["PRI"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["PRI"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["PRI"].ToString(), out adInfo_t.PRI);
                    }

                    if (adInfoTable.Rows[i]["ClickCountToHide"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["ClickCountToHide"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["ClickCountToHide"].ToString(), out adInfo_t.ClickCountToHide);
                    }

                    if (adInfoTable.Rows[i]["AdIndex"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["AdIndex"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["AdIndex"].ToString(), out adInfo_t.AdIndex);
                    }

                    if (adInfoTable.Rows[i]["ShowFullAdTime"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["ShowFullAdTime"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["ShowFullAdTime"].ToString(), out adInfo_t.ShowFullAdTime);
                    }

                    if (adInfoTable.Rows[i]["ShowFullAdCount"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["ShowFullAdCount"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["ShowFullAdCount"].ToString(), out adInfo_t.ShowFullAdCount);
                    }

                    if (adInfoTable.Rows[i]["RefreshBannersInterval"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["RefreshBannersInterval"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["RefreshBannersInterval"].ToString(), out adInfo_t.RefreshBannersInterval);
                    }

                    if (adInfoTable.Rows[i]["CarouselBannersInterval"] != null && !string.IsNullOrEmpty(adInfoTable.Rows[i]["CarouselBannersInterval"].ToString()))
                    {
                        int.TryParse(adInfoTable.Rows[i]["CarouselBannersInterval"].ToString(), out adInfo_t.CarouselBannersInterval);
                    }
                    
                    if (adInfo_t.ClickCountToHide > 0)
                    {
                        try
                        {
                            float highLimit;
                            if (float.TryParse(adInfoTable.Rows[i]["HighLimit"].ToString(), out highLimit))
                            {

                                string sqlCmd_dianjilv = string.Format("SELECT cast ([ClickCount] as float) / cast ([ShowCount] as float) FROM [dbo].[AdStatistics] WHERE [AppName]='{0}' AND [AppVersion]='{1}' AND [AdName]='{2}' AND [AdIndex]='{3}' AND [Date]='{4}'",
                                                    adsGetter.AppName, adsGetter.AppVersion, adInfo_t.AdName, adsGetter.AdIndex, DateTime.Now.Date.ToString("yyyy-MM-dd"));

                                object dianjilv = SqlHelper.Instance.ExecuteScalar(sqlCmd_dianjilv);

                                if (dianjilv != null)
                                {
                                    float currentDianjilv;
                                    if (float.TryParse(dianjilv.ToString(), out currentDianjilv))
                                    {
                                        if (currentDianjilv > highLimit)
                                        {
                                            adInfo_t.ClickCountToHide = -1;
                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                    }

                    AdInfoList.Add(adInfo_t);
                }

                return AdInfoList;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");
                return null;
            }
        }

        /// <summary>
        /// 广告点击数
        /// </summary>
        /// <param name="postAdData"></param>
        public string PostAdClickCount(PostAdData postAdData)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [dbo].[AdStatistics] WHERE [AppName]='{0}' AND [AppVersion]='{1}' AND [AdTpye]='{2}' AND [AdName]='{3}' AND [Date]='{4}' AND [AdIndex]='{5}'",
                                            postAdData.AppName, postAdData.AppVersion, postAdData.AdType, postAdData.AdName, DateTime.Now.Date.ToString("yyyy-MM-dd"), postAdData.AdIndex);

                string count_t = SqlHelper.Instance.ExecuteScalar(sqlCmd).ToString();
                if (count_t.Trim() != "0")
                {
                    string sqlCmdUpdate = string.Format("UPDATE [dbo].[AdStatistics] SET [ClickCount] = [ClickCount] + {0} WHERE [AppName]='{1}' AND [AppVersion]='{2}' AND [AdTpye]='{3}' AND [AdName]='{4}' AND [Date]='{5}' AND [AdIndex]='{6}'",
                                        postAdData.ClickCount, postAdData.AppName, postAdData.AppVersion, postAdData.AdType, postAdData.AdName, DateTime.Now.Date.ToString("yyyy-MM-dd"), postAdData.AdIndex);

                    SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
                }
                else
                {
                    string sqlCmdInsert = string.Format("INSERT INTO [dbo].[AdStatistics] ([AppName],[AppId],[AppVersion],[AdTpye],[AdName],[ShowCount],[ClickCount],[Date],[AdIndex]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    postAdData.AppName, postAdData.AppId, postAdData.AppVersion, postAdData.AdType, postAdData.AdName, postAdData.ShowCount, postAdData.ClickCount, DateTime.Now.Date.ToString("yyyy-MM-dd"), postAdData.AdIndex);

                    SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
                }

                return "200:ok";
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");

                return "-100:" + ex.Message;
            }
        }

        /// <summary>
        /// 广告展示数
        /// </summary>
        /// <param name="postAdData"></param>
        public string PostAdShowCount(PostAdData postAdData)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [dbo].[AdStatistics] WHERE [AppName]='{0}' AND [AppVersion]='{1}' AND [AdTpye]='{2}' AND [AdName]='{3}' AND [Date]='{4}' AND [AdIndex]='{5}'",
                                            postAdData.AppName, postAdData.AppVersion, postAdData.AdType, postAdData.AdName, DateTime.Now.Date.ToString("yyyy-MM-dd"), postAdData.AdIndex);

                string count_t = SqlHelper.Instance.ExecuteScalar(sqlCmd).ToString();
                if (count_t.Trim() != "0")
                {
                    string sqlCmdUpdate = string.Format("UPDATE [dbo].[AdStatistics] SET [ShowCount] = [ShowCount] + {0} WHERE [AppName]='{1}' AND [AppVersion]='{2}' AND [AdTpye]='{3}' AND [AdName]='{4}' AND [Date]='{5}' AND [AdIndex]='{6}'",
                                        postAdData.ShowCount, postAdData.AppName, postAdData.AppVersion, postAdData.AdType, postAdData.AdName, DateTime.Now.Date.ToString("yyyy-MM-dd"), postAdData.AdIndex);

                    SqlHelper.Instance.ExecuteCommand(sqlCmdUpdate);
                }
                else
                {
                    string sqlCmdInsert = string.Format("INSERT INTO [dbo].[AdStatistics] ([AppName],[AppId],[AppVersion],[AdTpye],[AdName],[ShowCount],[ClickCount],[Date],[AdIndex]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    postAdData.AppName, postAdData.AppId, postAdData.AppVersion, postAdData.AdType, postAdData.AdName, postAdData.ShowCount, postAdData.ClickCount, DateTime.Now.Date.ToString("yyyy-MM-dd"), postAdData.AdIndex);


                    SqlHelper.Instance.ExecuteCommand(sqlCmdInsert);
                }

                return "200:ok";
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), "DataBase");

                return "-100:" + ex.Message;
            }
        }

    }
}
