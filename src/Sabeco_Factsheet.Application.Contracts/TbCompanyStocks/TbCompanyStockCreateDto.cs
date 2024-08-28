using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public abstract class TbCompanyStockCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyStockConsts.CompanyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string CompanyCode { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        public bool IsPublicCompany { get; set; }
        [StringLength(TbCompanyStockConsts.StockExchangeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockExchange { get; set; }
        public DateTime? RegistrationDate { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? CharteredCapital { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? ParValue { get; set; }
        public int? TotalShare { get; set; }
        public int? ListedShare { get; set; }
        [StringLength(TbCompanyStockConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Description { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
    }
}