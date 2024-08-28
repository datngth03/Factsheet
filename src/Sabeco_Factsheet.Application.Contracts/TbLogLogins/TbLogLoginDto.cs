using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class TbLogLoginDtoBase : AuditedEntityDto<int>
    {
        public string? UserName { get; set; }
        public DateTime? LoginDate { get; set; }
        public string IPTracking { get; set; } = null!;
        public bool? StatusLogin { get; set; }

    }
}