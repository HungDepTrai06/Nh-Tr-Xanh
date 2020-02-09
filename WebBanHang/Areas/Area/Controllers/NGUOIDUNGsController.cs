using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;
using System.Net;
using System.Data.Entity;
namespace WebBanHang.Areas.Area.Controllers
{
    public class NGUOIDUNGsController : Controller
    {
        private DBWebThue db = new DBWebThue();

        // GET: Area/NGUOIDUNGs
        public ActionResult Index(int? page, string keySearch)
        {
            List<NGUOIDUNG> dsnd = new List<NGUOIDUNG>();
            if(keySearch!=null)
            {
                dsnd = db.NGUOIDUNG.Where(x => x.HOTENND.ToUpper().Contains(keySearch)).ToList();
                ViewBag.tieude = "Kết quả tìm được: " + dsnd.Count();
            }
            else { 
                dsnd= db.NGUOIDUNG.OrderByDescending(x => x.LEVEL).ToList();
                ViewBag.tieude ="Danh sách người dùng: " +dsnd.Count();
            }
            int pagesize = 9;
            int pagenumber = page ?? 1;
            return View(dsnd.ToPagedList(pagenumber, pagesize));
        }

        // GET: Area/NGUOIDUNGs/Details/5
        public ActionResult Details(int? id)
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

        // GET: Area/NGUOIDUNGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/NGUOIDUNGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAND,EMAIL,MATKHAU,HOTENND,GIOITINH,SDT1,SDT2,LEVEL")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.NGUOIDUNG.Add(nGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nGUOIDUNG);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(NGUOIDUNG nGUOIDUNG)
        {
           
            //string mkc = Request.Form["MKC"];
            var mkm = Request.Form["MKM"];
           // string MKC = MaHoa.MD5(mkc);
            //if (mkm.Length < 6)
            //    {
            //        ModelState.AddModelError("", "Mật khẫu mới ít nhất 6 ký tự bạn hãy xem lại");
            //        return View();
            //    }  
            //if(nGUOIDUNG.MATKHAU!=MKC)
            //{
            //    ModelState.AddModelError("", "Mật khẫu cũ bạn nhập chưa đúng");
            //    return View();
            //}
            if( mkm!=null)
            { 
            nGUOIDUNG.MATKHAU = MaHoa.MD5(mkm);
            }
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","NGUOIDUNGs");
            }
           
            return View(nGUOIDUNG);
        }
        // GET: Area/NGUOIDUNGs/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit(NGUOIDUNG nGUOIDUNG)
        {
            string mk = Request.Form["MKM"];
            if (mk != null)
            {
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

        // GET: Area/NGUOIDUNGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNG.Find(id);
            List<TINTUC> dstt = db.TINTUC.Where(x => x.MAND == nGUOIDUNG.MAND).ToList();
            if (nGUOIDUNG.LEVEL == 1)
            {
                ViewBag.CapBac = "Thành viên";
            }
            else
                ViewBag.CapBac = "Admin";
            ViewBag.SoBaiDang = dstt.Count();
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: Area/NGUOIDUNGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNG.Find(id);
            if (nGUOIDUNG.LEVEL == 2)
            {
                ModelState.AddModelError("","Không thể xóa User(Tài khoản) này, vì đây là tài khoản quản trị");
                return View();
            }
            List<TINTUC> dstt = db.TINTUC.Where(x => x.MAND == id).ToList();
            foreach(var tintuc in dstt.ToList())
            {
                List<DSANH> dsanh = db.DSANH.Where(x => x.ID_TINTUC == tintuc.ID_TinTuc).ToList();
                foreach(var ha in dsanh)
                {
                    db.DSANH.Remove(ha);
                }
                db.TINTUC.Remove(tintuc);
            }
            
            db.NGUOIDUNG.Remove(nGUOIDUNG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DSTINND(int? id, int? page)
        {
            NGUOIDUNG nd = db.NGUOIDUNG.Find(id);
            
            List<TINTUC> dstt = null;
            dstt = db.TINTUC.Where(x => x.MAND == id).ToList();
            int pagesize = 9;
            int pagenumber = page ?? 1;
            ViewBag.HoTen = nd.HOTENND;
            ViewBag.SoBaiDang=dstt.Count();
            return View(dstt.ToPagedList(pagenumber, pagesize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
