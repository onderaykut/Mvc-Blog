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
//using FluentValidation;


namespace MvcProjesi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());


        //[Authorize(Roles = "B")]
        [Authorize]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = cm.GetById(id);
            cm.CategoryDelete(categoryvalues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalues = cm.GetById(id);
            return View(categoryvalues);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");


        }

    }
}