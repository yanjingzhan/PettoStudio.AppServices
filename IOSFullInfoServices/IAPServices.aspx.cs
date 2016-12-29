using Controller;
using Models.IOSFullInfoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace IOSFullInfoServices
{
    public partial class IAPServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action, q;

            action = Request["action"] == null ? "" : Request["action"].Trim();
            q = Request["q"] == null ? "" : Request["q"].Trim();

            switch (action.ToLower())
            {
                case "insertiaprecord":
                    InsertIAPRecord(q);
                    break;

                default:
                    Response.Write("-100:action is error!");
                    break;
            }
        }

        private AppleIAPRecord DecryptionTOAppIAPRecordModel(string ecryptStr)
        {
            try
            {
                if (!string.IsNullOrEmpty(ecryptStr))
                {
                    //string t = HttpUtility.UrlDecode(ecryptStr);
                    string json = Encryption.Decrypt(ecryptStr);

                    return JsonHelper.DeserializeObjectFromJson<AppleIAPRecord>(json);
                }
            }
            catch { }

            return null;
        }

        private void InsertIAPRecord(string ecryptStr)
        {
            try
            {
                AppleIAPRecord t = DecryptionTOAppIAPRecordModel(ecryptStr);
                if(t == null)
                {
                    throw new Exception("解密失败!");
                }
                new IOSIAPServicesControl().InsertIAPRecord(t);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "InsertIAPRecord");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "InsertIAPRecord");
            }
        }
    }
}