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

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public abstract class EfCoreTbLogExportDataRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogExportData, int>
    {
        public EfCoreTbLogExportDataRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, timeExportMin, timeExportMax, isSuccess, userExportMin, userExportMax, tableName, reasonExportFailed);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogExportData>> GetListAsync(
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeExportMin, timeExportMax, isSuccess, userExportMin, userExportMax, tableName, reasonExportFailed);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogExportDataConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, timeExportMin, timeExportMax, isSuccess, userExportMin, userExportMax, tableName, reasonExportFailed);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogExportData> ApplyFilter(
            IQueryable<TbLogExportData> query,
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.TableName.ToLower().Contains(filterText.ToLower()) || e.ReasonExportFailed.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(timeExportMin.HasValue, e => e.TimeExport >= timeExportMin!.Value)
                    .WhereIf(timeExportMax.HasValue, e => e.TimeExport <= timeExportMax!.Value)
                    .WhereIf(isSuccess.HasValue, e => e.IsSuccess == isSuccess)
                    .WhereIf(userExportMin.HasValue, e => e.UserExport >= userExportMin!.Value)
                    .WhereIf(userExportMax.HasValue, e => e.UserExport <= userExportMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(tableName), e => e.TableName.ToLower().Contains(tableName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(reasonExportFailed), e => e.ReasonExportFailed.ToLower().Contains(reasonExportFailed.ToLower()));
        }
    }
}