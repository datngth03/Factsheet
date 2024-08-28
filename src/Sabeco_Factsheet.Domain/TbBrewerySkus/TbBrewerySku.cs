using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public abstract class TbBrewerySkuBase : Entity<int>
    {
        public virtual int? Year { get; set; }

        [CanBeNull]
        public virtual string? BreweryCode { get; set; }

        [CanBeNull]
        public virtual string? SKUCode { get; set; }

        public virtual decimal? ProductionVolume { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual int? BreweryId { get; set; }

        public virtual int? SKUId { get; set; }

        protected TbBrewerySkuBase()
        {

        }

        public TbBrewerySkuBase(int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null)
        {

            Check.Length(breweryCode, nameof(breweryCode), TbBrewerySkuConsts.BreweryCodeMaxLength, 0);
            Check.Length(sKUCode, nameof(sKUCode), TbBrewerySkuConsts.SKUCodeMaxLength, 0);
            Year = year;
            BreweryCode = breweryCode;
            SKUCode = sKUCode;
            ProductionVolume = productionVolume;
            DocStatus = docStatus;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            BreweryId = breweryId;
            SKUId = sKUId;
        }

    }
}