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
        }

        // Значения

        [DisplayName("#")]
        [Key]
        public int Id { get; set; }
        [DisplayName("Название")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Название на других языках")]
        [MaxLength(1000)]
        public string FullName { get; set; }
        [DisplayName("Описание")]
        [MaxLength(4000)]
        public string Description { get; set; }
        [DisplayName("Начало трансляции")]
        public DateTime Begin { get; set; }
        [DisplayName("Закончилось?")]
        public bool Ended { get; set; }
        [DisplayName("Конец трансляции")]
        public DateTime End { get; set; }
        [DisplayName("Количество эпизодов")]
        public int NumberofEpisode { get; set; }
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

        //Дополнения
        [DisplayName("Добавленно:")]
        public virtual User AddedBy { get; set; }
        [DisplayName("Отредактировано")]
        public virtual User EditedBy { get; set; }
        [DisplayName("Добавленно")]
        public DateTime Added { get; set; }
        [DisplayName("Отредактировано")]
        public DateTime Edited { get; set; }
    }
}