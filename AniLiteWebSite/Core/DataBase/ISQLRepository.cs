using AniLiteWebSite.Core.DataBase.Model;
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

        #region UserRole
        UserRole GetRoleById(int p);
        #endregion UserRole

        #region Product
        bool AddProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> getProducts(int from, int size);
        #endregion Product

        ViewedProduct getViewedByProductAndUser(Product product, User user);
    }
}