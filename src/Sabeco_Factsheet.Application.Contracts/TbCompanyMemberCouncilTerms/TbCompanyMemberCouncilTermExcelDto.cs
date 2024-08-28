using System;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class TbCompanyMemberCouncilTermExcelDtoBase
    {
        public int? CompanyId { get; set; }
        public int? TermFrom { get; set; }
        public int? TermEnd { get; set; }
    }
}