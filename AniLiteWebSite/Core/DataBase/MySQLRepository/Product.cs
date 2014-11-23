﻿using AniLiteWebSite.Core.DataBase.Model;
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
                ps.AvatarURI64 = p.AvatarURI;
                var names = new List<string>();
                names.Add(p.Name);
                if (usr != null)
                {
                    var query = from u in usr.Viewed where u.Product == p select u;
                    if (query.Count() > 0)
                    {
                        var v = query.First();
                        ps.Viewed = true;
                        ps.ViewedEnd = v.End;
                        ps.NumCurrent = v.Current;
                    }
                }
                foreach(var meta in p.MetaData)
                {
                    switch(meta.Type)
                    {
                        case TypeOfMetaProduct.Name: names.Add(meta.String); break;
                        case TypeOfMetaProduct.NumberOfEpisode: ps.NumOfEpisode = meta.Int; break;
                        case TypeOfMetaProduct.Begin: ps.Year = meta.DateTime.Year; break;
                        case TypeOfMetaProduct.PosterFromURI: ps.PosterFromURI = meta.String; break;
                        case TypeOfMetaProduct.FromURI: ps.FromURI = meta.String; break;

                    }
                }
                ps.Names = names;
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
                        pd.Begin = meta.DateTime;
                        break;
                    case TypeOfMetaProduct.End:
                        pd.End = meta.DateTime;
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

        public ProductEdit GetProductEditById(int id)
        {
            var p = GetProductById(id);
            if (p == null) return null;
            var pd = new ProductEdit();
            pd.Id = p.Id;
            pd.Name = p.Name;
            pd.Description = p.Description;
            List<string> names = null;
            pd.Rate = p.Rate;
            pd.AvatarURI = p.AvatarURI;
            pd.Confirmed = p.Confirmed;
            if (p.Who != null)
                try { pd.UserName = p.Who.FirstName + " " + p.Who.SecondName; }
                catch { pd.UserName = p.Who.Email; }
            List<string> genre = null;
            List<string> InRole = null;
            foreach (var meta in p.MetaData)
            {
                switch (meta.Type)
                {
                    case TypeOfMetaProduct.Name:
                        if (names == null) names = new List<string>();
                        names.Add(meta.String);
                        break;
                    case TypeOfMetaProduct.Begin:
                        pd.Begin = meta.DateTime;
                        break;
                    case TypeOfMetaProduct.End:
                        pd.End = meta.DateTime;
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
    }
}