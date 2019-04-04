using System.Web.Mvc;
using System.Web.Mvc.Filters;
using WEB.Controllers;

namespace WEB.Filters
{
    [ConnectionAttribute]
    public class AuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (ConnectionController.IsConnect && (user == null || !user.Identity.IsAuthenticated))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (ConnectionController.IsConnect && (user == null || !user.Identity.IsAuthenticated))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                { { "controller", "Account" }, { "action", "Login" } });
            }
        }
    }
}