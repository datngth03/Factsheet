using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class TbLogPrintingBase : Entity<int>
    {
        [CanBeNull]
        public virtual string? userName { get; set; }

        [CanBeNull]
        public virtual string? companyCode { get; set; }

        [CanBeNull]
        public virtual string? fileLanguage { get; set; }

        public virtual bool? isPrinting { get; set; }

        public virtual DateTime? printTime { get; set; }

        protected TbLogPrintingBase()
        {

        }

        public TbLogPrintingBase(string? userName = null, string? companyCode = null, string? fileLanguage = null, bool? isPrinting = null, DateTime? printTime = null)
        {

            Check.Length(userName, nameof(userName), TbLogPrintingConsts.userNameMaxLength, 0);
            Check.Length(companyCode, nameof(companyCode), TbLogPrintingConsts.companyCodeMaxLength, 0);
            Check.Length(fileLanguage, nameof(fileLanguage), TbLogPrintingConsts.fileLanguageMaxLength, 0);
            this.userName = userName;
            this.companyCode = companyCode;
            this.fileLanguage = fileLanguage;
            this.isPrinting = isPrinting;
            this.printTime = printTime;
        }

    }
}