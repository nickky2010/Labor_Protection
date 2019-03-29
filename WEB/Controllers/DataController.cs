using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Filters;
using WEB.Models.Data;

namespace WEB.Controllers
{
    [AuthenticationAttribute]
    public class DataController : Controller
    {
        IDataBaseService dbService;
        public DataController(IDataBaseService dbService)
        {
            this.dbService = dbService;
        }

        public ActionResult EmployeesData()
        {
            ICollection<EmployeeDTO> employeeDTOs = dbService.GetEmployees("Department");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var employee = mapper.Map<ICollection<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            return View(employee);
        }
        protected override void Dispose(bool disposing)
        {
            dbService.Dispose();
            base.Dispose(disposing);
        }
    }
}