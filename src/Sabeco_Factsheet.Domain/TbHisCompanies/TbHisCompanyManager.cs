using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public abstract class TbHisCompanyManagerBase : DomainService
    {
        public ITbHisCompanyRepository _tbHisCompanyRepository;

        public TbHisCompanyManagerBase(ITbHisCompanyRepository tbHisCompanyRepository)
        {
            _tbHisCompanyRepository = tbHisCompanyRepository;
        }

        public virtual async Task<TbHisCompany> CreateAsync(
        int type, int idCompany, int parentId, bool isGroup, string code, string name, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbHisCompanyConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbHisCompanyConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbHisCompanyConsts.Name_ENMaxLength);
            Check.Length(briefName, nameof(briefName), TbHisCompanyConsts.BriefNameMaxLength);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbHisCompanyConsts.ContactInfo_01MaxLength);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbHisCompanyConsts.ContactInfo_02MaxLength);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbHisCompanyConsts.ContactInfo_03MaxLength);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbHisCompanyConsts.ContactInfo_04MaxLength);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbHisCompanyConsts.ContactInfo_05MaxLength);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbHisCompanyConsts.ContactInfo_06MaxLength);
            Check.Length(stockCode, nameof(stockCode), TbHisCompanyConsts.StockCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbHisCompanyConsts.StockExchangeMaxLength);
            Check.Length(licenseNo, nameof(licenseNo), TbHisCompanyConsts.LicenseNoMaxLength);
            Check.Length(license, nameof(license), TbHisCompanyConsts.LicenseMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbHisCompanyConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbHisCompanyConsts.CompanyTypeMaxLength);
            Check.Length(contactName1, nameof(contactName1), TbHisCompanyConsts.ContactName1MaxLength);
            Check.Length(contactDept1, nameof(contactDept1), TbHisCompanyConsts.ContactDept1MaxLength);
            Check.Length(contactMail1, nameof(contactMail1), TbHisCompanyConsts.ContactMail1MaxLength);
            Check.Length(contactPosition1, nameof(contactPosition1), TbHisCompanyConsts.ContactPosition1MaxLength);
            Check.Length(contactPhone1, nameof(contactPhone1), TbHisCompanyConsts.ContactPhone1MaxLength);
            Check.Length(contactName2, nameof(contactName2), TbHisCompanyConsts.ContactName2MaxLength);
            Check.Length(contactDept2, nameof(contactDept2), TbHisCompanyConsts.ContactDept2MaxLength);
            Check.Length(contactMail2, nameof(contactMail2), TbHisCompanyConsts.ContactMail2MaxLength);
            Check.Length(contactPosition2, nameof(contactPosition2), TbHisCompanyConsts.ContactPosition2MaxLength);
            Check.Length(contactPhone2, nameof(contactPhone2), TbHisCompanyConsts.ContactPhone2MaxLength);
            Check.Length(note, nameof(note), TbHisCompanyConsts.NoteMaxLength);

            var tbHisCompany = new TbHisCompany(

             type, idCompany, parentId, isGroup, code, name, isSendMail, dateSendMail, insertDate, name_EN, briefName, contactInfo_01, contactInfo_02, contactInfo_03, contactInfo_04, contactInfo_05, contactInfo_06, stockCode, stockExchange, stockRegistrationDate, isPublicCompany, licenseNo, license, registrationOrder, registrationDate0, registrationDate, latestAmendment, legalRepresent, companyType, charteredCapital, totalShare, listedShare, parValue, contactName1, contactDept1, contactMail1, contactPosition1, contactPhone1, contactName2, contactDept2, contactMail2, contactPosition2, contactPhone2, longtitude, latitude, note, docStatus, directShareholding, consolidatedShareholding, consolidateNoted, votingRightDirect, votingRightTotal, image, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbHisCompanyRepository.InsertAsync(tbHisCompany);
        }

        public virtual async Task<TbHisCompany> UpdateAsync(
            int id,
            int type, int idCompany, int parentId, bool isGroup, string code, string name, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbHisCompanyConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbHisCompanyConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbHisCompanyConsts.Name_ENMaxLength);
            Check.Length(briefName, nameof(briefName), TbHisCompanyConsts.BriefNameMaxLength);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbHisCompanyConsts.ContactInfo_01MaxLength);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbHisCompanyConsts.ContactInfo_02MaxLength);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbHisCompanyConsts.ContactInfo_03MaxLength);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbHisCompanyConsts.ContactInfo_04MaxLength);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbHisCompanyConsts.ContactInfo_05MaxLength);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbHisCompanyConsts.ContactInfo_06MaxLength);
            Check.Length(stockCode, nameof(stockCode), TbHisCompanyConsts.StockCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbHisCompanyConsts.StockExchangeMaxLength);
            Check.Length(licenseNo, nameof(licenseNo), TbHisCompanyConsts.LicenseNoMaxLength);
            Check.Length(license, nameof(license), TbHisCompanyConsts.LicenseMaxLength);
            Check.Length(legalRepresent, nameof(legalRepresent), TbHisCompanyConsts.LegalRepresentMaxLength);
            Check.Length(companyType, nameof(companyType), TbHisCompanyConsts.CompanyTypeMaxLength);
            Check.Length(contactName1, nameof(contactName1), TbHisCompanyConsts.ContactName1MaxLength);
            Check.Length(contactDept1, nameof(contactDept1), TbHisCompanyConsts.ContactDept1MaxLength);
            Check.Length(contactMail1, nameof(contactMail1), TbHisCompanyConsts.ContactMail1MaxLength);
            Check.Length(contactPosition1, nameof(contactPosition1), TbHisCompanyConsts.ContactPosition1MaxLength);
            Check.Length(contactPhone1, nameof(contactPhone1), TbHisCompanyConsts.ContactPhone1MaxLength);
            Check.Length(contactName2, nameof(contactName2), TbHisCompanyConsts.ContactName2MaxLength);
            Check.Length(contactDept2, nameof(contactDept2), TbHisCompanyConsts.ContactDept2MaxLength);
            Check.Length(contactMail2, nameof(contactMail2), TbHisCompanyConsts.ContactMail2MaxLength);
            Check.Length(contactPosition2, nameof(contactPosition2), TbHisCompanyConsts.ContactPosition2MaxLength);
            Check.Length(contactPhone2, nameof(contactPhone2), TbHisCompanyConsts.ContactPhone2MaxLength);
            Check.Length(note, nameof(note), TbHisCompanyConsts.NoteMaxLength);

            var tbHisCompany = await _tbHisCompanyRepository.GetAsync(id);

            tbHisCompany.Type = type;
            tbHisCompany.IdCompany = idCompany;
            tbHisCompany.ParentId = parentId;
            tbHisCompany.IsGroup = isGroup;
            tbHisCompany.Code = code;
            tbHisCompany.Name = name;
            tbHisCompany.IsSendMail = isSendMail;
            tbHisCompany.DateSendMail = dateSendMail;
            tbHisCompany.InsertDate = insertDate;
            tbHisCompany.Name_EN = name_EN;
            tbHisCompany.BriefName = briefName;
            tbHisCompany.ContactInfo_01 = contactInfo_01;
            tbHisCompany.ContactInfo_02 = contactInfo_02;
            tbHisCompany.ContactInfo_03 = contactInfo_03;
            tbHisCompany.ContactInfo_04 = contactInfo_04;
            tbHisCompany.ContactInfo_05 = contactInfo_05;
            tbHisCompany.ContactInfo_06 = contactInfo_06;
            tbHisCompany.StockCode = stockCode;
            tbHisCompany.StockExchange = stockExchange;
            tbHisCompany.StockRegistrationDate = stockRegistrationDate;
            tbHisCompany.IsPublicCompany = isPublicCompany;
            tbHisCompany.LicenseNo = licenseNo;
            tbHisCompany.License = license;
            tbHisCompany.RegistrationOrder = registrationOrder;
            tbHisCompany.RegistrationDate0 = registrationDate0;
            tbHisCompany.RegistrationDate = registrationDate;
            tbHisCompany.LatestAmendment = latestAmendment;
            tbHisCompany.LegalRepresent = legalRepresent;
            tbHisCompany.CompanyType = companyType;
            tbHisCompany.CharteredCapital = charteredCapital;
            tbHisCompany.TotalShare = totalShare;
            tbHisCompany.ListedShare = listedShare;
            tbHisCompany.ParValue = parValue;
            tbHisCompany.ContactName1 = contactName1;
            tbHisCompany.ContactDept1 = contactDept1;
            tbHisCompany.ContactMail1 = contactMail1;
            tbHisCompany.ContactPosition1 = contactPosition1;
            tbHisCompany.ContactPhone1 = contactPhone1;
            tbHisCompany.ContactName2 = contactName2;
            tbHisCompany.ContactDept2 = contactDept2;
            tbHisCompany.ContactMail2 = contactMail2;
            tbHisCompany.ContactPosition2 = contactPosition2;
            tbHisCompany.ContactPhone2 = contactPhone2;
            tbHisCompany.longtitude = longtitude;
            tbHisCompany.latitude = latitude;
            tbHisCompany.Note = note;
            tbHisCompany.DocStatus = docStatus;
            tbHisCompany.DirectShareholding = directShareholding;
            tbHisCompany.ConsolidatedShareholding = consolidatedShareholding;
            tbHisCompany.ConsolidateNoted = consolidateNoted;
            tbHisCompany.VotingRightDirect = votingRightDirect;
            tbHisCompany.VotingRightTotal = votingRightTotal;
            tbHisCompany.Image = image;
            tbHisCompany.IsActive = isActive;
            tbHisCompany.crt_date = crt_date;
            tbHisCompany.crt_user = crt_user;
            tbHisCompany.mod_date = mod_date;
            tbHisCompany.mod_user = mod_user;

            return await _tbHisCompanyRepository.UpdateAsync(tbHisCompany);
        }

    }
}