using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class TbLogSendEmailDtoBase : AuditedEntityDto<int>
    {
        public DateTime TimeSend { get; set; }
        public bool IsSuccess { get; set; }
        public string? UserSend { get; set; }
        public string? TypeEmail { get; set; }
        public string? FailedReason { get; set; }

    }
}