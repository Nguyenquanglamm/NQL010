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
    public class NhanviensADMController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();
        StringProcess aukey = new StringProcess();

        // GET: Admins/NhanviensADM
        public ActionResult Index()
        {
            var nhanviens = db.Nhanviens.Include(n => n.Chucvus).Include(n => n.Phongbans);
            return View(nhanviens.ToList());
        }

        // GET: Admins/NhanviensADM/Details/5
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

        // GET: Admins/NhanviensADM/Create
        public ActionResult Create()
        {
            if (db.Nhanviens.Count() == 0)
            {
                ViewBag.NewNVID = "NV01";
            }
            else
            {
                var NVID = db.Nhanviens.OrderByDescending(m => m.IDnhanvien).FirstOrDefault().IDnhanvien;
                var newID = aukey.AutoGenerateCode("NV", NVID);
                ViewBag.NewNVID = newID;
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu");
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban");
            return View();
        }

        // POST: Admins/NhanviensADM/Create
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

        // GET: Admins/NhanviensADM/Edit/5
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

        // POST: Admins/NhanviensADM/Edit/5
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

        // GET: Admins/NhanviensADM/Delete/5
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

        // POST: Admins/NhanviensADM/Delete/5
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
