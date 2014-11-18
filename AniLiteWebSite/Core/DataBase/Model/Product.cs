using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase.Model
{
    public class Product
    {
        public Product()
        {
            this.Viewed = new List<ViewedProduct>();
            this.MetaData = new List<MetaProduct>();
        }

        // Значения

        [DisplayName("#")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MaxLength(4000)]
        public string Description { get; set; }

        [DisplayName("Рейтинг")]
        public float Rate { get; set; }

        [DisplayName("Постер")]
        [MaxLength(250)]
        public string AvatarURI { get; set; }

        [DisplayName("Ссылка на информацию")]
        [MaxLength(250)]
        public string FromURI { get; set; }

        [DisplayName("Утверждено?")]
        public bool Confirmed { get; set; }

        // Связи

        public virtual ICollection<ViewedProduct> Viewed { get; set; }
        public virtual User Who { get; set; }
        public virtual ICollection<MetaProduct> MetaData { get; set; }
    }
}