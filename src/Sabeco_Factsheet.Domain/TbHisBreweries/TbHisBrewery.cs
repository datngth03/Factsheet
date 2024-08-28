using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public abstract class TbHisBreweryBase : Entity<int>
    {
        public virtual bool? IsSendMail { get; set; }

        public virtual DateTime? DateSendMail { get; set; }

        public virtual DateTime InsertDate { get; set; }

        public virtual int Type { get; set; }

        public virtual int IdBrewery { get; set; }

        [NotNull]
        public virtual string BreweryName { get; set; }

        [CanBeNull]
        public virtual string? BreweryName_EN { get; set; }

        [CanBeNull]
        public virtual string? BreweryAdress { get; set; }

        [CanBeNull]
        public virtual string? BriefName { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual decimal? CapacityVolume { get; set; }

        public virtual decimal? DeliveryVolume { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbHisBreweryBase()
        {

        }

        public TbHisBreweryBase(DateTime insertDate, int type, int idBrewery, string breweryName, int companyId, bool? isSendMail = null, DateTime? dateSendMail = null, string? breweryName_EN = null, string? breweryAdress = null, string? briefName = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.NotNull(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbHisBreweryConsts.BreweryNameMaxLength, 0);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbHisBreweryConsts.BreweryName_ENMaxLength, 0);
            InsertDate = insertDate;
            Type = type;
            IdBrewery = idBrewery;
            BreweryName = breweryName;
            CompanyId = companyId;
            IsSendMail = isSendMail;
            DateSendMail = dateSendMail;
            BreweryName_EN = breweryName_EN;
            BreweryAdress = breweryAdress;
            BriefName = briefName;
            CapacityVolume = capacityVolume;
            DeliveryVolume = deliveryVolume;
            Note = note;
            DocStatus = docStatus;
            IsActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}