using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbFileUploads
{
    public abstract class TbFileUploadBase : Entity<int>
    {
        public virtual int? companyId { get; set; }

        public virtual int? personId { get; set; }

        [CanBeNull]
        public virtual string? fileName { get; set; }

        [CanBeNull]
        public virtual string? fullFileName { get; set; }

        [CanBeNull]
        public virtual string? fileLink { get; set; }

        public virtual DateTime? uploadDate { get; set; }

        public virtual int? UserUpload { get; set; }

        [CanBeNull]
        public virtual string? note { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual int DownloadCount { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        protected TbFileUploadBase()
        {

        }

        public TbFileUploadBase(int downloadCount, int? companyId = null, int? personId = null, string? fileName = null, string? fullFileName = null, string? fileLink = null, DateTime? uploadDate = null, int? userUpload = null, string? note = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            DownloadCount = downloadCount;
            this.companyId = companyId;
            this.personId = personId;
            this.fileName = fileName;
            this.fullFileName = fullFileName;
            this.fileLink = fileLink;
            this.uploadDate = uploadDate;
            UserUpload = userUpload;
            this.note = note;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
        }

    }
}