using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{
    public abstract class TbCompanyBusinessDetailTempUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyBusinessDetailTempConsts.RegistrationCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string RegistrationCode { get; set; } = null!;
        [StringLength(TbCompanyBusinessDetailTempConsts.RegistrationNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? RegistrationName { get; set; }
        [StringLength(TbCompanyBusinessDetailTempConsts.RegistrationName_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? RegistrationName_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }

    }
}