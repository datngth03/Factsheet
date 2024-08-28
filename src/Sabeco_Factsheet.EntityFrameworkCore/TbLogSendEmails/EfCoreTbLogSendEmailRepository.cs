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

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class EfCoreTbLogSendEmailRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogSendEmail, int>
    {
        public EfCoreTbLogSendEmailRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, timeSendMin, timeSendMax, isSuccess, userSend, typeEmail, failedReason);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogSendEmail>> GetListAsync(
            string? filterText = null,
            DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeSendMin, timeSendMax, isSuccess, userSend, typeEmail, failedReason);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogSendEmailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, timeSendMin, timeSendMax, isSuccess, userSend, typeEmail, failedReason);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogSendEmail> ApplyFilter(
            IQueryable<TbLogSendEmail> query,
            string? filterText = null,
            DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserSend.ToLower().Contains(filterText.ToLower()) || e.TypeEmail.ToLower().Contains(filterText.ToLower()) || e.FailedReason.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(timeSendMin.HasValue, e => e.TimeSend >= timeSendMin!.Value)
                    .WhereIf(timeSendMax.HasValue, e => e.TimeSend <= timeSendMax!.Value)
                    .WhereIf(isSuccess.HasValue, e => e.IsSuccess == isSuccess)
                    .WhereIf(!string.IsNullOrWhiteSpace(userSend), e => e.UserSend.ToLower().Contains(userSend.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(typeEmail), e => e.TypeEmail.ToLower().Contains(typeEmail.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(failedReason), e => e.FailedReason.ToLower().Contains(failedReason.ToLower()));
        }
    }
}