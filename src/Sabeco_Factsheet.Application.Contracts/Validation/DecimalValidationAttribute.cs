using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.Validation
{
    public class DecimalValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var culture = CultureInfo.CurrentCulture;
            var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            var groupSeparator = culture.NumberFormat.NumberGroupSeparator;

            string pattern = $@"^-?\d{{1,16}}(\{decimalSeparator}\d{{0,2}})?$";

            var stringValue = Convert.ToString(value, culture);

            if (Regex.IsMatch(stringValue, pattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"Value must be up to 18 digits in total, including up to 2 decimal places.");
        }
    }

}
