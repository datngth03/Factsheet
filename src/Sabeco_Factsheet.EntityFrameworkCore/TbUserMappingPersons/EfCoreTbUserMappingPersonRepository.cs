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

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class EfCoreTbUserMappingPersonRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbUserMappingPerson, int>
    {
        public EfCoreTbUserMappingPersonRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? useridMin = null,
            int? useridMax = null,
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, useridMin, useridMax, personidMin, personidMax, isActive);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbUserMappingPerson>> GetListAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, useridMin, useridMax, personidMin, personidMax, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserMappingPersonConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, useridMin, useridMax, personidMin, personidMax, isActive);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbUserMappingPerson> ApplyFilter(
            IQueryable<TbUserMappingPerson> query,
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(useridMin.HasValue, e => e.userid >= useridMin!.Value)
                    .WhereIf(useridMax.HasValue, e => e.userid <= useridMax!.Value)
                    .WhereIf(personidMin.HasValue, e => e.personid >= personidMin!.Value)
                    .WhereIf(personidMax.HasValue, e => e.personid <= personidMax!.Value)
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }
    }
}