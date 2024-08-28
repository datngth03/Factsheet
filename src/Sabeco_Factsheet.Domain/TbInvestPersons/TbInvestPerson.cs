using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public abstract class TbInvestPersonBase : Entity<int>
    {
        public virtual int ParentId { get; set; }

        public virtual int PersonId { get; set; }

        public virtual DateTime FromDate { get; set; }

        public virtual int? PersonalValue { get; set; }

        public virtual int? OwnerValue { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbInvestPersonBase()
        {

        }

        public TbInvestPersonBase(int parentId, int personId, DateTime fromDate, bool isDeleted, int? personalValue = null, int? ownerValue = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.Length(note, nameof(note), TbInvestPersonConsts.NoteMaxLength, 0);
            ParentId = parentId;
            PersonId = personId;
            FromDate = fromDate;
            IsDeleted = isDeleted;
            PersonalValue = personalValue;
            OwnerValue = ownerValue;
            Note = note;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}