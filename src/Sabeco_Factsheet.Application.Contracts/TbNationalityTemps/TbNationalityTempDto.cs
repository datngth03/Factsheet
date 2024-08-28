using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbNationalityTemps
{
    public abstract class TbNationalityTempDtoBase : AuditedEntityDto<int>
    {
        public string? Code { get; set; }
        public string? Code2 { get; set; }
        public string? Name_en { get; set; }
        public string? Name_vn { get; set; }
        public bool? IsActive { get; set; }

    }
}