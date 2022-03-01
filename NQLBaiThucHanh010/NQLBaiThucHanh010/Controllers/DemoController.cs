using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NQLBaiThucHanh010.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Masinhvien ,string Tensinhvien)
        {
            ViewBag.Message = Masinhvien + "   " + Tensinhvien;
            return View();
        }
    }
}