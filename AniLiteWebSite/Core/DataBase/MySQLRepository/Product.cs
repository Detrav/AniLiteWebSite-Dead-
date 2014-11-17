using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase
{
    public partial class MySQLRepository : ISQLRepository
    {
        public bool AddProduct(Product product)
        {
            if (product.Id != 0) return false;
            Db.Products.Add(product);
            Db.SaveChanges();
            return true;
        }

        public IEnumerable<Product> getProducts(int from, int size)
        {
            try
            {
                return Db.Products.OrderBy(u => u.Id).Skip(from).Take(size).ToList();
            }
            catch { return new List<Product>(); }
            
        }
    }
}