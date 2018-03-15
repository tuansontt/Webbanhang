using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;

namespace WebSiteBanHang.Controllers
{
    public class SanPhamController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPhamStyle1Partial()
        {

            return PartialView();
        }
        public ActionResult SanPhamStyle2Partial()
        {
            return PartialView();
        }
        public ActionResult XemSanPham(int? id,string tensp)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id && n.DaXoa == false);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult SanPham(int? maloai, int? mansx)
        {
            if (maloai == null || mansx == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sp = db.SanPhams.Where(n => n.MaLoaiSP == maloai && n.MaNSX == mansx && n.DaXoa == false);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

    }
}