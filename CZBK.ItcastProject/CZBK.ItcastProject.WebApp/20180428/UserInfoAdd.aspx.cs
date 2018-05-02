using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180428
{
    public partial class UserInfoAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Request.Form["IsPostBack"] != null)
            {
                string userName = Context.Request.Form["txtUserName"];
                string userPass = Context.Request.Form["PassUserPass"];
                string email = Context.Request.Form["txtEmail"];

                UserInfo userInfo = new UserInfo();
                userInfo.UserName = userName;
                userInfo.UserPass = userPass;
                userInfo.Email = email;
                userInfo.RegTime = DateTime.Now;
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();

                if (userInfoService.Create(userInfo))
                {
                    Context.Response.Redirect("UserInfoWebForm.aspx");
                }
                else
                {
                    Context.Response.Redirect("/Error.html");
                }
            }
        }
    }
}