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

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class EfCoreTbPositionRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbPosition, int>
    {
        public EfCoreTbPositionRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            string? name = null,
            string? name_EN = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? ctr_dateMin = null,
            DateTime? ctr_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? orderNumbMin = null,
            int? orderNumbMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, code, name, name_EN, positionTypeMin, positionTypeMax, isActive, crt_userMin, crt_userMax, ctr_dateMin, ctr_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, orderNumbMin, orderNumbMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbPosition>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? ctr_dateMin = null,
            DateTime? ctr_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? orderNumbMin = null,
            int? orderNumbMax = null,
            bool? isDeleted = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, name_EN, positionTypeMin, positionTypeMax, isActive, crt_userMin, crt_userMax, ctr_dateMin, ctr_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, orderNumbMin, orderNumbMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbPositionConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? ctr_dateMin = null,
            DateTime? ctr_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? orderNumbMin = null,
            int? orderNumbMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, name, name_EN, positionTypeMin, positionTypeMax, isActive, crt_userMin, crt_userMax, ctr_dateMin, ctr_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, orderNumbMin, orderNumbMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbPosition> ApplyFilter(
            IQueryable<TbPosition> query,
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? ctr_dateMin = null,
            DateTime? ctr_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? orderNumbMin = null,
            int? orderNumbMax = null,
            bool? isDeleted = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.Name.ToLower().Contains(filterText.ToLower()) || e.Name_EN.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.ToLower().Contains(name.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name_EN), e => e.Name_EN.ToLower().Contains(name_EN.ToLower()))

                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(ctr_dateMin.HasValue, e => e.ctr_date >= ctr_dateMin!.Value)
                    .WhereIf(ctr_dateMax.HasValue, e => e.ctr_date <= ctr_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(orderNumbMin.HasValue, e => e.OrderNumb >= orderNumbMin!.Value)
                    .WhereIf(orderNumbMax.HasValue, e => e.OrderNumb <= orderNumbMax!.Value)
                    .WhereIf(isDeleted.HasValue, e => e.IsDeleted == isDeleted);
        }
    }
}