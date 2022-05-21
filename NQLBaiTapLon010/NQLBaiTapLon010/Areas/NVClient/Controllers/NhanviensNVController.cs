using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NQLBaiTapLon010.Models;

namespace NQLBaiTapLon010.Areas.NVClient.Controllers
{
    public class NhanviensNVController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: NVClient/NhanviensNV
        public ActionResult Index()
        {
            var nhanviens = db.Nhanviens.Include(n => n.Chucvus).Include(n => n.Phongbans);
            return View(nhanviens.ToList());
        }

        // GET: NVClient/NhanviensNV/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: NVClient/NhanviensNV/Create
        public ActionResult Create()
        {
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu");
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban");
            return View();
        }

        // POST: NVClient/NhanviensNV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDnhanvien,Tennhanvien,Ngaysinhnhanvien,SDTnhanvien,Gioitinhnhanvien,Diachinhanvien,CCCDnhanvien,IDchucvu,IDphongban,NgayVao")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Nhanviens.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvien.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvien.IDphongban);
            return View(nhanvien);
        }

        // GET: NVClient/NhanviensNV/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvien.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvien.IDphongban);
            return View(nhanvien);
        }

        // POST: NVClient/NhanviensNV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDnhanvien,Tennhanvien,Ngaysinhnhanvien,SDTnhanvien,Gioitinhnhanvien,Diachinhanvien,CCCDnhanvien,IDchucvu,IDphongban,NgayVao")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvien.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvien.IDphongban);
            return View(nhanvien);
        }

        // GET: NVClient/NhanviensNV/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: NVClient/NhanviensNV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(id);
            db.Nhanviens.Remove(nhanvien);
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
