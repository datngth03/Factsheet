using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbSkus
{
    public abstract class TbSkuCreateDtoBase
    {
        [StringLength(TbSkuConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code { get; set; }
        [StringLength(TbSkuConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name { get; set; }
        [StringLength(TbSkuConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        [StringLength(TbSkuConsts.BrandCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BrandCode { get; set; }
        [StringLength(TbSkuConsts.UnitMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Unit { get; set; }
        [StringLength(TbSkuConsts.ItemBaseTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ItemBaseType { get; set; }
        public decimal? PackSize { get; set; }
        public int? PackQuantity { get; set; }
        public decimal? Weight { get; set; }
        public int? ExpiryDate { get; set; }
        public bool? IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? crt_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}