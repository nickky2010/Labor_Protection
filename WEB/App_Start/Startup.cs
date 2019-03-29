using BLL.DTO.Identity;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Ninject.Modules;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Controllers;
using WEB.Models.Connection;

[assembly: OwinStartup(typeof(WEB.App_Start.Startup))]
namespace WEB.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        private static IUserService CreateUserService()
        {
            return (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
        }
    }
}