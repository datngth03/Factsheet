using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public abstract class TbConfigRetirementTimeBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? Code { get; set; }

        public virtual int? YearNumb { get; set; }

        public virtual int? MonthNumb { get; set; }

        public virtual int? DayNumb { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        protected TbConfigRetirementTimeBase()
        {

        }

        public TbConfigRetirementTimeBase(string? code = null, int? yearNumb = null, int? monthNumb = null, int? dayNumb = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Code = code;
            YearNumb = yearNumb;
            MonthNumb = monthNumb;
            DayNumb = dayNumb;
            Note = note;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}