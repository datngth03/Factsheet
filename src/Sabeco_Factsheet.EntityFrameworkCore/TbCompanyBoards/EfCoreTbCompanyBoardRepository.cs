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

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class EfCoreTbCompanyBoardRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyBoard, int>
    {
        public EfCoreTbCompanyBoardRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? branchCode = null,
            string? companyCode = null,
            string? personCode = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string? positionCode = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, branchCode, companyCode, personCode, fromDateMin, fromDateMax, toDateMin, toDateMax, positionCode, personalValueMin, personalValueMax, ownerValueMin, ownerValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyBoard>> GetListAsync(
            string? filterText = null,
            string? branchCode = null,
            string? companyCode = null,
            string? personCode = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string? positionCode = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
            bool? isDeleted = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, branchCode, companyCode, personCode, fromDateMin, fromDateMax, toDateMin, toDateMax, positionCode, personalValueMin, personalValueMax, ownerValueMin, ownerValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyBoardConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? branchCode = null,
            string? companyCode = null,
            string? personCode = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string? positionCode = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, branchCode, companyCode, personCode, fromDateMin, fromDateMax, toDateMin, toDateMax, positionCode, personalValueMin, personalValueMax, ownerValueMin, ownerValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyBoard> ApplyFilter(
            IQueryable<TbCompanyBoard> query,
            string? filterText = null,
            string? branchCode = null,
            string? companyCode = null,
            string? personCode = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string? positionCode = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
            bool? isDeleted = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BranchCode.ToLower().Contains(filterText.ToLower()) || e.CompanyCode.ToLower().Contains(filterText.ToLower()) || e.PersonCode.ToLower().Contains(filterText.ToLower()) || e.PositionCode.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(branchCode), e => e.BranchCode.ToLower().Contains(branchCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.CompanyCode.ToLower().Contains(companyCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(personCode), e => e.PersonCode.ToLower().Contains(personCode.ToLower()))
                    .WhereIf(fromDateMin.HasValue, e => e.FromDate >= fromDateMin!.Value)
                    .WhereIf(fromDateMax.HasValue, e => e.FromDate <= fromDateMax!.Value)
                    .WhereIf(toDateMin.HasValue, e => e.ToDate >= toDateMin!.Value)
                    .WhereIf(toDateMax.HasValue, e => e.ToDate <= toDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(positionCode), e => e.PositionCode.ToLower().Contains(positionCode.ToLower()))
                    .WhereIf(personalValueMin.HasValue, e => e.PersonalValue >= personalValueMin!.Value)
                    .WhereIf(personalValueMax.HasValue, e => e.PersonalValue <= personalValueMax!.Value)
                    .WhereIf(ownerValueMin.HasValue, e => e.OwnerValue >= ownerValueMin!.Value)
                    .WhereIf(ownerValueMax.HasValue, e => e.OwnerValue <= ownerValueMax!.Value)
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
                    .WhereIf(isDeleted.HasValue, e => e.IsDeleted == isDeleted);
        }
    }
}