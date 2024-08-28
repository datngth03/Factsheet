using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweryBase : Entity<int>
    {
        public virtual int? userid { get; set; }

        public virtual int? breweryid { get; set; }

        public virtual bool? IsActive { get; set; }

        protected TbUserMappingBreweryBase()
        {

        }

        public TbUserMappingBreweryBase(int? userid = null, int? breweryid = null, bool? isActive = null)
        {

            this.userid = userid;
            this.breweryid = breweryid;
            IsActive = isActive;
        }

    }
}