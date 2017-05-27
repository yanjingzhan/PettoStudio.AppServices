using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IOSFullInfoServices
{
    public partial class Helper : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, ip, count, vpnaccount, vpnpassword, source;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                ip = Request["ip"] == null ? "" : Request["ip"].Trim();
                count = Request["count"] == null ? "" : Request["count"].Trim();
                vpnaccount = Request["vpnaccount"] == null ? "" : Request["vpnaccount"].Trim();
                vpnpassword = Request["vpnpassword"] == null ? "" : Request["vpnpassword"].Trim();
                source = Request["source"] == null ? "" : Request["source"].Trim();

                switch (action.ToLower())
                {
                    case "getip":
                        GetIP();
                        break;

                    case "addipcounts":
                        AddIPCounts(vpnaccount,vpnpassword,source);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;

                }
            }
        }

        private void GetIP()
        {
            string IP = Page.Request.ServerVariables["REMOTE_ADDR"].ToString();
            Response.Write(IP);
        }

        private void AddIPCounts(string VPNAccount, string VPNPassword, string source)
        {
                try
                {
                    string IP = Page.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    new HelperControl().AddIPCounts(VPNAccount, VPNPassword, source, IP);

                    Response.Write("200:ok");
                    LogWriter.WriteLog("200:ok", Page, "AddIPCounts");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    LogWriter.WriteLog(ex.Message, Page, "AddIPCounts");
                }
        }
    }
}