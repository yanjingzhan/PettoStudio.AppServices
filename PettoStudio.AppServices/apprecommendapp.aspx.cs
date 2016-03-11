#define TEST
using Controller;
using PettoStudio.AppServices.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace PettoStudio.AppServices
{
    public partial class apprecommendapp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, getterappname, recommendapplistid, token;
                action = Request["action"] == null ? "" : Request["action"].Trim();
                getterappname = Request["getterappname"] == null ? "" : Request["getterappname"].Trim();
                recommendapplistid = Request["recommendapplistid"] == null ? "" : Request["recommendapplistid"].Trim();
                token = Request["token"] == null ? "" : Request["token"].Trim();

                switch (action)
                {
                    case "getrecommendapp":
                        GetRecommendApp(getterappname, recommendapplistid, token);
                        break;
                    default:
                        break;
                }
            }
        }

        void GetRecommendApp(string getterappname, string recommendapplistid, string token)
        {
#if !TEST
            string md5Sum = Encryption.Md5Sum(getterappname + "fuck" + recommendapplistid + "petto");
            if (md5Sum != token)
            {
                Response.Write("-102:you are shabi!");
            }
            else
#endif
            {
                try
                {
                    string result = JsonHelper.SerializerToJson(
                     new RecommendAppControl().GetRecommendAppList
                     (
                          new Models.In.RecommendAppGetter
                          {
                              GetterAppName = getterappname,
                              RecommendAppListId = recommendapplistid
                          }
                     ));

                    Response.Write(result);
                    LogWriter.WriteLog(result, Page, "GetRecommendApp");
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    LogWriter.WriteLog(ex.Message, Page, "GetRecommendApp");
                }
            }
        }
    }
}