using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class TbCompanyMemberCouncilTermBase : Entity<int>
    {
        public virtual int? CompanyId { get; set; }

        public virtual int? TermFrom { get; set; }

        public virtual int? TermEnd { get; set; }

        protected TbCompanyMemberCouncilTermBase()
        {

        }

        public TbCompanyMemberCouncilTermBase(int? companyId = null, int? termFrom = null, int? termEnd = null)
        {

            CompanyId = companyId;
            TermFrom = termFrom;
            TermEnd = termEnd;
        }

    }
}