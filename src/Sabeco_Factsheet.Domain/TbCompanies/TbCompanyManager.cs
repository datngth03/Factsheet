using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanies
{
    public abstract class TbCompanyManagerBase : DomainService
    {
        public ITbCompanyRepository _tbCompanyRepository;

        public TbCompanyManagerBase(ITbCompanyRepository tbCompanyRepository)
        {
            _tbCompanyRepository = tbCompanyRepository;
        }

        public virtual async Task<TbCompany> CreateAsync(
        int parentId, bool isGroup, string code, string name, bool isDeleted, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? bravoCode = null, string? legacyCode = null, int? idCompanyType = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbCompanyConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbCompanyConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbCompanyConsts.Name_ENMaxLength);
            Check.Length(briefName, nameof(briefName), TbCompanyConsts.BriefNameMaxLength);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbCompanyConsts.ContactInfo_01MaxLength);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbCompanyConsts.ContactInfo_02MaxLength);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbCompanyConsts.ContactInfo_03MaxLength);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbCompanyConsts.ContactInfo_04MaxLength);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbCompanyConsts.ContactInfo_05MaxLength);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbCompanyConsts.ContactInfo_06MaxLength);
            Check.Length(stockCode, nameof(stockCode), TbCompanyConsts.StockCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyConsts.StockExchangeMaxLength);
            Check.Length(licenseNo, nameof(licenseNo), TbCompanyConsts.LicenseNoMaxLength);
            Check.Length(license, nameof(license), TbCompanyConsts.LicenseMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyConsts.CompanyTypeMaxLength);
            Check.Length(contactName1, nameof(contactName1), TbCompanyConsts.ContactName1MaxLength);
            Check.Length(contactDept1, nameof(contactDept1), TbCompanyConsts.ContactDept1MaxLength);
            Check.Length(contactMail1, nameof(contactMail1), TbCompanyConsts.ContactMail1MaxLength);
            Check.Length(contactPosition1, nameof(contactPosition1), TbCompanyConsts.ContactPosition1MaxLength);
            Check.Length(contactPhone1, nameof(contactPhone1), TbCompanyConsts.ContactPhone1MaxLength);
            Check.Length(contactName2, nameof(contactName2), TbCompanyConsts.ContactName2MaxLength);
            Check.Length(contactDept2, nameof(contactDept2), TbCompanyConsts.ContactDept2MaxLength);
            Check.Length(contactMail2, nameof(contactMail2), TbCompanyConsts.ContactMail2MaxLength);
            Check.Length(contactPosition2, nameof(contactPosition2), TbCompanyConsts.ContactPosition2MaxLength);
            Check.Length(contactPhone2, nameof(contactPhone2), TbCompanyConsts.ContactPhone2MaxLength);
            Check.Length(note, nameof(note), TbCompanyConsts.NoteMaxLength);
            Check.Length(bravoCode, nameof(bravoCode), TbCompanyConsts.BravoCodeMaxLength);
            Check.Length(legacyCode, nameof(legacyCode), TbCompanyConsts.LegacyCodeMaxLength);

            var tbCompany = new TbCompany(

             parentId, isGroup, code, name, isDeleted, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDate, isPublicCompany, licenseNo, license, registrationOrder, registrationDate0, registrationDate, latestAmendment, legalRepresent, companyType, charteredCapital, totalShare, listedShare, parValue, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitude, latitude, note, docStatus, directShareholding, consolidatedShareholding, consolidateNoted, votingRightDirect, votingRightTotal, image, isActive, crt_date, crt_user, mod_date, mod_user, bravoCode, legacyCode, idCompanyType
             );

            return await _tbCompanyRepository.InsertAsync(tbCompany);
        }

        public virtual async Task<TbCompany> UpdateAsync(
            int id,
            int parentId, bool isGroup, string code, string name, bool isDeleted, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? bravoCode = null, string? legacyCode = null, int? idCompanyType = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbCompanyConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbCompanyConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbCompanyConsts.Name_ENMaxLength);
            Check.Length(briefName, nameof(briefName), TbCompanyConsts.BriefNameMaxLength);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbCompanyConsts.ContactInfo_01MaxLength);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbCompanyConsts.ContactInfo_02MaxLength);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbCompanyConsts.ContactInfo_03MaxLength);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbCompanyConsts.ContactInfo_04MaxLength);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbCompanyConsts.ContactInfo_05MaxLength);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbCompanyConsts.ContactInfo_06MaxLength);
            Check.Length(stockCode, nameof(stockCode), TbCompanyConsts.StockCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyConsts.StockExchangeMaxLength);
            Check.Length(licenseNo, nameof(licenseNo), TbCompanyConsts.LicenseNoMaxLength);
            Check.Length(license, nameof(license), TbCompanyConsts.LicenseMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyConsts.CompanyTypeMaxLength);
            Check.Length(contactName1, nameof(contactName1), TbCompanyConsts.ContactName1MaxLength);
            Check.Length(contactDept1, nameof(contactDept1), TbCompanyConsts.ContactDept1MaxLength);
            Check.Length(contactMail1, nameof(contactMail1), TbCompanyConsts.ContactMail1MaxLength);
            Check.Length(contactPosition1, nameof(contactPosition1), TbCompanyConsts.ContactPosition1MaxLength);
            Check.Length(contactPhone1, nameof(contactPhone1), TbCompanyConsts.ContactPhone1MaxLength);
            Check.Length(contactName2, nameof(contactName2), TbCompanyConsts.ContactName2MaxLength);
            Check.Length(contactDept2, nameof(contactDept2), TbCompanyConsts.ContactDept2MaxLength);
            Check.Length(contactMail2, nameof(contactMail2), TbCompanyConsts.ContactMail2MaxLength);
            Check.Length(contactPosition2, nameof(contactPosition2), TbCompanyConsts.ContactPosition2MaxLength);
            Check.Length(contactPhone2, nameof(contactPhone2), TbCompanyConsts.ContactPhone2MaxLength);
            Check.Length(note, nameof(note), TbCompanyConsts.NoteMaxLength);
            Check.Length(bravoCode, nameof(bravoCode), TbCompanyConsts.BravoCodeMaxLength);
            Check.Length(legacyCode, nameof(legacyCode), TbCompanyConsts.LegacyCodeMaxLength);

            var tbCompany = await _tbCompanyRepository.GetAsync(id);

            tbCompany.ParentId = parentId;
            tbCompany.IsGroup = isGroup;
            tbCompany.Code = code;
            tbCompany.Name = name;
            tbCompany.IsDeleted = isDeleted;
            tbCompany.Name_EN = name_EN;
            tbCompany.BriefName = briefName;
            tbCompany.ContactInfo_01 = contactInfo_01;
            tbCompany.ContactInfo_02 = contactInfo_02;
            tbCompany.ContactInfo_03 = contactInfo_03;
            tbCompany.ContactInfo_04 = contactInfo_04;
            tbCompany.ContactInfo_05 = contactInfo_05;
            tbCompany.ContactInfo_06 = contactInfo_06;
            tbCompany.StockCode = stockCode;
            tbCompany.StockExchange = stockExchange;
            tbCompany.StockRegistrationDate = stockRegistrationDate;
            tbCompany.IsPublicCompany = isPublicCompany;
            tbCompany.LicenseNo = licenseNo;
            tbCompany.License = license;
            tbCompany.RegistrationOrder = registrationOrder;
            tbCompany.RegistrationDate0 = registrationDate0;
            tbCompany.RegistrationDate = registrationDate;
            tbCompany.LatestAmendment = latestAmendment;
            tbCompany.LegalRepresent = legalRepresent;
            tbCompany.CompanyType = companyType;
            tbCompany.CharteredCapital = charteredCapital;
            tbCompany.TotalShare = totalShare;
            tbCompany.ListedShare = listedShare;
            tbCompany.ParValue = parValue;
            tbCompany.ContactName1 = contactName1;
            tbCompany.ContactDept1 = contactDept1;
            tbCompany.ContactMail1 = contactMail1;
            tbCompany.ContactPosition1 = contactPosition1;
            tbCompany.ContactPhone1 = contactPhone1;
            tbCompany.ContactName2 = contactName2;
            tbCompany.ContactDept2 = contactDept2;
            tbCompany.ContactMail2 = contactMail2;
            tbCompany.ContactPosition2 = contactPosition2;
            tbCompany.ContactPhone2 = contactPhone2;
            tbCompany.longtitude = longtitude;
            tbCompany.latitude = latitude;
            tbCompany.Note = note;
            tbCompany.DocStatus = docStatus;
            tbCompany.DirectShareholding = directShareholding;
            tbCompany.ConsolidatedShareholding = consolidatedShareholding;
            tbCompany.ConsolidateNoted = consolidateNoted;
            tbCompany.VotingRightDirect = votingRightDirect;
            tbCompany.VotingRightTotal = votingRightTotal;
            tbCompany.Image = image;
            tbCompany.IsActive = isActive;
            tbCompany.crt_date = crt_date;
            tbCompany.crt_user = crt_user;
            tbCompany.mod_date = mod_date;
            tbCompany.mod_user = mod_user;
            tbCompany.BravoCode = bravoCode;
            tbCompany.LegacyCode = legacyCode;
            tbCompany.idCompanyType = idCompanyType;

            return await _tbCompanyRepository.UpdateAsync(tbCompany);
        }

    }
}