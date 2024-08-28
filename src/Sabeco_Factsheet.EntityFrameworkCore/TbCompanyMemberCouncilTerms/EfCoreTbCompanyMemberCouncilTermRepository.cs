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

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class EfCoreTbCompanyMemberCouncilTermRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyMemberCouncilTerm, int>
    {
        public EfCoreTbCompanyMemberCouncilTermRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, termFromMin, termFromMax, termEndMin, termEndMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyMemberCouncilTerm>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, termFromMin, termFromMax, termEndMin, termEndMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyMemberCouncilTermConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, termFromMin, termFromMax, termEndMin, termEndMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyMemberCouncilTerm> ApplyFilter(
            IQueryable<TbCompanyMemberCouncilTerm> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(termFromMin.HasValue, e => e.TermFrom >= termFromMin!.Value)
                    .WhereIf(termFromMax.HasValue, e => e.TermFrom <= termFromMax!.Value)
                    .WhereIf(termEndMin.HasValue, e => e.TermEnd >= termEndMin!.Value)
                    .WhereIf(termEndMax.HasValue, e => e.TermEnd <= termEndMax!.Value);
        }
    }
}