using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
      

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelistIn = mm.GetListInbox(p);
            return View(messagelistIn);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelistsend = mm.GetListSendbox(p);
            return View(messagelistsend);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];

            ValidationResult results = messageValidator.Validate(p);
            p.SenderMail = sender;
            

            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);

                return RedirectToAction("Sendbox");
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
    }
}