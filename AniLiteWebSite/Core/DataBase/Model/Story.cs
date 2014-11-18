using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase.Model
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Data { get; set; }
        [Required]
        public DateTime When { get; set; }
        [Required]
        virtual public User Who { get; set; }
    }
}