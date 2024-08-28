using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbTerms
{
    public abstract class TbTermCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbTermConsts.TermCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string TermCode { get; set; } = null!;
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        [StringLength(TbTermConsts.DescriptionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Description { get; set; }
    }
}