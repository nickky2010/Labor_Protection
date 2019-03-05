using DAL.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IApplicationUserManager
    {
        ApplicationUserManager CreateAppManager(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context);
    }
}
