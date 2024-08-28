using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbRoles
{
    public abstract class TbRoleBase : Entity<int>
    {
        [NotNull]
        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        protected TbRoleBase()
        {

        }

        public TbRoleBase(string code, string name, string? description = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), TbRoleConsts.CodeMaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), TbRoleConsts.NameMaxLength, 0);
            Check.Length(description, nameof(description), TbRoleConsts.DescriptionMaxLength, 0);
            Code = code;
            Name = name;
            Description = description;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}