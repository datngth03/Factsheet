using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public abstract class TbLogExportDataBase : Entity<int>
    {
        public virtual DateTime TimeExport { get; set; }

        public virtual bool IsSuccess { get; set; }

        public virtual int UserExport { get; set; }

        [CanBeNull]
        public virtual string? TableName { get; set; }

        [CanBeNull]
        public virtual string? ReasonExportFailed { get; set; }

        protected TbLogExportDataBase()
        {

        }

        public TbLogExportDataBase(DateTime timeExport, bool isSuccess, int userExport, string? tableName = null, string? reasonExportFailed = null)
        {

            TimeExport = timeExport;
            IsSuccess = isSuccess;
            UserExport = userExport;
            TableName = tableName;
            ReasonExportFailed = reasonExportFailed;
        }

    }
}