using DAL.EF;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LaborProtectionContext db;
        private EFRepository<Employee, LaborProtectionContext> employeeRepository;
        private EFRepository<Department, LaborProtectionContext> departmentRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new LaborProtectionContext(connectionString);
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EFRepository<Employee, LaborProtectionContext>(db);
                return employeeRepository;
            }
        }
        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new EFRepository<Department, LaborProtectionContext>(db);
                return departmentRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
