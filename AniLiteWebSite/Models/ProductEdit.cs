using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Models
{
    public class ProductEdit:ProductDetails
    {
        public string AddNames { get; set; }
        public string RemoveNames { get; set; }
        public ProductEdit() { }
    }

    
}
