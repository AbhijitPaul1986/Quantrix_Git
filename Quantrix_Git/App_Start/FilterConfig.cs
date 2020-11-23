using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quantrix_Git
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.UrlReferrer == null || filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
            {
                filterContext.Result = new RedirectToRouteResult(new
                                          RouteValueDictionary(new { controller = "Admin", action = "Logout" }));
            }
        }
    }
    public class UserSessionActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContextORG)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.Session["UserID"] == null)
            {

                filterContextORG.Result = new RedirectResult("~/Admin/Logout");
                return;
            }
        }
    }
}
