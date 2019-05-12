using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class KM
    {
        [Key]
        [Required(ErrorMessage = "Bạn chưa nhập mã khuyến mãi")]
        [Display(Name = "Mã khuyến mãi")]
        public string MaKhuyenMai { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập phần trăm giảm giá")]
        [Display(Name = "Phần trăm giảm giá")]
        public double PhanTram { get; set; }

        public virtual IList<SanPham> SanPhams { get; set; }
    }
}