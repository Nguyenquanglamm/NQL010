﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NQLBaiTapLon010.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]

    public class HomeAdminController : Controller
    {

        // GET: Admins/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}