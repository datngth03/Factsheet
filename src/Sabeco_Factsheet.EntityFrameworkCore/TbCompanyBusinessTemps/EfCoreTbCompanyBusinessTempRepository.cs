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

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public abstract class EfCoreTbCompanyBusinessTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyBusinessTemp, int>
    {
        public EfCoreTbCompanyBusinessTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? license = null,
            byte? registrationNoMin = null,
            byte? registrationNoMax = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            string? companyName = null,
            string? companyAddress = null,
            string? legalRepresent = null,
            string? companyType = null,
            string? majorBusiness = null,
            string? otherActivity = null,
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
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, license, registrationNoMin, registrationNoMax, registrationDateMin, registrationDateMax, companyName, companyAddress, legalRepresent, companyType, majorBusiness, otherActivity, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, latestAmendmentMin, latestAmendmentMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyBusinessTemp>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? license = null,
            byte? registrationNoMin = null,
            byte? registrationNoMax = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            string? companyName = null,
            string? companyAddress = null,
            string? legalRepresent = null,
            string? companyType = null,
            string? majorBusiness = null,
            string? otherActivity = null,
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
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, license, registrationNoMin, registrationNoMax, registrationDateMin, registrationDateMax, companyName, companyAddress, legalRepresent, companyType, majorBusiness, otherActivity, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, latestAmendmentMin, latestAmendmentMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyBusinessTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? license = null,
            byte? registrationNoMin = null,
            byte? registrationNoMax = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            string? companyName = null,
            string? companyAddress = null,
            string? legalRepresent = null,
            string? companyType = null,
            string? majorBusiness = null,
            string? otherActivity = null,
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
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, license, registrationNoMin, registrationNoMax, registrationDateMin, registrationDateMax, companyName, companyAddress, legalRepresent, companyType, majorBusiness, otherActivity, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, latestAmendmentMin, latestAmendmentMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyBusinessTemp> ApplyFilter(
            IQueryable<TbCompanyBusinessTemp> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? license = null,
            byte? registrationNoMin = null,
            byte? registrationNoMax = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            string? companyName = null,
            string? companyAddress = null,
            string? legalRepresent = null,
            string? companyType = null,
            string? majorBusiness = null,
            string? otherActivity = null,
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
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.License.ToLower().Contains(filterText.ToLower()) || e.CompanyName.ToLower().Contains(filterText.ToLower()) || e.CompanyAddress.ToLower().Contains(filterText.ToLower()) || e.LegalRepresent.ToLower().Contains(filterText.ToLower()) || e.CompanyType.ToLower().Contains(filterText.ToLower()) || e.MajorBusiness.ToLower().Contains(filterText.ToLower()) || e.OtherActivity.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(license), e => e.License.ToLower().Contains(license.ToLower()))

                    .WhereIf(registrationDateMin.HasValue, e => e.RegistrationDate >= registrationDateMin!.Value)
                    .WhereIf(registrationDateMax.HasValue, e => e.RegistrationDate <= registrationDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyName), e => e.CompanyName.ToLower().Contains(companyName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyAddress), e => e.CompanyAddress.ToLower().Contains(companyAddress.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(legalRepresent), e => e.LegalRepresent.ToLower().Contains(legalRepresent.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyType), e => e.CompanyType.ToLower().Contains(companyType.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(majorBusiness), e => e.MajorBusiness.ToLower().Contains(majorBusiness.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(otherActivity), e => e.OtherActivity.ToLower().Contains(otherActivity.ToLower()))
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
                    .WhereIf(latestAmendmentMin.HasValue, e => e.LatestAmendment >= latestAmendmentMin!.Value)
                    .WhereIf(latestAmendmentMax.HasValue, e => e.LatestAmendment <= latestAmendmentMax!.Value);
        }
    }
}