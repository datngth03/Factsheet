using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public abstract class TbHisLogPrintingBase : Entity<int>
    {
        public virtual bool? IsSendMail { get; set; }

        public virtual DateTime? DateSendMail { get; set; }

        public virtual int? Type { get; set; }

        public virtual DateTime InsertDate { get; set; }

        [CanBeNull]
        public virtual string? UserName { get; set; }

        [CanBeNull]
        public virtual string? CompanyCode { get; set; }

        [CanBeNull]
        public virtual string? FileLanguage { get; set; }

        public virtual bool? IsPrinting { get; set; }

        protected TbHisLogPrintingBase()
        {

        }

        public TbHisLogPrintingBase(DateTime insertDate, bool? isSendMail = null, DateTime? dateSendMail = null, int? type = null, string? userName = null, string? companyCode = null, string? fileLanguage = null, bool? isPrinting = null)
        {

            Check.Length(userName, nameof(userName), TbHisLogPrintingConsts.UserNameMaxLength, 0);
            Check.Length(companyCode, nameof(companyCode), TbHisLogPrintingConsts.CompanyCodeMaxLength, 0);
            Check.Length(fileLanguage, nameof(fileLanguage), TbHisLogPrintingConsts.FileLanguageMaxLength, 0);
            InsertDate = insertDate;
            IsSendMail = isSendMail;
            DateSendMail = dateSendMail;
            Type = type;
            UserName = userName;
            CompanyCode = companyCode;
            FileLanguage = fileLanguage;
            IsPrinting = isPrinting;
        }

    }
}