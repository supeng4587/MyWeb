using CZBK.ItcastProject.BLL;
using CZBK.ItcastProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }


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

            if(userInfoService.ValidateUserInfo(userName, userPass, out msg, out userInfo))
            {
                Session["userInfo"] = userInfo;
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