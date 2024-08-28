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

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class EfCoreTbInvestRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbInvest, int>
    {
        public EfCoreTbInvestRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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

            query = ApplyFilter(query, filterText, branchCode, branchIdMin, branchIdMax, companyIdMin, companyIdMax, companyCode, shareNumTotalMin, shareNumTotalMax, shareValueTotalMin, shareValueTotalMax, note, docStatusMin, docStatusMax, investGroup, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbInvest>> GetListAsync(
            string? filterText = null,
            string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, branchCode, branchIdMin, branchIdMax, companyIdMin, companyIdMax, companyCode, shareNumTotalMin, shareNumTotalMax, shareValueTotalMin, shareValueTotalMax, note, docStatusMin, docStatusMax, investGroup, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbInvestConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, branchCode, branchIdMin, branchIdMax, companyIdMin, companyIdMax, companyCode, shareNumTotalMin, shareNumTotalMax, shareValueTotalMin, shareValueTotalMax, note, docStatusMin, docStatusMax, investGroup, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbInvest> ApplyFilter(
            IQueryable<TbInvest> query,
            string? filterText = null,
            string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BranchCode.ToLower().Contains(filterText.ToLower()) || e.CompanyCode.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(branchCode), e => e.BranchCode.ToLower().Contains(branchCode.ToLower()))
                    .WhereIf(branchIdMin.HasValue, e => e.BranchId >= branchIdMin!.Value)
                    .WhereIf(branchIdMax.HasValue, e => e.BranchId <= branchIdMax!.Value)
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.CompanyCode.ToLower().Contains(companyCode.ToLower()))
                    .WhereIf(shareNumTotalMin.HasValue, e => e.ShareNumTotal >= shareNumTotalMin!.Value)
                    .WhereIf(shareNumTotalMax.HasValue, e => e.ShareNumTotal <= shareNumTotalMax!.Value)
                    .WhereIf(shareValueTotalMin.HasValue, e => e.ShareValueTotal >= shareValueTotalMin!.Value)
                    .WhereIf(shareValueTotalMax.HasValue, e => e.ShareValueTotal <= shareValueTotalMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))

                    .WhereIf(investGroup.HasValue, e => e.InvestGroup == investGroup)
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