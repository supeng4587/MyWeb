using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

/// <summary>
/// global文件名称不能改，而且必须放在网站根目录下
/// </summary>

namespace CZBK.ItcastProject.WebApp
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Web应用程序第一次启动时调用该方法，而且该方法只被调用一次。可以理解为是Web应用程序的入口，相当于winform中的main函数（不是.net）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 开始会话，浏览器（第一次访问网站）与服务器建立会话的时候被调用（再次访问其他页面时该方法不调用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {
            //application：服务端的状态保存机制，放在该对象中的数据是共享。application使用的时候是需要加锁和解锁的。
            //典型用来统计访客
            Application.Lock();
            int count = Convert.ToInt32(Application["count"]);
            count++;
            Application["count"] = count;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 全局的异常处理点。（可以在此定义将捕获到的异常记录成日志）抛错的方法不能有trycache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
        }

        /// <summary>
        /// 会话结束，session释放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            int count = Convert.ToInt32(Application["count"]);
            count--;
            Application["count"] = count;
            Application.UnLock();
        }


        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}