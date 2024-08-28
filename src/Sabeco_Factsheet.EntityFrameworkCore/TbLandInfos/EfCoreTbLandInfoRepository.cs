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

namespace Sabeco_Factsheet.TbLandInfos
{
    public abstract class EfCoreTbLandInfoRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLandInfo, int>
    {
        public EfCoreTbLandInfoRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? description = null,
            string? address = null,
            string? typeOfLand = null,
            decimal? areaMin = null,
            decimal? areaMax = null,
            string? supportingDocument = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            string? payment = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, description, address, typeOfLand, areaMin, areaMax, supportingDocument, issueDateMin, issueDateMax, expiryDateMin, expiryDateMax, payment, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLandInfo>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? description = null,
            string? address = null,
            string? typeOfLand = null,
            decimal? areaMin = null,
            decimal? areaMax = null,
            string? supportingDocument = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            string? payment = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, description, address, typeOfLand, areaMin, areaMax, supportingDocument, issueDateMin, issueDateMax, expiryDateMin, expiryDateMax, payment, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLandInfoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? description = null,
            string? address = null,
            string? typeOfLand = null,
            decimal? areaMin = null,
            decimal? areaMax = null,
            string? supportingDocument = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            string? payment = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, description, address, typeOfLand, areaMin, areaMax, supportingDocument, issueDateMin, issueDateMax, expiryDateMin, expiryDateMax, payment, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLandInfo> ApplyFilter(
            IQueryable<TbLandInfo> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? description = null,
            string? address = null,
            string? typeOfLand = null,
            decimal? areaMin = null,
            decimal? areaMax = null,
            string? supportingDocument = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            string? payment = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Description.ToLower().Contains(filterText.ToLower()) || e.Address.ToLower().Contains(filterText.ToLower()) || e.TypeOfLand.ToLower().Contains(filterText.ToLower()) || e.SupportingDocument.ToLower().Contains(filterText.ToLower()) || e.Payment.ToLower().Contains(filterText.ToLower()) || e.Remark.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.ToLower().Contains(description.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.ToLower().Contains(address.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(typeOfLand), e => e.TypeOfLand.ToLower().Contains(typeOfLand.ToLower()))
                    .WhereIf(areaMin.HasValue, e => e.Area >= areaMin!.Value)
                    .WhereIf(areaMax.HasValue, e => e.Area <= areaMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(supportingDocument), e => e.SupportingDocument.ToLower().Contains(supportingDocument.ToLower()))
                    .WhereIf(issueDateMin.HasValue, e => e.IssueDate >= issueDateMin!.Value)
                    .WhereIf(issueDateMax.HasValue, e => e.IssueDate <= issueDateMax!.Value)
                    .WhereIf(expiryDateMin.HasValue, e => e.ExpiryDate >= expiryDateMin!.Value)
                    .WhereIf(expiryDateMax.HasValue, e => e.ExpiryDate <= expiryDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(payment), e => e.Payment.ToLower().Contains(payment.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(remark), e => e.Remark.ToLower().Contains(remark.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(create_userMin.HasValue, e => e.create_user >= create_userMin!.Value)
                    .WhereIf(create_userMax.HasValue, e => e.create_user <= create_userMax!.Value)
                    .WhereIf(create_dateMin.HasValue, e => e.create_date >= create_dateMin!.Value)
                    .WhereIf(create_dateMax.HasValue, e => e.create_date <= create_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value);
        }
    }
}