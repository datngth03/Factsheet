using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class TbMenuUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbMenuConsts.ControlNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ControlName { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbMenuConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Description { get; set; } = null!;
        public bool? IsActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }

    }
}