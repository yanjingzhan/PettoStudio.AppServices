using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace AndroidFullInfoServices
{
    public partial class DevicesInfo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, networkOperator, language, timeZone;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                networkOperator = Request["networkoperator"] == null ? "" : Request["networkoperator"].Trim();
                language = Request["language"] == null ? "" : Request["language"].Trim();
                timeZone = Request["timezone"] == null ? "" : Request["timezone"].Trim();

                switch (action.ToLower())
                {
                    case "androidinfo":
                        AndroidInfo(networkOperator, language, timeZone);
                        break;

                    case "getisrequestad":
                        GetIsRequestAd();
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }   

        private void AndroidInfo(string networkOperator, string language, string timeZone)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new AndroidFullInfoServicesControl().GetAndroidInfo(networkOperator, language, timeZone));

                Response.Write(result);

                LogWriter.WriteLog(result, Page, "androidinfo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "androidinfo");
            }
        }

        private void GetIsRequestAd()
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new AndroidFullInfoServicesControl().GetIsRequestAd());

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIsRequestAd");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIsRequestAd");
            }
        }
    }
}