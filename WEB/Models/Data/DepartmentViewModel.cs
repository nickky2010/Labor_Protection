﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models.Data
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadOfDepartment { get; set; }
        public virtual ICollection<EmployeeDTO> Employees { get; set; }
    }
}