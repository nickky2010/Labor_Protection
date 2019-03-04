using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class InterfacesRegistrationsBLL : NinjectModule
    {
        public string ConnectionString { get; private set; }
        public InterfacesRegistrationsBLL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(ConnectionString);
            Bind<IIdentityUnitOfWork>().To<IdentityUnitOfWork>().WithConstructorArgument(ConnectionString);
        }
    }
}
