using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class TbLogSendEmailUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public DateTime TimeSend { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsSuccess { get; set; }
        public string? UserSend { get; set; }
        public string? TypeEmail { get; set; }
        public string? FailedReason { get; set; }

    }
}