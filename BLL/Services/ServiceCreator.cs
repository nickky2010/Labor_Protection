using BLL.DTO.Identity;
using BLL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceCreator : AbstractServiceCreator
    {
        public override IUserService CreateUserService()
        {
            return new UserService(new IdentityUnitOfWork(AbstractServiceCreator.ConnectionString));
        }
        public override IDataBaseService CreateDataService()
        {
            return new DataBaseService(new EFUnitOfWork(AbstractServiceCreator.ConnectionString));
        }
    }
}
