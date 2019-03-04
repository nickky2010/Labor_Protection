using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string HomeAddress { get; set; }
        public System.DateTime Birthday { get; set; }
        public System.DateTime DateHire { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
