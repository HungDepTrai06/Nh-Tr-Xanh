using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;
namespace WebBanHang.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public DBWebThue db = new DBWebThue();
        public ActionResult Index(int? page, int? MaLoaiTT, string MaHuyen, string keySearch, string IDGia, string IDDienTich)
        {
            List<TINTUC> dstintuc=null;
            if (MaLoaiTT != null)
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả  tìm hay lọc được";
            }
            else if (MaHuyen != null)
            {
                dstintuc = db.TINTUC.Where(x => x.MAHUYEN == MaHuyen && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (keySearch != null)
            {
                string tk = keySearch.ToString().ToUpper();
                dstintuc = db.TINTUC.Where(x => x.NOIDUNG.Contains(tk) || x.TIENICH.Contains(tk) || 
                x.TIEUDE.Contains(tk) ||x.DIACHITT.Contains(tk) ||x.LOAITT.TENLOAITT.Contains(tk)||
                x.HUYENQUAN.TENHUYEN.ToUpper().Contains(tk) && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && MaHuyen != null)
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && IDGia == "1")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN <= 2000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && IDGia == "2")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 2000000 && x.GIATIEN <= 3000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && IDGia == "3")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 3000000 && x.GIATIEN <= 4000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && IDGia == "4")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 4000000 && x.GIATIEN <= 5000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && IDGia == "5")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 5000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "1")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN <= 500000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "2")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN >= 500000 && x.GIATIEN <= 3000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "3")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN >= 5000000 && x.GIATIEN <= 4000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "4")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN >= 4000000 && x.GIATIEN <= 50000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "5")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN <= 500000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (IDGia == "1")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN <= 2000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (IDGia == "2")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 2000000 && x.GIATIEN <= 3000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (IDGia == "3")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 3000000 && x.GIATIEN <= 4000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (IDGia == "4")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 4000000 && x.GIATIEN <= 5000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else if (IDGia == "5")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 5000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm hay lọc được";
            }
            else
            {
                dstintuc = db.TINTUC.Where(x => x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Tin tức nổi bật";
            }
            int pageSize = 6;
            int pageNumber = page ?? 1;
            ViewBag.MaLoaiTT = MaLoaiTT;
            ViewBag.MaHuyen = MaHuyen;
            ViewBag.keySearch = keySearch;
            ViewBag.IDGia = IDGia;
            return View(dstintuc.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            TINTUC tintuc = db.TINTUC.Find(id);
            return View(tintuc);
        }
        public ActionResult HuongDan()
        {
            return View();
        }
        public ActionResult LienKet()
        {
            return View();
        }
        public ActionResult Huongdandangkithanhvien()
        {
            return View();
        }
        public ActionResult Huongdandangtin()
        {
            return View();
        }
        public ActionResult Huongdanquanlithongtin()
        {
            return View();
        }
        public ActionResult Map(int id)
        {
            TINTUC tintuc = db.TINTUC.Find(id);
            return View(tintuc);
        }
    }
}