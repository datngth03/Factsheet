using System;

namespace Sabeco_Factsheet.TbTerms
{
    public abstract class TbTermExcelDtoBase
    {
        public int BranchId { get; set; }
        public string TermCode { get; set; } = null!;
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string? Description { get; set; }
    }
}