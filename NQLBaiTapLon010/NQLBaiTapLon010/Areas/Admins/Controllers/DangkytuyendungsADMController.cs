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
    public class DangkytuyendungsADMController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: Admins/DangkytuyendungsADM
        public ActionResult Index()
        {
            return View(db.Dangkys.ToList());
        }

        // GET: Admins/DangkytuyendungsADM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dangkytuyendung dangkytuyendung = db.Dangkys.Find(id);
            if (dangkytuyendung == null)
            {
                return HttpNotFound();
            }
            return View(dangkytuyendung);
        }

        // GET: Admins/DangkytuyendungsADM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/DangkytuyendungsADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ten,SDT,Gioitinh,Ngaysinh,Quequan,Trinhdo,Gmail,Vitriungtuyen,Kinhnghiem")] Dangkytuyendung dangkytuyendung)
        {
            if (ModelState.IsValid)
            {
                db.Dangkys.Add(dangkytuyendung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dangkytuyendung);
        }

        // GET: Admins/DangkytuyendungsADM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dangkytuyendung dangkytuyendung = db.Dangkys.Find(id);
            if (dangkytuyendung == null)
            {
                return HttpNotFound();
            }
            return View(dangkytuyendung);
        }

        // POST: Admins/DangkytuyendungsADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ten,SDT,Gioitinh,Ngaysinh,Quequan,Trinhdo,Gmail,Vitriungtuyen,Kinhnghiem")] Dangkytuyendung dangkytuyendung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangkytuyendung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dangkytuyendung);
        }

        // GET: Admins/DangkytuyendungsADM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dangkytuyendung dangkytuyendung = db.Dangkys.Find(id);
            if (dangkytuyendung == null)
            {
                return HttpNotFound();
            }
            return View(dangkytuyendung);
        }

        // POST: Admins/DangkytuyendungsADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dangkytuyendung dangkytuyendung = db.Dangkys.Find(id);
            db.Dangkys.Remove(dangkytuyendung);
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
