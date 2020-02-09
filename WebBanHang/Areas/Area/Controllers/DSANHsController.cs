using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Area.Controllers
{
    public class DSANHsController : Controller
    {
        private DBWebThue db = new DBWebThue();

        // GET: Area/DSANHs
        public ActionResult Index(int id)
        {
            List<DSANH> dSANH = db.DSANH.Where(x => x.ID_TINTUC == id).ToList();
            ViewBag.Idtintuc = id;
            return View(dSANH.ToList());
        }

        // GET: Area/DSANHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSANH dSANH = db.DSANH.Find(id);
            if (dSANH == null)
            {
                return HttpNotFound();
            }
            return View(dSANH);
        }
        [HttpPost]
        // GET: Area/DSANHs/Create
        public ActionResult Create()
        {
            int id = int.Parse(Request.Form["id"]);
            var file = Request.Files["img"];
            if(file!=null&&file.ContentLength>0)
            {
                string path = Server.MapPath("/IndexLayout/images/imagePhongNha/" + file.FileName);
                file.SaveAs(path);
                DSANH anh = new DSANH();
                anh.ID_TINTUC = id;
                anh.DUONGDAN = file.FileName;
                db.DSANH.Add(anh);
                db.SaveChanges();
            }
            return RedirectToAction("Index","DSANHs", new { id= id });
        }

        // POST: Area/DSANHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        // GET: Area/DSANHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSANH dSANH = db.DSANH.Find(id);
            if (dSANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TINTUC = new SelectList(db.TINTUC, "ID_TinTuc", "MAHUYEN", dSANH.ID_TINTUC);
            return View(dSANH);
        }

        // POST: Area/DSANHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit( DSANH dSANH)
        {
            var file = Request.Files["DUONGDAN"];
            if (file!=null && file.ContentLength>0)
            {
                string path = Server.MapPath("/IndexLayout/images/imagePhongNha/" + file.FileName);
                file.SaveAs(path);
                dSANH.DUONGDAN = file.FileName;
                if(ModelState.IsValid)
                {
                    db.Entry(dSANH).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "DSANHs", new { id = dSANH.ID_TINTUC });
                }
            }
            //ViewBag.ID_TINTUC = new SelectList(db.TINTUC, "ID_TinTuc", "MAHUYEN", dSANH.ID_TINTUC);
            return RedirectToAction("Edit", new { id = dSANH.ID_ANH });
        }
    
        public ActionResult Delete(int id)
        {
            DSANH dSANH = db.DSANH.Find(id);
            int idtt = dSANH.ID_TINTUC;
            db.DSANH.Remove(dSANH);
            db.SaveChanges();
            return RedirectToAction("Index","DSANHs",new { id = idtt});
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
