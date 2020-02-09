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
namespace WebBanHang.Areas.Area.Controllers
{
    public class LOAITTsController : Controller
    {
        private DBWebThue db = new DBWebThue();

        // GET: Area/LOAITTs
        public ActionResult Index()
        {
            List<LOAITT> dsltt = db.LOAITT.OrderBy(x => x.MALOAITT).ToList();
                
            return View(dsltt.ToList());
        }
        public ActionResult XemTatCa(int? ID, int? page)
        {
            LOAITT loai = db.LOAITT.Find(ID);
            ViewBag.TenLoai = loai.TENLOAITT;
            List<TINTUC> dstt = db.TINTUC.Where(x => x.MALOAITT == ID).ToList();
            var pagesize = 9;
            var pagenumber = page ?? 1;

            return View(dstt.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult TTTheoQuan(string ID, int? page)
        {
            HUYENQUAN hq = db.HUYENQUAN.SingleOrDefault(x=>x.MAHUYEN==ID);
            ViewBag.TenLoai = hq.TENHUYEN;
            List<TINTUC> dstt = db.TINTUC.Where(x => x.MAHUYEN == hq.MAHUYEN).ToList();
            var pagesize = 9;
            var pagenumber = page ?? 1;
            return View(dstt.ToPagedList(pagenumber, pagesize));
        }
        // GET: Area/LOAITTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAITT lOAITT = db.LOAITT.Find(id);
            if (lOAITT == null)
            {
                return HttpNotFound();
            }
            return View(lOAITT);
        }

        // GET: Area/LOAITTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/LOAITTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAITT,TENLOAITT")] LOAITT lOAITT)
        {
            if (ModelState.IsValid)
            {
                db.LOAITT.Add(lOAITT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAITT);
        }

        // GET: Area/LOAITTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAITT lOAITT = db.LOAITT.Find(id);
            if (lOAITT == null)
            {
                return HttpNotFound();
            }
            return View(lOAITT);
        }

        // POST: Area/LOAITTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAITT,TENLOAITT")] LOAITT lOAITT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAITT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAITT);
        }

        // GET: Area/LOAITTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAITT lOAITT = db.LOAITT.Find(id);
            if (lOAITT == null)
            {
                return HttpNotFound();
            }
            return View(lOAITT);
        }

        // POST: Area/LOAITTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<TINTUC> dstt = db.TINTUC.Where(x => x.ID_TinTuc == id).ToList();
            foreach(var item in dstt.ToList())
            {
                foreach (var ha in db.DSANH.Where(x=>x.ID_TINTUC==item.ID_TinTuc).ToList())
                {
                    db.DSANH.Remove(ha);
                }
                db.TINTUC.Remove(item);
            }
            LOAITT lOAITT = db.LOAITT.Find(id);
            db.LOAITT.Remove(lOAITT);
            db.SaveChanges();
            return RedirectToAction("Index");
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
