using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase
{
    public partial class MySQLRepository : ISQLRepository
    {
        [Inject]
        public AniLiteDBContext Db { get; set; }
    }
}