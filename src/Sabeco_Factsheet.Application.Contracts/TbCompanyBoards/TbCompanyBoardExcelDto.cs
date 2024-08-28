using System;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class TbCompanyBoardExcelDtoBase
    {
        public string? BranchCode { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string PersonCode { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? PositionCode { get; set; }
        public int? PersonalValue { get; set; }
        public int? OwnerValue { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}