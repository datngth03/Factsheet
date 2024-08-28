using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyTemps
{
    public abstract class TbCompanyTempManagerBase : DomainService
    {
        public ITbCompanyTempRepository _tbCompanyTempRepository;

        public TbCompanyTempManagerBase(ITbCompanyTempRepository tbCompanyTempRepository)
        {
            _tbCompanyTempRepository = tbCompanyTempRepository;
        }

        public virtual async Task<TbCompanyTemp> CreateAsync(
        int idCompany, int parentId, bool isGroup, string code, string name, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? bravoCode = null, string? legacyCode = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbCompanyTempConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbCompanyTempConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbCompanyTempConsts.Name_ENMaxLength);
            Check.Length(briefName, nameof(briefName), TbCompanyTempConsts.BriefNameMaxLength);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbCompanyTempConsts.ContactInfo_01MaxLength);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbCompanyTempConsts.ContactInfo_02MaxLength);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbCompanyTempConsts.ContactInfo_03MaxLength);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbCompanyTempConsts.ContactInfo_04MaxLength);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbCompanyTempConsts.ContactInfo_05MaxLength);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbCompanyTempConsts.ContactInfo_06MaxLength);
            Check.Length(stockCode, nameof(stockCode), TbCompanyTempConsts.StockCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyTempConsts.StockExchangeMaxLength);
            Check.Length(licenseNo, nameof(licenseNo), TbCompanyTempConsts.LicenseNoMaxLength);
            Check.Length(license, nameof(license), TbCompanyTempConsts.LicenseMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyTempConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyTempConsts.CompanyTypeMaxLength);
            Check.Length(contactName1, nameof(contactName1), TbCompanyTempConsts.ContactName1MaxLength);
            Check.Length(contactDept1, nameof(contactDept1), TbCompanyTempConsts.ContactDept1MaxLength);
            Check.Length(contactMail1, nameof(contactMail1), TbCompanyTempConsts.ContactMail1MaxLength);
            Check.Length(contactPosition1, nameof(contactPosition1), TbCompanyTempConsts.ContactPosition1MaxLength);
            Check.Length(contactPhone1, nameof(contactPhone1), TbCompanyTempConsts.ContactPhone1MaxLength);
            Check.Length(contactName2, nameof(contactName2), TbCompanyTempConsts.ContactName2MaxLength);
            Check.Length(contactDept2, nameof(contactDept2), TbCompanyTempConsts.ContactDept2MaxLength);
            Check.Length(contactMail2, nameof(contactMail2), TbCompanyTempConsts.ContactMail2MaxLength);
            Check.Length(contactPosition2, nameof(contactPosition2), TbCompanyTempConsts.ContactPosition2MaxLength);
            Check.Length(contactPhone2, nameof(contactPhone2), TbCompanyTempConsts.ContactPhone2MaxLength);
            Check.Length(note, nameof(note), TbCompanyTempConsts.NoteMaxLength);
            Check.Length(bravoCode, nameof(bravoCode), TbCompanyTempConsts.BravoCodeMaxLength);
            Check.Length(legacyCode, nameof(legacyCode), TbCompanyTempConsts.LegacyCodeMaxLength);

            var tbCompanyTemp = new TbCompanyTemp(

             idCompany, parentId, isGroup, code, name, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDate, isPublicCompany, licenseNo, license, registrationOrder, registrationDate0, registrationDate, latestAmendment, legalRepresent, companyType, charteredCapital, totalShare, listedShare, parValue, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitude, latitude, note, docStatus, directShareholding, consolidatedShareholding, consolidateNoted, votingRightDirect, votingRightTotal, image, isActive, crt_date, crt_user, mod_date, mod_user, bravoCode, legacyCode
             );

            return await _tbCompanyTempRepository.InsertAsync(tbCompanyTemp);
        }

        public virtual async Task<TbCompanyTemp> UpdateAsync(
            int id,
            int idCompany, int parentId, bool isGroup, string code, string name, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? bravoCode = null, string? legacyCode = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbCompanyTempConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbCompanyTempConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbCompanyTempConsts.Name_ENMaxLength);
            Check.Length(briefName, nameof(briefName), TbCompanyTempConsts.BriefNameMaxLength);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbCompanyTempConsts.ContactInfo_01MaxLength);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbCompanyTempConsts.ContactInfo_02MaxLength);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbCompanyTempConsts.ContactInfo_03MaxLength);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbCompanyTempConsts.ContactInfo_04MaxLength);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbCompanyTempConsts.ContactInfo_05MaxLength);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbCompanyTempConsts.ContactInfo_06MaxLength);
            Check.Length(stockCode, nameof(stockCode), TbCompanyTempConsts.StockCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyTempConsts.StockExchangeMaxLength);
            Check.Length(licenseNo, nameof(licenseNo), TbCompanyTempConsts.LicenseNoMaxLength);
            Check.Length(license, nameof(license), TbCompanyTempConsts.LicenseMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyTempConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbCompanyTempConsts.CompanyTypeMaxLength);
            Check.Length(contactName1, nameof(contactName1), TbCompanyTempConsts.ContactName1MaxLength);
            Check.Length(contactDept1, nameof(contactDept1), TbCompanyTempConsts.ContactDept1MaxLength);
            Check.Length(contactMail1, nameof(contactMail1), TbCompanyTempConsts.ContactMail1MaxLength);
            Check.Length(contactPosition1, nameof(contactPosition1), TbCompanyTempConsts.ContactPosition1MaxLength);
            Check.Length(contactPhone1, nameof(contactPhone1), TbCompanyTempConsts.ContactPhone1MaxLength);
            Check.Length(contactName2, nameof(contactName2), TbCompanyTempConsts.ContactName2MaxLength);
            Check.Length(contactDept2, nameof(contactDept2), TbCompanyTempConsts.ContactDept2MaxLength);
            Check.Length(contactMail2, nameof(contactMail2), TbCompanyTempConsts.ContactMail2MaxLength);
            Check.Length(contactPosition2, nameof(contactPosition2), TbCompanyTempConsts.ContactPosition2MaxLength);
            Check.Length(contactPhone2, nameof(contactPhone2), TbCompanyTempConsts.ContactPhone2MaxLength);
            Check.Length(note, nameof(note), TbCompanyTempConsts.NoteMaxLength);
            Check.Length(bravoCode, nameof(bravoCode), TbCompanyTempConsts.BravoCodeMaxLength);
            Check.Length(legacyCode, nameof(legacyCode), TbCompanyTempConsts.LegacyCodeMaxLength);

            var tbCompanyTemp = await _tbCompanyTempRepository.GetAsync(id);

            tbCompanyTemp.idCompany = idCompany;
            tbCompanyTemp.ParentId = parentId;
            tbCompanyTemp.IsGroup = isGroup;
            tbCompanyTemp.Code = code;
            tbCompanyTemp.Name = name;
            tbCompanyTemp.Name_EN = name_EN;
            tbCompanyTemp.BriefName = briefName;
            tbCompanyTemp.ContactInfo_01 = contactInfo_01;
            tbCompanyTemp.ContactInfo_02 = contactInfo_02;
            tbCompanyTemp.ContactInfo_03 = contactInfo_03;
            tbCompanyTemp.ContactInfo_04 = contactInfo_04;
            tbCompanyTemp.ContactInfo_05 = contactInfo_05;
            tbCompanyTemp.ContactInfo_06 = contactInfo_06;
            tbCompanyTemp.StockCode = stockCode;
            tbCompanyTemp.StockExchange = stockExchange;
            tbCompanyTemp.StockRegistrationDate = stockRegistrationDate;
            tbCompanyTemp.IsPublicCompany = isPublicCompany;
            tbCompanyTemp.LicenseNo = licenseNo;
            tbCompanyTemp.License = license;
            tbCompanyTemp.RegistrationOrder = registrationOrder;
            tbCompanyTemp.RegistrationDate0 = registrationDate0;
            tbCompanyTemp.RegistrationDate = registrationDate;
            tbCompanyTemp.LatestAmendment = latestAmendment;
            tbCompanyTemp.LegalRepresent = legalRepresent;
            tbCompanyTemp.CompanyType = companyType;
            tbCompanyTemp.CharteredCapital = charteredCapital;
            tbCompanyTemp.TotalShare = totalShare;
            tbCompanyTemp.ListedShare = listedShare;
            tbCompanyTemp.ParValue = parValue;
            tbCompanyTemp.ContactName1 = contactName1;
            tbCompanyTemp.ContactDept1 = contactDept1;
            tbCompanyTemp.ContactMail1 = contactMail1;
            tbCompanyTemp.ContactPosition1 = contactPosition1;
            tbCompanyTemp.ContactPhone1 = contactPhone1;
            tbCompanyTemp.ContactName2 = contactName2;
            tbCompanyTemp.ContactDept2 = contactDept2;
            tbCompanyTemp.ContactMail2 = contactMail2;
            tbCompanyTemp.ContactPosition2 = contactPosition2;
            tbCompanyTemp.ContactPhone2 = contactPhone2;
            tbCompanyTemp.longtitude = longtitude;
            tbCompanyTemp.latitude = latitude;
            tbCompanyTemp.Note = note;
            tbCompanyTemp.DocStatus = docStatus;
            tbCompanyTemp.DirectShareholding = directShareholding;
            tbCompanyTemp.ConsolidatedShareholding = consolidatedShareholding;
            tbCompanyTemp.ConsolidateNoted = consolidateNoted;
            tbCompanyTemp.VotingRightDirect = votingRightDirect;
            tbCompanyTemp.VotingRightTotal = votingRightTotal;
            tbCompanyTemp.Image = image;
            tbCompanyTemp.IsActive = isActive;
            tbCompanyTemp.crt_date = crt_date;
            tbCompanyTemp.crt_user = crt_user;
            tbCompanyTemp.mod_date = mod_date;
            tbCompanyTemp.mod_user = mod_user;
            tbCompanyTemp.BravoCode = bravoCode;
            tbCompanyTemp.LegacyCode = legacyCode;

            return await _tbCompanyTempRepository.UpdateAsync(tbCompanyTemp);
        }

    }
}