using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase
{
    public partial class MySQLRepository : ISQLRepository
    {
        public UserRole GetRoleById(int p)
        {
            try { return Db.UserRoles.Find(p); }
            catch { return null; }
        }
    }
}