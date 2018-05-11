using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180511
{
    public partial class SeeeionDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string userName = Request.Form["txtUserName"];
                Session["userName"] = userName;
                Response.Redirect("Test.aspx");
            }
        }
    }
}