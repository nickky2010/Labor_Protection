using System;
using System.Web;
using System.Web.Mvc;
using WEB.Models.Connection;
using BLL.Interfaces;
using BLL.Services;
using WEB.Util;

namespace WEB.Controllers
{
    public class ConnectionController : Controller
    {
        public static bool IsConnect { get; private set; }
        static ConnectionController()
        {
            IsConnect = false;
        }
        // GET: Connection
        public ActionResult ConnectionStartPage()
        {
            try
            {
                HttpCookie cookieReq = Request.Cookies["userConnectionString"];
                if (cookieReq != null)
                {
                    string connectionString = cookieReq["ConnectionString"].Replace(",", ";");
                    IsConnect = GetService(connectionString).CheckExistsDataBase();
                    if (connectionString != null && IsConnect)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                return View();
            }
            catch
            {
                HttpCookie cookie = new HttpCookie("userConnectionString");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response?.Cookies?.Add(cookie);
                return RedirectToAction("CouldNotOpenConnectionToSQLServer", "Error");
            }
        }
        private IDataBaseService GetService(string connStr)
        {
            DependencyInjection.Injection(connStr);
            AbstractServiceCreator.ConnectionString = connStr;
            AbstractServiceCreator serviceCreator = new ServiceCreator();
            IDataBaseService service = serviceCreator.CreateDataService();
            int countEmpl = service.GetDepartments().Count;
            return service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConnectionStartPage(ConnectionModel conMod, string typeDb)
        {
            try
            {
                string connectionString = CreateConnectionString(conMod, typeDb);
                if (ModelState.IsValid)
                {
                    IsConnect = GetService(connectionString).CheckExistsDataBase();
                    if (IsConnect)
                    {
                        HttpCookie cookie = new HttpCookie("userConnectionString");
                        cookie["ConnectionString"] = connectionString.Replace(";",",");
                        cookie.Expires = DateTime.Now.AddMonths(1);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Login", "Account");
                    }
                }
                return RedirectToAction("Connection", "ConnectionStartPage");
            }
            catch
            {
                return RedirectToAction("CouldNotOpenConnectionToSQLServer", "Error");
            }
        }
        private string CreateConnectionString(ConnectionModel conMod, string typeDb)
        {
            IConnectionStringService connection = new SqlConnectionStringService();
            connection.DataSource = conMod.DataSource;
            connection.InitialCatalog = conMod.InitialCatalog;
            if (typeDb == "new")
            {
                connection.AttachDBFilename = conMod.AttachDBFilename;
            }
            connection.IntegratedSecurity = conMod.IntegratedSecurity;
            if (!conMod.IntegratedSecurity)
            {
                connection.User = conMod.User;
                connection.Password = conMod.Password;
            }
            connection.ConnectionTimeout = 10;
            return connection.ConnectionString();
        }
    }
}