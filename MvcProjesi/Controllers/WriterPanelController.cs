using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjesi.Controllers
{

    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        Context c = new Context(); 
        
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id= 0)  /* başlangıcta 0 olacak yoksa null donuyo*/
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = p; /*viewbag ile mail değerini view'a taşıyorum.*/
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.a = id;  /*viewbag ile id değerini view'a taşıyorum.*/
            var writervalues = wm.GetById(id);
            return View(writervalues);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            //   wm.WriterUpdate(p);

        }


        public ActionResult MyHeading(string p)
        {
          
            p = (string)Session["WriterMail"];

           var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var headingvalues = hm.GetListByWriter(writeridinfo);
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;  // bu deger ViewBag ile View e taşınacak (writeridinfo)

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                           ).ToList();
            ViewBag.vlc = valuecategory;
           
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            p.WriterID = writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
           
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlc = valuecategory;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetById(id);
            headingvalues.HeadingStatus = false;
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int page=1)
        {
            var headings = hm.GetList().ToPagedList(page, 4); //page'den itibaren 4er 4er getir.
            return View(headings); 
        }

    }
}
 //< customErrors mode = "On" >
 
 //          < error statusCode = "404" redirect = "/ErrorPage/Page404/" />
    
 //         </ customErrors >