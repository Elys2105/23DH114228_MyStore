using _23DH114228_MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23DH114228_MyStore.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private masterEntities db = new masterEntities();
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View();
        }
    }
}