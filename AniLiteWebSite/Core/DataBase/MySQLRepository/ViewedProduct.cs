using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase
{
    public partial class MySQLRepository : ISQLRepository
    {
        public ViewedProduct getViewedByProductAndUser(Product product, User user)
        {
            if (product == null) return null;
            if (user == null) return null;
            var query = from u in user.Viewed where u.Product == product select u;
            if (query.Count() == 0) return null;
            return query.First();
        }

        
    }
}
