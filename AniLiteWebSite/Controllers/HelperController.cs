using AniLiteWebSite.Core;
using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AniLiteWebSite.Controllers
{
    public class HelperController : MyController
    {
        //
        // GET: /Helper/

        public ActionResult AuthWidget()
        {
            if (ControllerContext.ParentActionViewContext == null) RedirectToAction("Error","Error");
            if(User == null)
            {
                ViewData["AuthURI"] = AuthLink;
                return View();
            }
            var rd = ControllerContext.ParentActionViewContext.RouteData;
            ViewData["PAction"] = rd.GetRequiredString("action") as string;
            ViewData["PController"] = rd.GetRequiredString("controller") as string;
            return View(User);
        }

        public ActionResult MainMenu()
        {
            if (ControllerContext.ParentActionViewContext == null)
            {
                return RedirectToAction("Error", "Error");
            }
            else
            {
                var rd = ControllerContext.ParentActionViewContext.RouteData;
                ViewData["PAction"] = rd.GetRequiredString("action") as string;
                ViewData["PController"] = rd.GetRequiredString("controller") as string;
                //ViewData["ULevel"] = UserLevel;
                return View();
            }
        }
        
        public ActionResult Logout()
        {
            var cookie = new HttpCookie("Login", "");
            Response.SetCookie(cookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            try
            {
                var info = Auth.Clients.First().GetUserInfo(Request.QueryString);
                if (info == null) { return RedirectToAction("Authorization", "Error"); }
                User usr = sqlRepository.GetUserByIdGoogle(info.Id);
                if (usr == null)
                {
                    usr = new User();
                    usr.IdGoogle = info.Id;
                    usr.Role = sqlRepository.GetRoleById(1);
                    usr.IdU = Guid.NewGuid().ToString();
                }
                usr.LastLogin = DateTime.Now;
                usr.FirstName = info.FirstName;
                usr.SecondName = info.LastName;
                usr.Email = info.Email;
                usr.AvatarURI = info.PhotoUri;

                if (!sqlRepository.CreateUser(usr))
                    if (!sqlRepository.UpdateUser(usr))
                    {
                        return RedirectToAction("Authorization", "Error");
                    }

                User = usr;
                if (User == null) return RedirectToAction("Authorization", "Error");
                return RedirectToAction("Index", "Home");;
            }
            catch { return RedirectToAction("Authorization", "Error"); }
        }
    }
}
