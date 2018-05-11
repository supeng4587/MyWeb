using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZBK.ItcastProject.Common;

namespace CZBK.ItcastProject.WebApp._20180511
{
    /// <summary>
    /// captcha 的摘要说明
    /// </summary>
    public class captcha : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    //一般处理程序使用session时，必须实现System.Web.SessionState.IRequiresSessionState标记接口
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Common.ValidateCode captcha = new Common.ValidateCode();
            string code = captcha.CreateValidateCode(4);
            context.Session["captchaCode"] = code;
            captcha.CreateValidateGraphic(code, context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}