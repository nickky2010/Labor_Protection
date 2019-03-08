﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        IDataBaseService dbService;
        public HomeController(IDataBaseService dbService)
        {
            this.dbService = dbService;
        }
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> employeeDTOs = dbService.GetEmployees();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var employee = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            return View(employee);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            dbService.Dispose();
            base.Dispose(disposing);
        }
    }
}