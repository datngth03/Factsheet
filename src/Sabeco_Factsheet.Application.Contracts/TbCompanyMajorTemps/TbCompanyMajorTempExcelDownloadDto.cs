using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public abstract class TbCompanyMajorTempExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? ShareHolderMajor { get; set; }
        public string? ShareHolderType { get; set; }
        public DateTime? FromDateMin { get; set; }
        public DateTime? FromDateMax { get; set; }
        public DateTime? ToDateMin { get; set; }
        public DateTime? ToDateMax { get; set; }
        public decimal? ShareHolderValueMin { get; set; }
        public decimal? ShareHolderValueMax { get; set; }
        public decimal? ShareHolderRateMin { get; set; }
        public decimal? ShareHolderRateMax { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public int? ClassIdMin { get; set; }
        public int? ClassIdMax { get; set; }
        public bool? IsDeleted { get; set; }

        public TbCompanyMajorTempExcelDownloadDtoBase()
        {

        }
    }
}