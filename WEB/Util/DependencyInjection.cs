using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;

namespace WEB.Util
{
    public static class DependencyInjection
    {
        public static void Injection(string connectionString)
        {
            NinjectModule interfacesRegistrationsWeb = new InterfacesRegistrationsWEB();
            NinjectModule interfacesRegistrationsBLL = new InterfacesRegistrationsBLL(connectionString);
            var kernel = new StandardKernel(interfacesRegistrationsWeb, interfacesRegistrationsBLL);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}