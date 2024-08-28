using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbUsers
{
    public abstract class TbUserDtoBase : AuditedEntityDto<int>
    {
        public string UserPrincipalName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public int? CompanyId { get; set; }
        public byte? DocStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public Guid? AbpUserId { get; set; }

    }
}