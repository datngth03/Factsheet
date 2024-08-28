using System;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public abstract class TbInvestDetailExcelDtoBase
    {
        public int ParentId { get; set; }
        public DateTime? DocDate { get; set; }
        public string? DocNo { get; set; }
        public int InvestType { get; set; }
        public int? ShareNum { get; set; }
        public decimal? ShareValue { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}