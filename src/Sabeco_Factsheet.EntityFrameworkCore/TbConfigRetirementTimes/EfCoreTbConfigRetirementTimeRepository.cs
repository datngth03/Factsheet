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

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public abstract class EfCoreTbConfigRetirementTimeRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbConfigRetirementTime, int>
    {
        public EfCoreTbConfigRetirementTimeRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            int? yearNumbMin = null,
            int? yearNumbMax = null,
            int? monthNumbMin = null,
            int? monthNumbMax = null,
            int? dayNumbMin = null,
            int? dayNumbMax = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, code, yearNumbMin, yearNumbMax, monthNumbMin, monthNumbMax, dayNumbMin, dayNumbMax, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbConfigRetirementTime>> GetListAsync(
            string? filterText = null,
            string? code = null,
            int? yearNumbMin = null,
            int? yearNumbMax = null,
            int? monthNumbMin = null,
            int? monthNumbMax = null,
            int? dayNumbMin = null,
            int? dayNumbMax = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, yearNumbMin, yearNumbMax, monthNumbMin, monthNumbMax, dayNumbMin, dayNumbMax, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbConfigRetirementTimeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            int? yearNumbMin = null,
            int? yearNumbMax = null,
            int? monthNumbMin = null,
            int? monthNumbMax = null,
            int? dayNumbMin = null,
            int? dayNumbMax = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, yearNumbMin, yearNumbMax, monthNumbMin, monthNumbMax, dayNumbMin, dayNumbMax, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbConfigRetirementTime> ApplyFilter(
            IQueryable<TbConfigRetirementTime> query,
            string? filterText = null,
            string? code = null,
            int? yearNumbMin = null,
            int? yearNumbMax = null,
            int? monthNumbMin = null,
            int? monthNumbMax = null,
            int? dayNumbMin = null,
            int? dayNumbMax = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(yearNumbMin.HasValue, e => e.YearNumb >= yearNumbMin!.Value)
                    .WhereIf(yearNumbMax.HasValue, e => e.YearNumb <= yearNumbMax!.Value)
                    .WhereIf(monthNumbMin.HasValue, e => e.MonthNumb >= monthNumbMin!.Value)
                    .WhereIf(monthNumbMax.HasValue, e => e.MonthNumb <= monthNumbMax!.Value)
                    .WhereIf(dayNumbMin.HasValue, e => e.DayNumb >= dayNumbMin!.Value)
                    .WhereIf(dayNumbMax.HasValue, e => e.DayNumb <= dayNumbMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value);
        }
    }
}