using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public abstract class TbLogSyncUatDtoBase : AuditedEntityDto<int>
    {
        public DateTime TimeExport { get; set; }
        public bool IsSuccess { get; set; }
        public int UserExport { get; set; }
        public string? ReasonExportFailed { get; set; }

    }
}