using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public abstract class TbCompanyBusinessCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [StringLength(TbCompanyBusinessConsts.LicenseMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? License { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [Range(0, 255, ErrorMessage = "The value must be between {1} and {2}.")]
        public byte RegistrationNo { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public DateTime RegistrationDate { get; set; }
        [StringLength(TbCompanyBusinessConsts.CompanyNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyName { get; set; }
        [StringLength(TbCompanyBusinessConsts.CompanyAddressMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyAddress { get; set; }
        [StringLength(TbCompanyBusinessConsts.LegalRepresentMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegalRepresent { get; set; }
        [StringLength(TbCompanyBusinessConsts.CompanyTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyType { get; set; }
        [StringLength(TbCompanyBusinessConsts.MajorBusinessMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? MajorBusiness { get; set; }
        [StringLength(TbCompanyBusinessConsts.OtherActivityMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? OtherActivity { get; set; }
        [StringLength(TbCompanyBusinessConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? LatestAmendment { get; set; }
    }
}