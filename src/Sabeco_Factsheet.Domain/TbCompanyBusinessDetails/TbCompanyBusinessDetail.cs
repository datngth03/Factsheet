using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public abstract class TbCompanyBusinessDetailBase : Entity<int>
    {
        public virtual int ParentId { get; set; }

        [NotNull]
        public virtual string RegistrationCode { get; set; }

        [CanBeNull]
        public virtual string? RegistrationName { get; set; }

        [CanBeNull]
        public virtual string? RegistrationName_EN { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        protected TbCompanyBusinessDetailBase()
        {

        }

        public TbCompanyBusinessDetailBase(int parentId, string registrationCode, string? registrationName = null, string? registrationName_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            Check.NotNull(registrationCode, nameof(registrationCode));
            Check.Length(registrationCode, nameof(registrationCode), TbCompanyBusinessDetailConsts.RegistrationCodeMaxLength, 0);
            Check.Length(registrationName, nameof(registrationName), TbCompanyBusinessDetailConsts.RegistrationNameMaxLength, 0);
            Check.Length(registrationName_EN, nameof(registrationName_EN), TbCompanyBusinessDetailConsts.RegistrationName_ENMaxLength, 0);
            ParentId = parentId;
            RegistrationCode = registrationCode;
            RegistrationName = registrationName;
            RegistrationName_EN = registrationName_EN;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}