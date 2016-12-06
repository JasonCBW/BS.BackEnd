using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: WebAdmin/Home
        public ActionResult Info()
        {
            return View();
        }
    }
}