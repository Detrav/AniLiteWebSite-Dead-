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
        public bool AddView(int ProductId, int UserId)
        {
            var product = Db.Products.Find(ProductId);
            if (product == null) return false;
            var user = Db.Users.Find(UserId);
            if (user == null) return false;
            var query1 = from m in Db.ProductVieweds where m.Product.Id == product.Id select m;
            var query2 = from m in query1 where m.User.Id == user.Id select m;
            foreach(var it in query2)
            {
                return false;
            }
            ViewedProduct vp = new ViewedProduct { Product = product, User = user, Current = 0, End = false, Reminder = "" };
            Db.ProductVieweds.Add(vp);
            Db.SaveChanges();
            return true;
        }
        public bool RemoveView(int ViewId, int UserId)
        {
            var viewed = Db.ProductVieweds.Find(ViewId);
            if (viewed == null) return false;
            if (viewed.User.Id != UserId) return false;
            Db.ProductVieweds.Remove(viewed);
            Db.SaveChanges();
            return true;
        }
        public bool UpdateView(int ViewId, int UserId, int Value)
        {
            var viewed = Db.ProductVieweds.Find(ViewId);
            if (viewed == null) return false;
            if (viewed.User.Id != UserId) return false;
            viewed.Current += Value;
            if (viewed.Current < 0) viewed.Current = 0;
            var num = ProductNumEpisode(viewed.Product);
            if (viewed.Current > num) viewed.Current = num;
            Db.SaveChanges();
            return true;
        }

        public int ProductNumEpisode(Product product)
        {
            foreach (var it in product.MetaData) { if (it.Type == TypeOfMetaProduct.NumberOfEpisode) { return it.Int; } } return 0;
        }

        public ViewDetails GetViewDetails(int ProductId, int UserId)
        {
            ViewDetails vd = new ViewDetails();
            vd.ProductId = ProductId;
            vd.UserId = UserId;
            var query1 = from m in Db.ProductVieweds where m.Product.Id == ProductId select m;
            var query2 = from m in query1 where m.User.Id == UserId select m;
            ViewedProduct view = null;
            foreach (var it in query2)
            {
                view = it;
            }
            if (view == null) return vd;
            vd.ViewId = view.Id;
            vd.CurrentEpisode = view.Current;
            vd.MaxEpisode = 0;
            vd.AvatarURI = view.Product.AvatarURI;
            vd.Year = 0;
            vd.Names = new List<string>();
            vd.Names.Add(view.Product.Name);
            vd.FromURI = null;
            vd.PosterFromURI = null;
            vd.Reminder = view.Reminder;

            foreach(var it in view.Product.MetaData)
            {
                switch(it.Type)
                {
                    case TypeOfMetaProduct.NumberOfEpisode:
                        vd.MaxEpisode = it.Int;
                        break;
                    case TypeOfMetaProduct.Begin:
                        vd.Year = it.Date.Year;
                        break;
                    case TypeOfMetaProduct.Name:
                        vd.Names.Add(it.String);
                        break;
                    case TypeOfMetaProduct.FromURI:
                        vd.FromURI = it.String;
                        break;
                    case TypeOfMetaProduct.PosterFromURI:
                        vd.PosterFromURI = it.String;
                        break;
                }
            }
            return vd;
        }
    }
}
