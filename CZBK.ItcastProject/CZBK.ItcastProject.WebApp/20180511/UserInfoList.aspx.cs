using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CZBK.ItcastProject.Model;

namespace CZBK.ItcastProject.WebApp._20180511
{
    public partial class UserInfoList : Common.CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userInfo"] == null)
            //{
            //    Response.Redirect("UserLogin.aspx");
            //}
            //else
            //{
            //    Response.Write("欢迎" + ((UserInfo)Session["userinfo"]).UserName+"登录");
            //}

            Response.Write("欢迎" + ((UserInfo)Session["userinfo"]).UserName + "登录");


        }
    }
}