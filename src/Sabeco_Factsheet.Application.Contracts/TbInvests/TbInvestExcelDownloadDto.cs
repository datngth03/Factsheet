using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class TbInvestExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? BranchCode { get; set; }
        public int? BranchIdMin { get; set; }
        public int? BranchIdMax { get; set; }
        public int? CompanyIdMin { get; set; }
        public int? CompanyIdMax { get; set; }
        public string? CompanyCode { get; set; }
        public int? ShareNumTotalMin { get; set; }
        public int? ShareNumTotalMax { get; set; }
        public decimal? ShareValueTotalMin { get; set; }
        public decimal? ShareValueTotalMax { get; set; }
        public string? Note { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public bool? InvestGroup { get; set; }
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

        public TbInvestExcelDownloadDtoBase()
        {

        }
    }
}