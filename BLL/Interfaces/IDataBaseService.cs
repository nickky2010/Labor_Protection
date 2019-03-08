using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDataBaseService
    {
        void CreateDatabaseOfDataFromExcel(string filename);
        ICollection<EmployeeDTO> GetEmployees();
        ICollection<DepartmentDTO> GetDepartments();
        ICollection<EmployeeDTO> GetEmployees(string entity);
        ICollection<DepartmentDTO> GetDepartments(string entity);

        void Dispose();

    }
}
