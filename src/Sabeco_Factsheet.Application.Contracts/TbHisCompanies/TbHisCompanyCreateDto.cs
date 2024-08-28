using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public abstract class TbHisCompanyCreateDtoBase
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int IdCompany { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public bool IsGroup { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbHisCompanyConsts.CodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "The field is required.")]
        [StringLength(TbHisCompanyConsts.NameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string Name { get; set; } = null!;
        [StringLength(TbHisCompanyConsts.Name_ENMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Name_EN { get; set; }
        [StringLength(TbHisCompanyConsts.BriefNameMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? BriefName { get; set; }
        [StringLength(TbHisCompanyConsts.ContactInfo_01MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_01 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactInfo_02MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_02 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactInfo_03MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_03 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactInfo_04MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_04 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactInfo_05MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_05 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactInfo_06MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactInfo_06 { get; set; }
        [StringLength(TbHisCompanyConsts.StockCodeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockCode { get; set; }
        [StringLength(TbHisCompanyConsts.StockExchangeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? StockExchange { get; set; }
        public DateTime? StockRegistrationDate { get; set; }
        public bool? IsPublicCompany { get; set; }
        [StringLength(TbHisCompanyConsts.LicenseNoMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LicenseNo { get; set; }
        [StringLength(TbHisCompanyConsts.LicenseMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? License { get; set; }
        public byte? RegistrationOrder { get; set; }
        public DateTime? RegistrationDate0 { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LatestAmendment { get; set; }
        [StringLength(TbHisCompanyConsts.LegalRepresentMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? LegalRepresent { get; set; }
        [StringLength(TbHisCompanyConsts.CompanyTypeMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? CompanyType { get; set; }
        public decimal? CharteredCapital { get; set; }
        public decimal? TotalShare { get; set; }
        public decimal? ListedShare { get; set; }
        public int? ParValue { get; set; }
        [StringLength(TbHisCompanyConsts.ContactName1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactName1 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactDept1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept1 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactMail1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactMail1 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactPosition1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition1 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactPhone1MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone1 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactName2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactName2 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactDept2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactDept2 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactMail2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactMail2 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactPosition2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPosition2 { get; set; }
        [StringLength(TbHisCompanyConsts.ContactPhone2MaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? ContactPhone2 { get; set; }
        public double? longtitude { get; set; }
        public double? latitude { get; set; }
        [StringLength(TbHisCompanyConsts.NoteMaxLength, ErrorMessage = "The field must be a string with a maximum length of {1}.")] 
        public string? Note { get; set; }
        public byte? DocStatus { get; set; }
        public decimal? DirectShareholding { get; set; }
        public decimal? ConsolidatedShareholding { get; set; }
        public string? ConsolidateNoted { get; set; }
        public decimal? VotingRightDirect { get; set; }
        public decimal? VotingRightTotal { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_date { get; set; }
        public int? crt_user { get; set; }
        public DateTime? mod_date { get; set; }
        public int? mod_user { get; set; }
    }
}