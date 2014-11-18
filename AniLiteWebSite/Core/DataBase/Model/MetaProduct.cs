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
    }

    public enum TypeOfMetaProduct : int
    {
        Begin = 0,
        End = 10,
        Ended = 20,
        Name = 30,
        NumberOfEpisode = 40,
        PosterFromURI = 50,
        FromURI = 60
    }
}
