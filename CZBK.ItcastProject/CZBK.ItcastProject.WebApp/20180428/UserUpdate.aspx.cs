using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180428
{
    public partial class UserUpdate : System.Web.UI.Page
    {
        public UserInfo UserInfo { get; set; }
        BLL.UserInfoService userInfoService = new BLL.UserInfoService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetUserInfo()
        {
            int id;
            if (int.TryParse(Context.Request.QueryString["ID"], out id))
            {
                UserInfo = userInfoService.GetList(id); ;
            }
            else
            {
                Context.Response.Write("参数错误");
            }
        }

        public void UpdateUserInfo()
        {
            UserInfo.ID = int.Parse(Context.Request.Form["ID"]);
            UserInfo.UserName = Context.Request.Form["txtUserName"];
            UserInfo.UserPass = Context.Request.Form["passUserPass"];
            UserInfo.Email = Context.Request.Form["txtEmail"];
            UserInfo.RegTime = DateTime.Parse(Context.Request.Form["RegTime"]);

            if (userInfoService.Update(UserInfo))
            {
                Context.Response.Redirect("UserInfoWebForm.aspx");
            }
            else
            {
                Context.Response.Redirect("/Error.html.html");
            }
        }
    }
}