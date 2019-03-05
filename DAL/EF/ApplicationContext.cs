﻿using DAL.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }
        public static ApplicationContext Create(string сonectionString)
        {
            return new ApplicationContext(сonectionString);
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
