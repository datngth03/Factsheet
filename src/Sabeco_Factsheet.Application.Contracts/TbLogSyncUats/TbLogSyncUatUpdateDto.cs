using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public abstract class TbLogSyncUatUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public DateTime TimeExport { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsSuccess { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int UserExport { get; set; }
        public string? ReasonExportFailed { get; set; }

    }
}