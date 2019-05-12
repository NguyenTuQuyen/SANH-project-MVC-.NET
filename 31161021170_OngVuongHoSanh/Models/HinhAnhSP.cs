using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class HinhAnhSP
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("SanPhamObj")]
        public int SanPhamID { get; set; }
        public virtual SanPham SanPhamObj { get; set; }

        [MaxLength]
        public string PicturePath { get; set; }
    }
}