using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class TbBranchDtoBase : AuditedEntityDto<int>
    {
        public string Code { get; set; } = null!;
        public string? BriefName { get; set; }
        public string Name { get; set; } = null!;
        public string? Name_EN { get; set; }
        public string? CompanyCode { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Crt_Date { get; set; }

    }
}