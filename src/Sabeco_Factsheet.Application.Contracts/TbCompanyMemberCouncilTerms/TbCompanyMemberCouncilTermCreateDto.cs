using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class TbCompanyMemberCouncilTermCreateDtoBase
    {
        public int? CompanyId { get; set; }
        public int? TermFrom { get; set; }
        public int? TermEnd { get; set; }
    }
}