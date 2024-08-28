using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbUsers
{
    public abstract class TbUserBase : Entity<int>
    {
        [NotNull]
        public virtual string UserPrincipalName { get; set; }

        [NotNull]
        public virtual string UserName { get; set; }

        [NotNull]
        public virtual string FullName { get; set; }

        [CanBeNull]
        public virtual string? Email { get; set; }

        public virtual int? CompanyId { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual Guid? AbpUserId { get; set; }

        protected TbUserBase()
        {

        }

        public TbUserBase(string userPrincipalName, string userName, string fullName, bool isActive, string? email = null, int? companyId = null, byte? docStatus = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, Guid? abpUserId = null)
        {

            Check.NotNull(userPrincipalName, nameof(userPrincipalName));
            Check.Length(userPrincipalName, nameof(userPrincipalName), TbUserConsts.UserPrincipalNameMaxLength, 0);
            Check.NotNull(userName, nameof(userName));
            Check.Length(userName, nameof(userName), TbUserConsts.UserNameMaxLength, 0);
            Check.NotNull(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbUserConsts.FullNameMaxLength, 0);
            Check.Length(email, nameof(email), TbUserConsts.EmailMaxLength, 0);
            UserPrincipalName = userPrincipalName;
            UserName = userName;
            FullName = fullName;
            IsActive = isActive;
            Email = email;
            CompanyId = companyId;
            DocStatus = docStatus;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            AbpUserId = abpUserId;
        }

    }
}