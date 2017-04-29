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
                string action;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                switch (action.ToLower())
                {
                    case "getip":
                        GetIP();
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
    }
}