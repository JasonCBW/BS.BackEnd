using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class FromController : Controller
    {
        // GET: WebAdmin/From
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Components()
        {
            return View();
        }

        public ActionResult Examples()
        {
            return View();
        }

        public ActionResult Validation()
        {
            return View();
        }
    }
}