using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class TbLogRefeshAccountBase : Entity<int>
    {
        [NotNull]
        public virtual string AccessToken { get; set; }

        public virtual DateTime TimeRefesh { get; set; }

        public virtual bool IsSuccess { get; set; }

        [CanBeNull]
        public virtual string? UseRefesh { get; set; }

        [CanBeNull]
        public virtual string? FailedReason { get; set; }

        protected TbLogRefeshAccountBase()
        {

        }

        public TbLogRefeshAccountBase(string accessToken, DateTime timeRefesh, bool isSuccess, string? useRefesh = null, string? failedReason = null)
        {

            Check.NotNull(accessToken, nameof(accessToken));
            AccessToken = accessToken;
            TimeRefesh = timeRefesh;
            IsSuccess = isSuccess;
            UseRefesh = useRefesh;
            FailedReason = failedReason;
        }

    }
}