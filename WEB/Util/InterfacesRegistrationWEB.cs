using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Util
{
    public class InterfacesRegistrationsWEB: NinjectModule
    {
        public override void Load()
        {
            Bind<IDataBaseService>().To<DataBaseService>();
        }
    }
}