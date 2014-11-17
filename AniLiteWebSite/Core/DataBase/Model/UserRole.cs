using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Core.DataBase.Model
{
    public class UserRole
    {
        public UserRole()
        {
            this.Users = new List<User>();
        }

        //Значения

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        [Required]
        public int Level { get; set; }

        //Связи

        public virtual ICollection<User> Users { get; set; }

        //Дополнения

        public System.DateTime Added { get; set; }
        public System.DateTime Edited { get; set; }
    }
}
