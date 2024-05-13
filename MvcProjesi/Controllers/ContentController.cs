using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }  

        public ActionResult GetAllContents( string p)
        {
            p = "";   /* Başlangıçta tüm değerleri getirmek için p nin içiin boş bıraktım.*/
            var values = cm.GetList(p);
           
            if (string.IsNullOrEmpty(p))                

            {
                return View(values.ToList());
            }
            return View(values);          
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingId(id);
            return View(contentvalues);
        }

    }
}