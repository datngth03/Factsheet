using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public abstract class TbCompanyInvestExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? CompanyName { get; set; }
        public decimal? SharesMin { get; set; }
        public decimal? SharesMax { get; set; }
        public decimal? HoldingMin { get; set; }
        public decimal? HoldingMax { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public bool? IsDeleted { get; set; }

        public TbCompanyInvestExcelDownloadDtoBase()
        {

        }
    }
}