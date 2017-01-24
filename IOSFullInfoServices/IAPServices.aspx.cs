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
            if (!IsPostBack)
            {
                string action, q, dayscount;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                q = Request["q"] == null ? "" : Request["q"].Trim();
                dayscount = Request["dayscount"] == null ? "" : Request["dayscount"].Trim();

                switch (action.ToLower())
                {
                    case "insertiaprecord":
                        InsertIAPRecord(q);
                        break;

                    case "login":
                        Login(q);
                        break;

                    case "getsumscorebyaccount":
                        GetSumScoreByAccount(q);
                        break;

                    case "getiaprecorditemmodellstbyaccount":
                        GetIAPRecordItemModelLstByAccount(q, dayscount);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
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
                if (t == null)
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

        private void Login(string ecryptStr)
        {
            try
            {
                AppleIAPRecord t = DecryptionTOAppIAPRecordModel(ecryptStr);
                if (t == null)
                {
                    throw new Exception("解密失败!");
                }
                new IOSIAPServicesControl().Login(t.Account, t.Password);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "Login");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "Login");
            }
        }

        private void GetSumScoreByAccount(string ecryptStr)
        {
            try
            {
                AppleIAPRecord t = DecryptionTOAppIAPRecordModel(ecryptStr);
                if (t == null)
                {
                    throw new Exception("解密失败!");
                }
                string result = new IOSIAPServicesControl().GetSumScoreByAccount(t.Account, t.Password, t.GameName);

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetSumScoreByAccount");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetSumScoreByAccount");
            }
        }

        private void GetIAPRecordItemModelLstByAccount(string ecryptStr, string daysCount)
        {
            try
            {
                AppleIAPRecord t = DecryptionTOAppIAPRecordModel(ecryptStr);
                if (t == null)
                {
                    throw new Exception("解密失败!");
                }
                string result = JsonHelper.SerializerToJson(new IOSIAPServicesControl().GetIAPRecordItemModelLstByAccount(t.Account, t.Password, t.GameName, daysCount));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIAPRecordItemModelLstByAccount");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIAPRecordItemModelLstByAccount");
            }
        }
    }
}