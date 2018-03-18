using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteBanHang.Controllers
{
    public class GioHangController : Controller
    {
        // GET: XemGioHang
        public ActionResult XemGioHang()
        {
            return View();
        }
        public ActionResult GioHangPartial()
        {
            return PartialView();
        }
    }
}