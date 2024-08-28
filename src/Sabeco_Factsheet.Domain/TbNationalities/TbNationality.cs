using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbNationalities
{
    public abstract class TbNationalityBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? Code { get; set; }

        [CanBeNull]
        public virtual string? Code2 { get; set; }

        [CanBeNull]
        public virtual string? Name_en { get; set; }

        [CanBeNull]
        public virtual string? Name_vn { get; set; }

        public virtual bool? IsActive { get; set; }

        protected TbNationalityBase()
        {

        }

        public TbNationalityBase(string? code = null, string? code2 = null, string? name_en = null, string? name_vn = null, bool? isActive = null)
        {

            Check.Length(code, nameof(code), TbNationalityConsts.CodeMaxLength, 0);
            Check.Length(code2, nameof(code2), TbNationalityConsts.Code2MaxLength, 0);
            Check.Length(name_en, nameof(name_en), TbNationalityConsts.Name_enMaxLength, 0);
            Check.Length(name_vn, nameof(name_vn), TbNationalityConsts.Name_vnMaxLength, 0);
            Code = code;
            Code2 = code2;
            Name_en = name_en;
            Name_vn = name_vn;
            IsActive = isActive;
        }

    }
}