using System;
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
    public class NhanvienTTsADMController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: Admins/NhanvienTTsADM
        public ActionResult Index()
        {
            var nhanviens = db.NhanvienTTs.Include(n => n.Chucvus).Include(n => n.Phongbans);
            return View(nhanviens.ToList());
        }

        // GET: Admins/NhanvienTTsADM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanvienTT nhanvienTT = db.NhanvienTTs.Find(id);
            if (nhanvienTT == null)
            {
                return HttpNotFound();
            }
            return View(nhanvienTT);
        }

        // GET: Admins/NhanvienTTsADM/Create
        public ActionResult Create()
        {
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu");
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban");
            return View();
        }

        // POST: Admins/NhanvienTTsADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDnhanvien,Tennhanvien,Ngaysinhnhanvien,SDTnhanvien,Gioitinhnhanvien,Diachinhanvien,CCCDnhanvien,IDchucvu,IDphongban,NgayVao,Thoigianthuctap")] NhanvienTT nhanvienTT)
        {
            if (ModelState.IsValid)
            {
                db.Nhanviens.Add(nhanvienTT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvienTT.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvienTT.IDphongban);
            return View(nhanvienTT);
        }

        // GET: Admins/NhanvienTTsADM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanvienTT nhanvienTT = db.NhanvienTTs.Find(id);
            if (nhanvienTT == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvienTT.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvienTT.IDphongban);
            return View(nhanvienTT);
        }

        // POST: Admins/NhanvienTTsADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDnhanvien,Tennhanvien,Ngaysinhnhanvien,SDTnhanvien,Gioitinhnhanvien,Diachinhanvien,CCCDnhanvien,IDchucvu,IDphongban,NgayVao,Thoigianthuctap")] NhanvienTT nhanvienTT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvienTT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvienTT.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvienTT.IDphongban);
            return View(nhanvienTT);
        }

        // GET: Admins/NhanvienTTsADM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanvienTT nhanvienTT = db.NhanvienTTs.Find(id);
            if (nhanvienTT == null)
            {
                return HttpNotFound();
            }
            return View(nhanvienTT);
        }

        // POST: Admins/NhanvienTTsADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanvienTT nhanvienTT = db.NhanvienTTs.Find(id);
            db.Nhanviens.Remove(nhanvienTT);
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
