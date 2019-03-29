﻿using BLL.DTO.Identity;
using BLL.Services;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public abstract class AbstractServiceCreator
    {
        public static string ConnectionString { get; set; }
        public abstract IUserService CreateUserService();
        public abstract IDataBaseService CreateDataService();
    }
}
