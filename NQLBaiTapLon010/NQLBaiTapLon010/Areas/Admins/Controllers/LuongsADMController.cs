﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NQLBaiTapLon010.Models;

namespace NQLBaiTapLon010.Areas.Admins.Controllers
{
    public class LuongsADMController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: Admins/LuongsADM
        public ActionResult Index()
        {
            var luongs = db.Luongs.Include(l => l.Nhanviens);
            return View(luongs.ToList());
        }

        // GET: Admins/LuongsADM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.Luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // GET: Admins/LuongsADM/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien");
            return View();
        }

        // POST: Admins/LuongsADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDNhanVien,Thang,LuongNgay,NgayCong,TamUng")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                db.Luongs.Add(luong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNhanVien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien", luong.IDNhanVien);
            return View(luong);
        }

        // GET: Admins/LuongsADM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.Luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhanVien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien", luong.IDNhanVien);
            return View(luong);
        }

        // POST: Admins/LuongsADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDNhanVien,Thang,LuongNgay,NgayCong,TamUng")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNhanVien = new SelectList(db.Nhanviens, "IDnhanvien", "Tennhanvien", luong.IDNhanVien);
            return View(luong);
        }

        // GET: Admins/LuongsADM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.Luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // POST: Admins/LuongsADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luong luong = db.Luongs.Find(id);
            db.Luongs.Remove(luong);
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
