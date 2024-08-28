using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbSkus
{
    public abstract class TbSkuBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? Code { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Name_EN { get; set; }

        [CanBeNull]
        public virtual string? BrandCode { get; set; }

        [CanBeNull]
        public virtual string? Unit { get; set; }

        [CanBeNull]
        public virtual string? ItemBaseType { get; set; }

        public virtual decimal? PackSize { get; set; }

        public virtual int? PackQuantity { get; set; }

        public virtual decimal? Weight { get; set; }

        public virtual int? ExpiryDate { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbSkuBase()
        {

        }

        public TbSkuBase(string? code = null, string? name = null, string? name_EN = null, string? brandCode = null, string? unit = null, string? itemBaseType = null, decimal? packSize = null, int? packQuantity = null, decimal? weight = null, int? expiryDate = null, bool? isActive = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.Length(code, nameof(code), TbSkuConsts.CodeMaxLength, 0);
            Check.Length(name, nameof(name), TbSkuConsts.NameMaxLength, 0);
            Check.Length(name_EN, nameof(name_EN), TbSkuConsts.Name_ENMaxLength, 0);
            Check.Length(brandCode, nameof(brandCode), TbSkuConsts.BrandCodeMaxLength, 0);
            Check.Length(unit, nameof(unit), TbSkuConsts.UnitMaxLength, 0);
            Check.Length(itemBaseType, nameof(itemBaseType), TbSkuConsts.ItemBaseTypeMaxLength, 0);
            Code = code;
            Name = name;
            Name_EN = name_EN;
            BrandCode = brandCode;
            Unit = unit;
            ItemBaseType = itemBaseType;
            PackSize = packSize;
            PackQuantity = packQuantity;
            Weight = weight;
            ExpiryDate = expiryDate;
            IsActive = isActive;
            this.crt_user = crt_user;
            this.crt_date = crt_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}