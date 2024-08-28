using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public abstract class TbLogSyncUatBase : Entity<int>
    {
        public virtual DateTime TimeExport { get; set; }

        public virtual bool IsSuccess { get; set; }

        public virtual int UserExport { get; set; }

        [CanBeNull]
        public virtual string? ReasonExportFailed { get; set; }

        protected TbLogSyncUatBase()
        {

        }

        public TbLogSyncUatBase(DateTime timeExport, bool isSuccess, int userExport, string? reasonExportFailed = null)
        {

            TimeExport = timeExport;
            IsSuccess = isSuccess;
            UserExport = userExport;
            ReasonExportFailed = reasonExportFailed;
        }

    }
}