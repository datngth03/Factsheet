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

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class EfCoreTbUserMappingCompanyRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbUserMappingCompany, int>
    {
        public EfCoreTbUserMappingCompanyRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, useridMin, useridMax, companyidMin, companyidMax, isActive);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbUserMappingCompany>> GetListAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, useridMin, useridMax, companyidMin, companyidMax, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserMappingCompanyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, useridMin, useridMax, companyidMin, companyidMax, isActive);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbUserMappingCompany> ApplyFilter(
            IQueryable<TbUserMappingCompany> query,
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(useridMin.HasValue, e => e.userid >= useridMin!.Value)
                    .WhereIf(useridMax.HasValue, e => e.userid <= useridMax!.Value)
                    .WhereIf(companyidMin.HasValue, e => e.companyid >= companyidMin!.Value)
                    .WhereIf(companyidMax.HasValue, e => e.companyid <= companyidMax!.Value)
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }
    }
}