using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBWebMvcApp.Controllers
{
    using Models;
    public class HomeController : Controller
    {
        ShopEntities model = new ShopEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            return View(model.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            ViewBag.SelectedProductId = id;

            Product product = model.Products.Find(id);
            model.Entry(product).Collection(c => c.Orders).Load(); //explict loading for navigation property

            return View(product.Orders);
        }

        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            Counter ctr = model.Counters.Find("product");
            product.Id = ++ctr.CurrentValue + 100;
            model.Products.Add(product);
            model.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}