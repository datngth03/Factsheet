using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class TbBranchCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbBranchConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [StringLength(TbBranchConsts.BriefNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BriefName { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbBranchConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name { get; set; } = null!;
        [StringLength(TbBranchConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        [StringLength(TbBranchConsts.CompanyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyCode { get; set; }
        [StringLength(TbBranchConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Description { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public DateTime? Crt_Date { get; set; }
    }
}