using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace CZBK.ItcastProject.WebApp._20180504
{
    public partial class UrlReferrer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.Url.ToString());
            Response.Write("<hr/>");
            //Response.Clear();
            //Response.End();
            Response.Flush();
            Thread.Sleep(10000);
            Response.Write(Request.UrlReferrer.ToString());
            Response.Write("<hr/>");
            Response.Flush();
            Thread.Sleep(10000);
            Response.Write(Server.MapPath("/index.html"));
            Response.Write("<br/>");
            Response.Write(Request.MapPath("/index.html"));
        }
    }
}