using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCHomeWork1.ActionFilter
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        //繼承AuthorizeAttribute，並Override OnAuthorization()
        public class PermissionFilter : AuthorizeAttribute
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
                //判斷!! 當是未登入使用者時
                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    //自己寫的Method，用來做判斷未登入使用者是從哪個頁面來的
                    CheckPermission(filterContext);
                    return;
                }
            }

            ////public override void OnActionExecuting(ActionExecutingContext filterContext)
            ////{
            ////    File.AppendAllText(@"C:ActionFilter.log",
            ////    "方法：OnActionExecuting、執行時間：" +
            ////    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "rn");
            ////}

            ////public override void OnActionExecuted(ActionExecutedContext filterContext)
            ////{
            ////    Thread.Sleep(3000);
            ////    File.AppendAllText(@"C:ActionFilter.log",
            ////        "方法：OnActionExecuted、執行時間：" +
            ////        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "rn");
            ////}

            ////public override void OnResultExecuting(ResultExecutingContext filterContext)
            ////{
            ////    Thread.Sleep(3000);
            ////    File.AppendAllText(@"C:ActionFilter.log",
            ////        "方法：OnResultExecuting、執行時間：" +
            ////        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "rn");
            ////}

            ////public override void OnResultExecuted(ResultExecutedContext filterContext)
            ////{
            ////    Thread.Sleep(3000);
            ////    File.AppendAllText(@"C:ActionFilter.log",
            ////        "方法：OnResultExecuted、執行時間：" +
            ////        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "rn");
            ////}

            private void CheckPermission(AuthorizationContext filterContext)
            {
                object areaName = null;

                //當使用者是從area來的，並且這個area名稱是Admin時(也就是後台管理者未登入時)
                if (filterContext.RouteData.DataTokens.TryGetValue("area", out areaName)
                    && (areaName as string) == "Admin")
                {
                    //導向 /Default/LogOn
                    filterContext.Result = new RedirectToRouteResult("Admin_default",
                            new RouteValueDictionary
                      {
                          { "controller", "Account" },
                          { "action", "Login" },
                          { "id", UrlParameter.Optional }
                      });
                }
                else
                {
                    //否則就直接用預設的登入頁面
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        }
    }
}