using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbTerms
{
    public abstract class TbTermBase : Entity<int>
    {
        public virtual int BranchId { get; set; }

        [NotNull]
        public virtual string TermCode { get; set; }

        public virtual int? FromYear { get; set; }

        public virtual int? ToYear { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected TbTermBase()
        {

        }

        public TbTermBase(int branchId, string termCode, int? fromYear = null, int? toYear = null, string? description = null)
        {

            Check.NotNull(termCode, nameof(termCode));
            Check.Length(termCode, nameof(termCode), TbTermConsts.TermCodeMaxLength, 0);
            Check.Length(description, nameof(description), TbTermConsts.DescriptionMaxLength, 0);
            BranchId = branchId;
            TermCode = termCode;
            FromYear = fromYear;
            ToYear = toYear;
            Description = description;
        }

    }
}