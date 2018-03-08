using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;

namespace WebSiteBanHang.Controllers
{

    public class SanPhamController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: SanPham
        public ActionResult SanPham1()
        {
            var lrtSanPham = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1);
            ViewBag.ltrSP = lrtSanPham;
            var lrtSanPhamDT = db.SanPhams.Where(n => n.MaLoaiSP == 1 );
            ViewBag.ltrDT = lrtSanPhamDT;
            return View();
        }
        public ActionResult SanPham2()
        {
            var lrtSanPham = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1);
            ViewBag.ltrSP = lrtSanPham;
            return View();
        }
        [ChildActionOnly]
        public ActionResult PartialSanPham()
        {
            //var lrtSanPham = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1);
            //return PartialView(lrtSanPham);
            return PartialView();
        }
    }
}