using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbNationalityTemps
{
    public abstract class TbNationalityTempCreateDtoBase
    {
        [StringLength(TbNationalityTempConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code { get; set; }
        [StringLength(TbNationalityTempConsts.Code2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code2 { get; set; }
        [StringLength(TbNationalityTempConsts.Name_enMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_en { get; set; }
        [StringLength(TbNationalityTempConsts.Name_vnMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_vn { get; set; }
        public bool? IsActive { get; set; }
    }
}