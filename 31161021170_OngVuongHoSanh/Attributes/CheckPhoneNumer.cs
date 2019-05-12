using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using _31161021170_OngVuongHoSanh.Models;
using Microsoft.AspNet.Identity;

namespace _31161021170_OngVuongHoSanh.Attributes
{
    public class CheckPhoneNumer : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Phone = value.ToString();
            var db =new ApplicationDbContext();
            if (!db.Users.Any(x => x.PhoneNumber==Phone))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(
            ErrorMessage ?? "Số điện thoại này đã tồn tại. Bạn hãy nhập số điện thoại khác");
        }
    }
}