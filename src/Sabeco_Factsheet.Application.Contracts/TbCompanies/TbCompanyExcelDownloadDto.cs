using Volo.Abp.Application.Dtos;
using System;

namespace Sabeco_Factsheet.TbCompanies
{
    public abstract class TbCompanyExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? ParentIdMin { get; set; }
        public int? ParentIdMax { get; set; }
        public bool? IsGroup { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
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
        public DateTime? StockRegistrationDateMin { get; set; }
        public DateTime? StockRegistrationDateMax { get; set; }
        public bool? IsPublicCompany { get; set; }
        public string? LicenseNo { get; set; }
        public string? License { get; set; }
        public byte? RegistrationOrderMin { get; set; }
        public byte? RegistrationOrderMax { get; set; }
        public DateTime? RegistrationDate0Min { get; set; }
        public DateTime? RegistrationDate0Max { get; set; }
        public DateTime? RegistrationDateMin { get; set; }
        public DateTime? RegistrationDateMax { get; set; }
        public DateTime? LatestAmendmentMin { get; set; }
        public DateTime? LatestAmendmentMax { get; set; }
        public string? LegalRepresent { get; set; }
        public string? CompanyType { get; set; }
        public decimal? CharteredCapitalMin { get; set; }
        public decimal? CharteredCapitalMax { get; set; }
        public decimal? TotalShareMin { get; set; }
        public decimal? TotalShareMax { get; set; }
        public decimal? ListedShareMin { get; set; }
        public decimal? ListedShareMax { get; set; }
        public int? ParValueMin { get; set; }
        public int? ParValueMax { get; set; }
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
        public double? longtitudeMin { get; set; }
        public double? longtitudeMax { get; set; }
        public double? latitudeMin { get; set; }
        public double? latitudeMax { get; set; }
        public string? Note { get; set; }
        public byte? DocStatusMin { get; set; }
        public byte? DocStatusMax { get; set; }
        public decimal? DirectShareholdingMin { get; set; }
        public decimal? DirectShareholdingMax { get; set; }
        public decimal? ConsolidatedShareholdingMin { get; set; }
        public decimal? ConsolidatedShareholdingMax { get; set; }
        public string? ConsolidateNoted { get; set; }
        public decimal? VotingRightDirectMin { get; set; }
        public decimal? VotingRightDirectMax { get; set; }
        public decimal? VotingRightTotalMin { get; set; }
        public decimal? VotingRightTotalMax { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? crt_dateMin { get; set; }
        public DateTime? crt_dateMax { get; set; }
        public int? crt_userMin { get; set; }
        public int? crt_userMax { get; set; }
        public DateTime? mod_dateMin { get; set; }
        public DateTime? mod_dateMax { get; set; }
        public int? mod_userMin { get; set; }
        public int? mod_userMax { get; set; }
        public string? BravoCode { get; set; }
        public string? LegacyCode { get; set; }
        public int? idCompanyTypeMin { get; set; }
        public int? idCompanyTypeMax { get; set; }
        public bool? IsDeleted { get; set; }

        public TbCompanyExcelDownloadDtoBase()
        {

        }
    }
}