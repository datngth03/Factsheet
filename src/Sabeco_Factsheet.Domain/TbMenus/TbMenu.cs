using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class TbMenuBase : Entity<int>
    {
        [NotNull]
        public virtual string ControlName { get; set; }

        [NotNull]
        public virtual string Description { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbMenuBase()
        {

        }

        public TbMenuBase(string controlName, string description, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.NotNull(controlName, nameof(controlName));
            Check.Length(controlName, nameof(controlName), TbMenuConsts.ControlNameMaxLength, 0);
            Check.NotNull(description, nameof(description));
            Check.Length(description, nameof(description), TbMenuConsts.DescriptionMaxLength, 0);
            ControlName = controlName;
            Description = description;
            IsActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}