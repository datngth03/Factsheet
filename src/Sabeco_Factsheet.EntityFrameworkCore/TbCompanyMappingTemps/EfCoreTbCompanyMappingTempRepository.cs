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

namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public abstract class EfCoreTbCompanyMappingTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyMappingTemp, int>
    {
        public EfCoreTbCompanyMappingTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, companyTypeShareholdingCode, companyTypesCode, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, idCompanyTypeShareholdingCodeMin, idCompanyTypeShareholdingCodeMax, idCompanyTypesCodeMin, idCompanyTypesCodeMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyMappingTemp>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, companyTypeShareholdingCode, companyTypesCode, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, idCompanyTypeShareholdingCodeMin, idCompanyTypeShareholdingCodeMax, idCompanyTypesCodeMin, idCompanyTypesCodeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyMappingTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, companyTypeShareholdingCode, companyTypesCode, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, idCompanyTypeShareholdingCodeMin, idCompanyTypeShareholdingCodeMax, idCompanyTypesCodeMin, idCompanyTypesCodeMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyMappingTemp> ApplyFilter(
            IQueryable<TbCompanyMappingTemp> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CompanyTypeShareholdingCode.ToLower().Contains(filterText.ToLower()) || e.CompanyTypesCode.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyTypeShareholdingCode), e => e.CompanyTypeShareholdingCode.ToLower().Contains(companyTypeShareholdingCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyTypesCode), e => e.CompanyTypesCode.ToLower().Contains(companyTypesCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(idCompanyTypeShareholdingCodeMin.HasValue, e => e.idCompanyTypeShareholdingCode >= idCompanyTypeShareholdingCodeMin!.Value)
                    .WhereIf(idCompanyTypeShareholdingCodeMax.HasValue, e => e.idCompanyTypeShareholdingCode <= idCompanyTypeShareholdingCodeMax!.Value)
                    .WhereIf(idCompanyTypesCodeMin.HasValue, e => e.idCompanyTypesCode >= idCompanyTypesCodeMin!.Value)
                    .WhereIf(idCompanyTypesCodeMax.HasValue, e => e.idCompanyTypesCode <= idCompanyTypesCodeMax!.Value);
        }
    }
}