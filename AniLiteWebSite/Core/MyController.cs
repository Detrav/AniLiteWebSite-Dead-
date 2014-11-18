using AniLiteWebSite.Core.DataBase;
using AniLiteWebSite.Core.DataBase.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ninject;
using OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AniLiteWebSite.Core
{
    public class MyController : Controller
    {
        private string _AuthLink;
        private User _User;
        private bool _UserTry = false;

        [Inject]
        public AuthorizationRoot Auth { get; set; }

        [Inject]
        public ISQLRepository sqlRepository { get; set; }
        public string AuthLink
        {
            get
            {
                if (_AuthLink == null)
                { 
                    try
                    {
                        _AuthLink = Auth.Clients.First().GetLoginLinkUri();
                    }
                    catch
                    {
                        _AuthLink = "";
                    }
                }
                return _AuthLink;
            }
        }

        new public User User
        {
            get
            {
                if (_UserTry == false)
                {
                    try
                    {
                        var cookie = Request.Cookies["login"].Value;
                        var data = Convert.FromBase64String(cookie);
                        var str = Encoding.UTF8.GetString(data);
                        var array = (JObject)JsonConvert.DeserializeObject(str);

                        var user = sqlRepository.GetUserByIdGoogle((string)array["IdGoogle"]);
                        _User = user;
                        _UserTry = true;
                    }
                    catch
                    {
                        _UserTry = true;
                    }
                }
                return _User;
            }
            set
            {
                _UserTry = true;
                try
                {
                    string array = @"{'IdGoogle': '" + value.IdGoogle + @"','IdU': '" + value.IdU + @"'}";
                    var bytes = Encoding.UTF8.GetBytes(array);
                    var cookie = new HttpCookie("Login", Convert.ToBase64String(bytes));
                    Response.SetCookie(cookie); 
                    _User = value;
                }
                catch
                {
                    _User = null;
                    var cookie = new HttpCookie("Login", "");
                    Response.SetCookie(cookie);
                }
            }
        }

        public new UserRole UserRole
        {
            get
            {
                if (User != null)
                    return User.Role;
                return UserRole.Guest;
            }
        }
    }
}