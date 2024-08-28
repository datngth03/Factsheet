using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public abstract class TbBreweryDeliveryVolumeTempBase : Entity<int>
    {
        public virtual int? idBreweryDeliveryVolume { get; set; }

        public virtual int? BreweryId { get; set; }

        [CanBeNull]
        public virtual string? BreweryCode { get; set; }

        public virtual int? Year { get; set; }

        public virtual decimal? DeliveryVolume { get; set; }

        public virtual bool? isActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbBreweryDeliveryVolumeTempBase()
        {

        }

        public TbBreweryDeliveryVolumeTempBase(int? idBreweryDeliveryVolume = null, int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.Length(breweryCode, nameof(breweryCode), TbBreweryDeliveryVolumeTempConsts.BreweryCodeMaxLength, 0);
            this.idBreweryDeliveryVolume = idBreweryDeliveryVolume;
            BreweryId = breweryId;
            BreweryCode = breweryCode;
            Year = year;
            DeliveryVolume = deliveryVolume;
            this.isActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}