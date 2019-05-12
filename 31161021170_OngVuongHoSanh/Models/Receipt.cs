using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }

        [Display(Name = "Chi tiết đơn hàng")]
        public IList<ReceiptDetail> ReceiptDetails { get; set; }

        [Display(Name = "Tổng cộng")]
        public double TotalCost { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

        public string CustomerID { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        public Receipt()
        {
            ReceiptDetails = new List<ReceiptDetail>();
        }
    }
}