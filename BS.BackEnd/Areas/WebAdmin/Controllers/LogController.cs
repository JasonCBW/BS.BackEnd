using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class LogController : Controller
    {
        // GET: WebAdmin/Log
        public ActionResult Index()
        {
            return View();
        }
    }
}