using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Attributes
{
    public class CheckDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime ns = (DateTime)value;
            if (DateTime.UtcNow.Year - ns.Year >= 18)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? "Bạn phải trên 18 tuổi.");
        }
    }
}