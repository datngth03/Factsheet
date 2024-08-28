using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TsClassTemps
{
    public abstract class TsClassTempCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TsClassTempConsts.ParentCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ParentCode { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TsClassTempConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [StringLength(TsClassTempConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name { get; set; }
        [StringLength(TsClassTempConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        [StringLength(TsClassTempConsts.Code_TypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code_Type { get; set; }
    }
}