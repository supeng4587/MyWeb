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
                string postUserName = Request.Form["txtUserName"];
                //写cookie
                Response.Cookies["userName"].Value = Server.UrlEncode(postUserName);
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(3);
            }
            else
            {
                if (Request.Cookies["userName"] != null)
                {
                    string getUserName = Server.UrlDecode(Request.Cookies["userName"].Value);
                    loginUserName = getUserName;
                    Response.Cookies["userName"].Value = Server.UrlEncode(getUserName);
                    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(3);
                }
            }
        }
    }
}