using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public abstract class TbHisBreweryDeliveryVolumeBase : Entity<int>
    {
        public virtual bool? IsSendMail { get; set; }

        public virtual DateTime? DateSendMail { get; set; }

        public virtual DateTime? InsertDate { get; set; }

        public virtual int Type { get; set; }

        public virtual int IdBreweryDeliveryVolume { get; set; }

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

        protected TbHisBreweryDeliveryVolumeBase()
        {

        }

        public TbHisBreweryDeliveryVolumeBase(int type, int idBreweryDeliveryVolume, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.Length(breweryCode, nameof(breweryCode), TbHisBreweryDeliveryVolumeConsts.BreweryCodeMaxLength, 0);
            Type = type;
            IdBreweryDeliveryVolume = idBreweryDeliveryVolume;
            IsSendMail = isSendMail;
            DateSendMail = dateSendMail;
            InsertDate = insertDate;
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