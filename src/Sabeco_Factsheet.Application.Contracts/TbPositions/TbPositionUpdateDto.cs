using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class TbPositionUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbPositionConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbPositionConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbPositionConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name_EN { get; set; } = null!;
        public byte? PositionType { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? ctr_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? OrderNumb { get; set; }
        public bool IsDeleted { get; set; }

    }
}