using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public abstract class TbCompanyMappingBase : Entity<int>
    {
        public virtual int? CompanyId { get; set; }

        [CanBeNull]
        public virtual string? CompanyTypeShareholdingCode { get; set; }

        [CanBeNull]
        public virtual string? CompanyTypesCode { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        public virtual DateTime? mod_date { get; set; }

        public virtual int? mod_user { get; set; }

        public virtual int? idCompanyTypeShareholdingCode { get; set; }

        public virtual int? idCompanyTypesCode { get; set; }

        protected TbCompanyMappingBase()
        {

        }

        public TbCompanyMappingBase(int? companyId = null, string? companyTypeShareholdingCode = null, string? companyTypesCode = null, string? note = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? idCompanyTypeShareholdingCode = null, int? idCompanyTypesCode = null)
        {

            CompanyId = companyId;
            CompanyTypeShareholdingCode = companyTypeShareholdingCode;
            CompanyTypesCode = companyTypesCode;
            Note = note;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
            this.mod_date = mod_date;
            this.mod_user = mod_user;
            this.idCompanyTypeShareholdingCode = idCompanyTypeShareholdingCode;
            this.idCompanyTypesCode = idCompanyTypesCode;
        }

    }
}