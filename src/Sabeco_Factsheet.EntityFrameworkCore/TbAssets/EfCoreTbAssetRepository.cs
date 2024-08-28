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

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class EfCoreTbAssetRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbAsset, int>
    {
        public EfCoreTbAssetRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
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

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, assetType, assetItem, assetAddress, quantityMin, quantityMax, docNo, docDateMin, docDateMax, expireDateMin, expireDateMax, description, docStatusMin, docStatusMax, isActive, isDeleted, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbAsset>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, assetType, assetItem, assetAddress, quantityMin, quantityMax, docNo, docDateMin, docDateMax, expireDateMin, expireDateMax, description, docStatusMin, docStatusMax, isActive, isDeleted, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbAssetConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, assetType, assetItem, assetAddress, quantityMin, quantityMax, docNo, docDateMin, docDateMax, expireDateMin, expireDateMax, description, docStatusMin, docStatusMax, isActive, isDeleted, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbAsset> ApplyFilter(
            IQueryable<TbAsset> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.AssetType.ToLower().Contains(filterText.ToLower()) || e.AssetItem.ToLower().Contains(filterText.ToLower()) || e.AssetAddress.ToLower().Contains(filterText.ToLower()) || e.DocNo.ToLower().Contains(filterText.ToLower()) || e.Description.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(assetType), e => e.AssetType.ToLower().Contains(assetType.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(assetItem), e => e.AssetItem.ToLower().Contains(assetItem.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(assetAddress), e => e.AssetAddress.ToLower().Contains(assetAddress.ToLower()))
                    .WhereIf(quantityMin.HasValue, e => e.Quantity >= quantityMin!.Value)
                    .WhereIf(quantityMax.HasValue, e => e.Quantity <= quantityMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(docNo), e => e.DocNo.ToLower().Contains(docNo.ToLower()))
                    .WhereIf(docDateMin.HasValue, e => e.DocDate >= docDateMin!.Value)
                    .WhereIf(docDateMax.HasValue, e => e.DocDate <= docDateMax!.Value)
                    .WhereIf(expireDateMin.HasValue, e => e.ExpireDate >= expireDateMin!.Value)
                    .WhereIf(expireDateMax.HasValue, e => e.ExpireDate <= expireDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.ToLower().Contains(description.ToLower()))

                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(isDeleted.HasValue, e => e.IsDeleted == isDeleted)
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