using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public abstract class TbBreweryImageBase : Entity<int>
    {
        public virtual int? CompanyId { get; set; }

        [CanBeNull]
        public virtual string? BreweryImage { get; set; }

        [CanBeNull]
        public virtual string? ImageLink { get; set; }

        public virtual bool? isActive { get; set; }

        public virtual int? create_user { get; set; }

        public virtual DateTime? create_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        protected TbBreweryImageBase()
        {

        }

        public TbBreweryImageBase(int? companyId = null, string? breweryImage = null, string? imageLink = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {

            CompanyId = companyId;
            BreweryImage = breweryImage;
            ImageLink = imageLink;
            this.isActive = isActive;
            this.create_user = create_user;
            this.create_date = create_date;
            this.mod_user = mod_user;
            this.mod_date = mod_date;
        }

    }
}