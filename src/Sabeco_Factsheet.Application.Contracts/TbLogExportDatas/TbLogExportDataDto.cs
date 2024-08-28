using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public abstract class TbLogExportDataDtoBase : AuditedEntityDto<int>
    {
        public DateTime TimeExport { get; set; }
        public bool IsSuccess { get; set; }
        public int UserExport { get; set; }
        public string? TableName { get; set; }
        public string? ReasonExportFailed { get; set; }

    }
}