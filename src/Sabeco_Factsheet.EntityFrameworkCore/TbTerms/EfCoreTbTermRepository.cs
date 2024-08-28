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

namespace Sabeco_Factsheet.TbTerms
{
    public abstract class EfCoreTbTermRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbTerm, int>
    {
        public EfCoreTbTermRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, branchIdMin, branchIdMax, termCode, fromYearMin, fromYearMax, toYearMin, toYearMax, description);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbTerm>> GetListAsync(
            string? filterText = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, branchIdMin, branchIdMax, termCode, fromYearMin, fromYearMax, toYearMin, toYearMax, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbTermConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, branchIdMin, branchIdMax, termCode, fromYearMin, fromYearMax, toYearMin, toYearMax, description);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbTerm> ApplyFilter(
            IQueryable<TbTerm> query,
            string? filterText = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.TermCode.ToLower().Contains(filterText.ToLower()) || e.Description.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(branchIdMin.HasValue, e => e.BranchId >= branchIdMin!.Value)
                    .WhereIf(branchIdMax.HasValue, e => e.BranchId <= branchIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(termCode), e => e.TermCode.ToLower().Contains(termCode.ToLower()))
                    .WhereIf(fromYearMin.HasValue, e => e.FromYear >= fromYearMin!.Value)
                    .WhereIf(fromYearMax.HasValue, e => e.FromYear <= fromYearMax!.Value)
                    .WhereIf(toYearMin.HasValue, e => e.ToYear >= toYearMin!.Value)
                    .WhereIf(toYearMax.HasValue, e => e.ToYear <= toYearMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.ToLower().Contains(description.ToLower()));
        }
    }
}