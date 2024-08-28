using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbHisPersons
{
    public abstract class TbHisPersonCreateDtoBase
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IdPerson { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbHisPersonConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        public int? CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbHisPersonConsts.FullNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        public DateTime BirthDate { get; set; }
        [StringLength(TbHisPersonConsts.BirthPlaceMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BirthPlace { get; set; }
        [StringLength(TbHisPersonConsts.AddressMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Address { get; set; }
        [StringLength(TbHisPersonConsts.IDCardNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? IDCardNo { get; set; }
        public DateTime? IDCardDate { get; set; }
        [StringLength(TbHisPersonConsts.IdCardIssuePlaceMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? IdCardIssuePlace { get; set; }
        [StringLength(TbHisPersonConsts.EthnicityMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Ethnicity { get; set; }
        [StringLength(TbHisPersonConsts.ReligionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Religion { get; set; }
        [StringLength(TbHisPersonConsts.NationalityCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? NationalityCode { get; set; }
        [StringLength(TbHisPersonConsts.GenderMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Gender { get; set; }
        [StringLength(TbHisPersonConsts.PhoneMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Phone { get; set; }
        [StringLength(TbHisPersonConsts.EmailMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Email { get; set; }
        [StringLength(TbHisPersonConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
        public byte? DocStatus { get; set; }
        public bool? IsCheckRetirement { get; set; }
        public bool? IsCheckTermEnd { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        [StringLength(TbHisPersonConsts.OldCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? OldCode { get; set; }
    }
}