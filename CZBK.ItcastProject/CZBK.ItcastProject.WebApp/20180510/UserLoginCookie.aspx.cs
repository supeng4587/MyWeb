using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180510
{
    public partial class UserLoginCookie : System.Web.UI.Page
    {
        public string loginUserName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string userName = Request.Form["txtUserName"];
                //写cookie
                Response.Cookies["userName"].Value = userName;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(3);
            }
            else
            {
                if (Request.Cookies["userName"] != null)
                {
                    loginUserName = Request.Cookies["userName"].Value;
                }
            }
        }
    }
}