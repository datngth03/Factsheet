using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class TbLogLoginBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? UserName { get; set; }

        public virtual DateTime? LoginDate { get; set; }

        [NotNull]
        public virtual string IPTracking { get; set; }

        public virtual bool? StatusLogin { get; set; }

        protected TbLogLoginBase()
        {

        }

        public TbLogLoginBase(string iPTracking, string? userName = null, DateTime? loginDate = null, bool? statusLogin = null)
        {

            Check.NotNull(iPTracking, nameof(iPTracking));
            IPTracking = iPTracking;
            UserName = userName;
            LoginDate = loginDate;
            StatusLogin = statusLogin;
        }

    }
}