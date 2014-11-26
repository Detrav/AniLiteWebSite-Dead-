using AniLiteWebSite.Core.DataBase.Model;
using AniLiteWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase
{
    public interface ISQLRepository
    {
        #region User
        bool CreateUser(User usr);
        User CreateOrUpdateUser(OAuth2.Models.UserInfo usr);
        bool UpdateUser(User usr);
        User GetUserByIdGoogle(string p);
        #endregion User

        #region Product
        bool AddProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> getProducts(int from, int size);
        IEnumerable<ProductSimple> GetProductSimples(int from, int size,User usr);
        #endregion Product

        ViewedProduct getViewedByProductAndUser(Product product, User user);

        ProductDetails GetProductDetailsById(int id);
        bool UpdateProductByDetails(ProductDetails pd);

        bool AddView(int ProductId, int UserId);
        bool RemoveView(int ViewId, int UserId);
        bool UpdateView(int ViewId, int UserId, int Value);
        int ProductNumEpisode(Product product);

        ViewDetails GetViewDetails(int ProductId, int UserId);

        bool UpdateViewStar(int ViewId, int UserId);
    }
}