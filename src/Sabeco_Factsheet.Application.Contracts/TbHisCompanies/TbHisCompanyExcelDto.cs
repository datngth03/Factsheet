using System;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public abstract class TbHisCompanyExcelDtoBase
    {
        public bool? IsSendMail { get; set; }
        public DateTime? DateSendMail { get; set; }
        public DateTime? InsertDate { get; set; }
        public int Type { get; set; }
        public int IdCompany { get; set; }
        public int ParentId { get; set; }
        public bool IsGroup { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Name_EN { get; set; }
        public string? BriefName { get; set; }
        public string? ContactInfo_01 { get; set; }
        public string? ContactInfo_02 { get; set; }
        public string? ContactInfo_03 { get; set; }
        public string? ContactInfo_04 { get; set; }
        public string? ContactInfo_05 { get; set; }
        public string? ContactInfo_06 { get; set; }
        public string? StockCode { get; set; }
        public string? StockExchange { get; set; }
        public DateTime? StockRegistrationDate { get; set; }
        public bool? IsPublicCompany { get; set; }
        public string? LicenseNo { get; set; }
        public string? License { get; set; }
        public byte? RegistrationOrder { get; set; }
        public DateTime? RegistrationDate0 { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LatestAmendment { get; set; }
        public string? LegalRepresent { get; set; }
        public string? CompanyType { get; set; }
        public decimal? CharteredCapital { get; set; }
        public decimal? TotalShare { get; set; }
        public decimal? ListedShare { get; set; }
        public int? ParValue { get; set; }
        public string? ContactName1 { get; set; }
        public string? ContactDept1 { get; set; }
        public string? ContactMail1 { get; set; }
        public string? ContactPosition1 { get; set; }
        public string? ContactPhone1 { get; set; }
        public string? ContactName2 { get; set; }
        public string? ContactDept2 { get; set; }
        public string? ContactMail2 { get; set; }
        public string? ContactPosition2 { get; set; }
        public string? ContactPhone2 { get; set; }
        public double? longtitude { get; set; }
        public double? latitude { get; set; }
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