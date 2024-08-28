using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public abstract class TbTimeScriptBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? Code { get; set; }

        public virtual int? Year { get; set; }

        public virtual int? Month { get; set; }

        public virtual int? Day { get; set; }

        public virtual int? Hour { get; set; }

        public virtual int? Minute { get; set; }

        public virtual int? Second { get; set; }

        protected TbTimeScriptBase()
        {

        }

        public TbTimeScriptBase(string? code = null, int? year = null, int? month = null, int? day = null, int? hour = null, int? minute = null, int? second = null)
        {

            Check.Length(code, nameof(code), TbTimeScriptConsts.CodeMaxLength, 0);
            Code = code;
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

    }
}