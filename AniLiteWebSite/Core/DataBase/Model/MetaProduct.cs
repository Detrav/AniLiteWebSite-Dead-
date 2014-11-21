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
        [NotMapped]
        public DateTime DateTime
        {
            get
            {
                try { return DateTime.Parse(Data); }
                catch { return DateTime.MinValue; }
            }
            set
            {
                Data = value.ToString();
            }
        }
        [NotMapped]
        public string String
        {
            get { return Data; }
            set { Data = value; }
        }
        [NotMapped]
        public int Int
        {
            get
            {
                try { return int.Parse(Data); }
                catch { return 0; }
            }
            set
            {
                Data = value.ToString();
            }

        }
        [NotMapped]
        public bool Bool
        {
            get
            {
                try { return bool.Parse(Data); }
                catch { return false; }
            }
            set
            {
                Data = value.ToString();
            }

        }
    }

    public enum TypeOfMetaProduct : int
    {
        [Display(Name="Начало трансляции")]
        Begin = 0,
        [Display(Name = "Конец трансляции")]
        End = 10,
        [Display(Name = "Закончилось?")]
        Ended = 20,
        [Display(Name = "Название на других языках")]
        Name = 30,
        [Display(Name = "Количество эпизодов")]
        NumberOfEpisode = 40,
        [Display(Name = "Логотип откуда взята информация")]
        PosterFromURI = 50,
        [Display(Name = "Источник информации")]
        FromURI = 60,
        [Display(Name = "Страна")]
        Country = 70,
        [Display(Name = "Жанр")]
        Genre = 80,
        [Display(Name = "Тип произведения")]
        Type = 90, // ТВ, Полнометражка, короткометражка
        [Display(Name = "Вид произведения")]
        View = 100,// Кино Анимация 3D
        [Display(Name = "Режисёр")]
        Director = 110,
        [Display(Name = "Автор оригинала")]
        Author = 120,
        [Display(Name = "В ролях")]
        InRole = 130
    }
}
