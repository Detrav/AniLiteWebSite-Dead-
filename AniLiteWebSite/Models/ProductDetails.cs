﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Models
{
    public class ProductDetails
    {
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }

        IEnumerable<string> Names { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Рейтинг")]
        public float Rate { get; set; }

        [DisplayName("Постер")]
        public string AvatarURI { get; set; }

        [DisplayName("Утверждено?")]
        public bool Confirmed { get; set; }

        [DisplayName("Автор")]
        public string UserName { get; set; }
        
        [DisplayName("Начало трансляции")]
        public DateTime Begin { get; set; }
        [DisplayName("Конец трансляции")]
        public DateTime End { get; set; }

        [DisplayName("Закончилось")]
        public bool Ended { get; set; }

        [DisplayName("Количество эпизодов")]
        public int NumOfEpisode { get; set; }

        [DisplayName("Постер ссылки на источник")]
        public string PosterFromURI { get; set; }

        [DisplayName("Ссылка на источник")]
        public string FromURI { get; set; }
    }
}
