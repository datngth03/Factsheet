using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TsClasses
{
    public abstract class TsClassCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TsClassConsts.ParentCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ParentCode { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TsClassConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [StringLength(TsClassConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name { get; set; }
        [StringLength(TsClassConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        [StringLength(TsClassConsts.Code_TypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Code_Type { get; set; }
    }
}