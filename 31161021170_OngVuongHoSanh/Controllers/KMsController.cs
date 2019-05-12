using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _31161021170_OngVuongHoSanh.Models;

namespace _31161021170_OngVuongHoSanh.Controllers
{
    public class KMsController : Controller
    {
        private SanPhamDBContext db = new SanPhamDBContext();

        // GET: KMs
        public ActionResult Index()
        {
            return View(db.KmS.ToList());
        }

        // GET: KMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KM kM = db.KmS.Find(id);
            if (kM == null)
            {
                return HttpNotFound();
            }
            return View(kM);
        }

        // GET: KMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhuyenMai,PhanTram")] KM kM)
        {
            if (ModelState.IsValid)
            {
                db.KmS.Add(kM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kM);
        }

        // GET: KMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KM kM = db.KmS.Find(id);
            if (kM == null)
            {
                return HttpNotFound();
            }
            return View(kM);
        }

        // POST: KMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhuyenMai,PhanTram")] KM kM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kM);
        }

        // GET: KMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KM kM = db.KmS.Find(id);
            if (kM == null)
            {
                return HttpNotFound();
            }
            return View(kM);
        }

        // POST: KMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KM kM = db.KmS.Find(id);
            db.KmS.Remove(kM);
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
