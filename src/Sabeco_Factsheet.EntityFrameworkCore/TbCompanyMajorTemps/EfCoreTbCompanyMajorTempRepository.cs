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

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public abstract class EfCoreTbCompanyMajorTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyMajorTemp, int>
    {
        public EfCoreTbCompanyMajorTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? shareHolderMajor = null,
            string? shareHolderType = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            decimal? shareHolderValueMin = null,
            decimal? shareHolderValueMax = null,
            decimal? shareHolderRateMin = null,
            decimal? shareHolderRateMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? classIdMin = null,
            int? classIdMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, shareHolderMajor, shareHolderType, fromDateMin, fromDateMax, toDateMin, toDateMax, shareHolderValueMin, shareHolderValueMax, shareHolderRateMin, shareHolderRateMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, classIdMin, classIdMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyMajorTemp>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? shareHolderMajor = null,
            string? shareHolderType = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            decimal? shareHolderValueMin = null,
            decimal? shareHolderValueMax = null,
            decimal? shareHolderRateMin = null,
            decimal? shareHolderRateMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? classIdMin = null,
            int? classIdMax = null,
            bool? isDeleted = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, shareHolderMajor, shareHolderType, fromDateMin, fromDateMax, toDateMin, toDateMax, shareHolderValueMin, shareHolderValueMax, shareHolderRateMin, shareHolderRateMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, classIdMin, classIdMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyMajorTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? shareHolderMajor = null,
            string? shareHolderType = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            decimal? shareHolderValueMin = null,
            decimal? shareHolderValueMax = null,
            decimal? shareHolderRateMin = null,
            decimal? shareHolderRateMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? classIdMin = null,
            int? classIdMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, shareHolderMajor, shareHolderType, fromDateMin, fromDateMax, toDateMin, toDateMax, shareHolderValueMin, shareHolderValueMax, shareHolderRateMin, shareHolderRateMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, classIdMin, classIdMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyMajorTemp> ApplyFilter(
            IQueryable<TbCompanyMajorTemp> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? shareHolderMajor = null,
            string? shareHolderType = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            decimal? shareHolderValueMin = null,
            decimal? shareHolderValueMax = null,
            decimal? shareHolderRateMin = null,
            decimal? shareHolderRateMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? classIdMin = null,
            int? classIdMax = null,
            bool? isDeleted = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ShareHolderMajor.ToLower().Contains(filterText.ToLower()) || e.ShareHolderType.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(shareHolderMajor), e => e.ShareHolderMajor.ToLower().Contains(shareHolderMajor.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(shareHolderType), e => e.ShareHolderType.ToLower().Contains(shareHolderType.ToLower()))
                    .WhereIf(fromDateMin.HasValue, e => e.FromDate >= fromDateMin!.Value)
                    .WhereIf(fromDateMax.HasValue, e => e.FromDate <= fromDateMax!.Value)
                    .WhereIf(toDateMin.HasValue, e => e.ToDate >= toDateMin!.Value)
                    .WhereIf(toDateMax.HasValue, e => e.ToDate <= toDateMax!.Value)
                    .WhereIf(shareHolderValueMin.HasValue, e => e.ShareHolderValue >= shareHolderValueMin!.Value)
                    .WhereIf(shareHolderValueMax.HasValue, e => e.ShareHolderValue <= shareHolderValueMax!.Value)
                    .WhereIf(shareHolderRateMin.HasValue, e => e.ShareHolderRate >= shareHolderRateMin!.Value)
                    .WhereIf(shareHolderRateMax.HasValue, e => e.ShareHolderRate <= shareHolderRateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(classIdMin.HasValue, e => e.ClassId >= classIdMin!.Value)
                    .WhereIf(classIdMax.HasValue, e => e.ClassId <= classIdMax!.Value)
                    .WhereIf(isDeleted.HasValue, e => e.IsDeleted == isDeleted);
        }
    }
}