using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Models
{
    public class ProductSimple
    {
        public int id;
        public string AvatarURI64;
        public IEnumerable<string> Names;

        public bool Viewed;
        public bool ViewedEnd;
        public int NumCurrent;

        public int Year;
        public int NumOfEpisode;
        public string FromURI;
        public string PosterFromURI;
    }
}
