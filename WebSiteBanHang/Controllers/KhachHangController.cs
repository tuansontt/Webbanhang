using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;

namespace WebSiteBanHang.Controllers
{
    public class KhachHangController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: KhachHang
        public ActionResult Index()
        {
            var ltsKH = from KH in db.KhachHangs select KH; 
            return View(ltsKH);
        }
        public ActionResult Index1()
        {
            var ltsKH = from KH in db.KhachHangs select KH;
            return View(ltsKH);
        }
        public ActionResult TruyVanMotDoiTuong()
        {
            var ltsKH = db.KhachHangs.Single(n => n.MaKH == 1);
            return View(ltsKH);
        }
        public ActionResult SoreDuLieu()
        {
            var ltsKH = db.KhachHangs.OrderByDescending(n=>n.TenKH).ToList();
            return View(ltsKH);
        }
        public ActionResult GroupDuLieu()
        {
            var ltsKH = db.ThanhViens.OrderByDescending(n => n.TaiKhoan).ToList();
            return View(ltsKH);
        }
    }
}