using CZBK.ItcastProject.BLL;
using CZBK.ItcastProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180511
{
    public partial class UserLogin : System.Web.UI.Page
    {
        public string Msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (checkCaptcha())
                {
                    checkUserInfo();
                }
                else
                {
                    Msg = "验证码错误";
                }

            }
            else
            {
                if (Session["userInfo"] != null)
                {
                    Response.Redirect("UserInfoList.aspx");
                }

                CheckCookieInfo();
            }
        }

        #region 检验Cookie中的信息

        protected void CheckCookieInfo()
        {
            if (Request.Cookies["cp1"] != null && Request.Cookies["cp2"] != null)
            {
                string userName = Request.Cookies["cp1"].Value;
                string userPass = Request.Cookies["cp2"].Value;

                UserInfoService userInfoService = new UserInfoService();
                UserInfo userInfo = userInfoService.GetList(userName);

                if (userInfo.UserName == userName)
                {
                    //一定要将用户的密码进行加密后再存储到数据库中。
                    //可以在用户注册的时候进行一次加密，存储进数据库。由于cookie要存储再客户端，可进行两次加密。
                    //使用的时候可以将数据库中取出的密码进行一次加密后，再于cookie中存储的密码进行比较。
                    if (Common.WebCommon.GetMD5String(Common.WebCommon.GetMD5String(userInfo.UserPass)) == userPass)
                    {
                        Session["userInfo"] = userInfo;
                        Response.Redirect("UserInfoList.aspx");
                    }
                }
                Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        #endregion

        #region 校验用户密码
        protected void checkUserInfo()
        {
            //获取用户密码
            string userName = Request.Form["txtUserName"];
            string userPass = Request.Form["txtUserPass"];
            //校验用户密码
            string msg = string.Empty;
            UserInfo userInfo = null;
            UserInfoService userInfoService = new UserInfoService();

            if (userInfoService.ValidateUserInfo(userName, userPass, out msg, out userInfo))
            {
                Session["userInfo"] = userInfo;
                if (!string.IsNullOrEmpty(Request.Form["autoLogin"]))//页面上如果有多个复选框的时候，只能将选中的复选框的值传递到服务端
                {
                    //Response.Cookies["userName"].Value = userName;
                    //Response.Cookies["userPass"].Value = userPass;
                    //Response.Cookies["userName"].Expires = DateTime.Now.AddDays(7);
                    //Response.Cookies["userPass"].Expires = DateTime.Now.AddDays(7);

                    HttpCookie cookie1 = new HttpCookie("cp1", userName);
                    HttpCookie cookie2 = new HttpCookie("cp2", Common.WebCommon.GetMD5String(Common.WebCommon.GetMD5String(userPass)));//两层MD5加密
                    cookie1.Expires = DateTime.Now.AddDays(7);
                    cookie2.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }
                Response.Redirect("UserInfoList.aspx");
            }
            else
            {
                Msg = msg;
            }
        }
        #endregion

        #region 验证吗校验
        protected bool checkCaptcha()
        {
            bool isSucess = false;
            if (Session["captchaCode"] != null)
            {
                string txtCode = Request.Form["txtCode"];
                string sysCode = Session["captchaCode"].ToString();

                if (sysCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    Session["captchaCode"] = null;
                    isSucess = true;
                }
            }
            return isSucess;
        }
        #endregion
    }
}