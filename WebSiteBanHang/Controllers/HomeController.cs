using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace WebSiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: Home
        public ActionResult Index()
        {

            var listLTM = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListLTM = listLTM;
            var listDTM = db.SanPhams.Where(n => n.MaLoaiSP == 3 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListDTM = listDTM;
            var listMTM = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListMTM = listMTM;
            return View();
        }

        public ActionResult MenuPartial()
        {
            var listSP = db.SanPhams;
            return PartialView(listSP);
        }

        public ActionResult MenuNgangPartial()
        {
            var listSP1 = db.SanPhams;
            return PartialView(listSP1);
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            ViewBag.CauHoi = new SelectList(Listcauhoi());
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(ThanhVien tv)
        {
            ViewBag.CauHoi = new SelectList(Listcauhoi());
            if (this.IsCaptchaValid("Capcha is not vali"))
            {
                ViewBag.Thongbao = "Dang ky thanh cong";
                db.ThanhViens.Add(tv);
                db.SaveChanges();
            }
            ViewBag.Thongbao = "Nhap sai ma capcha";
            return View();
        }
        public List<string> Listcauhoi()
        {
            List<string> listcauhoi = new List<string>();
            listcauhoi.Add("Ban thich con vat nao nhat");
            listcauhoi.Add("Ban tung hoc o dau");
            listcauhoi.Add("Bo cua ban la ai");
            listcauhoi.Add("Ban bao nhieu tuoi");
            return listcauhoi;
        }
    }
}