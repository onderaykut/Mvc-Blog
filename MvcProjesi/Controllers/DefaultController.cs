using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjesi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headinglist = hm.GetList();

            return View(headinglist);

        }

        // GET: Default
        public PartialViewResult Index(int id = 0)
        {
            var contentlist = cm.GetListByHeadingId(id);
            return PartialView(contentlist);
        }
    }
}