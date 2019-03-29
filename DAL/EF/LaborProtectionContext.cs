using DAL.Models;
using DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class LaborProtectionContext : DbContext
    {
        // инициализация бд начальными значениями
        static LaborProtectionContext()
        {
            Database.SetInitializer<LaborProtectionContext>(new LaborProtectionDBInitializer());
        }
        public LaborProtectionContext() : base("name=LaborProtection")
        {

        }
        public LaborProtectionContext(string cs) : base(cs)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            //modelBuilder.Entity<Employees>().Property(f => f.Birthday).HasColumnType("datetime2");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

    public class LaborProtectionDBInitializer : DropCreateDatabaseAlways<LaborProtectionContext>
    {
        protected override void Seed(LaborProtectionContext db)
        {
            db.Departments.Add(new Department { Name = "Участок ручной уборки Новобелицкого района", HeadOfDepartment = 1 });
            db.Departments.Add(new Department { Name = "Колонна специализированных машин", HeadOfDepartment = 2 });
            db.Departments.Add(new Department { Name = "Ремонтно-механическая мастерская", HeadOfDepartment = 3 });
            db.Employees.Add(new Employee { Surname = "Лукомская", Name = "Валентина", LastName = "Евгеньевна", HomeAddress = "ул.Чечерская, 18, кв. 26", Birthday = new DateTime(1972, 02, 14), DateHire = new DateTime(2007, 12, 20), DepartmentId = 1 });
            db.Employees.Add(new Employee { Surname = "Сафонов", Name = "Сергей", LastName = "Олегович", HomeAddress = "пр-кт Октября, 51, кв. 72", Birthday = new DateTime(1984, 07, 11), DateHire = new DateTime(2015, 10, 01), DepartmentId = 2 });
            db.Employees.Add(new Employee { Surname = "Протосовицкий", Name = "Андрей", LastName = "Николаевич", HomeAddress = "пр. Речицкий, д. 62 кв. 89", Birthday = new DateTime(1966, 08, 24), DateHire = new DateTime(2016, 05, 22), DepartmentId = 3 });
            base.Seed(db);
        }
    }
}
