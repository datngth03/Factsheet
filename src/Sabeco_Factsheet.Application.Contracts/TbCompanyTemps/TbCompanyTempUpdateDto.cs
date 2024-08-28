using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Sabeco_Factsheet.Validation;

namespace Sabeco_Factsheet.TbCompanyTemps
{
    public abstract class TbCompanyTempUpdateDtoBase : AuditedEntityDto<int>
    {
        [Required(ErrorMessage = "The field is required.")]
        public int idCompany { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsGroup { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyTempConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbCompanyTempConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name { get; set; } = null!;
        [StringLength(TbCompanyTempConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        [StringLength(TbCompanyTempConsts.BriefNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BriefName { get; set; }
        [StringLength(TbCompanyTempConsts.ContactInfo_01MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_01 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactInfo_02MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_02 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactInfo_03MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_03 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactInfo_04MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_04 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactInfo_05MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_05 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactInfo_06MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_06 { get; set; }
        [StringLength(TbCompanyTempConsts.StockCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockCode { get; set; }
        [StringLength(TbCompanyTempConsts.StockExchangeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockExchange { get; set; }
        public DateTime? StockRegistrationDate { get; set; }
        public bool? IsPublicCompany { get; set; }
        [StringLength(TbCompanyTempConsts.LicenseNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LicenseNo { get; set; }
        [StringLength(TbCompanyTempConsts.LicenseMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? License { get; set; }
        [Range(0, 255, ErrorMessage = "The value must be between {1} and {2}.")]
        public byte? RegistrationOrder { get; set; }
        public DateTime? RegistrationDate0 { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LatestAmendment { get; set; }
        [StringLength(TbCompanyTempConsts.LegalRepresentMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegalRepresent { get; set; }
        [StringLength(TbCompanyTempConsts.CompanyTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyType { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? CharteredCapital { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? TotalShare { get; set; }

        
        [DecimalValidation(ErrorMessage = "Value must be up to 18 digits in total, including up to 2 decimal places.")]
        public decimal? ListedShare { get; set; }
        [Range(1, 2147483647, ErrorMessage = "The value must be between {1} and {2}.")]
        public int? ParValue { get; set; }
        [StringLength(TbCompanyTempConsts.ContactName1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactName1 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactDept1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept1 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactMail1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactMail1 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactPosition1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition1 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactPhone1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone1 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactName2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactName2 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactDept2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept2 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactMail2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactMail2 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactPosition2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition2 { get; set; }
        [StringLength(TbCompanyTempConsts.ContactPhone2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone2 { get; set; }
        public double? longtitude { get; set; }
        public double? latitude { get; set; }
        [StringLength(TbCompanyTempConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
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
        [StringLength(TbCompanyTempConsts.BravoCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BravoCode { get; set; }
        [StringLength(TbCompanyTempConsts.LegacyCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegacyCode { get; set; }

    }
}