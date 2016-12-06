using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class MailBoxController : Controller
    {
        // GET: WebAdmin/Task
        public ActionResult Inbox()
        {
            return View();
        }

        public ActionResult MailDetails()
        {
            return View();
        }
    }
}