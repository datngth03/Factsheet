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

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public abstract class EfCoreTbInfoUpdateRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbInfoUpdate, int>
    {
        public EfCoreTbInfoUpdateRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? tableName = null,
            string? columnName = null,
            string? screenName = null,
            int? screenIdMin = null,
            int? screenIdMax = null,
            int? rowIdMin = null,
            int? rowIdMax = null,
            string? command = null,
            string? groupName = null,
            string? lastValue = null,
            string? newValue = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            string? comment = null,
            int? isActiveMin = null,
            int? isActiveMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            Guid? changeSetId = null,
            DateTime? timeAssessmentMin = null,
            DateTime? timeAssessmentMax = null,
            bool? isVisible = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, tableName, columnName, screenName, screenIdMin, screenIdMax, rowIdMin, rowIdMax, command, groupName, lastValue, newValue, docStatusMin, docStatusMax, comment, isActiveMin, isActiveMax, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, changeSetId, timeAssessmentMin, timeAssessmentMax, isVisible);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbInfoUpdate>> GetListAsync(
            string? filterText = null,
            string? tableName = null,
            string? columnName = null,
            string? screenName = null,
            int? screenIdMin = null,
            int? screenIdMax = null,
            int? rowIdMin = null,
            int? rowIdMax = null,
            string? command = null,
            string? groupName = null,
            string? lastValue = null,
            string? newValue = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            string? comment = null,
            int? isActiveMin = null,
            int? isActiveMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            Guid? changeSetId = null,
            DateTime? timeAssessmentMin = null,
            DateTime? timeAssessmentMax = null,
            bool? isVisible = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, tableName, columnName, screenName, screenIdMin, screenIdMax, rowIdMin, rowIdMax, command, groupName, lastValue, newValue, docStatusMin, docStatusMax, comment, isActiveMin, isActiveMax, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, changeSetId, timeAssessmentMin, timeAssessmentMax, isVisible);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbInfoUpdateConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? tableName = null,
            string? columnName = null,
            string? screenName = null,
            int? screenIdMin = null,
            int? screenIdMax = null,
            int? rowIdMin = null,
            int? rowIdMax = null,
            string? command = null,
            string? groupName = null,
            string? lastValue = null,
            string? newValue = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            string? comment = null,
            int? isActiveMin = null,
            int? isActiveMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            Guid? changeSetId = null,
            DateTime? timeAssessmentMin = null,
            DateTime? timeAssessmentMax = null,
            bool? isVisible = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, tableName, columnName, screenName, screenIdMin, screenIdMax, rowIdMin, rowIdMax, command, groupName, lastValue, newValue, docStatusMin, docStatusMax, comment, isActiveMin, isActiveMax, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, changeSetId, timeAssessmentMin, timeAssessmentMax, isVisible);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbInfoUpdate> ApplyFilter(
            IQueryable<TbInfoUpdate> query,
            string? filterText = null,
            string? tableName = null,
            string? columnName = null,
            string? screenName = null,
            int? screenIdMin = null,
            int? screenIdMax = null,
            int? rowIdMin = null,
            int? rowIdMax = null,
            string? command = null,
            string? groupName = null,
            string? lastValue = null,
            string? newValue = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            string? comment = null,
            int? isActiveMin = null,
            int? isActiveMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            Guid? changeSetId = null,
            DateTime? timeAssessmentMin = null,
            DateTime? timeAssessmentMax = null,
            bool? isVisible = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.TableName.ToLower().Contains(filterText.ToLower()) || e.ColumnName.ToLower().Contains(filterText.ToLower()) || e.ScreenName.ToLower().Contains(filterText.ToLower()) || e.Command.ToLower().Contains(filterText.ToLower()) || e.GroupName.ToLower().Contains(filterText.ToLower()) || e.LastValue.ToLower().Contains(filterText.ToLower()) || e.NewValue.ToLower().Contains(filterText.ToLower()) || e.Comment.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(tableName), e => e.TableName.ToLower().Contains(tableName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(columnName), e => e.ColumnName.ToLower().Contains(columnName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(screenName), e => e.ScreenName.ToLower().Contains(screenName.ToLower()))
                    .WhereIf(screenIdMin.HasValue, e => e.ScreenId >= screenIdMin!.Value)
                    .WhereIf(screenIdMax.HasValue, e => e.ScreenId <= screenIdMax!.Value)
                    .WhereIf(rowIdMin.HasValue, e => e.RowId >= rowIdMin!.Value)
                    .WhereIf(rowIdMax.HasValue, e => e.RowId <= rowIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(command), e => e.Command.ToLower().Contains(command.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(groupName), e => e.GroupName.ToLower().Contains(groupName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(lastValue), e => e.LastValue.ToLower().Contains(lastValue.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(newValue), e => e.NewValue.ToLower().Contains(newValue.ToLower()))

                    .WhereIf(!string.IsNullOrWhiteSpace(comment), e => e.Comment.ToLower().Contains(comment.ToLower()))
                    .WhereIf(isActiveMin.HasValue, e => e.IsActive >= isActiveMin!.Value)
                    .WhereIf(isActiveMax.HasValue, e => e.IsActive <= isActiveMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(changeSetId.HasValue, e => e.ChangeSetId == changeSetId)
                    .WhereIf(timeAssessmentMin.HasValue, e => e.TimeAssessment >= timeAssessmentMin!.Value)
                    .WhereIf(timeAssessmentMax.HasValue, e => e.TimeAssessment <= timeAssessmentMax!.Value)
                    .WhereIf(isVisible.HasValue, e => e.IsVisible == isVisible);
        }
    }
}