using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;

namespace WebSiteBanHang.Controllers
{
    public class DemoAjaxController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: DemoAjax
        public ActionResult DemoAjax()
        {
            return View();
        }
        public ActionResult ActionLink()
        {
            System.Threading.Thread.Sleep(500);
            return Content("Hello TuanSon");
        }
        public ActionResult BeginformAjax(FormCollection f)
        {
            System.Threading.Thread.Sleep(2000);
            string x = f["txtName"].ToString();
            return Content(x);
        }
        public ActionResult AjaxJquery(int a)
        {
            var listSP = db.SanPhams.Where(n => n.MaLoaiSP == a);
            return PartialView(listSP);
        }
        public ActionResult ActionAjax() {
            var listSP = db.SanPhams;
            return PartialView(listSP);
        }
        public ActionResult BeginFAjax()
        {
            var listSP = db.SanPhams;
            return PartialView(listSP);
        }
    }
}