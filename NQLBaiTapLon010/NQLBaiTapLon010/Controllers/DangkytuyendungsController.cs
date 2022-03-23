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
    public class DangkytuyendungsController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();
        StringProcess aukey = new StringProcess();

        // GET: Dangkytuyendungs
        public ActionResult Index()
        {
            return View(db.Dangkys.ToList());
        }

        // GET: Dangkytuyendungs/Details/5
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

        // GET: Dangkytuyendungs/Create
        public ActionResult Create()
        {
            if (db.Dangkys.Count() == 0)
            {
                ViewBag.NewID = "HS01";
            }
            else
            {
                var ID = db.Dangkys.OrderByDescending(m => m.ID).FirstOrDefault().ID;
                var newID = aukey.AutoGenerateCode("HS", ID);
                ViewBag.NewID = newID;
            }
            return View();
        }

        // POST: Dangkytuyendungs/Create
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

        // GET: Dangkytuyendungs/Edit/5
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

        // POST: Dangkytuyendungs/Edit/5
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

        // GET: Dangkytuyendungs/Delete/5
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

        // POST: Dangkytuyendungs/Delete/5
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
