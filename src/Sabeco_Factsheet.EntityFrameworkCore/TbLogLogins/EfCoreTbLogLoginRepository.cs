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

namespace Sabeco_Factsheet.TbLogLogins
{
    public abstract class EfCoreTbLogLoginRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogLogin, int>
    {
        public EfCoreTbLogLoginRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, userName, loginDateMin, loginDateMax, iPTracking, statusLogin);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogLogin>> GetListAsync(
            string? filterText = null,
            string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userName, loginDateMin, loginDateMax, iPTracking, statusLogin);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogLoginConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userName, loginDateMin, loginDateMax, iPTracking, statusLogin);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogLogin> ApplyFilter(
            IQueryable<TbLogLogin> query,
            string? filterText = null,
            string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserName.ToLower().Contains(filterText.ToLower()) || e.IPTracking.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.ToLower().Contains(userName.ToLower()))
                    .WhereIf(loginDateMin.HasValue, e => e.LoginDate >= loginDateMin!.Value)
                    .WhereIf(loginDateMax.HasValue, e => e.LoginDate <= loginDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(iPTracking), e => e.IPTracking.ToLower().Contains(iPTracking.ToLower()))
                    .WhereIf(statusLogin.HasValue, e => e.StatusLogin == statusLogin);
        }
    }
}