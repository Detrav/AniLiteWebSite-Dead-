using AniLiteWebSite.Core.DataBase.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core
{
    [Serializable()]
    public class SConfiguration
    {

        public UserRole DefaultRole;
    }
}