using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public abstract class TbAdditionInfoUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        public DateTime? DocDate { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbAdditionInfoConsts.TypeOfGroupMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string TypeOfGroup { get; set; } = null!;
        public string? TypeOfEvent { get; set; }
        public string? Description { get; set; }
        public string? NoOfDocument { get; set; }
        public string? Remark { get; set; }
        public bool? IsActive { get; set; }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }

    }
}