using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestServices
{
    public partial class IP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string REMOTE_ADDR = Page.Request.ServerVariables["REMOTE_ADDR"] ?? "无";
            string HTTP_VIA = Page.Request.ServerVariables["HTTP_VIA"] ?? "无";
            string HTTP_X_FORWARDED_FOR = Page.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]?? "无";

            Response.Write(string.Format("REMOTE_ADDR:{0}        HTTP_VIA:{1}         HTTP_X_FORWARDED_FOR:{2}", REMOTE_ADDR, HTTP_VIA, HTTP_X_FORWARDED_FOR));
        }
    }
}