using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NQLBaiTapLon010.Models;

namespace NQLBaiTapLon010.Controllers
{
    public class HopdongsController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: Hopdongs
        public ActionResult Index()
        {
            var hopdongs = db.Hopdongs.Include(h => h.Nhanviens);
            return View(hopdongs.ToList());
        }

        // GET: Hopdongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            return View(hopdong);
        }

        // GET: Hopdongs/Create
        public ActionResult Create()
        {
            ViewBag.IDnhanvien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien");
            return View();
        }

        // POST: Hopdongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDnhanvien,Ngaykyket,Thoihanhopdong")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                db.Hopdongs.Add(hopdong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDnhanvien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien", hopdong.IDnhanvien);
            return View(hopdong);
        }

        // GET: Hopdongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDnhanvien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien", hopdong.IDnhanvien);
            return View(hopdong);
        }

        // POST: Hopdongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDnhanvien,Ngaykyket,Thoihanhopdong")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopdong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDnhanvien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien", hopdong.IDnhanvien);
            return View(hopdong);
        }

        // GET: Hopdongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            return View(hopdong);
        }

        // POST: Hopdongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hopdong hopdong = db.Hopdongs.Find(id);
            db.Hopdongs.Remove(hopdong);
            db.SaveChanges();
            return RedirectToAction("Index");
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
