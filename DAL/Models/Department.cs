using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadOfDepartment { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
