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

namespace Sabeco_Factsheet.TbLogErrors
{
    public abstract class EfCoreTbLogErrorRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogError, int>
    {
        public EfCoreTbLogErrorRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, timeLogMin, timeLogMax, userLogMin, userLogMax, iPAddress, classLog, functionLog, reasonFailed);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogError>> GetListAsync(
            string? filterText = null,
            DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeLogMin, timeLogMax, userLogMin, userLogMax, iPAddress, classLog, functionLog, reasonFailed);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogErrorConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, timeLogMin, timeLogMax, userLogMin, userLogMax, iPAddress, classLog, functionLog, reasonFailed);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogError> ApplyFilter(
            IQueryable<TbLogError> query,
            string? filterText = null,
            DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.IPAddress.ToLower().Contains(filterText.ToLower()) || e.ClassLog.ToLower().Contains(filterText.ToLower()) || e.FunctionLog.ToLower().Contains(filterText.ToLower()) || e.ReasonFailed.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(timeLogMin.HasValue, e => e.TimeLog >= timeLogMin!.Value)
                    .WhereIf(timeLogMax.HasValue, e => e.TimeLog <= timeLogMax!.Value)
                    .WhereIf(userLogMin.HasValue, e => e.UserLog >= userLogMin!.Value)
                    .WhereIf(userLogMax.HasValue, e => e.UserLog <= userLogMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(iPAddress), e => e.IPAddress.ToLower().Contains(iPAddress.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(classLog), e => e.ClassLog.ToLower().Contains(classLog.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(functionLog), e => e.FunctionLog.ToLower().Contains(functionLog.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(reasonFailed), e => e.ReasonFailed.ToLower().Contains(reasonFailed.ToLower()));
        }
    }
}