using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DataBaseService : IDataBaseService
    {
        IUnitOfWork Database { get; set; }
        public DataBaseService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateDatabaseOfDataFromExcel(string filename)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Department>, List<DepartmentDTO>>(Database.Departments.GetAll());
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
