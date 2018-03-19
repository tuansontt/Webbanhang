using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;

namespace WebSiteBanHang.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: XemGioHang
        public List<ItemGioHang> LayGioHang()
        {
            //neu da ton tai gio hang thi gan bang mot bien session
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                // Neu chua ton tai gio hang thi tao mot gio hang moi va gan sesion bang bien do
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int MaSP,string strURL)
        {
            //kiem tra san pham them vao gio hang co trong CSDL hay khong
            SanPham sp = db.SanPhams.SingleOrDefault(n=>n.MaSP==MaSP);
            if (sp == null)
            {
                // Neu kiem tra ko co trong CSDL thi bao loi
                Response.StatusCode = 404;
                return null;
            }
            //lay ra gio hang
            List<ItemGioHang> lstGioHang = LayGioHang();
            //truong hop 1 trong gio hang da co san pham
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);  // lay ra mot san pham trong list voi dieu kien cu the, ko co thi tra ve null
            if (spCheck != null)//neu da co sp thi spchek !=null , thi tang so luong san pham len 1
            {
                if (sp.SoLuongTon < spCheck.SoLuong)//kiem tra xem so luong hang con du khong, neu khong du thi tra ve thong bao
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }
            //truong hop 2 chua co sp thi them mot sp moi vao gio hang
            ItemGioHang itemGH = new ItemGioHang(MaSP);
            if (sp.SoLuongTon < itemGH.SoLuong)//kiem tra xem so luong hang con du khong, neu khong du thi tra ve thong bao
            {
                return View("ThongBao");
            }           
            //neu chua co san pham thi add them san pham moi vao gio hang
            lstGioHang.Add(itemGH);
            return Redirect(strURL);
        }

        public double TinhTongSoLuong()
        {
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.SoLuong);
        }
        public decimal TinhTongTien()
        {
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);
        }
        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong() == 0 || TinhTongTien() == 0)
            {
                ViewBag.tongsoluon = 0;
                ViewBag.tongtien = 0;
                return PartialView();
            }
            ViewBag.tongsoluon = TinhTongSoLuong();
            ViewBag.tongtien = TinhTongTien();
            return PartialView();
        }
        public ActionResult XemGioHang()
        {
            return View();
        }
      
    }
}