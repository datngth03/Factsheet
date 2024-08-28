using System;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public abstract class TbCompanyMajorExcelDtoBase
    {
        public int CompanyId { get; set; }
        public string ShareHolderMajor { get; set; } = null!;
        public string ShareHolderType { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? ShareHolderValue { get; set; }
        public decimal? ShareHolderRate { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public int? ClassId { get; set; }
        public bool IsDeleted { get; set; }
    }
}