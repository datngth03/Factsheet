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

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public abstract class EfCoreTbCompanyPersonTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyPersonTemp, int>
    {
        public EfCoreTbCompanyPersonTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? idCompanyPersonMin = null,
            int? idCompanyPersonMax = null,
            string? branchCode = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            int? positionIdMin = null,
            int? positionIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            string? positionCode = null,
            decimal? personalValueMin = null,
            decimal? personalValueMax = null,
            decimal? personalSharePercentageMin = null,
            decimal? personalSharePercentageMax = null,
            decimal? ownerValueMin = null,
            decimal? ownerValueMax = null,
            decimal? representativePercentageMin = null,
            decimal? representativePercentageMax = null,
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

            query = ApplyFilter(query, filterText, idCompanyPersonMin, idCompanyPersonMax, branchCode, companyIdMin, companyIdMax, personIdMin, personIdMax, positionIdMin, positionIdMax, fromDateMin, fromDateMax, toDateMin, toDateMax, positionTypeMin, positionTypeMax, positionCode, personalValueMin, personalValueMax, personalSharePercentageMin, personalSharePercentageMax, ownerValueMin, ownerValueMax, representativePercentageMin, representativePercentageMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyPersonTemp>> GetListAsync(
            string? filterText = null,
            int? idCompanyPersonMin = null,
            int? idCompanyPersonMax = null,
            string? branchCode = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            int? positionIdMin = null,
            int? positionIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            string? positionCode = null,
            decimal? personalValueMin = null,
            decimal? personalValueMax = null,
            decimal? personalSharePercentageMin = null,
            decimal? personalSharePercentageMax = null,
            decimal? ownerValueMin = null,
            decimal? ownerValueMax = null,
            decimal? representativePercentageMin = null,
            decimal? representativePercentageMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, idCompanyPersonMin, idCompanyPersonMax, branchCode, companyIdMin, companyIdMax, personIdMin, personIdMax, positionIdMin, positionIdMax, fromDateMin, fromDateMax, toDateMin, toDateMax, positionTypeMin, positionTypeMax, positionCode, personalValueMin, personalValueMax, personalSharePercentageMin, personalSharePercentageMax, ownerValueMin, ownerValueMax, representativePercentageMin, representativePercentageMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyPersonTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? idCompanyPersonMin = null,
            int? idCompanyPersonMax = null,
            string? branchCode = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            int? positionIdMin = null,
            int? positionIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            string? positionCode = null,
            decimal? personalValueMin = null,
            decimal? personalValueMax = null,
            decimal? personalSharePercentageMin = null,
            decimal? personalSharePercentageMax = null,
            decimal? ownerValueMin = null,
            decimal? ownerValueMax = null,
            decimal? representativePercentageMin = null,
            decimal? representativePercentageMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, idCompanyPersonMin, idCompanyPersonMax, branchCode, companyIdMin, companyIdMax, personIdMin, personIdMax, positionIdMin, positionIdMax, fromDateMin, fromDateMax, toDateMin, toDateMax, positionTypeMin, positionTypeMax, positionCode, personalValueMin, personalValueMax, personalSharePercentageMin, personalSharePercentageMax, ownerValueMin, ownerValueMax, representativePercentageMin, representativePercentageMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyPersonTemp> ApplyFilter(
            IQueryable<TbCompanyPersonTemp> query,
            string? filterText = null,
            int? idCompanyPersonMin = null,
            int? idCompanyPersonMax = null,
            string? branchCode = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            int? positionIdMin = null,
            int? positionIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            string? positionCode = null,
            decimal? personalValueMin = null,
            decimal? personalValueMax = null,
            decimal? personalSharePercentageMin = null,
            decimal? personalSharePercentageMax = null,
            decimal? ownerValueMin = null,
            decimal? ownerValueMax = null,
            decimal? representativePercentageMin = null,
            decimal? representativePercentageMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BranchCode.ToLower().Contains(filterText.ToLower()) || e.PositionCode.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(idCompanyPersonMin.HasValue, e => e.idCompanyPerson >= idCompanyPersonMin!.Value)
                    .WhereIf(idCompanyPersonMax.HasValue, e => e.idCompanyPerson <= idCompanyPersonMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(branchCode), e => e.BranchCode.ToLower().Contains(branchCode.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(personIdMin.HasValue, e => e.PersonId >= personIdMin!.Value)
                    .WhereIf(personIdMax.HasValue, e => e.PersonId <= personIdMax!.Value)
                    .WhereIf(positionIdMin.HasValue, e => e.PositionId >= positionIdMin!.Value)
                    .WhereIf(positionIdMax.HasValue, e => e.PositionId <= positionIdMax!.Value)
                    .WhereIf(fromDateMin.HasValue, e => e.FromDate >= fromDateMin!.Value)
                    .WhereIf(fromDateMax.HasValue, e => e.FromDate <= fromDateMax!.Value)
                    .WhereIf(toDateMin.HasValue, e => e.ToDate >= toDateMin!.Value)
                    .WhereIf(toDateMax.HasValue, e => e.ToDate <= toDateMax!.Value)

                    .WhereIf(!string.IsNullOrWhiteSpace(positionCode), e => e.PositionCode.ToLower().Contains(positionCode.ToLower()))
                    .WhereIf(personalValueMin.HasValue, e => e.PersonalValue >= personalValueMin!.Value)
                    .WhereIf(personalValueMax.HasValue, e => e.PersonalValue <= personalValueMax!.Value)
                    .WhereIf(personalSharePercentageMin.HasValue, e => e.PersonalSharePercentage >= personalSharePercentageMin!.Value)
                    .WhereIf(personalSharePercentageMax.HasValue, e => e.PersonalSharePercentage <= personalSharePercentageMax!.Value)
                    .WhereIf(ownerValueMin.HasValue, e => e.OwnerValue >= ownerValueMin!.Value)
                    .WhereIf(ownerValueMax.HasValue, e => e.OwnerValue <= ownerValueMax!.Value)
                    .WhereIf(representativePercentageMin.HasValue, e => e.RepresentativePercentage >= representativePercentageMin!.Value)
                    .WhereIf(representativePercentageMax.HasValue, e => e.RepresentativePercentage <= representativePercentageMax!.Value)
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