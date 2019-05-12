using _31161021170_OngVuongHoSanh.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class ShippingDetail
    {
        public int ID { get; set; }

        [Display(Name = "Họ tên")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        public string Address { get; set; }
         
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại ")]
        [Required]
        public int Mobile { get; set; }

        [Display(Name = "Ngày giao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Mã giảm giá")]
        [CheckVoucher]
        public string VoucherString { get; set; }
    }
}