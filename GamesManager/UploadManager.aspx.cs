using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamesManager
{
    public partial class UploadManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string f in Request.Files.AllKeys)
            {
                HttpPostedFile file = Request.Files[f];

                string currentPath = System.Web.HttpContext.Current.Request.MapPath("/");
                file.SaveAs(Path.Combine(currentPath, @"resoures\wp\moniqi\" + file.FileName));
            }
        }
    }
}