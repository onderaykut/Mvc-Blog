using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Burası Benim Hakkında Sayfam";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Burası Benim İletişim Sayfam";

            return View();
        }
        public ActionResult Bilgi()
        {
            return View();
        }
        public ActionResult Profilim()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}