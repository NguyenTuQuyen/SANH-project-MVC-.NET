using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập giá sản phẩm")]
        [Display(Name = "Giá sản phẩm")]
        public double Gia { get; set; }

        [Display(Name = "Giảm giá")]
        public double? GiamGia { get; set; }

        [Display(Name = "Mô tả ngắn")]
        public string MoTa { get; set; }

        [Display(Name = "Mô tả dài")]
        public string MoTaDai { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public IEnumerable<HttpPostedFileBase> PictureUpload { get; set; }

        [Display(Name = "Giao hàng nhanh")]
        public bool GiaoHangNhanh { get; set; }

        [Display(Name = "Trả góp")]
        public bool TraGop { get; set; }

        [Display(Name = "Danh mục")]
        [ForeignKey("DanhMucObj")]
        public int? DanhMucID { get; set; }
        public virtual DanhMuc DanhMucObj { get; set; }
        public SanPham()
        {
            HinhAnhs = new List<HinhAnhSP>();
        }
        public virtual IList<HinhAnhSP> HinhAnhs { get; set; }

        [Display(Name = "Mã khuyến mãi")]
        [ForeignKey("KMObj")]
        public string MaKhuyenMai { get; set; }
        public virtual KM KMObj { get; set; }

    }
}