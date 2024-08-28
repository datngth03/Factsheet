using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class TbLogRefeshAccountDtoBase : AuditedEntityDto<int>
    {
        public string AccessToken { get; set; } = null!;
        public DateTime TimeRefesh { get; set; }
        public bool IsSuccess { get; set; }
        public string? UseRefesh { get; set; }
        public string? FailedReason { get; set; }

    }
}