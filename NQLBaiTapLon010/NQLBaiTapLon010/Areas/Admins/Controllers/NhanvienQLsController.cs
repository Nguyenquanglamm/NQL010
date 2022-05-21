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
    public class NhanvienQLsController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: Admins/NhanvienQLs
        public ActionResult Index()
        {
            var nhanviens = db.NhanvienQLs.Include(n => n.Chucvus).Include(n => n.Phongbans);
            return View(nhanviens.ToList());
        }

        // GET: Admins/NhanvienQLs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanvienQL nhanvienQL = db.NhanvienQLs.Find(id);
            if (nhanvienQL == null)
            {
                return HttpNotFound();
            }
            return View(nhanvienQL);
        }

        // GET: Admins/NhanvienQLs/Create
        public ActionResult Create()
        {
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu");
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban");
            return View();
        }

        // POST: Admins/NhanvienQLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDnhanvien,Tennhanvien,Ngaysinhnhanvien,SDTnhanvien,Gioitinhnhanvien,Diachinhanvien,CCCDnhanvien,IDchucvu,IDphongban,NgayVao,note")] NhanvienQL nhanvienQL)
        {
            if (ModelState.IsValid)
            {
                db.Nhanviens.Add(nhanvienQL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvienQL.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvienQL.IDphongban);
            return View(nhanvienQL);
        }

        // GET: Admins/NhanvienQLs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanvienQL nhanvienQL = db.NhanvienQLs.Find(id);
            if (nhanvienQL == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvienQL.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvienQL.IDphongban);
            return View(nhanvienQL);
        }

        // POST: Admins/NhanvienQLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDnhanvien,Tennhanvien,Ngaysinhnhanvien,SDTnhanvien,Gioitinhnhanvien,Diachinhanvien,CCCDnhanvien,IDchucvu,IDphongban,NgayVao,note")] NhanvienQL nhanvienQL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvienQL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDchucvu = new SelectList(db.Chucvus, "IDchucvu", "Tenchucvu", nhanvienQL.IDchucvu);
            ViewBag.IDphongban = new SelectList(db.Phongbans, "IDphongban", "Tenphongban", nhanvienQL.IDphongban);
            return View(nhanvienQL);
        }

        // GET: Admins/NhanvienQLs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanvienQL nhanvienQL = db.NhanvienQLs.Find(id);
            if (nhanvienQL == null)
            {
                return HttpNotFound();
            }
            return View(nhanvienQL);
        }

        // POST: Admins/NhanvienQLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanvienQL nhanvienQL = db.NhanvienQLs.Find(id);
            db.Nhanviens.Remove(nhanvienQL);
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
