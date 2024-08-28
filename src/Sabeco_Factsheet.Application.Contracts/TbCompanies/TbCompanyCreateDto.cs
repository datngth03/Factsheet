using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbCompanies
{
    public abstract class TbCompanyCreateDtoBase
    {
        [Required(ErrorMessage = "The field is required.")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsGroup { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name { get; set; } = null!;
        [StringLength(TbCompanyConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        [StringLength(TbCompanyConsts.BriefNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BriefName { get; set; }
        [StringLength(TbCompanyConsts.ContactInfo_01MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_01 { get; set; }
        [StringLength(TbCompanyConsts.ContactInfo_02MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_02 { get; set; }
        [StringLength(TbCompanyConsts.ContactInfo_03MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_03 { get; set; }
        [StringLength(TbCompanyConsts.ContactInfo_04MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_04 { get; set; }
        [StringLength(TbCompanyConsts.ContactInfo_05MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_05 { get; set; }
        [StringLength(TbCompanyConsts.ContactInfo_06MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_06 { get; set; }
        [StringLength(TbCompanyConsts.StockCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockCode { get; set; }
        [StringLength(TbCompanyConsts.StockExchangeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockExchange { get; set; }
        public DateTime? StockRegistrationDate { get; set; }
        public bool? IsPublicCompany { get; set; }
        [StringLength(TbCompanyConsts.LicenseNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LicenseNo { get; set; }
        [StringLength(TbCompanyConsts.LicenseMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? License { get; set; }
        [Range(TbCompanyConsts.RegistrationOrderMinLength, TbCompanyConsts.RegistrationOrderMaxLength, ErrorMessage = "The value must be between {1} and {2}.")]
        public byte? RegistrationOrder { get; set; }
        public DateTime? RegistrationDate0 { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LatestAmendment { get; set; }
        [StringLength(TbCompanyConsts.LegalRepresentMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegalRepresent { get; set; }
        [StringLength(TbCompanyConsts.CompanyTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyType { get; set; }
        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? CharteredCapital { get; set; }
        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? TotalShare { get; set; }
        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? ListedShare { get; set; }
        [Range(1, 2147483647, ErrorMessage = "The value must be between {1} and {2}.")]
        public int? ParValue { get; set; }
        [StringLength(TbCompanyConsts.ContactName1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactName1 { get; set; }
        [StringLength(TbCompanyConsts.ContactDept1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept1 { get; set; }
        [StringLength(TbCompanyConsts.ContactMail1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactMail1 { get; set; }
        [StringLength(TbCompanyConsts.ContactPosition1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition1 { get; set; }
        [StringLength(TbCompanyConsts.ContactPhone1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone1 { get; set; }
        [StringLength(TbCompanyConsts.ContactName2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactName2 { get; set; }
        [StringLength(TbCompanyConsts.ContactDept2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept2 { get; set; }
        [StringLength(TbCompanyConsts.ContactMail2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactMail2 { get; set; }
        [StringLength(TbCompanyConsts.ContactPosition2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition2 { get; set; }
        [StringLength(TbCompanyConsts.ContactPhone2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone2 { get; set; }
        public double? longtitude { get; set; }
        public double? latitude { get; set; }
        [StringLength(TbCompanyConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? DirectShareholding { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? ConsolidatedShareholding { get; set; }
        public string? ConsolidateNoted { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? VotingRightDirect { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? VotingRightTotal { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
        [StringLength(TbCompanyConsts.BravoCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BravoCode { get; set; }
        [StringLength(TbCompanyConsts.LegacyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegacyCode { get; set; }
        public int? idCompanyType { get; set; }
        public bool IsDeleted { get; set; }
    }
}