using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class WidgetController : Controller
    {
        // GET: WebAdmin/Widget
        public ActionResult Index()
        {
            return View();
        }
    }
}