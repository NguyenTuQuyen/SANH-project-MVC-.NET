using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class SanPhamDBContext:DbContext
    {
        public SanPhamDBContext()
        : base("DefaultConnection")
        {
            //Database.Log = s
            //=> System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<HinhAnhSP> HinhAnhSPs { get; set; }
        public DbSet<KM> KmS { get; set; }
        public System.Data.Entity.DbSet<_31161021170_OngVuongHoSanh.Models.AssignRole> AssignRoles { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
    }
}