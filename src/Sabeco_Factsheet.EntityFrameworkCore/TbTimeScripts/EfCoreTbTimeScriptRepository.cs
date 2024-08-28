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

namespace Sabeco_Factsheet.TbTimeScripts
{
    public abstract class EfCoreTbTimeScriptRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbTimeScript, int>
    {
        public EfCoreTbTimeScriptRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
            int? dayMin = null,
            int? dayMax = null,
            int? hourMin = null,
            int? hourMax = null,
            int? minuteMin = null,
            int? minuteMax = null,
            int? secondMin = null,
            int? secondMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, code, yearMin, yearMax, monthMin, monthMax, dayMin, dayMax, hourMin, hourMax, minuteMin, minuteMax, secondMin, secondMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbTimeScript>> GetListAsync(
            string? filterText = null,
            string? code = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
            int? dayMin = null,
            int? dayMax = null,
            int? hourMin = null,
            int? hourMax = null,
            int? minuteMin = null,
            int? minuteMax = null,
            int? secondMin = null,
            int? secondMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, yearMin, yearMax, monthMin, monthMax, dayMin, dayMax, hourMin, hourMax, minuteMin, minuteMax, secondMin, secondMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbTimeScriptConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
            int? dayMin = null,
            int? dayMax = null,
            int? hourMin = null,
            int? hourMax = null,
            int? minuteMin = null,
            int? minuteMax = null,
            int? secondMin = null,
            int? secondMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, yearMin, yearMax, monthMin, monthMax, dayMin, dayMax, hourMin, hourMax, minuteMin, minuteMax, secondMin, secondMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbTimeScript> ApplyFilter(
            IQueryable<TbTimeScript> query,
            string? filterText = null,
            string? code = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
            int? dayMin = null,
            int? dayMax = null,
            int? hourMin = null,
            int? hourMax = null,
            int? minuteMin = null,
            int? minuteMax = null,
            int? secondMin = null,
            int? secondMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(yearMin.HasValue, e => e.Year >= yearMin!.Value)
                    .WhereIf(yearMax.HasValue, e => e.Year <= yearMax!.Value)
                    .WhereIf(monthMin.HasValue, e => e.Month >= monthMin!.Value)
                    .WhereIf(monthMax.HasValue, e => e.Month <= monthMax!.Value)
                    .WhereIf(dayMin.HasValue, e => e.Day >= dayMin!.Value)
                    .WhereIf(dayMax.HasValue, e => e.Day <= dayMax!.Value)
                    .WhereIf(hourMin.HasValue, e => e.Hour >= hourMin!.Value)
                    .WhereIf(hourMax.HasValue, e => e.Hour <= hourMax!.Value)
                    .WhereIf(minuteMin.HasValue, e => e.Minute >= minuteMin!.Value)
                    .WhereIf(minuteMax.HasValue, e => e.Minute <= minuteMax!.Value)
                    .WhereIf(secondMin.HasValue, e => e.Second >= secondMin!.Value)
                    .WhereIf(secondMax.HasValue, e => e.Second <= secondMax!.Value);
        }
    }
}