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
                User = sqlRepository.CreateOrUpdateUser(info);
                if (User == null) return RedirectToAction("Authorization", "Error");
                return RedirectToAction("Index", "Home"); ;
            }
            catch (Exception e)
            {
                return RedirectToAction("Authorization", "Error");
            }
        }
    }
}
