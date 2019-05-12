using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using _31161021170_OngVuongHoSanh.Models;

namespace _31161021170_OngVuongHoSanh.Controllers
{
    public class DanhMucsController : Controller
    {
        private SanPhamDBContext db = new SanPhamDBContext();

        // GET: DanhMucs
        //public ActionResult Index()
        //{
        //    return View(db.DanhMucs.ToList());
        //}

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var danhmucs = from s in db.DanhMucs
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                danhmucs = danhmucs.Where(s => s.Name.Contains(searchString) || s.MoTa.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    danhmucs = danhmucs.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    danhmucs = danhmucs.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(danhmucs.ToPagedList(pageNumber, pageSize));
        }

        // GET: DanhMucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

       // //[Authorize(Roles = "Admin")]
        // GET: DanhMucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

       // //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MoTa")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMuc);
        }

        //[Authorize(Roles = "Admin")]
        // GET: DanhMucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: DanhMucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MoTa")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }

        //[Authorize(Roles = "Admin")]
        // GET: DanhMucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }
        //[Authorize(Roles = "Admin")]
        // POST: DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
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
             

        public ActionResult DanhMuc()
        {
            var model = db.DanhMucs;
            return PartialView("_DanhMucPartial", model);
        }

    }
}
