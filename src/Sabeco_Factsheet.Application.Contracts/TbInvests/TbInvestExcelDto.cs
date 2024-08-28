using System;

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class TbInvestExcelDtoBase
    {
        public string BranchCode { get; set; } = null!;
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyCode { get; set; } = null!;
        public int? ShareNumTotal { get; set; }
        public decimal? ShareValueTotal { get; set; }
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public bool? InvestGroup { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}