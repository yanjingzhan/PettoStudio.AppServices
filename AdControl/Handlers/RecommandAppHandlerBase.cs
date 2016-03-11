using PAdControl.Encryption;
using PAdControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PAdControl.Handlers
{
    public class RecommandAppHandlerBase
    {
        private static RecommandAppHandlerBase _recommandAppHandlerBase;

        private static object _locker = new object();

        public static RecommandAppHandlerBase Instance
        {
            get
            {
                if (_recommandAppHandlerBase == null)
                {
                    lock (_locker)
                    {
                        _recommandAppHandlerBase = new RecommandAppHandlerBase();
                    }
                }

                return _recommandAppHandlerBase;
            }
        }

        /// <summary>
        /// 获取推荐列表信息完成
        /// </summary>
        public event EventHandler<RecommendAppEventArgs> GetRecommendAppListCompleted;

        public void GetRecommendAppListAsync(string getterAppName, string recommendAppListId)
        {
            try
            {
                string token = MD5.GetMd5String(getterAppName + "fuck" + recommendAppListId + "petto");
                WebClient wc = new WebClient();
                string url = string.Format("http://appservices.ad.pettostudio.net/apprecommendapp.aspx?action=getrecommendapp&getterappname={0}&recommendapplistid={1}&token={2}&timestamp=" + DateTime.Now.Millisecond
                    , getterAppName, recommendAppListId, token);

                wc.DownloadStringAsync(new Uri(url, UriKind.Absolute));
                wc.DownloadStringCompleted += (s1, e1) =>
                {
                    try
                    {
                        if (GetRecommendAppListCompleted != null)
                        {
                            if (e1.Error == null)
                            {
                                List<RecommendAppModel> recommendAppList = Serialize.JsonHelper.DeSerializerFromJson<List<RecommendAppModel>>(e1.Result);
                                GetRecommendAppListCompleted(this, new RecommendAppEventArgs { RecommendAppList = recommendAppList, ErrorMessage = e1.Result });
                            }
                            else
                            {
                                GetRecommendAppListCompleted(this, new RecommendAppEventArgs { RecommendAppList = null, ErrorMessage = e1.Error.Message });
                            }

                        }
                    }
                    catch { }
                };
            }
            catch (Exception ex)
            {
                GetRecommendAppListCompleted(this, new RecommendAppEventArgs { RecommendAppList = null, ErrorMessage = ex.Message });
            }
        }

    }
}
