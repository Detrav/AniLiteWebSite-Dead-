using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Models
{
    public class ProductEdit
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MaxLength(4000)]
        public string Description { get; set; }

        [DisplayName("Постер")]
        [MaxLength(250)]
        public string AvatarURI { get; set; }

        [DisplayName("Утверждено?")]
        public bool Confirmed { get; set; }

        public List<MetaProduct> MetaData { get; set; }
        public TypeOfMetaProduct ForAdd { get; set; }
        public string AddMeta { get; set; }
        public string DeleteMeta { get; set; }
    }

    
}
