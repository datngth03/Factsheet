using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public abstract class TbInvestDetailBase : Entity<int>
    {
        public virtual int ParentId { get; set; }

        public virtual DateTime? DocDate { get; set; }

        [CanBeNull]
        public virtual string? DocNo { get; set; }

        public virtual int InvestType { get; set; }

        public virtual int? ShareNum { get; set; }

        public virtual decimal? ShareValue { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbInvestDetailBase()
        {

        }

        public TbInvestDetailBase(int parentId, int investType, bool isDeleted, DateTime? docDate = null, string? docNo = null, int? shareNum = null, decimal? shareValue = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.Length(docNo, nameof(docNo), TbInvestDetailConsts.DocNoMaxLength, 0);
            Check.Length(note, nameof(note), TbInvestDetailConsts.NoteMaxLength, 0);
            ParentId = parentId;
            InvestType = investType;
            IsDeleted = isDeleted;
            DocDate = docDate;
            DocNo = docNo;
            ShareNum = shareNum;
            ShareValue = shareValue;
            Note = note;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}