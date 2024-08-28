using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class TbCompanyBoardBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? BranchCode { get; set; }

        [NotNull]
        public virtual string CompanyCode { get; set; }

        [NotNull]
        public virtual string PersonCode { get; set; }

        public virtual DateTime? FromDate { get; set; }

        public virtual DateTime? ToDate { get; set; }

        [CanBeNull]
        public virtual string? PositionCode { get; set; }

        public virtual int? PersonalValue { get; set; }

        public virtual int? OwnerValue { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbCompanyBoardBase()
        {

        }

        public TbCompanyBoardBase(string companyCode, string personCode, bool isActive, bool isDeleted, string? branchCode = null, DateTime? fromDate = null, DateTime? toDate = null, string? positionCode = null, int? personalValue = null, int? ownerValue = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.NotNull(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyBoardConsts.CompanyCodeMaxLength, 0);
            Check.NotNull(personCode, nameof(personCode));
            Check.Length(personCode, nameof(personCode), TbCompanyBoardConsts.PersonCodeMaxLength, 0);
            Check.Length(branchCode, nameof(branchCode), TbCompanyBoardConsts.BranchCodeMaxLength, 0);
            Check.Length(positionCode, nameof(positionCode), TbCompanyBoardConsts.PositionCodeMaxLength, 0);
            Check.Length(note, nameof(note), TbCompanyBoardConsts.NoteMaxLength, 0);
            CompanyCode = companyCode;
            PersonCode = personCode;
            IsActive = isActive;
            IsDeleted = isDeleted;
            BranchCode = branchCode;
            FromDate = fromDate;
            ToDate = toDate;
            PositionCode = positionCode;
            PersonalValue = personalValue;
            OwnerValue = ownerValue;
            Note = note;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}