using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyInvestTemps
{
    public abstract class TbCompanyInvestTempDtoBase : AuditedEntityDto<int>
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public decimal? Shares { get; set; }
        public decimal? Holding { get; set; }
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}