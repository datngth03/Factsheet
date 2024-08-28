using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class TbUserMappingCompanyBase : Entity<int>
    {
        public virtual int? userid { get; set; }

        public virtual int? companyid { get; set; }

        public virtual bool? IsActive { get; set; }

        protected TbUserMappingCompanyBase()
        {

        }

        public TbUserMappingCompanyBase(int? userid = null, int? companyid = null, bool? isActive = null)
        {

            this.userid = userid;
            this.companyid = companyid;
            IsActive = isActive;
        }

    }
}