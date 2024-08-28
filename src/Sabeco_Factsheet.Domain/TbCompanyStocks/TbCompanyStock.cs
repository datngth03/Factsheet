using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public abstract class TbCompanyStockBase : Entity<int>
    {
        public virtual int CompanyId { get; set; }

        [NotNull]
        public virtual string CompanyCode { get; set; }

        public virtual bool IsPublicCompany { get; set; }

        [CanBeNull]
        public virtual string? StockExchange { get; set; }

        public virtual DateTime? RegistrationDate { get; set; }

        public virtual decimal? CharteredCapital { get; set; }

        public virtual decimal? ParValue { get; set; }

        public virtual int? TotalShare { get; set; }

        public virtual int? ListedShare { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        protected TbCompanyStockBase()
        {

        }

        public TbCompanyStockBase(int companyId, string companyCode, bool isPublicCompany, bool isActive, string? stockExchange = null, DateTime? registrationDate = null, decimal? charteredCapital = null, decimal? parValue = null, int? totalShare = null, int? listedShare = null, string? description = null, DateTime? crt_date = null, int? crt_user = null)
        {

            Check.NotNull(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyStockConsts.CompanyCodeMaxLength, 0);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyStockConsts.StockExchangeMaxLength, 0);
            Check.Length(description, nameof(description), TbCompanyStockConsts.DescriptionMaxLength, 0);
            CompanyId = companyId;
            CompanyCode = companyCode;
            IsPublicCompany = isPublicCompany;
            IsActive = isActive;
            StockExchange = stockExchange;
            RegistrationDate = registrationDate;
            CharteredCapital = charteredCapital;
            ParValue = parValue;
            TotalShare = totalShare;
            ListedShare = listedShare;
            Description = description;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
        }

    }
}