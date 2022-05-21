using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NQLBaiTapLon010.Areas.NVClient.Controllers
{
    [Authorize(Roles ="client")]
    public class HomeNVController : Controller
    {
        // GET: NVClient/HomeNV
        public ActionResult Index()
        {
            return View();
        }
    }
}