using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using _31161021170_OngVuongHoSanh.Models;
using Microsoft.AspNet.Identity;
using System.Text;
using PagedList;

namespace _31161021170_OngVuongHoSanh.Controllers
{
    public class SanPhamsController : Controller
    {
        private SanPhamDBContext db = new SanPhamDBContext();

        // GET: SanPhams
        public ActionResult Index(int? id, string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var sanPhams = db.SanPhams.Include(s => s.DanhMucObj).Include(s => s.KMObj);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var sanPham = from s in db.SanPhams
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = sanPhams.Where(s => s.Ten.Contains(searchString) || s.MoTa.Contains(searchString) || s.MoTaDai.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.Ten);
                    break;
                default:  // Name ascending 
                    sanPhams = sanPhams.OrderBy(s => s.Ten);
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            if (id == null)
            {
                return View(sanPhams.ToPagedList(pageNumber, pageSize));
                //return View(sanPhams.ToList());
            }
            else
            {
                return View(sanPhams.Where(s => s.DanhMucID == id).ToPagedList(pageNumber, pageSize));
                //return View(sanPhams.Where(s => s.DanhMucID == id).ToList());
            }
        }

        public ActionResult IndexPage(int? id, string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var sanPhams = db.SanPhams.Include(s => s.DanhMucObj).Include(s => s.KMObj);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var sanPham = from s in db.SanPhams
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = sanPhams.Where(s => s.Ten.Contains(searchString) || s.MoTa.Contains(searchString) || s.MoTaDai.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.Ten);
                    break;
                default:  // Name ascending 
                    sanPhams = sanPhams.OrderBy(s => s.Ten);
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            if (id == null)
            {
                return View(sanPhams.ToPagedList(pageNumber, pageSize));
                //return View(sanPhams.ToList());
            }
            else
            {
                return View(sanPhams.Where(s => s.DanhMucID == id).ToPagedList(pageNumber, pageSize));
                //return View(sanPhams.Where(s => s.DanhMucID == id).ToList());
            }
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }


        // GET: SanPhams/Create
        ////[Authorize(Roles = "Admin,QuanLy")]
        public ActionResult Create()
        {
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "ID", "Name");
            ViewBag.MaKhuyenMai = new SelectList(db.KmS, "MaKhuyenMai", "MaKhuyenMai");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // //[Authorize(Roles = "Admin,QuanLy")]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                //db.SanPhams.Add(sanPham);
                //db.SaveChanges();
                //return RedirectToAction("Index");

                foreach (var item in sanPham.PictureUpload)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Images/"), Path.GetFileName(item.FileName));
                    item.SaveAs(path);

                    string pathInDb = "/Content/Images/" + Path.GetFileName(item.FileName);

                    HinhAnhSP img = new HinhAnhSP();
                    img.SanPhamID = sanPham.ID;
                    img.SanPhamObj = sanPham;
                    img.PicturePath = pathInDb;
                    db.HinhAnhSPs.Add(img);
                }

                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("IndexPage");
            }

            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "ID", "Name", sanPham.DanhMucID);
            ViewBag.MaKhuyenMai = new SelectList(db.KmS, "MaKhuyenMai", "MaKhuyenMai", sanPham.MaKhuyenMai);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        //[Authorize(Roles = "Admin,QuanLy")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "ID", "Name", sanPham.DanhMucID);
            ViewBag.MaKhuyenMai = new SelectList(db.KmS, "MaKhuyenMai", "MaKhuyenMai", sanPham.MaKhuyenMai);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        ////[Authorize(Roles = "Admin,QuanLy")]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexPage");
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "ID", "Name", sanPham.DanhMucID);
            ViewBag.MaKhuyenMai = new SelectList(db.KmS, "MaKhuyenMai", "MaKhuyenMai", sanPham.MaKhuyenMai);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        ////[Authorize(Roles = "Admin,QuanLy")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        ////[Authorize(Roles = "Admin,QuanLy")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("IndexPage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddToCart(int? id)
        {
            //Kiem tra Id movie ton tai hay khong
            //if (id==null)
            //{
            //    var HoaDon = this.Session["Receipt"] as Receipt;
            //    if (HoaDon == null)
            //    {
            //        return View("NoItem");
            //    }         

            //}
            int iD = int.Parse(id.ToString());
            var item = db.SanPhams.Where(x => x.ID == iD).FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            var hoaDon = this.Session["Receipt"] as Receipt;
            if (hoaDon == null)
            {
                hoaDon = new Receipt();
                hoaDon.DateCreate = DateTime.Now;
                hoaDon.ReceiptDetails = new List<ReceiptDetail>();
                //Lay id cua user
                if (User.Identity.IsAuthenticated)
                {
                    hoaDon.CustomerID = User.Identity.GetUserId();
                }
                this.Session["Receipt"] = hoaDon;
                db.Receipts.Add(hoaDon);
            }
            //Kiem tra don hang da co truoc do
            var chiTietHoaDon = hoaDon.ReceiptDetails.Where(x => x.SanPhamObj.ID == iD).FirstOrDefault();
            if (chiTietHoaDon == null)
            {
                chiTietHoaDon = new ReceiptDetail();
                chiTietHoaDon.SanPhamID = iD;
                chiTietHoaDon.SanPhamObj = item;
                chiTietHoaDon.ReceiptObj = hoaDon;
                chiTietHoaDon.Total = 1;
                hoaDon.ReceiptDetails.Add(chiTietHoaDon);
            }
            else
            {
                chiTietHoaDon.Total++;
            }
            hoaDon.Status = 0;
            hoaDon.TotalCost = double.Parse(hoaDon.ReceiptDetails.Sum(x => x.Total * (x.SanPhamObj.Gia - x.SanPhamObj.GiamGia)).ToString());
            db.SaveChanges();
            return View(hoaDon);
        }

        //Tăng số lượng from cart
        public ActionResult PlusFromCart(int iD)
        {
            var hoaDon = this.Session["Receipt"] as Receipt;
            var chiTietHoaDon = hoaDon.ReceiptDetails.Where(x => x.SanPhamObj.ID == iD).FirstOrDefault();
            chiTietHoaDon.Total++;
            hoaDon.TotalCost = double.Parse(hoaDon.ReceiptDetails.Sum(x => x.Total * (x.SanPhamObj.Gia - x.SanPhamObj.GiamGia)).ToString());
            db.SaveChanges();
            return View("AddToCart", hoaDon);
        }

        //Giảm số lượng from cart
        public ActionResult MinusFromCart(int iD)
        {
            var hoaDon = this.Session["Receipt"] as Receipt;
            var chiTietHoaDon = hoaDon.ReceiptDetails.Where(x => x.SanPhamObj.ID == iD).FirstOrDefault();

            if (chiTietHoaDon.Total == 0)
            {
                chiTietHoaDon.Total = 0;
            }
            else chiTietHoaDon.Total--;
            hoaDon.TotalCost = double.Parse(hoaDon.ReceiptDetails.Sum(x => x.Total * (x.SanPhamObj.Gia - x.SanPhamObj.GiamGia)).ToString());
            db.SaveChanges();
            return View("AddToCart", hoaDon);
        }

        //Xoá sản phẩm khỏi đơn hàng
        public ActionResult RemoveFromCart(int id)
        {
            var hoaDon = this.Session["Receipt"] as Receipt;
            var chiTietHoaDon = hoaDon.ReceiptDetails.Where(x => x.SanPhamObj.ID == id).LastOrDefault();
            hoaDon.ReceiptDetails.Remove(chiTietHoaDon);
            hoaDon.TotalCost = Single.Parse(hoaDon.ReceiptDetails.Sum(x => x.Total * (x.SanPhamObj.Gia - x.SanPhamObj.GiamGia)).ToString());
            return View("AddToCart", hoaDon);
        }

        public PartialViewResult Summary()
        {
            var hoaDon = this.Session["Receipt"] as Receipt;
            if (hoaDon == null)
            {
                return PartialView("NoCart");
            }
            return PartialView(hoaDon);
        }

        [Authorize]
        public ActionResult Checkout()
        {

            var hoaDon = this.Session["Receipt"] as Receipt;
            if (hoaDon == null)
            {
                return View("NoItem");
            }
            else
            {
                if (hoaDon.ReceiptDetails.Count() == 0)
                {
                    return View("NoItem");
                }
                return View();
            }

        }
        [Authorize]
        [HttpPost]
        public ActionResult Checkout(ShippingDetail detail)
        {


            var hoaDon = this.Session["Receipt"] as Receipt;
            if (hoaDon != null)
            {
                hoaDon.ReceiptDetails = db.ReceiptDetails.Where(x => x.ReceiptID == hoaDon.ReceiptID).ToList();
                if (ModelState.IsValid)
                {
                    KM voucher = db.KmS.Where(x => x.MaKhuyenMai == detail.VoucherString).FirstOrDefault();
                    if (detail.VoucherString != null)
                    {
                        hoaDon.TotalCost = hoaDon.TotalCost * (1 - voucher.PhanTram / 100);
                    }
                    StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                    foreach (var hoaDonChiTiet in hoaDon.ReceiptDetails)
                    {
                        var subtotal = hoaDonChiTiet.SanPhamObj.Gia * hoaDonChiTiet.Total;
                        body.AppendFormat("{0} x {1} (subtotal: {2:c}", hoaDonChiTiet.Total,
                        hoaDonChiTiet.SanPhamObj.Ten,
                        subtotal);
                    }

                    body.AppendFormat("Total order value: {0:c}", hoaDon.TotalCost)
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(detail.Name)
                    .AppendLine(detail.Address)
                    .AppendLine(detail.Mobile.ToString());

                    this.Session["Receipt"] = null;
                    hoaDon.Status = 1;
                    db.SaveChanges();
                    return View("CheckoutCompleted");
                }
                else
                {
                    return View(new ShippingDetail());
                }
            }
            else
            {
                return View("NoItem");
            }


        }
    }
}
