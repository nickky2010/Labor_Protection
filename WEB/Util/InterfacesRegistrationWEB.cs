using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WEB.Util
{
    public class InterfacesRegistrationsWEB: NinjectModule
    {
        public override void Load()
        {
            Bind<IDataBaseService>().To<DataBaseService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}