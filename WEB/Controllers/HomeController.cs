﻿using System.Web.Mvc;
using WEB.Filters;

namespace WEB.Controllers
{
    [AuthenticationAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Develop()
        {
            return View();
        }
    }
}