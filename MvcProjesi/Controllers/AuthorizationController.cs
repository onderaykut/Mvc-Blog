using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        AdminValidator adminValidator = new AdminValidator();
     
        public ActionResult Index()
        {
            var adminvalues = _adminManager.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            _adminManager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValues = _adminManager.GetById(id);
            return View(adminValues);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            _adminManager.AdminUpdate(p);
            return RedirectToAction("Index");


        }

    }
}