using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteBanHang.Models
{
    public class ItemGioHang
    {
        public int MaSP { set; get; }
        public string TenSP { set; get; }
        public int SoLuong { set; get; }
        public decimal DonGia { set; get; }
        public string HinhAnh { set; get; }
        public decimal ThanhTien { set; get; }
        public ItemGioHang(int iMaSP, int sl)
        {
            using (QuanLyBanHangEntities db = new QuanLyBanHangEntities())
            {
                SanPham sp = db.SanPhams.Single(n=>n.MaSP==iMaSP);
                this.TenSP = sp.TenSP;
                this.DonGia = sp.DonGia.Value;
                this.HinhAnh = sp.HinhAnh;
                this.SoLuong = sl;
                this.ThanhTien = SoLuong * DonGia;
            }
        }

    }
}