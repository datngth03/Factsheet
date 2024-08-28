using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public abstract class TbCompanyBusinessDetailDtoBase : AuditedEntityDto<int>
    {
        public int ParentId { get; set; }
        public string RegistrationCode { get; set; } = null!;
        public string? RegistrationName { get; set; }
        public string? RegistrationName_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}