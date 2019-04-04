using System.Web.Mvc;
using WEB.Controllers;

namespace WEB.Filters
{
    public class ConnectionAttribute : FilterAttribute, IActionFilter
    {
        bool connect = false;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!ConnectionController.IsConnect)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!connect)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                { { "controller", "Connection" }, { "action", "ConnectionStartPage" } });
                connect = true;
            }
        }
    }
}