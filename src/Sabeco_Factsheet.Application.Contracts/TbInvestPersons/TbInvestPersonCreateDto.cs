using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public abstract class TbInvestPersonCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public DateTime FromDate { get; set; }
        public int? PersonalValue { get; set; }
        public int? OwnerValue { get; set; }
        [StringLength(TbInvestPersonConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public bool IsDeleted { get; set; }
    }
}