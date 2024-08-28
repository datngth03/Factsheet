using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyPersons
{
    public abstract class TbCompanyPersonBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? BranchCode { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual int PersonId { get; set; }

        public virtual int? PositionId { get; set; }

        public virtual DateTime? FromDate { get; set; }

        public virtual DateTime? ToDate { get; set; }

        [CanBeNull]
        public virtual string? PositionCode { get; set; }

        public virtual byte? PostionType { get; set; }

        public virtual decimal? PersonalValue { get; set; }

        public virtual decimal? PersonalSharePercentage { get; set; }

        public virtual decimal? OwnerValue { get; set; }

        public virtual decimal? RepresentativePercentage { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbCompanyPersonBase()
        {

        }

        public TbCompanyPersonBase(int companyId, int personId, bool isActive, bool isDeleted, string? branchCode = null, int? positionId = null, DateTime? fromDate = null, DateTime? toDate = null, string? positionCode = null, byte? postionType = null, decimal? personalValue = null, decimal? personalSharePercentage = null, decimal? ownerValue = null, decimal? representativePercentage = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.Length(branchCode, nameof(branchCode), TbCompanyPersonConsts.BranchCodeMaxLength, 0);
            Check.Length(positionCode, nameof(positionCode), TbCompanyPersonConsts.PositionCodeMaxLength, 0);
            Check.Length(note, nameof(note), TbCompanyPersonConsts.NoteMaxLength, 0);
            CompanyId = companyId;
            PersonId = personId;
            IsActive = isActive;
            IsDeleted = isDeleted;
            BranchCode = branchCode;
            PositionId = positionId;
            FromDate = fromDate;
            ToDate = toDate;
            PositionCode = positionCode;
            PostionType = postionType;
            PersonalValue = personalValue;
            PersonalSharePercentage = personalSharePercentage;
            OwnerValue = ownerValue;
            RepresentativePercentage = representativePercentage;
            Note = note;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}