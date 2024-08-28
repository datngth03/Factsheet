using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class TbBranchBase : Entity<int>
    {
        [NotNull]
        public virtual string Code { get; set; }

        [CanBeNull]
        public virtual string? BriefName { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Name_EN { get; set; }

        [CanBeNull]
        public virtual string? CompanyCode { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? Crt_Date { get; set; }

        protected TbBranchBase()
        {

        }

        public TbBranchBase(string code, string name, bool isActive, string? briefName = null, string? name_EN = null, string? companyCode = null, string? description = null, DateTime? crt_Date = null)
        {

            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), TbBranchConsts.CodeMaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), TbBranchConsts.NameMaxLength, 0);
            Check.Length(briefName, nameof(briefName), TbBranchConsts.BriefNameMaxLength, 0);
            Check.Length(name_EN, nameof(name_EN), TbBranchConsts.Name_ENMaxLength, 0);
            Check.Length(companyCode, nameof(companyCode), TbBranchConsts.CompanyCodeMaxLength, 0);
            Check.Length(description, nameof(description), TbBranchConsts.DescriptionMaxLength, 0);
            Code = code;
            Name = name;
            IsActive = isActive;
            BriefName = briefName;
            Name_EN = name_EN;
            CompanyCode = companyCode;
            Description = description;
            Crt_Date = crt_Date;
        }

    }
}