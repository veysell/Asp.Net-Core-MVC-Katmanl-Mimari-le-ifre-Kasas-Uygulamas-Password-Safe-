using BusinnesLayer.Concrete;
using DataAccessLayer.Context;
using EntitiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordApp.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password
        PasswordRepository passwordRepository = new PasswordRepository();
        DataContext db = new DataContext();
        [Authorize]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["Id"]);
            var passwordList = db.Passwords.Where(x => x.UserId == id).ToList();
            return View(passwordList);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Password p)
        {
            if (ModelState.IsValid)
            {
                p.UserId = Convert.ToInt32(Session["Id"]);
                passwordRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu");
            passwordRepository.Insert(p);
            return View();
        }

        public ActionResult Update(int id)
        {
            var update = passwordRepository.GetById(id);
            return View(update);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Password p)
        {
            if (ModelState.IsValid)
            {
                var update = passwordRepository.GetById(p.Id);
                update.SiteUserName = p.SiteUserName;
                update.SitePassword = p.SitePassword;
                update.ReSitePassword = p.ReSitePassword;
                update.WebSiteName = p.WebSiteName;
                update.UserId = Convert.ToInt32(Session["Id"]);
                passwordRepository.Update(update);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu");
            return View();
        }

     
        public ActionResult Delete(int id)
        {
            var delete = passwordRepository.GetById(id);
            passwordRepository.Delete(delete);
            return RedirectToAction("Index");
        }
    }
}