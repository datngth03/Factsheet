using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.Validation
{
    public class MultipleEmailsAttribute : ValidationAttribute
    {
        private const string regexEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success; // Nếu không có giá trị, coi như hợp lệ
            }

            string emailString = value.ToString().Trim();
            if (emailString.EndsWith(","))
            {
                return new ValidationResult("Email list cannot end with a comma.");
            }

            string[] emails = emailString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(regexEmail);

            // Kiểm tra lỗi đầu tiên
            if (emails.Any(email => string.IsNullOrWhiteSpace(email.Trim())))
            {
                return new ValidationResult("Email list contains empty entries.");
            }

            if (emails.Any(email => !regex.IsMatch(email.Trim())))
            {
                return new ValidationResult("Invalid email address.");
            }

            return ValidationResult.Success;
        }
    } 
}
