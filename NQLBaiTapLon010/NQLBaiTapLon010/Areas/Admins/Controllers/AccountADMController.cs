using NQLBaiTapLon010.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NQLBaiTapLon010.Areas.Admins.Controllers
{
    public class AccountADMController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();
        Encrytion enc = new Encrytion();
        Process strPro = new Process();
        // GET: Accounts
        public ActionResult Login(string returnUrl)

        {
            if (CheckSession() == 1)

            {

                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            }
            else if (CheckSession() == 2)

            {
                return RedirectToAction("Index", "HomeNV", new { Area = "NVClient" });


            }
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(Account acc, string returnUrl)

        {
            try
            {
                if (!string.IsNullOrEmpty(acc.UseName) && !string.IsNullOrEmpty(acc.PassWord))
                {

                    using (var db = new LTQLDbContext())

                    {
                        var passToMD5 = strPro.GetMD5(acc.PassWord);
                        var account = db.Accounts.Where(m => m.UseName.Equals(acc.UseName) && m.PassWord.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UseName, false);
                            Session["idUser"] = acc.UseName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectTolocal(returnUrl);
                        }

                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");

                    }
                }
                ModelState.AddModelError("", "Username and password is required.");
            }

            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                //Mã Hóa mật khẩu trước khi cho vào database
                acc.PassWord = enc.PasswordEncrytion(acc.PassWord);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index", "AccountADM", new { Area = "Admins" });
            }
            return View(acc);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["iduser"] = null;
            return RedirectToAction("Login", "Accounts");
        }
        private ActionResult RedirectTolocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "HomeNV", new { Area = "NVClient" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private int CheckSession()
        {
            using (var db = new LTQLDbContext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "client")
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }

        public ActionResult Change_password(string id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change_password(Account acc, FormCollection form)
        {



            if (ModelState.IsValid)
            {
                try
                {
                    acc.PassWord = enc.PasswordEncrytion(form["PassWord"]);
                    db.Entry(acc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
                }
            }
            ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
            return View(acc);
        }
        public ActionResult Change_password_ADM(string id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change_password_ADM(Account acc, FormCollection form)
        {



            if (ModelState.IsValid)
            {
                try
                {
                    acc.PassWord = enc.PasswordEncrytion(form["PassWord"]);
                    db.Entry(acc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home", new { Area = "Admins" });
                }
                catch
                {
                    ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
                }
            }
            ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
            return View(acc);
        }
    }
}