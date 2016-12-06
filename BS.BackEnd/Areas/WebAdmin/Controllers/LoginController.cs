using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: WebAdmin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lock()
        {
            return View();
        } 

    }
}