using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbContacts
{
    public abstract class TbContactCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int companyid { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbContactConsts.ContactNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string ContactName { get; set; } = null!;
        [StringLength(TbContactConsts.ContactDeptMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept { get; set; }
        [StringLength(TbContactConsts.ContactPositionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition { get; set; }
        [StringLength(TbContactConsts.ContactEmailMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactEmail { get; set; }
        [StringLength(TbContactConsts.ContactPhoneMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone { get; set; }
        [StringLength(TbContactConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
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