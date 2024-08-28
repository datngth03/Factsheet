using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbContactTemps
{
    public abstract class TbContactTempDtoBase : AuditedEntityDto<int>
    {
        public int companyid { get; set; }
        public string ContactName { get; set; } = null!;
        public string? ContactDept { get; set; }
        public string? ContactPosition { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public bool IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? crt_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
        public bool IsDeleted { get; set; }

    }
}