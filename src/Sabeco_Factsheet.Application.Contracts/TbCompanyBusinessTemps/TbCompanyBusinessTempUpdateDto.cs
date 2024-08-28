using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public abstract class TbCompanyBusinessTempUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int CompanyId { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.LicenseMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? License { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [Range(0, 255, ErrorMessage = "The value must be between {1} and {2}.")]
        public byte RegistrationNo { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public DateTime RegistrationDate { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.CompanyNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyName { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.CompanyAddressMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyAddress { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.LegalRepresentMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegalRepresent { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.CompanyTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyType { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.MajorBusinessMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? MajorBusiness { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.OtherActivityMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? OtherActivity { get; set; }
        [StringLength(TbCompanyBusinessTempConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        public DateTime? LatestAmendment { get; set; }

    }
}