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

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class EfCoreTbLogRefeshAccountRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogRefeshAccount, int>
    {
        public EfCoreTbLogRefeshAccountRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, accessToken, timeRefeshMin, timeRefeshMax, isSuccess, useRefesh, failedReason);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogRefeshAccount>> GetListAsync(
            string? filterText = null,
            string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, accessToken, timeRefeshMin, timeRefeshMax, isSuccess, useRefesh, failedReason);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogRefeshAccountConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, accessToken, timeRefeshMin, timeRefeshMax, isSuccess, useRefesh, failedReason);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogRefeshAccount> ApplyFilter(
            IQueryable<TbLogRefeshAccount> query,
            string? filterText = null,
            string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.AccessToken.ToLower().Contains(filterText.ToLower()) || e.UseRefesh.ToLower().Contains(filterText.ToLower()) || e.FailedReason.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(accessToken), e => e.AccessToken.ToLower().Contains(accessToken.ToLower()))
                    .WhereIf(timeRefeshMin.HasValue, e => e.TimeRefesh >= timeRefeshMin!.Value)
                    .WhereIf(timeRefeshMax.HasValue, e => e.TimeRefesh <= timeRefeshMax!.Value)
                    .WhereIf(isSuccess.HasValue, e => e.IsSuccess == isSuccess)
                    .WhereIf(!string.IsNullOrWhiteSpace(useRefesh), e => e.UseRefesh.ToLower().Contains(useRefesh.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(failedReason), e => e.FailedReason.ToLower().Contains(failedReason.ToLower()));
        }
    }
}