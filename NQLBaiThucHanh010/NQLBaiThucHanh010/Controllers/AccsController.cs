using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NQLBaiThucHanh010.Models;

namespace NQLBaiThucHanh010.Controllers
{
    public class AccsController : Controller
    {
        private LtqlDbContext db = new LtqlDbContext();


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Acc account)
        {
            if (ModelState.IsValid)
            {
                db.Accs.Add(account);
                db.SaveChanges();
            }
            return RedirectToAction("Login","Accs");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Acc account)
        {

            var model = db.Accs.Where(m => m.UseName == account.UseName && m.PassWord == account.PassWord).ToList().Count();
            if (model == 1)
            {
                FormsAuthentication.SetAuthCookie(account.UseName, true);
                return RedirectToAction("Index", "Home");
            }else
            {
               
            }
            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UseName,PassWord,RoleID")] Acc acc)
        {
            if (ModelState.IsValid)
            {
                db.Accs.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acc);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
