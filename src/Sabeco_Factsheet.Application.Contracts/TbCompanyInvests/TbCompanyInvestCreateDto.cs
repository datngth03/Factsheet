using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public abstract class TbCompanyInvestCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string CompanyName { get; set; } = null!;

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? Shares { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? Holding { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}