﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadOfDepartment { get; set; }
        public virtual ICollection<EmployeeDTO> Employees { get; set; }
    }
}
