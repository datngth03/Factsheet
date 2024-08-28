using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbContactTemps
{
    public abstract class TbContactTempBase : Entity<int>
    {
        public virtual int companyid { get; set; }

        [NotNull]
        public virtual string ContactName { get; set; }

        [CanBeNull]
        public virtual string? ContactDept { get; set; }

        [CanBeNull]
        public virtual string? ContactPosition { get; set; }

        [CanBeNull]
        public virtual string? ContactEmail { get; set; }

        [CanBeNull]
        public virtual string? ContactPhone { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual byte? DocStatus { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual bool IsDeleted { get; set; }

        protected TbContactTempBase()
        {

        }

        public TbContactTempBase(int companyid, string contactName, bool isActive, bool isDeleted, string? contactDept = null, string? contactPosition = null, string? contactEmail = null, string? contactPhone = null, string? note = null, byte? docStatus = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            Check.NotNull(contactName, nameof(contactName));
            Check.Length(contactName, nameof(contactName), TbContactTempConsts.ContactNameMaxLength, 0);
            Check.Length(contactDept, nameof(contactDept), TbContactTempConsts.ContactDeptMaxLength, 0);
            Check.Length(contactPosition, nameof(contactPosition), TbContactTempConsts.ContactPositionMaxLength, 0);
            Check.Length(contactEmail, nameof(contactEmail), TbContactTempConsts.ContactEmailMaxLength, 0);
            Check.Length(contactPhone, nameof(contactPhone), TbContactTempConsts.ContactPhoneMaxLength, 0);
            Check.Length(note, nameof(note), TbContactTempConsts.NoteMaxLength, 0);
            this.companyid = companyid;
            ContactName = contactName;
            IsActive = isActive;
            IsDeleted = isDeleted;
            ContactDept = contactDept;
            ContactPosition = contactPosition;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            Note = note;
            DocStatus = docStatus;
            this.crt_user = crt_user;
            this.crt_date = crt_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}