using System;

namespace Sabeco_Factsheet.TbBreweries
{
    public abstract class TbBreweryExcelDtoBase
    {
        public string BreweryCode { get; set; } = null!;
        public string BreweryName { get; set; } = null!;
        public string? BreweryName_EN { get; set; }
        public string? BriefName { get; set; }
        public string? BreweryAdress { get; set; }
        public int CompanyId { get; set; }
        public decimal? CapacityVolume { get; set; }
        public decimal? DeliveryVolume { get; set; }
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public bool? isActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
    }
}