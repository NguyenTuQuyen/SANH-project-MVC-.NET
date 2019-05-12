namespace _31161021170_OngVuongHoSanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlCompact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignRoles",
                c => new
                    {
                        userName = c.String(nullable: false, maxLength: 4000),
                        roleName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.userName);
            
            CreateTable(
                "dbo.DanhMucs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        MoTa = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 4000),
                        Gia = c.Double(nullable: false),
                        GiamGia = c.Double(),
                        MoTa = c.String(maxLength: 4000),
                        MoTaDai = c.String(maxLength: 4000),
                        GiaoHangNhanh = c.Boolean(nullable: false),
                        TraGop = c.Boolean(nullable: false),
                        DanhMucID = c.Int(),
                        MaKhuyenMai = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DanhMucs", t => t.DanhMucID)
                .ForeignKey("dbo.KMs", t => t.MaKhuyenMai)
                .Index(t => t.DanhMucID)
                .Index(t => t.MaKhuyenMai);
            
            CreateTable(
                "dbo.HinhAnhSPs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SanPhamID = c.Int(nullable: false),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamID, cascadeDelete: true)
                .Index(t => t.SanPhamID);
            
            CreateTable(
                "dbo.KMs",
                c => new
                    {
                        MaKhuyenMai = c.String(nullable: false, maxLength: 4000),
                        PhanTram = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhuyenMai);
            
            CreateTable(
                "dbo.ReceiptDetails",
                c => new
                    {
                        ReceiptDetailID = c.Int(nullable: false, identity: true),
                        ReceiptID = c.Int(nullable: false),
                        SanPhamID = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiptDetailID)
                .ForeignKey("dbo.Receipts", t => t.ReceiptID, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamID, cascadeDelete: true)
                .Index(t => t.ReceiptID)
                .Index(t => t.SanPhamID);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptID = c.Int(nullable: false, identity: true),
                        TotalCost = c.Double(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        CustomerID = c.String(maxLength: 4000),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiptID);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Address = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        Mobile = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        VoucherString = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptDetails", "SanPhamID", "dbo.SanPhams");
            DropForeignKey("dbo.ReceiptDetails", "ReceiptID", "dbo.Receipts");
            DropForeignKey("dbo.SanPhams", "MaKhuyenMai", "dbo.KMs");
            DropForeignKey("dbo.HinhAnhSPs", "SanPhamID", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "DanhMucID", "dbo.DanhMucs");
            DropIndex("dbo.ReceiptDetails", new[] { "SanPhamID" });
            DropIndex("dbo.ReceiptDetails", new[] { "ReceiptID" });
            DropIndex("dbo.HinhAnhSPs", new[] { "SanPhamID" });
            DropIndex("dbo.SanPhams", new[] { "MaKhuyenMai" });
            DropIndex("dbo.SanPhams", new[] { "DanhMucID" });
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Receipts");
            DropTable("dbo.ReceiptDetails");
            DropTable("dbo.KMs");
            DropTable("dbo.HinhAnhSPs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.DanhMucs");
            DropTable("dbo.AssignRoles");
        }
    }
}
