using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class TbLogSendEmailRetirementBase : Entity<int>
    {
        public virtual int? idCompany { get; set; }

        public virtual int? idPerson { get; set; }

        public virtual bool? IsSendEmail { get; set; }

        public virtual DateTime? DateSendEmail { get; set; }

        public virtual int? Type { get; set; }

        protected TbLogSendEmailRetirementBase()
        {

        }

        public TbLogSendEmailRetirementBase(int? idCompany = null, int? idPerson = null, bool? isSendEmail = null, DateTime? dateSendEmail = null, int? type = null)
        {

            this.idCompany = idCompany;
            this.idPerson = idPerson;
            IsSendEmail = isSendEmail;
            DateSendEmail = dateSendEmail;
            Type = type;
        }

    }
}