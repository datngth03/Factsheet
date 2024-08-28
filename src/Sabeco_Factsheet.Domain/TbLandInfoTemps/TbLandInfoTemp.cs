using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public abstract class TbLandInfoTempBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        [CanBeNull]
        public virtual string? Address { get; set; }

        [NotNull]
        public virtual string TypeOfLand { get; set; }

        public virtual decimal? Area { get; set; }

        [CanBeNull]
        public virtual string? SupportingDocument { get; set; }

        public virtual DateTime? IssueDate { get; set; }

        public virtual DateTime? ExpiryDate { get; set; }

        [CanBeNull]
        public virtual string? Payment { get; set; }

        [CanBeNull]
        public virtual string? Remark { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbLandInfoTempBase()
        {

        }

        public TbLandInfoTempBase(int companyId, string typeOfLand, string? description = null, string? address = null, decimal? area = null, string? supportingDocument = null, DateTime? issueDate = null, DateTime? expiryDate = null, string? payment = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.NotNull(typeOfLand, nameof(typeOfLand));
            CompanyId = companyId;
            TypeOfLand = typeOfLand;
            Description = description;
            Address = address;
            Area = area;
            SupportingDocument = supportingDocument;
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
            Payment = payment;
            Remark = remark;
            IsActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}