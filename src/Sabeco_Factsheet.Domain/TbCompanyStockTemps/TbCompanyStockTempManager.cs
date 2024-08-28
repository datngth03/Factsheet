using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public abstract class TbCompanyStockTempManagerBase : DomainService
    {
        public ITbCompanyStockTempRepository _tbCompanyStockTempRepository;

        public TbCompanyStockTempManagerBase(ITbCompanyStockTempRepository tbCompanyStockTempRepository)
        {
            _tbCompanyStockTempRepository = tbCompanyStockTempRepository;
        }

        public virtual async Task<TbCompanyStockTemp> CreateAsync(
        int companyId, string companyCode, bool isPublicCompany, bool isActive, string? stockExchange = null, DateTime? registrationDate = null, decimal? charteredCapital = null, decimal? parValue = null, int? totalShare = null, int? listedShare = null, string? description = null, DateTime? crt_date = null, int? crt_user = null)
        {
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyStockTempConsts.CompanyCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyStockTempConsts.StockExchangeMaxLength);
            Check.Length(description, nameof(description), TbCompanyStockTempConsts.DescriptionMaxLength);

            var tbCompanyStockTemp = new TbCompanyStockTemp(

             companyId, companyCode, isPublicCompany, isActive, stockExchange, registrationDate, charteredCapital, parValue, totalShare, listedShare, description, crt_date, crt_user
             );

            return await _tbCompanyStockTempRepository.InsertAsync(tbCompanyStockTemp);
        }

        public virtual async Task<TbCompanyStockTemp> UpdateAsync(
            int id,
            int companyId, string companyCode, bool isPublicCompany, bool isActive, string? stockExchange = null, DateTime? registrationDate = null, decimal? charteredCapital = null, decimal? parValue = null, int? totalShare = null, int? listedShare = null, string? description = null, DateTime? crt_date = null, int? crt_user = null
        )
        {
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyStockTempConsts.CompanyCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyStockTempConsts.StockExchangeMaxLength);
            Check.Length(description, nameof(description), TbCompanyStockTempConsts.DescriptionMaxLength);

            var tbCompanyStockTemp = await _tbCompanyStockTempRepository.GetAsync(id);

            tbCompanyStockTemp.CompanyId = companyId;
            tbCompanyStockTemp.CompanyCode = companyCode;
            tbCompanyStockTemp.IsPublicCompany = isPublicCompany;
            tbCompanyStockTemp.IsActive = isActive;
            tbCompanyStockTemp.StockExchange = stockExchange;
            tbCompanyStockTemp.RegistrationDate = registrationDate;
            tbCompanyStockTemp.CharteredCapital = charteredCapital;
            tbCompanyStockTemp.ParValue = parValue;
            tbCompanyStockTemp.TotalShare = totalShare;
            tbCompanyStockTemp.ListedShare = listedShare;
            tbCompanyStockTemp.Description = description;
            tbCompanyStockTemp.crt_date = crt_date;
            tbCompanyStockTemp.crt_user = crt_user;

            return await _tbCompanyStockTempRepository.UpdateAsync(tbCompanyStockTemp);
        }

    }
}