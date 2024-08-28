using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public abstract class TbCompanyStockTempCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyStockTempConsts.CompanyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string CompanyCode { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        public bool IsPublicCompany { get; set; }
        [StringLength(TbCompanyStockTempConsts.StockExchangeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockExchange { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public decimal? CharteredCapital { get; set; }
        public decimal? ParValue { get; set; }
        public int? TotalShare { get; set; }
        public int? ListedShare { get; set; }
        [StringLength(TbCompanyStockTempConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Description { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
    }
}