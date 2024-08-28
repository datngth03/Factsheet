using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public abstract class TbCompanyMajorTempBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        [NotNull]
        public virtual string ShareHolderMajor { get; set; }

        [NotNull]
        public virtual string ShareHolderType { get; set; }

        public virtual DateTime? FromDate { get; set; }

        public virtual DateTime? ToDate { get; set; }

        public virtual decimal? ShareHolderValue { get; set; }

        public virtual decimal? ShareHolderRate { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual int? ClassId { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbCompanyMajorTempBase()
        {

        }

        public TbCompanyMajorTempBase(int companyId, string shareHolderMajor, string shareHolderType, bool isActive, bool isDeleted, DateTime? fromDate = null, DateTime? toDate = null, decimal? shareHolderValue = null, decimal? shareHolderRate = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? classId = null)
        {

            Check.NotNull(shareHolderMajor, nameof(shareHolderMajor));
            Check.NotNull(shareHolderType, nameof(shareHolderType));
            Check.Length(shareHolderType, nameof(shareHolderType), TbCompanyMajorTempConsts.ShareHolderTypeMaxLength, 0);
            Check.Length(note, nameof(note), TbCompanyMajorTempConsts.NoteMaxLength, 0);
            CompanyId = companyId;
            ShareHolderMajor = shareHolderMajor;
            ShareHolderType = shareHolderType;
            IsActive = isActive;
            IsDeleted = isDeleted;
            FromDate = fromDate;
            ToDate = toDate;
            ShareHolderValue = shareHolderValue;
            ShareHolderRate = shareHolderRate;
            Note = note;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            ClassId = classId;
        }

    }
}