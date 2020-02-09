using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Controllers
{
    public class CustommerController : Controller
    {
        DBWebThue db = new DBWebThue();
        // GET: Custommer
        public ActionResult Register(CustomerVielModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.NGUOIDUNG.SingleOrDefault(x => x.EMAIL == model.Email) != null)
                {
                    ModelState.AddModelError("", "Email này đã đăng ký, bạn hãy kiểm tra lại");
                    return View();
                }
                NGUOIDUNG kh = new NGUOIDUNG();
                kh.EMAIL = model.Email;
                kh.MATKHAU = MaHoa.MD5(model.PW_ND);
                kh.GIOITINH = model.GIOITINH;
                kh.HOTENND = model.HoTen;
                kh.SDT1 = model.SDT1;
                kh.SDT2 = model.SDT2;
                kh.LEVEL = 1;
                db.NGUOIDUNG.Add(kh);
                db.SaveChanges();
                Session["KhachHang"] = kh; 
                return RedirectToAction("Index", "TinTuc");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomerLoginView model)
        {
            if (ModelState.IsValid)
            {
                string mk = MaHoa.MD5(model.MATKHAU);
                NGUOIDUNG kh = db.NGUOIDUNG.SingleOrDefault(x => x.EMAIL == model.Email &&
                x.MATKHAU ==mk );
                if (kh != null) 
                {
                    Session["KhachHang"] = kh;
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại, Email hoặc mật khẫu bạn nhập chưa đúng, vui lòng xem lại");
                }
            }
            return View();
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "TinTuc");
        }
    }
}