using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CZBK.ItcastProject.Common
{
    public class validateSessionHttpModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += Context_AcquireRequestState;
        }

        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext httpContext = application.Context;//获取当前的httpcontext
            string url = httpContext.Request.Url.ToString();//获取用户请求的url地址
            if (url.Contains("Admin"))
            {
                if (httpContext.Session["userInfo"]==null)
                {
                    httpContext.Response.Redirect("/20180511/UserLogin.aspx");
                }
            }
        }
    }
}
