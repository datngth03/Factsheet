using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public abstract class TbAdditionInfoTempBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        public virtual DateTime? DocDate { get; set; }

        [CanBeNull]
        public virtual string? TypeOfGroup { get; set; }

        [CanBeNull]
        public virtual string? TypeOfEvent { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        [CanBeNull]
        public virtual string? NoOfDocument { get; set; }

        [CanBeNull]
        public virtual string? Remark { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbAdditionInfoTempBase()
        {

        }

        public TbAdditionInfoTempBase(int companyId, DateTime? docDate = null, string? typeOfGroup = null, string? typeOfEvent = null, string? description = null, string? noOfDocument = null, string? remark = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.Length(typeOfGroup, nameof(typeOfGroup), TbAdditionInfoTempConsts.TypeOfGroupMaxLength, 0);
            CompanyId = companyId;
            DocDate = docDate;
            TypeOfGroup = typeOfGroup;
            TypeOfEvent = typeOfEvent;
            Description = description;
            NoOfDocument = noOfDocument;
            Remark = remark;
            IsActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}