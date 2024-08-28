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

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class EfCoreTbUserMappingBreweryRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbUserMappingBrewery, int>
    {
        public EfCoreTbUserMappingBreweryRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? useridMin = null,
            int? useridMax = null,
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, useridMin, useridMax, breweryidMin, breweryidMax, isActive);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbUserMappingBrewery>> GetListAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, useridMin, useridMax, breweryidMin, breweryidMax, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserMappingBreweryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, useridMin, useridMax, breweryidMin, breweryidMax, isActive);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbUserMappingBrewery> ApplyFilter(
            IQueryable<TbUserMappingBrewery> query,
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(useridMin.HasValue, e => e.userid >= useridMin!.Value)
                    .WhereIf(useridMax.HasValue, e => e.userid <= useridMax!.Value)
                    .WhereIf(breweryidMin.HasValue, e => e.breweryid >= breweryidMin!.Value)
                    .WhereIf(breweryidMax.HasValue, e => e.breweryid <= breweryidMax!.Value)
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }
    }
}