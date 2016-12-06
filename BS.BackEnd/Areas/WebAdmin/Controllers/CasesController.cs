using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS.RepositoryIService;
using Entity.Base; 

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class CasesController : Controller
    {
        private readonly ICasesService _cases;

        public CasesController(ICasesService casesServices)
        {
            _cases = casesServices;
        }

        // GET: WebAdmin/Cases
        public ActionResult Index()
        {
            return View();
        }
    }
}