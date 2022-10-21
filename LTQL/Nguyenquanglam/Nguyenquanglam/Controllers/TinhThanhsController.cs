using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nguyenquanglam.Models;

namespace Nguyenquanglam.Controllers
{
    public class TinhThanhsController : Controller
    {
        private LTQLDB db = new LTQLDB();

        // GET: TinhThanhs
        public ActionResult Index()
        {
            return View(db.TinhThanhs.ToList());
        }

        // GET: TinhThanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinhThanh tinhThanh = db.TinhThanhs.Find(id);
            if (tinhThanh == null)
            {
                return HttpNotFound();
            }
            return View(tinhThanh);
        }

        // GET: TinhThanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TinhThanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinhThanh,TenTinhThanh")] TinhThanh tinhThanh)
        {
            if (ModelState.IsValid)
            {
                db.TinhThanhs.Add(tinhThanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinhThanh);
        }

        // GET: TinhThanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinhThanh tinhThanh = db.TinhThanhs.Find(id);
            if (tinhThanh == null)
            {
                return HttpNotFound();
            }
            return View(tinhThanh);
        }

        // POST: TinhThanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinhThanh,TenTinhThanh")] TinhThanh tinhThanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinhThanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinhThanh);
        }

        // GET: TinhThanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinhThanh tinhThanh = db.TinhThanhs.Find(id);
            if (tinhThanh == null)
            {
                return HttpNotFound();
            }
            return View(tinhThanh);
        }

        // POST: TinhThanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinhThanh tinhThanh = db.TinhThanhs.Find(id);
            db.TinhThanhs.Remove(tinhThanh);
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
