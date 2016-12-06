using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS.RepositoryIService;
using Entity.Base;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;

        public ProductController(IProductService productServices)
        {
            _product = productServices;
        }

        // GET: WebAdmin/Product
        public ActionResult Index()
        { 
            return View();
        }
    }
}