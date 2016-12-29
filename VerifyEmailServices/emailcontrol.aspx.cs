using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using Utility;
using System.IO;

namespace VerifyEmailServices
{
    public partial class emailcontrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, account, password;
                action = Request["action"] == null ? "" : Request["action"].Trim();
                account = Request["account"] == null ? "" : Request["account"].Trim();
                password = Request["password"] == null ? "" : Request["password"].Trim();

                switch (action.ToLower())
                {
                    case "addemail":
                        AddEmail(account, password);
                        break;

                    case "getshortsecuritycode":
                        GetShortSecurityCode(account, password);
                        break;

                    case "getlongsecuritycode":
                        GetLongSecurityCode(account, password);
                        break;

                        
                    default:
                        //GetRankingsDataByMyRankingData(action, version, appname, playerid, playername, totalscore, devicetype, devicename, token);
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        private void AddEmail(string account,string password)
        {
            try
            {
                string result = new VerifyEmailControl().AddEmail(account, password);

                Response.Write(result);
                WriteLog(result, Page, "AddEmail");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                WriteLog(ex.Message, Page, "GetShortSecurityCode");
            }
        }

        private void GetShortSecurityCode(string account, string password)
        {
            try
            {
                string result = new VerifyEmailControl().GetShortSecurityCode(account, password);

                Response.Write(result);
                WriteLog(result, Page, "GetShortSecurityCode");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                WriteLog(ex.Message, Page, "GetShortSecurityCode");
            }
        }

        private void GetLongSecurityCode(string account, string password)
        {
            try
            {
                string result = new VerifyEmailControl().GetLongSecurityCode(account, password);

                Response.Write(result);
                WriteLog(result, Page, "GetLongSecurityCode");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                WriteLog(ex.Message, Page, "GetShortSecurityCode");
            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="LogMessage">日志内容</param>
        public static void WriteLog(string LogMessage, System.Web.UI.Page page, string fileNamePre)
        {
            string IP = page.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string stringFrom = string.Empty;
            string stringQuery = string.Empty;
            System.Collections.Specialized.NameValueCollection NameValues = page.Request.Form;
            if (NameValues.Count > 0)
            {
                string[] AllKeys = NameValues.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringFrom.Length == 0)
                    {
                        stringFrom += tepKey + "=" + NameValues[tepKey];
                    }
                    else
                    {
                        stringFrom += "&" + tepKey + "=" + NameValues[tepKey];
                    }
                }
            }

            System.Collections.Specialized.NameValueCollection NameVlaues1 = page.Request.QueryString;

            if (NameVlaues1.Count > 0)
            {
                string[] AllKeys = NameVlaues1.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringQuery.Length == 0)
                    {
                        stringQuery += tepKey + "=" + NameVlaues1[tepKey];
                    }
                    else
                    {
                        stringQuery += "&" + tepKey + "=" + NameVlaues1[tepKey];
                    }
                }
            }
            Log.Write(IP, stringFrom, stringQuery, LogMessage, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), fileNamePre);
        }
    }
}