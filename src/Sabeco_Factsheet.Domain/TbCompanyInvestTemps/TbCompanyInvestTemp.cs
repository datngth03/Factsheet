using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyInvestTemps
{
    public abstract class TbCompanyInvestTempBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        [CanBeNull]
        public virtual string? CompanyName { get; set; }

        public virtual decimal? Shares { get; set; }

        public virtual decimal? Holding { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        protected TbCompanyInvestTempBase()
        {

        }

        public TbCompanyInvestTempBase(int companyId, bool isActive, string? companyName = null, decimal? shares = null, decimal? holding = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            CompanyId = companyId;
            IsActive = isActive;
            CompanyName = companyName;
            Shares = shares;
            Holding = holding;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}