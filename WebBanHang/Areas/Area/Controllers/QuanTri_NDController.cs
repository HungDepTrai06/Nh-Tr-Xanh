using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;
using System.Net;
using System.Data.Entity;

namespace WebBanHang.Areas.Area.Controllers
{
    public class QuanTri_NDController : Controller
    {
        public DBWebThue db = new DBWebThue();
        // GET: Area/QuanTri_ND
        public ActionResult Index(int? page)
        {
            List<TINTUC> dstt = null;
            NGUOIDUNG nd = (NGUOIDUNG)Session["KhachHang"];
            if (nd.LEVEL != 1)
            {
                return RedirectToAction("AdminIndex");
                //dstt = db.TINTUC.Where(k => k.TRANGTHAI == true).OrderByDescending(x => x.NGAYDT).ToList();
                //ViewBag.SoBaiDang = dstt.Count();
            }
            else
            {
                dstt = db.TINTUC.Where(k => k.MAND == nd.MAND && k.TRANGTHAI==true).OrderBy(x => x.NGAYDT).ToList();
                ViewBag.SoBaiDang = dstt.Count();
            } 
            int pagesize = 9;
            int pagenumber = page ?? 1;
            return View(dstt.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult AdminIndex(int? page, int? MaLoaiTT, string MaHuyen, string keySearch, string IDGia, string IDDienTich)
        {
            List<TINTUC> dstintuc = null;
            if (MaLoaiTT != null)
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaHuyen != null)
            {
                dstintuc = db.TINTUC.Where(x => x.MAHUYEN == MaHuyen && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (keySearch != null)
            {
                string tk = keySearch.ToString().ToUpper();
                dstintuc = db.TINTUC.Where(x => x.NOIDUNG.Contains(tk) || x.TIENICH.Contains(tk) ||
                x.TIEUDE.Contains(tk) || x.DIACHITT.Contains(tk) || x.LOAITT.TENLOAITT.Contains(tk) ||
                x.HUYENQUAN.TENHUYEN.ToUpper().Contains(tk) && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null)
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && IDGia == "1")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN <= 2000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && IDGia == "2")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 2000000 && x.GIATIEN <= 3000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && IDGia == "3")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 3000000 && x.GIATIEN <= 4000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && IDGia == "4")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 4000000 && x.GIATIEN <= 5000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && IDGia == "5")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 5000000 && x.MALOAITT == MaLoaiTT && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "1")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN <= 500000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "2")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN >= 500000 && x.GIATIEN <= 3000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "3")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN >= 5000000 && x.GIATIEN <= 4000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "4")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN >= 4000000 && x.GIATIEN <= 50000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (MaLoaiTT != null && MaHuyen != null && IDGia == "5")
            {
                dstintuc = db.TINTUC.Where(x => x.MALOAITT == MaLoaiTT && x.MAHUYEN == MaHuyen && x.GIATIEN <= 500000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (IDGia == "1")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN <= 2000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả lọc hoặc tìm được";
            }
            else if (IDGia == "2")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 2000000 && x.GIATIEN <= 3000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm được";
            }
            else if (IDGia == "3")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 3000000 && x.GIATIEN <= 4000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm được";
            }
            else if (IDGia == "4")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 4000000 && x.GIATIEN <= 5000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm được";
            }
            else if (IDGia == "5")
            {
                dstintuc = db.TINTUC.Where(x => x.GIATIEN >= 5000000 && x.TRANGTHAI == true).ToList();
                ViewBag.tieude = "Kết quả tìm được";
            }
            else
            {
                dstintuc = db.TINTUC.Where(x => x.TRANGTHAI == true).OrderByDescending(x=>x.NGAYDT).ToList();
                ViewBag.tieude = "Tất cả tin tức, bài đăng";
            }
            int pageSize = 6;
            int pageNumber = page ?? 1;
            ViewBag.MaLoaiTT = MaLoaiTT;
            ViewBag.MaHuyen = MaHuyen;
            ViewBag.keySearch = keySearch;
            ViewBag.IDGia = IDGia;
            return View(dstintuc.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult TimKiem_ND(int? page)
        {
            NGUOIDUNG nd = (NGUOIDUNG)Session["KhachHang"];
            string key = Request.Form["keySearch"];
            string tk = key.ToString().ToUpper();
            List<TINTUC> dstt = db.TINTUC.Where(x => x.NOIDUNG.Contains(tk) || x.TIENICH.Contains(tk) ||
                x.TIEUDE.Contains(tk) || x.DIACHITT.Contains(tk) || x.LOAITT.TENLOAITT.Contains(tk) ||
                x.HUYENQUAN.TENHUYEN.ToUpper().Contains(tk) && x.MAND==nd.MAND).ToList();
                ViewBag.tieude = "kết quả tìm được";
            int pagesize = 9;
            int pagenumber = page ?? 1;
            return View(dstt.ToPagedList(pagenumber, pagesize));
        }


        public ActionResult BaiChoKD(int? page)
        {
            List<TINTUC> dstt = null;
            NGUOIDUNG nd = (NGUOIDUNG)Session["KhachHang"];
            if (nd.LEVEL != 1)
            {
                dstt = db.TINTUC.Where(x => x.TRANGTHAI == false).OrderBy(x => x.MAND).ToList();
                ViewBag.SoBaiDang = dstt.Count();
            }
            else
            {
                dstt = db.TINTUC.Where(k => k.MAND == nd.MAND && k.TRANGTHAI==false).OrderBy(x => x.ID_TinTuc).ToList();
                ViewBag.SoBaiDang = dstt.Count();
            }
            int pagesize = 9;
            int pagenumber = page ?? 1;
            return View(dstt.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult DetaisTT(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUC.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }
        public ActionResult CreateTT()
        {
            NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            ViewBag.MaND = kh.MAND;
            ViewBag.MaHuyen = new SelectList(db.HUYENQUAN, "MaHuyen", "TenHuyen");
            ViewBag.MaLoaiTT = new SelectList(db.LOAITT, "MaLoaiTT", "TenLoaiTT");
            return View();
        }

        // POST: QuanTri_ND/TINTUCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateTT(TINTUC tINTUC)
        {
            NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];

            if (ModelState.IsValid)
            {
                
                tINTUC.TRANGTHAI = false;
                tINTUC.MAND = kh.MAND;
                tINTUC.NGAYDT = DateTime.Now.Date;
                tINTUC.NGAYKT = tINTUC.NGAYDT.AddDays(30);
                db.TINTUC.Add(tINTUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHuyen = new SelectList(db.HUYENQUAN, "MaHuyen", "TenHuyen");
            ViewBag.MaLoaiTT = new SelectList(db.LOAITT, "MaLoaiTT", "TenLoaiTT");
            return View(tINTUC);
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public ActionResult EditTT(int id)
        {
            NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            ViewBag.MaND = kh.MAND;
            TINTUC tINTUC = db.TINTUC.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            //ViewBag.NgayDT = tINTUC.NGAYDT;
            //ViewBag.NgayKT = tINTUC.NGAYKT;
            tINTUC.TrangThai=false;
            ViewBag.MAHUYEN = new SelectList(db.HUYENQUAN, "MAHUYEN", "TENHUYEN", tINTUC.MAHUYEN);
            ViewBag.MALOAITT = new SelectList(db.LOAITT, "MALOAITT", "TENLOAITT", tINTUC.MALOAITT);
            return View(tINTUC);
        }

        // POST: QuanTri/TINTUCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditTT(TINTUC tINTUC)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(tINTUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.Entry(tINTUC).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewBag.MAHUYEN = new SelectList(db.HUYENQUAN, "MAHUYEN", "MATINH", tINTUC.MAHUYEN);
            ViewBag.MALOAITT = new SelectList(db.LOAITT, "MALOAITT", "TENLOAITT", tINTUC.MALOAITT);
            return View(tINTUC);
        }
        public ActionResult KiemDuyet(int? id)
        {
            //NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            //ViewBag.MaND = kh.MAND;
            TINTUC tINTUC = db.TINTUC.Find(id);
            ViewBag.HoTen = tINTUC.NGUOIDUNG.HOTENND;
            ViewBag.SDT = tINTUC.NGUOIDUNG.SDT1;
            ViewBag.Email = tINTUC.NGUOIDUNG.EMAIL;
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            //ViewBag.NgayDT = tINTUC.NGAYDT;
            //ViewBag.NgayKT = tINTUC.NGAYKT;
            ViewBag.MAHUYEN = new SelectList(db.HUYENQUAN, "MAHUYEN", "TENHUYEN", tINTUC.MAHUYEN);
            ViewBag.MALOAITT = new SelectList(db.LOAITT, "MALOAITT", "TENLOAITT", tINTUC.MALOAITT);
            return View(tINTUC);
        }

        // POST: QuanTri/TINTUCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult KiemDuyet(TINTUC tINTUC)
        {
            if(tINTUC.TRANGTHAI==false)
            {
                ModelState.AddModelError("", "Bạn chưa xác nhận đăng tin, vui lòng xem lại");
                ViewBag.HoTen = tINTUC.NGUOIDUNG.SDT1;
                ViewBag.SDT = tINTUC.NGUOIDUNG.SDT1;
                ViewBag.Email = tINTUC.NGUOIDUNG.EMAIL;
                ViewBag.MAHUYEN = new SelectList(db.HUYENQUAN, "MAHUYEN", "MATINH", tINTUC.MAHUYEN);
                ViewBag.MALOAITT = new SelectList(db.LOAITT, "MALOAITT", "TENLOAITT", tINTUC.MALOAITT);
                return View(tINTUC);
            }
            if (ModelState.IsValid)
            {
                db.Entry(tINTUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.Entry(tINTUC).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewBag.HoTen = tINTUC.NGUOIDUNG.HOTENND;
            ViewBag.SDT = tINTUC.NGUOIDUNG.SDT1;
            ViewBag.Email = tINTUC.NGUOIDUNG.EMAIL;
            ViewBag.MAHUYEN = new SelectList(db.HUYENQUAN, "MAHUYEN", "MATINH", tINTUC.MAHUYEN);
            ViewBag.MALOAITT = new SelectList(db.LOAITT, "MALOAITT", "TENLOAITT", tINTUC.MALOAITT);
            return View(tINTUC);
        }
        public ActionResult DeleteTT(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUC.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }


        [HttpPost, ActionName("DeleteTT")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TINTUC tINTUC = db.TINTUC.Find(id);
            List<DSANH> dsanh = db.DSANH.Where(x => x.ID_TINTUC == id).ToList();
            if(dsanh!=null)
            { 
            foreach(var anh in dsanh)
            {
                db.DSANH.Remove(anh);
            }
            }
            db.TINTUC.Remove(tINTUC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SuaThongTin(int? id)
        {
            NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            ViewBag.MaND = kh.MAND;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNG.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: Area/NGUOIDUNGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SuaThongTin(NGUOIDUNG nGUOIDUNG)
        {
            string mk = Request.Form["MKM"];
            if (mk != "")
            {
                //if (mk.Length < 6)
                //{
                //    ModelState.AddModelError("", "Mật khẩu mới phải có it nhất 6 ký tự, bạn kiểm tra lại ");
                //    return View();
                //}
                nGUOIDUNG.MATKHAU = MaHoa.MD5(mk);
            }

            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGUOIDUNG);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult DoiMatKhau(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNG.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: Area/NGUOIDUNGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(DoiMatKhau model) 
        {
            string mk = Request.Form["MKC"];
            string MKC = MaHoa.MD5(mk);
            NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            if (ModelState.IsValid)
            {
                if (kh.MATKHAU != MKC)
                {
                    ModelState.AddModelError("", "Mật khẫu cũ bạn nhập chưa đúng, hãy kiểm tra lại");
                    return View();
                }
                kh.MATKHAU = MaHoa.MD5(model.MatKhauMoi);
                db.Entry(kh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "TinTuc");
            }
            return View(kh);
        }
        public ActionResult BaiKiemDuyet(int? page)
        {
            List<TINTUC> dstt = null;
            dstt = db.TINTUC.Where(k => k.TRANGTHAI == false).OrderBy(x => x.ID_TinTuc).ToList();
            ViewBag.SoBaiDang = dstt.Count();
            int pagesize = 9;
            int pagenumber = page ?? 1;
            return View(dstt.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult AllHinh(int? page)
        {
            NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            //List<TINTUC> dstt = db.TINTUC.Where(x => x.MAND == kh.MAND).ToList();
            List<DSANH> dsha = null;
            dsha = db.DSANH.Where(x => x.TINTUC.MAND == kh.MAND).ToList();
            int pagesize = 16;
            int pagenumber = page ?? 1;
            return View(dsha.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult ThongKe()
        {
            //NGUOIDUNG kh = (NGUOIDUNG)Session["KhachHang"];
            List<TINTUC> dstt = db.TINTUC.ToList();
            ViewBag.SoTT = dstt.Count();
            List<TINTUC> dsttfalse = db.TINTUC.Where(x=>x.TRANGTHAI==false).ToList();
            ViewBag.SoTTfalse = dsttfalse.Count();
            List<NGUOIDUNG> dsnd = db.NGUOIDUNG.ToList();
            ViewBag.SoND = dsnd.Count();
            List<DSANH> dsha = db.DSANH.ToList();
            ViewBag.SoHA = dsha.Count();
            return View();
        }

    }
}
