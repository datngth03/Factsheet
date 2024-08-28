using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbBreweryTemps
{
    public abstract class TbBreweryTempBase : Entity<int>
    {
        public virtual int idBrewery { get; set; }

        [NotNull]
        public virtual string BreweryCode { get; set; }

        [NotNull]
        public virtual string BreweryName { get; set; }

        [CanBeNull]
        public virtual string? BreweryName_EN { get; set; }

        [CanBeNull]
        public virtual string? BriefName { get; set; }

        [CanBeNull]
        public virtual string? BreweryAdress { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual decimal? CapacityVolume { get; set; }

        public virtual decimal? DeliveryVolume { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool? isActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbBreweryTempBase()
        {

        }

        public TbBreweryTempBase(int idBrewery, string breweryCode, string breweryName, int companyId, string? breweryName_EN = null, string? briefName = null, string? breweryAdress = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.NotNull(breweryCode, nameof(breweryCode));
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryTempConsts.BreweryCodeMaxLength, 0);
            Check.NotNull(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbBreweryTempConsts.BreweryNameMaxLength, 0);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbBreweryTempConsts.BreweryName_ENMaxLength, 0);
            this.idBrewery = idBrewery;
            BreweryCode = breweryCode;
            BreweryName = breweryName;
            CompanyId = companyId;
            BreweryName_EN = breweryName_EN;
            BriefName = briefName;
            BreweryAdress = breweryAdress;
            CapacityVolume = capacityVolume;
            DeliveryVolume = deliveryVolume;
            Note = note;
            DocStatus = docStatus;
            this.isActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}