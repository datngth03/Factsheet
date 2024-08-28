using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class TbLogLoginUpdateDtoBase : AuditedEntityDto<int>
    {
        public string? UserName { get; set; }
        public DateTime? LoginDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string IPTracking { get; set; } = null!;
        public bool? StatusLogin { get; set; }

    }
}