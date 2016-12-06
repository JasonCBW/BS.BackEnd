using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class SettingController : Controller
    {
        // GET: WebAdmin/Setting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}