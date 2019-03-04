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
        IEnumerable<EmployeeDTO> GetEmployees();
        IEnumerable<DepartmentDTO> GetDepartments();
        void Dispose();

    }
}
