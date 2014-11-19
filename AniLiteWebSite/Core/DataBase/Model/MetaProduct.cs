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
        Begin = 0,
        End = 10,
        Ended = 20,
        Name = 30,
        NumberOfEpisode = 40,
        PosterFromURI = 50,
        FromURI = 60,
        Country = 70,
        Genre = 80,
        Type = 90, // ТВ, Полнометражка, короткометражка
        View = 100,// Кино Анимация 3D
        Director = 110,
        Author = 120,
        InRole = 130
    }
}
