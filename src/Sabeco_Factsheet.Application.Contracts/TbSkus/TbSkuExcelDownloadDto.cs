using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbSkus
{
    public abstract class TbSkuExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public string? BrandCode { get; set; }
        public string? Unit { get; set; }
        public string? ItemBaseType { get; set; }
        public decimal? PackSizeMin { get; set; }
        public decimal? PackSizeMax { get; set; }
        public int? PackQuantityMin { get; set; }
        public int? PackQuantityMax { get; set; }
        public decimal? WeightMin { get; set; }
        public decimal? WeightMax { get; set; }
        public int? ExpiryDateMin { get; set; }
        public int? ExpiryDateMax { get; set; }
        public bool? IsActive { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public TbSkuExcelDownloadDtoBase()
        {

        }
    }
}