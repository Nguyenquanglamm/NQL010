using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
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
        Exceltodatatable excelPro = new Exceltodatatable();


        public ActionResult Index()
        {
            var luongs = db.Luongs.Include(l => l.Nhanviens);
            return View(luongs.ToList());
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            DataTable dt = CopyDataFromExcelFile(file);
            OverwriteFastData(dt);
            ViewBag.Message = "File uploaded successfully.";
            return RedirectToAction("Index", "HomeAdmin");
        }

        public DataTable CopyDataFromExcelFile(HttpPostedFileBase file)
        {
            string fileExtention = file.FileName.Substring(file.FileName.IndexOf("."));
            string _FileName = "LuongsADM" + fileExtention; //Tên file Excel
            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
            file.SaveAs(_path);
            DataTable dt = excelPro.ReadDataFromExcelFile(_path);
            return dt;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LTQLDbContext1"].ConnectionString);
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LTQLDbContext"].ConnectionString);
        private void OverwriteFastData(DataTable dt)
        {
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = "Luongs";
            //bulkCopy.ColumnMappings.Add(0, "ID");
            bulkCopy.ColumnMappings.Add(1, "IDNhanVien");
            bulkCopy.ColumnMappings.Add(2, "Thang");
            bulkCopy.ColumnMappings.Add(3, "LuongNgay");
            bulkCopy.ColumnMappings.Add(4, "NgayCong");
            bulkCopy.ColumnMappings.Add(5, "TamUng");
            con.Open();
            bulkCopy.WriteToServer(dt);
            con.Close();
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
