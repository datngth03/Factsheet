using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TsClasses
{
    public abstract class TsClassBase : Entity<int>
    {
        [NotNull]
        public virtual string ParentCode { get; set; }

        [NotNull]
        public virtual string Code { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Name_EN { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        [CanBeNull]
        public virtual string? Code_Type { get; set; }

        protected TsClassBase()
        {

        }

        public TsClassBase(string parentCode, string code, string? name = null, string? name_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? code_Type = null)
        {

            Check.NotNull(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), TsClassConsts.ParentCodeMaxLength, 0);
            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), TsClassConsts.CodeMaxLength, 0);
            Check.Length(name, nameof(name), TsClassConsts.NameMaxLength, 0);
            Check.Length(name_EN, nameof(name_EN), TsClassConsts.Name_ENMaxLength, 0);
            Check.Length(code_Type, nameof(code_Type), TsClassConsts.Code_TypeMaxLength, 0);
            ParentCode = parentCode;
            Code = code;
            Name = name;
            Name_EN = name_EN;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            Code_Type = code_Type;
        }

    }
}