using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public abstract class TbCompanyStockManagerBase : DomainService
    {
        public ITbCompanyStockRepository _tbCompanyStockRepository;

        public TbCompanyStockManagerBase(ITbCompanyStockRepository tbCompanyStockRepository)
        {
            _tbCompanyStockRepository = tbCompanyStockRepository;
        }

        public virtual async Task<TbCompanyStock> CreateAsync(
        int companyId, string companyCode, bool isPublicCompany, bool isActive, string? stockExchange = null, DateTime? registrationDate = null, decimal? charteredCapital = null, decimal? parValue = null, int? totalShare = null, int? listedShare = null, string? description = null, DateTime? crt_date = null, int? crt_user = null)
        {
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyStockConsts.CompanyCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyStockConsts.StockExchangeMaxLength);
            Check.Length(description, nameof(description), TbCompanyStockConsts.DescriptionMaxLength);

            var tbCompanyStock = new TbCompanyStock(

             companyId, companyCode, isPublicCompany, isActive, stockExchange, registrationDate, charteredCapital, parValue, totalShare, listedShare, description, crt_date, crt_user
             );

            return await _tbCompanyStockRepository.InsertAsync(tbCompanyStock);
        }

        public virtual async Task<TbCompanyStock> UpdateAsync(
            int id,
            int companyId, string companyCode, bool isPublicCompany, bool isActive, string? stockExchange = null, DateTime? registrationDate = null, decimal? charteredCapital = null, decimal? parValue = null, int? totalShare = null, int? listedShare = null, string? description = null, DateTime? crt_date = null, int? crt_user = null
        )
        {
            Check.NotNullOrWhiteSpace(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), TbCompanyStockConsts.CompanyCodeMaxLength);
            Check.Length(stockExchange, nameof(stockExchange), TbCompanyStockConsts.StockExchangeMaxLength);
            Check.Length(description, nameof(description), TbCompanyStockConsts.DescriptionMaxLength);

            var tbCompanyStock = await _tbCompanyStockRepository.GetAsync(id);

            tbCompanyStock.CompanyId = companyId;
            tbCompanyStock.CompanyCode = companyCode;
            tbCompanyStock.IsPublicCompany = isPublicCompany;
            tbCompanyStock.IsActive = isActive;
            tbCompanyStock.StockExchange = stockExchange;
            tbCompanyStock.RegistrationDate = registrationDate;
            tbCompanyStock.CharteredCapital = charteredCapital;
            tbCompanyStock.ParValue = parValue;
            tbCompanyStock.TotalShare = totalShare;
            tbCompanyStock.ListedShare = listedShare;
            tbCompanyStock.Description = description;
            tbCompanyStock.crt_date = crt_date;
            tbCompanyStock.crt_user = crt_user;

            return await _tbCompanyStockRepository.UpdateAsync(tbCompanyStock);
        }

    }
}