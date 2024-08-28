using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbRoles
{
    public abstract class TbRoleCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbRoleConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbRoleConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name { get; set; } = null!;
        [StringLength(TbRoleConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
    }
}