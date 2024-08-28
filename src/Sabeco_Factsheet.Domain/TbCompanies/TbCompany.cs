using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanies
{
    public abstract class TbCompanyBase : Entity<int>
    {
        public virtual int ParentId { get; set; }

        public virtual bool IsGroup { get; set; }

        [NotNull]
        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Name_EN { get; set; }

        [CanBeNull]
        public virtual string? BriefName { get; set; }

        [CanBeNull]
        public virtual string? ContactInfo_01 { get; set; }

        [CanBeNull]
        public virtual string? ContactInfo_02 { get; set; }

        [CanBeNull]
        public virtual string? ContactInfo_03 { get; set; }

        [CanBeNull]
        public virtual string? ContactInfo_04 { get; set; }

        [CanBeNull]
        public virtual string? ContactInfo_05 { get; set; }

        [CanBeNull]
        public virtual string? ContactInfo_06 { get; set; }

        [CanBeNull]
        public virtual string? StockCode { get; set; }

        [CanBeNull]
        public virtual string? StockExchange { get; set; }

        public virtual DateTime? StockRegistrationDate { get; set; }

        public virtual bool? IsPublicCompany { get; set; }

        [CanBeNull]
        public virtual string? LicenseNo { get; set; }

        [CanBeNull]
        public virtual string? License { get; set; }

        public virtual byte? RegistrationOrder { get; set; }

        public virtual DateTime? RegistrationDate0 { get; set; }

        public virtual DateTime? RegistrationDate { get; set; }

        public virtual DateTime? LatestAmendment { get; set; }

        [CanBeNull]
        public virtual string? LegalRepresent { get; set; }

        [CanBeNull]
        public virtual string? CompanyType { get; set; }

        public virtual decimal? CharteredCapital { get; set; }

        public virtual decimal? TotalShare { get; set; }

        public virtual decimal? ListedShare { get; set; }

        public virtual int? ParValue { get; set; }

        [CanBeNull]
        public virtual string? ContactName1 { get; set; }

        [CanBeNull]
        public virtual string? ContactDept1 { get; set; }

        [CanBeNull]
        public virtual string? ContactMail1 { get; set; }

        [CanBeNull]
        public virtual string? ContactPosition1 { get; set; }

        [CanBeNull]
        public virtual string? ContactPhone1 { get; set; }

        [CanBeNull]
        public virtual string? ContactName2 { get; set; }

        [CanBeNull]
        public virtual string? ContactDept2 { get; set; }

        [CanBeNull]
        public virtual string? ContactMail2 { get; set; }

        [CanBeNull]
        public virtual string? ContactPosition2 { get; set; }

        [CanBeNull]
        public virtual string? ContactPhone2 { get; set; }

        public virtual double? longtitude { get; set; }

        public virtual double? latitude { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual decimal? DirectShareholding { get; set; }

        public virtual decimal? ConsolidatedShareholding { get; set; }

        [CanBeNull]
        public virtual string? ConsolidateNoted { get; set; }

        public virtual decimal? VotingRightDirect { get; set; }

        public virtual decimal? VotingRightTotal { get; set; }

        [CanBeNull]
        public virtual string? Image { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        [CanBeNull]
        public virtual string? BravoCode { get; set; }

        [CanBeNull]
        public virtual string? LegacyCode { get; set; }

        public virtual int? idCompanyType { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbCompanyBase()
        {

        }

        public TbCompanyBase(int parentId, bool isGroup, string code, string name, bool isDeleted, string? name_EN = null, string? briefName = null, string? contactInfo_01 = null, string? contactInfo_02 = null, string? contactInfo_03 = null, string? contactInfo_04 = null, string? contactInfo_05 = null, string? contactInfo_06 = null, string? stockCode = null, string? stockExchange = null, DateTime? stockRegistrationDate = null, bool? isPublicCompany = null, string? licenseNo = null, string? license = null, byte? registrationOrder = null, DateTime? registrationDate0 = null, DateTime? registrationDate = null, DateTime? latestAmendment = null, string? legalRepresent = null, string? companyType = null, decimal? charteredCapital = null, decimal? totalShare = null, decimal? listedShare = null, int? parValue = null, string? contactName1 = null, string? contactDept1 = null, string? contactMail1 = null, string? contactPosition1 = null, string? contactPhone1 = null, string? contactName2 = null, string? contactDept2 = null, string? contactMail2 = null, string? contactPosition2 = null, string? contactPhone2 = null, double? longtitude = null, double? latitude = null, string? note = null, byte? docStatus = null, decimal? directShareholding = null, decimal? consolidatedShareholding = null, string? consolidateNoted = null, decimal? votingRightDirect = null, decimal? votingRightTotal = null, string? image = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? bravoCode = null, string? legacyCode = null, int? idCompanyType = null)
        {

            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), TbCompanyConsts.CodeMaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), TbCompanyConsts.NameMaxLength, 0);
            Check.Length(name_EN, nameof(name_EN), TbCompanyConsts.Name_ENMaxLength, 0);
            Check.Length(briefName, nameof(briefName), TbCompanyConsts.BriefNameMaxLength, 0);
            Check.Length(contactInfo_01, nameof(contactInfo_01), TbCompanyConsts.ContactInfo_01MaxLength, 0);
            Check.Length(contactInfo_02, nameof(contactInfo_02), TbCompanyConsts.ContactInfo_02MaxLength, 0);
            Check.Length(contactInfo_03, nameof(contactInfo_03), TbCompanyConsts.ContactInfo_03MaxLength, 0);
            Check.Length(contactInfo_04, nameof(contactInfo_04), TbCompanyConsts.ContactInfo_04MaxLength, 0);
            Check.Length(contactInfo_05, nameof(contactInfo_05), TbCompanyConsts.ContactInfo_05MaxLength, 0);
            Check.Length(contactInfo_06, nameof(contactInfo_06), TbCompanyConsts.ContactInfo_06MaxLength, 0);
            Check.Length(stockCode, nameof(stockCode), TbCompanyConsts.StockCodeMaxLength, 0);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyConsts.StockExchangeMaxLength, 0);
            Check.Length(licenseNo, nameof(licenseNo), TbCompanyConsts.LicenseNoMaxLength, 0);
            Check.Length(license, nameof(license), TbCompanyConsts.LicenseMaxLength, 0);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyConsts.LegalRepresentMaxLength, 0);
            Check.Length(companyType, nameof(companyType), TbCompanyConsts.CompanyTypeMaxLength, 0);
            Check.Length(contactName1, nameof(contactName1), TbCompanyConsts.ContactName1MaxLength, 0);
            Check.Length(contactDept1, nameof(contactDept1), TbCompanyConsts.ContactDept1MaxLength, 0);
            Check.Length(contactMail1, nameof(contactMail1), TbCompanyConsts.ContactMail1MaxLength, 0);
            Check.Length(contactPosition1, nameof(contactPosition1), TbCompanyConsts.ContactPosition1MaxLength, 0);
            Check.Length(contactPhone1, nameof(contactPhone1), TbCompanyConsts.ContactPhone1MaxLength, 0);
            Check.Length(contactName2, nameof(contactName2), TbCompanyConsts.ContactName2MaxLength, 0);
            Check.Length(contactDept2, nameof(contactDept2), TbCompanyConsts.ContactDept2MaxLength, 0);
            Check.Length(contactMail2, nameof(contactMail2), TbCompanyConsts.ContactMail2MaxLength, 0);
            Check.Length(contactPosition2, nameof(contactPosition2), TbCompanyConsts.ContactPosition2MaxLength, 0);
            Check.Length(contactPhone2, nameof(contactPhone2), TbCompanyConsts.ContactPhone2MaxLength, 0);
            Check.Length(note, nameof(note), TbCompanyConsts.NoteMaxLength, 0);
            Check.Length(bravoCode, nameof(bravoCode), TbCompanyConsts.BravoCodeMaxLength, 0);
            Check.Length(legacyCode, nameof(legacyCode), TbCompanyConsts.LegacyCodeMaxLength, 0);
            ParentId = parentId;
            IsGroup = isGroup;
            Code = code;
            Name = name;
            this.IsDeleted = isDeleted;
            Name_EN = name_EN;
            BriefName = briefName;
            ContactInfo_01 = contactInfo_01;
            ContactInfo_02 = contactInfo_02;
            ContactInfo_03 = contactInfo_03;
            ContactInfo_04 = contactInfo_04;
            ContactInfo_05 = contactInfo_05;
            ContactInfo_06 = contactInfo_06;
            StockCode = stockCode;
            StockExchange = stockExchange;
            StockRegistrationDate = stockRegistrationDate;
            IsPublicCompany = isPublicCompany;
            LicenseNo = licenseNo;
            License = license;
            RegistrationOrder = registrationOrder;
            RegistrationDate0 = registrationDate0;
            RegistrationDate = registrationDate;
            LatestAmendment = latestAmendment;
            LegalRepresent = legalRepresent;
            CompanyType = companyType;
            CharteredCapital = charteredCapital;
            TotalShare = totalShare;
            ListedShare = listedShare;
            ParValue = parValue;
            ContactName1 = contactName1;
            ContactDept1 = contactDept1;
            ContactMail1 = contactMail1;
            ContactPosition1 = contactPosition1;
            ContactPhone1 = contactPhone1;
            ContactName2 = contactName2;
            ContactDept2 = contactDept2;
            ContactMail2 = contactMail2;
            ContactPosition2 = contactPosition2;
            ContactPhone2 = contactPhone2;
            this.longtitude = longtitude;
            this.latitude = latitude;
            Note = note;
            DocStatus = docStatus;
            DirectShareholding = directShareholding;
            ConsolidatedShareholding = consolidatedShareholding;
            ConsolidateNoted = consolidateNoted;
            VotingRightDirect = votingRightDirect;
            VotingRightTotal = votingRightTotal;
            Image = image;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            BravoCode = bravoCode;
            LegacyCode = legacyCode;
            this.idCompanyType = idCompanyType;
        }

    }
}