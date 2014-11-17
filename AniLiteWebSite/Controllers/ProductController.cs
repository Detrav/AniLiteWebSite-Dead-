using AniLiteWebSite.Core;
using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AniLiteWebSite.Controllers
{
    public class ProductController : MyController
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            Product p = new Product();
            return View(p);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if(ModelState.IsValid)
            {
                product.AddedBy = User;
                product.Added = DateTime.Now;
                product.EditedBy = null;
                product.Edited = DateTime.MinValue;
                if(sqlRepository.AddProduct(product))
                {
                    return RedirectToAction("Details", "Product", new { id = product.Id });
                }
                return RedirectToAction("Error", "Error");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
