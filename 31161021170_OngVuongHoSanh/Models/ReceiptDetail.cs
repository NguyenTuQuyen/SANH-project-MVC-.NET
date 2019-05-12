using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class ReceiptDetail
    {
        [Key]
        public int ReceiptDetailID { get; set; }

        [ForeignKey("ReceiptObj")]
        public int ReceiptID { get; set; }
        public virtual Receipt ReceiptObj { get; set; }

        [ForeignKey("SanPhamObj")]
        public int SanPhamID { get; set; }
        public virtual SanPham SanPhamObj { get; set; }

        public int Total { get; set; }

        public ReceiptDetail()
        {

        }
    }
}