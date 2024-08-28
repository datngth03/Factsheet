using System;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public abstract class TbBrewerySkuExcelDtoBase
    {
        public int? Year { get; set; }
        public string? BreweryCode { get; set; }
        public string? SKUCode { get; set; }
        public decimal? ProductionVolume { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public int? BreweryId { get; set; }
        public int? SKUId { get; set; }
    }
}