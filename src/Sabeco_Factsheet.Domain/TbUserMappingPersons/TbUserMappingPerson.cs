using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonBase : Entity<int>
    {
        public virtual int? userid { get; set; }

        public virtual int? personid { get; set; }

        public virtual bool? IsActive { get; set; }

        protected TbUserMappingPersonBase()
        {

        }

        public TbUserMappingPersonBase(int? userid = null, int? personid = null, bool? isActive = null)
        {

            this.userid = userid;
            this.personid = personid;
            IsActive = isActive;
        }

    }
}