using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbNationalities
{
    public abstract class TbNationalityUpdateDtoBase : AuditedEntityDto<int>
    {
        [StringLength(TbNationalityConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code { get; set; }
        [StringLength(TbNationalityConsts.Code2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code2 { get; set; }
        [StringLength(TbNationalityConsts.Name_enMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_en { get; set; }
        [StringLength(TbNationalityConsts.Name_vnMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_vn { get; set; }
        public bool? IsActive { get; set; }

    }
}