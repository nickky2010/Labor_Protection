using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WEB.Util;

namespace WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // dependency injection
            NinjectModule interfacesRegistrationsWeb = new InterfacesRegistrationsWEB();
            NinjectModule interfacesRegistrationsBLL = new InterfacesRegistrationsBLL("LaborProtection");
            var kernel = new StandardKernel(interfacesRegistrationsWeb, interfacesRegistrationsBLL);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
