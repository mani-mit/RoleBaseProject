using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBaseProject.Controllers
{
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

        public ActionResult Admin()
        {
            ViewBag.Message = "Welcome to admin page.";

            return View();
        }

        public ActionResult Manager()
        {
            ViewBag.Message = "welcome to manager page.";

            return View();
        }
        public ActionResult Employee()
        {
            ViewBag.Message = "welcome to employee page.";

            return View();
        }
    }
}