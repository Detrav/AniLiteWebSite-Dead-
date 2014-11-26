using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Models
{
    public class ViewDetails
    {
        public int UserId { get; set; }
        public int ViewId { get; set; }
        public UserRole Role { get; set; }
        public int ProductId { get; set; }
        public int CurrentEpisode { get; set; }
        public int MaxEpisode { get; set; }
        public string AvatarURI { get; set;}
        public int Year { get; set; }
        public List<string> Names { get; set; }
        public string FromURI { get; set; }
        public string PosterFromURI { get; set; }
        public string Reminder { get; set; }

        public string Condition { get; set; }
        public bool Star { get; set; }
    }
}
