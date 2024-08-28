using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogErrors
{
    public abstract class TbLogErrorDtoBase : AuditedEntityDto<int>
    {
        public DateTime TimeLog { get; set; }
        public int UserLog { get; set; }
        public string? IPAddress { get; set; }
        public string? ClassLog { get; set; }
        public string FunctionLog { get; set; } = null!;
        public string ReasonFailed { get; set; } = null!;

    }
}