using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public abstract class TbCompanyBusinessTempBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        [CanBeNull]
        public virtual string? License { get; set; }

        public virtual byte RegistrationNo { get; set; }

        public virtual DateTime RegistrationDate { get; set; }

        [CanBeNull]
        public virtual string? CompanyName { get; set; }

        [CanBeNull]
        public virtual string? CompanyAddress { get; set; }

        [CanBeNull]
        public virtual string? LegalRepresent { get; set; }

        [CanBeNull]
        public virtual string? CompanyType { get; set; }

        [CanBeNull]
        public virtual string? MajorBusiness { get; set; }

        [CanBeNull]
        public virtual string? OtherActivity { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? LatestAmendment { get; set; }

        protected TbCompanyBusinessTempBase()
        {

        }

        public TbCompanyBusinessTempBase(int companyId, byte registrationNo, DateTime registrationDate, string? license = null, string? companyName = null, string? companyAddress = null, string? legalRepresent = null, string? companyType = null, string? majorBusiness = null, string? otherActivity = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, DateTime? latestAmendment = null)
        {

            Check.Length(license, nameof(license), TbCompanyBusinessTempConsts.LicenseMaxLength, 0);
            Check.Length(companyName, nameof(companyName), TbCompanyBusinessTempConsts.CompanyNameMaxLength, 0);
            Check.Length(companyAddress, nameof(companyAddress), TbCompanyBusinessTempConsts.CompanyAddressMaxLength, 0);
            Check.Length(legalRepresent, nameof(legalRepresent), TbCompanyBusinessTempConsts.LegalRepresentMaxLength, 0);
            Check.Length(companyType, nameof(companyType), TbCompanyBusinessTempConsts.CompanyTypeMaxLength, 0);
            Check.Length(majorBusiness, nameof(majorBusiness), TbCompanyBusinessTempConsts.MajorBusinessMaxLength, 0);
            Check.Length(otherActivity, nameof(otherActivity), TbCompanyBusinessTempConsts.OtherActivityMaxLength, 0);
            Check.Length(note, nameof(note), TbCompanyBusinessTempConsts.NoteMaxLength, 0);
            CompanyId = companyId;
            RegistrationNo = registrationNo;
            RegistrationDate = registrationDate;
            License = license;
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            LegalRepresent = legalRepresent;
            CompanyType = companyType;
            MajorBusiness = majorBusiness;
            OtherActivity = otherActivity;
            Note = note;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            LatestAmendment = latestAmendment;
        }

    }
}