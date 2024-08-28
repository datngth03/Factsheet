using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class TbCompanyMemberCouncilTermUpdateDtoBase : AuditedEntityDto<int>
    {
        public int? CompanyId { get; set; }
        public int? TermFrom { get; set; }
        public int? TermEnd { get; set; }

    }
}