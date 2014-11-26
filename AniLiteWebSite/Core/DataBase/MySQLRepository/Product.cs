using AniLiteWebSite.Core.DataBase.Model;
using AniLiteWebSite.Models;
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

        public Product GetProductById(int id)
        {
            try { return Db.Products.Find(id); }
            catch{ return null;}
        }

        public IEnumerable<Product> getProducts(int from, int size)
        {
            try
            {
                return Db.Products.OrderBy(u => u.Id).Skip(from).Take(size).ToList();
            }
            catch { return new List<Product>(); }
            
        }

        public IEnumerable<ProductSimple> GetProductSimples(int from, int size, User usr)
        {
            var products = Db.Products.OrderBy(u => u.Id).Skip(from).Take(size).ToList();
            var productsimples = new List<ProductSimple>();
            foreach(var p in products)
            {
                ProductSimple ps = new ProductSimple();
                ps.id = p.Id;
                productsimples.Add(ps);
            }

            return productsimples;
        }

        public ProductDetails GetProductDetailsById(int id)
        {
            var p = GetProductById(id);
            if (p == null) return null;
            var pd = new ProductDetails();
            pd.Id = p.Id;
            pd.Name = p.Name;
            pd.Description = p.Description;
            List<string> names = null;
            pd.Rate = p.Rate;
            pd.AvatarURI = p.AvatarURI;
            pd.Confirmed = p.Confirmed;
            if(p.Who!=null)
            try { pd.UserName = p.Who.FirstName + " " + p.Who.SecondName; }
            catch { pd.UserName = p.Who.Email; }
            List<string> genre = null;
            List<string> InRole = null;
            foreach(var meta in p.MetaData)
            {
                switch(meta.Type)
                {
                    case TypeOfMetaProduct.Name:
                        if (names == null) names = new List<string>();
                        names.Add(meta.String);
                        break;
                    case TypeOfMetaProduct.Begin:
                        pd.Begin = meta.Date;
                        break;
                    case TypeOfMetaProduct.End:
                        pd.End = meta.Date;
                        break;
                    case TypeOfMetaProduct.Ended:
                        pd.Ended = meta.Bool;
                        break;
                    case TypeOfMetaProduct.NumberOfEpisode:
                        pd.NumOfEpisode = meta.Int;
                        break;
                    case TypeOfMetaProduct.PosterFromURI:
                        pd.PosterFromURI = meta.String;
                        break;
                    case TypeOfMetaProduct.FromURI:
                        pd.FromURI = meta.String;
                        break;
                    case TypeOfMetaProduct.Country:
                        pd.Country = meta.String;
                        break;
                    case TypeOfMetaProduct.Genre:
                        if (genre == null) genre = new List<string>();
                        genre.Add(meta.String);
                        break;
                    case TypeOfMetaProduct.Type:
                        pd.Type = meta.String;
                        break;
                    case TypeOfMetaProduct.View:
                        pd.View = meta.String;
                        break;
                    case TypeOfMetaProduct.Director:
                        pd.Director = meta.String;
                        break;
                    case TypeOfMetaProduct.Author:
                        pd.Author = meta.String;
                        break;
                    case TypeOfMetaProduct.InRole:
                        if (InRole == null) InRole = new List<string>();
                        InRole.Add(meta.String);
                        break;
                }
            }
            pd.Names = names;
            pd.Genre = genre;
            pd.InRole = InRole;
            return pd;
        }

        public bool UpdateProductByDetails(ProductDetails pd)
        {
            if (pd == null) return false;
            if (pd.Id == 0) return false;
            var p = GetProductById(pd.Id);
            if (p == null) return false;
            p.Name = pd.Name;
            p.Description = pd.Description;
            p.Confirmed = pd.Confirmed;
            p.AvatarURI = pd.AvatarURI;
            List<MetaProduct> mp = new List<MetaProduct>();
            if (pd.Names != null) { foreach (var name in pd.Names) { if (name != "") { mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Name, String = name }); } } }
            if (pd.Begin > DateTime.Now.AddYears(-200)) mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Begin, Date = pd.Begin });
            if (pd.End > DateTime.Now.AddYears(-200)) mp.Add(new MetaProduct { Type = TypeOfMetaProduct.End, Date = pd.End });
            if (pd.Ended) mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Ended, Bool = pd.Ended });
            if (pd.NumOfEpisode > 0) mp.Add(new MetaProduct { Type = TypeOfMetaProduct.NumberOfEpisode, Int = pd.NumOfEpisode });
            if (pd.FromURI != null) if (pd.FromURI != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.FromURI, String = pd.FromURI });
            if (pd.PosterFromURI != null) if (pd.PosterFromURI != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.PosterFromURI, String = pd.PosterFromURI });
            if (pd.Country != null) if (pd.Country != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Country, String = pd.Country });
            if (pd.Genre != null) { foreach (var gen in pd.Genre) { if (gen != "") { mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Genre, String = gen }); } } }
            if (pd.Type != null) if (pd.Type != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Type, String = pd.Type });
            if (pd.View != null) if (pd.View != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.View, String = pd.View });
            if (pd.Director != null) if (pd.Director != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Director, String = pd.Director });
            if (pd.Author != null) if (pd.Author != "") mp.Add(new MetaProduct { Type = TypeOfMetaProduct.Author, String = pd.Author });
            if (pd.InRole != null) { foreach (var role in pd.InRole) { if (role != "") { mp.Add(new MetaProduct { Type = TypeOfMetaProduct.InRole, String = role }); } } }

            var mpOld = p.MetaData.ToList();
            int i = 0;
                for(;i<mpOld.Count;i++)
                {
                    if (mp.Count > i)
                    {
                        mpOld[i].Type = mp[i].Type;
                        mpOld[i].Data = mp[i].Data;
                    }
                    else
                    {
                        Db.MetaProducts.Remove(mpOld[i]);
                    }
                }
                for (; i < mp.Count; i++)
                {
                    p.MetaData.Add(mp[i]);
                }
            
            Db.SaveChanges();
            return true;
        }
    }
}