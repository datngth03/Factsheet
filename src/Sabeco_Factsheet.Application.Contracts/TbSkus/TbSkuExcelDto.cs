using System;

namespace Sabeco_Factsheet.TbSkus
{
    public abstract class TbSkuExcelDtoBase
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public string? BrandCode { get; set; }
        public string? Unit { get; set; }
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