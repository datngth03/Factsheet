using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public abstract class TbCompanyStockTempExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? CompanyCode { get; set; }
        public bool? IsPublicCompany { get; set; }
        public string? StockExchange { get; set; }
        public DateTime? RegistrationDateMin { get; set; }
        public DateTime? RegistrationDateMax { get; set; }
        public decimal? CharteredCapitalMin { get; set; }
        public decimal? CharteredCapitalMax { get; set; }
        public decimal? ParValueMin { get; set; }
        public decimal? ParValueMax { get; set; }
        public int? TotalShareMin { get; set; }
        public int? TotalShareMax { get; set; }
        public int? ListedShareMin { get; set; }
        public int? ListedShareMax { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }

        public TbCompanyStockTempExcelDownloadDtoBase()
        {

        }
    }
}