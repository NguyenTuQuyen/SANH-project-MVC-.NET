using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using _31161021170_OngVuongHoSanh.Models;
using Microsoft.AspNet.Identity;

namespace _31161021170_OngVuongHoSanh.Attributes
{
    public class CheckVoucher: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value==null)
            {
                return ValidationResult.Success;
            }
            else
            {
                string ma = value.ToString();
                var db = new SanPhamDBContext();
                if (!db.KmS.Any(x => x.MaKhuyenMai == ma))
                {
                    return new ValidationResult(
                ErrorMessage ?? "Mã khuyến mãi này không tồn tại, Bạn hãy nhập mã khác nếu có!");
                }
                return ValidationResult.Success;
            }            
        }
    }
}
