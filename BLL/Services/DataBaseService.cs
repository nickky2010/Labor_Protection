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

        public ICollection<DepartmentDTO> GetDepartments()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<ICollection<Department>, List<DepartmentDTO>>(Database.Departments.GetAll());
        }
        public ICollection<DepartmentDTO> GetDepartments(string entity)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<ICollection<Department>, List<DepartmentDTO>>(Database.Departments.GetAllInclude(entity));
        }

        public ICollection<EmployeeDTO> GetEmployees()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<ICollection<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }
        public ICollection<EmployeeDTO> GetEmployees(string entity)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<ICollection<Employee>, List<EmployeeDTO>>(Database.Employees.GetAllInclude(entity));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
