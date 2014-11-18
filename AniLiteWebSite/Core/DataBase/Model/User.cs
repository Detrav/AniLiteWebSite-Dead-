using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase.Model
{
    public class User
    {
        public User()
        {
            this.Viewed = new List<ViewedProduct>();
            this.History = new List<Story>();
            this.Products = new List<Product>();
        }

        //Значения

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string IdGoogle { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string SecondName { get; set; }
        [MaxLength(250)]
        public string AvatarURI { get; set; }
        [MaxLength(50)]
        public string IdU { get; set; }

        public UserRole Role { get; set; }

        //Cвязи

        public virtual ICollection<ViewedProduct> Viewed { get; set; }
        public virtual ICollection<Story> History { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        // Дополнения

        public System.DateTime LastLogin { get; set; }
    }

    public enum UserRole : byte
    {
        [Display(Name = "Заблокировано")]
        Ban = 0,
        [Display(Name= "Гость")]
        Guest = 1,
        [Display(Name = "Пользователь")]
        User = 11,
        [Display(Name = "Модератор")]
        Moderator = 21,
        [Display(Name = "Администратор")]
        Administrator = 31,
        [Display(Name = "Создатель")]
        Creator = 41
    }
}