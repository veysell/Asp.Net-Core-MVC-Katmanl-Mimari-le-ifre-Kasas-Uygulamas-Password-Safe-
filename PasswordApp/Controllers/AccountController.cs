using DataAccessLayer.Context;
using EntitiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PasswordApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Mail == data.Mail && x.Password == data.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                Session["Name"] = bilgiler.Name.ToString();
                Session["SurName"] = bilgiler.Surname.ToString();
                Session["Id"] = bilgiler.Id.ToString();
                return RedirectToActionPermanent("Index", "Password");
            }
            else
            {
                ViewBag.hata ="E-Posta yada şifre hatalı";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User data)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(data);
                db.SaveChanges();
                ModelState.AddModelError("", "Başarılı");
                return RedirectToAction("Login",data);
            }
            else
            {
                ModelState.AddModelError("", "Hatalı");
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}