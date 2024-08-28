using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public abstract class TbCompanyBranchBase : Entity<int>
    {
        public virtual int? CompanyId { get; set; }

        [CanBeNull]
        public virtual string? BranchName { get; set; }

        [CanBeNull]
        public virtual string? BranchAddress { get; set; }

        [CanBeNull]
        public virtual string? BranchCode { get; set; }

        [CanBeNull]
        public virtual string? ContactPerson { get; set; }

        [CanBeNull]
        public virtual string? ContactPhone { get; set; }

        [CanBeNull]
        public virtual string? Email { get; set; }

        public virtual bool? isActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbCompanyBranchBase()
        {

        }

        public TbCompanyBranchBase(int? companyId = null, string? branchName = null, string? branchAddress = null, string? branchCode = null, string? contactPerson = null, string? contactPhone = null, string? email = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            CompanyId = companyId;
            BranchName = branchName;
            BranchAddress = branchAddress;
            BranchCode = branchCode;
            ContactPerson = contactPerson;
            ContactPhone = contactPhone;
            Email = email;
            this.isActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}