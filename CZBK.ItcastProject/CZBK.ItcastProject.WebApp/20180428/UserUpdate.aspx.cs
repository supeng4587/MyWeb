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
        public UserInfo userInfoHtml { get; set; }
        UserInfo userInfo = new UserInfo();
        BLL.UserInfoService userInfoService = new BLL.UserInfoService();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Context.Request.Form["IsPostBack"] == null)
            {
                GetUserInfo();
            }
            else
            {
                UpdateUserInfo();
            }
        }

        public void GetUserInfo()
        {
            int id;
            if (int.TryParse(Context.Request.QueryString["ID"], out id))
            {
                userInfo = userInfoService.GetList(id);
                if (userInfo != null)
                {
                    userInfoHtml = userInfo;
                }
                else
                {
                    Context.Response.Redirect("/Error.html");
                }

            }
            else
            {
                Context.Response.Write("参数错误");
            }
        }

        public void UpdateUserInfo()
        {
            userInfo.ID = int.Parse(Context.Request.Form["ID"]);
            userInfo.UserName = Context.Request.Form["txtUserName"];
            userInfo.UserPass = Context.Request.Form["passUserPass"];
            userInfo.Email = Context.Request.Form["txtEmail"];
            userInfo.RegTime = DateTime.Parse(Context.Request.Form["RegTime"]);

            if (userInfoService.Update(userInfo))
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