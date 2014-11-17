using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniLiteWebSite.Core.DataBase
{
    public partial class MySQLRepository : ISQLRepository
    {
        public bool CreateUser(User usr)
        {
            if (usr == null) return false;
            if (usr.Id != 0) return false;
            if (usr.LastLogin == null) usr.LastLogin = DateTime.MinValue;
            usr.Edited = DateTime.MinValue;
            usr.Added = DateTime.Now;
            if(usr.IdU ==null) usr.IdU = Guid.NewGuid().ToString();
            Db.Users.Add(usr);
            Db.SaveChanges();
            return true;
        }
        public bool UpdateUser(User usr)
        {
            if (usr == null) return false;
            var user = Db.Users.Find(usr.Id);
            if (user == null) return false;
            user.IdGoogle = usr.IdGoogle;
            user.Email = usr.Email;
            user.FirstName = usr.FirstName;
            user.SecondName = usr.SecondName;
            user.AvatarURI = usr.AvatarURI;
            user.IdU = usr.IdU;
            user.Added = usr.Added;
            user.Edited = DateTime.Now;
            user.LastLogin = usr.LastLogin;
            user.Role = usr.Role;
            Db.SaveChanges();
            return true;
        }
        public User GetUserByIdGoogle(string p)
        {
            var query = from u in Db.Users where u.IdGoogle == p select u;
            if (query.Count() == 0) { return null; }
            return query.First();
        }
    }
}
