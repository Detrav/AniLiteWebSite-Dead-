using AniLiteWebSite.Core;
using AniLiteWebSite.Core.DataBase.Model;
using AniLiteWebSite.Models;
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

        public ActionResult Index(int from = 0,int size = 10)
        {
            IEnumerable<ProductSimple> products = sqlRepository.GetProductSimples(from, size,User);
            return View(products);
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
            var product = sqlRepository.GetProductById(id);
            if (product == null) return RedirectToAction("Error", "Error");
            return View(product);
        }

    }
}
