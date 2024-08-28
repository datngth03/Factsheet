using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogErrors
{
    public abstract class TbLogErrorBase : Entity<int>
    {
        public virtual DateTime TimeLog { get; set; }

        public virtual int UserLog { get; set; }

        [CanBeNull]
        public virtual string? IPAddress { get; set; }

        [CanBeNull]
        public virtual string? ClassLog { get; set; }

        [NotNull]
        public virtual string FunctionLog { get; set; }

        [NotNull]
        public virtual string ReasonFailed { get; set; }

        protected TbLogErrorBase()
        {

        }

        public TbLogErrorBase(DateTime timeLog, int userLog, string functionLog, string reasonFailed, string? iPAddress = null, string? classLog = null)
        {

            Check.NotNull(functionLog, nameof(functionLog));
            Check.NotNull(reasonFailed, nameof(reasonFailed));
            TimeLog = timeLog;
            UserLog = userLog;
            FunctionLog = functionLog;
            ReasonFailed = reasonFailed;
            IPAddress = iPAddress;
            ClassLog = classLog;
        }

    }
}