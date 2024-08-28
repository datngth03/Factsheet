using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class TbInvestBase : Entity<int>
    {
        [NotNull]
        public virtual string BranchCode { get; set; }

        public virtual int? BranchId { get; set; }

        public virtual int? CompanyId { get; set; }

        [NotNull]
        public virtual string CompanyCode { get; set; }

        public virtual int? ShareNumTotal { get; set; }

        public virtual decimal? ShareValueTotal { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool? InvestGroup { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbInvestBase()
        {

        }

        public TbInvestBase(string branchCode, string companyCode, bool isDeleted, int? branchId = null, int? companyId = null, int? shareNumTotal = null, decimal? shareValueTotal = null, string? note = null, byte? docStatus = null, bool? investGroup = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.NotNull(branchCode, nameof(branchCode));
            Check.Length(branchCode, nameof(branchCode), TbInvestConsts.BranchCodeMaxLength, 0);
            Check.NotNull(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbInvestConsts.CompanyCodeMaxLength, 0);
            Check.Length(note, nameof(note), TbInvestConsts.NoteMaxLength, 0);
            BranchCode = branchCode;
            CompanyCode = companyCode;
            IsDeleted = isDeleted;
            BranchId = branchId;
            CompanyId = companyId;
            ShareNumTotal = shareNumTotal;
            ShareValueTotal = shareValueTotal;
            Note = note;
            DocStatus = docStatus;
            InvestGroup = investGroup;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}