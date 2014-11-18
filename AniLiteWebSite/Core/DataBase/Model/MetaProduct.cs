using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Core.DataBase.Model
{
    public class MetaProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TypeOfMetaProduct Type { get; set; }
        [MaxLength(100)]
        public string Data { get; set; }

        public virtual Product Product { get; set; }

        public object Parse() { return null; }
        public void Set() { }
    }

    public enum TypeOfMetaProduct : int
    {
        Begin,
        End,
        Ended
    }
}
