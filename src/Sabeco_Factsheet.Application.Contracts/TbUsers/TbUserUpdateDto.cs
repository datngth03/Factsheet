using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbUsers
{
    public abstract class TbUserUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required]
        [StringLength(TbUserConsts.UserPrincipalNameMaxLength)]
        public string UserPrincipalName { get; set; } = null!;
        [Required]
        [StringLength(TbUserConsts.UserNameMaxLength)]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(TbUserConsts.FullNameMaxLength)]
        public string FullName { get; set; } = null!;
        [StringLength(TbUserConsts.EmailMaxLength)]
        public string? Email { get; set; }
        public int? CompanyId { get; set; }
        public byte? DocStatus { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public Guid? AbpUserId { get; set; }

    }
}