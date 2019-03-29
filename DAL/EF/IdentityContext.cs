using DAL.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(string conectionString) : base(conectionString) { }
        public static IdentityContext Create(string сonectionString)
        {
            return new IdentityContext(сonectionString);
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
