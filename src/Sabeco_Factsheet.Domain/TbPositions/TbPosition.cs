using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class TbPositionBase : Entity<int>
    {
        [NotNull]
        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string Name_EN { get; set; }

        public virtual byte? PositionType { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? ctr_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? OrderNumb { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbPositionBase()
        {

        }

        public TbPositionBase(string code, string name, string name_EN, bool isActive, bool isDeleted, byte? positionType = null, int? crt_user = null, DateTime? ctr_date = null, int? mod_user = null, DateTime? mod_date = null, int? orderNumb = null)
        {

            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), TbPositionConsts.CodeMaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), TbPositionConsts.NameMaxLength, 0);
            Check.NotNull(name_EN, nameof(name_EN));
            Check.Length(name_EN, nameof(name_EN), TbPositionConsts.Name_ENMaxLength, 0);
            Code = code;
            Name = name;
            Name_EN = name_EN;
            IsActive = isActive;
            IsDeleted = isDeleted;
            PositionType = positionType;
            this.crt_user = crt_user;
            this.ctr_date = ctr_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
            OrderNumb = orderNumb;
        }

    }
}