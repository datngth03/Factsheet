using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbBreweries
{
    public abstract class TbBreweryExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? BreweryCode { get; set; }
        public string? BreweryName { get; set; }
        public string? BreweryName_EN { get; set; }
        public string? BriefName { get; set; }
        public string? BreweryAdress { get; set; }
        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public decimal? CapacityVolumeMin { get; set; }
        public decimal? CapacityVolumeMax { get; set; }
        public decimal? DeliveryVolumeMin { get; set; }
        public decimal? DeliveryVolumeMax { get; set; }
        public string? Note { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? isActive { get; set; }
        public int? create_userMin { get; set; }
        public int? create_userMax { get; set; }
        public DateTime? create_dateMin { get; set; }
        public DateTime? create_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }

        public TbBreweryExcelDownloadDtoBase()
        {

        }
    }
}