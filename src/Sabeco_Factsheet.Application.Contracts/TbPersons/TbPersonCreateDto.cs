using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbPersons
{
    public abstract class TbPersonCreateDtoBase
    { 
        [StringLength(TbPersonConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        public int? CompanyId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbPersonConsts.FullNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        public DateTime BirthDate { get; set; }
        [StringLength(TbPersonConsts.BirthPlaceMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BirthPlace { get; set; }
        [StringLength(TbPersonConsts.AddressMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Address { get; set; }
        [StringLength(TbPersonConsts.IDCardNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? IDCardNo { get; set; }
        public DateTime? IDCardDate { get; set; }
        [StringLength(TbPersonConsts.IdCardIssuePlaceMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? IdCardIssuePlace { get; set; }
        [StringLength(TbPersonConsts.EthnicityMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Ethnicity { get; set; }
        [StringLength(TbPersonConsts.ReligionMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Religion { get; set; }
        [StringLength(TbPersonConsts.NationalityCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? NationalityCode { get; set; }
        [StringLength(TbPersonConsts.GenderMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Gender { get; set; }

        [StringLength(TbPersonConsts.PhoneMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")]  
        [RegularExpression(@"^(84)[0-9]{9}$|^(0)[3-9][0-9]{8}$", ErrorMessage = "Phone number must start with '84' followed by 9 digits, or '0' followed by 9 digits.")]
        public string? Phone { get; set; }

        [StringLength(TbPersonConsts.EmailMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        [MultipleEmails(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [StringLength(TbPersonConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
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
        [StringLength(TbPersonConsts.OldCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? OldCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}