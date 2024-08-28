using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbPersons
{
    public abstract class TbPersonBase : Entity<int>
    {
        [NotNull]
        public virtual string Code { get; set; }

        public virtual int? CompanyId { get; set; }

        [NotNull]
        public virtual string FullName { get; set; }

        public virtual DateTime BirthDate { get; set; }

        [CanBeNull]
        public virtual string? BirthPlace { get; set; }

        [CanBeNull]
        public virtual string? Address { get; set; }

        [CanBeNull]
        public virtual string? IDCardNo { get; set; }

        public virtual DateTime? IDCardDate { get; set; }

        [CanBeNull]
        public virtual string? IdCardIssuePlace { get; set; }

        [CanBeNull]
        public virtual string? Ethnicity { get; set; }

        [CanBeNull]
        public virtual string? Religion { get; set; }

        [CanBeNull]
        public virtual string? NationalityCode { get; set; }

        [CanBeNull]
        public virtual string? Gender { get; set; }

        [CanBeNull]
        public virtual string? Phone { get; set; }

        [CanBeNull]
        public virtual string? Email { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Image { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool? IsCheckRetirement { get; set; }

        public virtual bool? IsCheckTermEnd { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        [CanBeNull]
        public virtual string? OldCode { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbPersonBase()
        {

        }

        public TbPersonBase(string code, string fullName, DateTime birthDate, bool isDeleted, int? companyId = null, string? birthPlace = null, string? address = null, string? iDCardNo = null, DateTime? iDCardDate = null, string? idCardIssuePlace = null, string? ethnicity = null, string? religion = null, string? nationalityCode = null, string? gender = null, string? phone = null, string? email = null, string? note = null, string? image = null, bool? isActive = null, byte? docStatus = null, bool? isCheckRetirement = null, bool? isCheckTermEnd = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? oldCode = null)
        {

            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), TbPersonConsts.CodeMaxLength, 0);
            Check.NotNull(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbPersonConsts.FullNameMaxLength, 0);
            Check.Length(birthPlace, nameof(birthPlace), TbPersonConsts.BirthPlaceMaxLength, 0);
            Check.Length(address, nameof(address), TbPersonConsts.AddressMaxLength, 0);
            Check.Length(iDCardNo, nameof(iDCardNo), TbPersonConsts.IDCardNoMaxLength, 0);
            Check.Length(idCardIssuePlace, nameof(idCardIssuePlace), TbPersonConsts.IdCardIssuePlaceMaxLength, 0);
            Check.Length(ethnicity, nameof(ethnicity), TbPersonConsts.EthnicityMaxLength, 0);
            Check.Length(religion, nameof(religion), TbPersonConsts.ReligionMaxLength, 0);
            Check.Length(nationalityCode, nameof(nationalityCode), TbPersonConsts.NationalityCodeMaxLength, 0);
            Check.Length(gender, nameof(gender), TbPersonConsts.GenderMaxLength, 0);
            Check.Length(phone, nameof(phone), TbPersonConsts.PhoneMaxLength, 0);
            Check.Length(email, nameof(email), TbPersonConsts.EmailMaxLength, 0);
            Check.Length(note, nameof(note), TbPersonConsts.NoteMaxLength, 0);
            Check.Length(oldCode, nameof(oldCode), TbPersonConsts.OldCodeMaxLength, 0);
            Code = code;
            FullName = fullName;
            BirthDate = birthDate;
            IsDeleted = isDeleted;
            CompanyId = companyId;
            BirthPlace = birthPlace;
            Address = address;
            IDCardNo = iDCardNo;
            IDCardDate = iDCardDate;
            IdCardIssuePlace = idCardIssuePlace;
            Ethnicity = ethnicity;
            Religion = religion;
            NationalityCode = nationalityCode;
            Gender = gender;
            Phone = phone;
            Email = email;
            Note = note;
            Image = image;
            IsActive = isActive;
            DocStatus = docStatus;
            IsCheckRetirement = isCheckRetirement;
            IsCheckTermEnd = isCheckTermEnd;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            OldCode = oldCode;
        }

    }
}