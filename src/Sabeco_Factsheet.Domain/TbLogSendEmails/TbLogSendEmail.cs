using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class TbLogSendEmailBase : Entity<int>
    {
        public virtual DateTime TimeSend { get; set; }

        public virtual bool IsSuccess { get; set; }

        [CanBeNull]
        public virtual string? UserSend { get; set; }

        [CanBeNull]
        public virtual string? TypeEmail { get; set; }

        [CanBeNull]
        public virtual string? FailedReason { get; set; }

        protected TbLogSendEmailBase()
        {

        }

        public TbLogSendEmailBase(DateTime timeSend, bool isSuccess, string? userSend = null, string? typeEmail = null, string? failedReason = null)
        {

            TimeSend = timeSend;
            IsSuccess = isSuccess;
            UserSend = userSend;
            TypeEmail = typeEmail;
            FailedReason = failedReason;
        }

    }
}