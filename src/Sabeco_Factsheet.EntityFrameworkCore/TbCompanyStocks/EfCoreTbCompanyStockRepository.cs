using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Sabeco_Factsheet.EntityFrameworkCore;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public abstract class EfCoreTbCompanyStockRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyStock, int>
    {
        public EfCoreTbCompanyStockRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, companyCode, isPublicCompany, stockExchange, registrationDateMin, registrationDateMax, charteredCapitalMin, charteredCapitalMax, parValueMin, parValueMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, description, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyStock>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, companyCode, isPublicCompany, stockExchange, registrationDateMin, registrationDateMax, charteredCapitalMin, charteredCapitalMax, parValueMin, parValueMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, description, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyStockConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, companyCode, isPublicCompany, stockExchange, registrationDateMin, registrationDateMax, charteredCapitalMin, charteredCapitalMax, parValueMin, parValueMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, description, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyStock> ApplyFilter(
            IQueryable<TbCompanyStock> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CompanyCode.ToLower().Contains(filterText.ToLower()) || e.StockExchange.ToLower().Contains(filterText.ToLower()) || e.Description.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.CompanyCode.ToLower().Contains(companyCode.ToLower()))
                    .WhereIf(isPublicCompany.HasValue, e => e.IsPublicCompany == isPublicCompany)
                    .WhereIf(!string.IsNullOrWhiteSpace(stockExchange), e => e.StockExchange.ToLower().Contains(stockExchange.ToLower()))
                    .WhereIf(registrationDateMin.HasValue, e => e.RegistrationDate >= registrationDateMin!.Value)
                    .WhereIf(registrationDateMax.HasValue, e => e.RegistrationDate <= registrationDateMax!.Value)
                    .WhereIf(charteredCapitalMin.HasValue, e => e.CharteredCapital >= charteredCapitalMin!.Value)
                    .WhereIf(charteredCapitalMax.HasValue, e => e.CharteredCapital <= charteredCapitalMax!.Value)
                    .WhereIf(parValueMin.HasValue, e => e.ParValue >= parValueMin!.Value)
                    .WhereIf(parValueMax.HasValue, e => e.ParValue <= parValueMax!.Value)
                    .WhereIf(totalShareMin.HasValue, e => e.TotalShare >= totalShareMin!.Value)
                    .WhereIf(totalShareMax.HasValue, e => e.TotalShare <= totalShareMax!.Value)
                    .WhereIf(listedShareMin.HasValue, e => e.ListedShare >= listedShareMin!.Value)
                    .WhereIf(listedShareMax.HasValue, e => e.ListedShare <= listedShareMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.ToLower().Contains(description.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value);
        }
    }
}