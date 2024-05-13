using MvcProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClass = new List<CategoryClass>();
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "Kitap",
                CategoryCount = 5
            });
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 2
            });
            return categoryClass;
        }



    }
}