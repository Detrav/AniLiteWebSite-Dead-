using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Core.DataBase.Model
{
    public class ViewedProduct
    {
        // Значения

        [Key]
        public int Id { get; set; }
        [Required]
        public int Current { get; set; }
        public bool End { get; set; }
        [MaxLength(500)]
        public string Reminder { get; set; }
        // Связи

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
