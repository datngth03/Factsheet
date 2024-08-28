using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbContactTemps
{
    public abstract class TbContactTempCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int companyid { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbContactTempConsts.ContactNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ContactName { get; set; } = null!;
        [StringLength(TbContactTempConsts.ContactDeptMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept { get; set; }
        [StringLength(TbContactTempConsts.ContactPositionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition { get; set; }
        [StringLength(TbContactTempConsts.ContactEmailMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactEmail { get; set; }
        [StringLength(TbContactTempConsts.ContactPhoneMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone { get; set; }
        [StringLength(TbContactTempConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsActive { get; set; }
        public int? crt_user { get; set; }
        public DateTime? crt_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? mod_date { get; set; }
        public bool IsDeleted { get; set; }
    }
}