using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class DanhMuc
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục.")]
        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(4000, MinimumLength = 3)]
        public string MoTa { get; set; }

        public virtual IList<SanPham> SanPhams { get; set; }
    }
}