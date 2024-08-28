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

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{
    public abstract class EfCoreTbCompanyBusinessDetailTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyBusinessDetailTemp, int>
    {
        public EfCoreTbCompanyBusinessDetailTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
            bool? isActive = null,
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

            query = ApplyFilter(query, filterText, parentIdMin, parentIdMax, registrationCode, registrationName, registrationName_EN, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyBusinessDetailTemp>> GetListAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
            bool? isActive = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentIdMin, parentIdMax, registrationCode, registrationName, registrationName_EN, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyBusinessDetailTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
            bool? isActive = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, parentIdMin, parentIdMax, registrationCode, registrationName, registrationName_EN, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyBusinessDetailTemp> ApplyFilter(
            IQueryable<TbCompanyBusinessDetailTemp> query,
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
            bool? isActive = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.RegistrationCode.ToLower().Contains(filterText.ToLower()) || e.RegistrationName.ToLower().Contains(filterText.ToLower()) || e.RegistrationName_EN.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(parentIdMin.HasValue, e => e.ParentId >= parentIdMin!.Value)
                    .WhereIf(parentIdMax.HasValue, e => e.ParentId <= parentIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(registrationCode), e => e.RegistrationCode.ToLower().Contains(registrationCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(registrationName), e => e.RegistrationName.ToLower().Contains(registrationName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(registrationName_EN), e => e.RegistrationName_EN.ToLower().Contains(registrationName_EN.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
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