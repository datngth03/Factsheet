using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class TbLogRefeshAccountUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public string AccessToken { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        public DateTime TimeRefesh { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsSuccess { get; set; }
        public string? UseRefesh { get; set; }
        public string? FailedReason { get; set; }

    }
}