using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180510
{
    public partial class CookieDemo2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取Cookie数据
            if (Request.Cookies["cp1"] != null)
            {
                Response.Write(Request.Cookies["cp1"].Value);
            }
            Response.Write("<hr/>");
            if (Request.Cookies["cp2"] != null)
            {
                Response.Write(Request.Cookies["cp2"].Value
                    );
            }
        }
    }
}