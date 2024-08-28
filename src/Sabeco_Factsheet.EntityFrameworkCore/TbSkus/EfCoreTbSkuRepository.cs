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

namespace Sabeco_Factsheet.TbSkus
{
    public abstract class EfCoreTbSkuRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbSku, int>
    {
        public EfCoreTbSkuRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            string? name = null,
            string? name_EN = null,
            string? brandCode = null,
            string? unit = null,
            string? itemBaseType = null,
            decimal? packSizeMin = null,
            decimal? packSizeMax = null,
            int? packQuantityMin = null,
            int? packQuantityMax = null,
            decimal? weightMin = null,
            decimal? weightMax = null,
            int? expiryDateMin = null,
            int? expiryDateMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, code, name, name_EN, brandCode, unit, itemBaseType, packSizeMin, packSizeMax, packQuantityMin, packQuantityMax, weightMin, weightMax, expiryDateMin, expiryDateMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbSku>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? brandCode = null,
            string? unit = null,
            string? itemBaseType = null,
            decimal? packSizeMin = null,
            decimal? packSizeMax = null,
            int? packQuantityMin = null,
            int? packQuantityMax = null,
            decimal? weightMin = null,
            decimal? weightMax = null,
            int? expiryDateMin = null,
            int? expiryDateMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, name_EN, brandCode, unit, itemBaseType, packSizeMin, packSizeMax, packQuantityMin, packQuantityMax, weightMin, weightMax, expiryDateMin, expiryDateMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbSkuConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? brandCode = null,
            string? unit = null,
            string? itemBaseType = null,
            decimal? packSizeMin = null,
            decimal? packSizeMax = null,
            int? packQuantityMin = null,
            int? packQuantityMax = null,
            decimal? weightMin = null,
            decimal? weightMax = null,
            int? expiryDateMin = null,
            int? expiryDateMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, name, name_EN, brandCode, unit, itemBaseType, packSizeMin, packSizeMax, packQuantityMin, packQuantityMax, weightMin, weightMax, expiryDateMin, expiryDateMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbSku> ApplyFilter(
            IQueryable<TbSku> query,
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? brandCode = null,
            string? unit = null,
            string? itemBaseType = null,
            decimal? packSizeMin = null,
            decimal? packSizeMax = null,
            int? packQuantityMin = null,
            int? packQuantityMax = null,
            decimal? weightMin = null,
            decimal? weightMax = null,
            int? expiryDateMin = null,
            int? expiryDateMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.Name.ToLower().Contains(filterText.ToLower()) || e.Name_EN.ToLower().Contains(filterText.ToLower()) || e.BrandCode.ToLower().Contains(filterText.ToLower()) || e.Unit.ToLower().Contains(filterText.ToLower()) || e.ItemBaseType.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.ToLower().Contains(name.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name_EN), e => e.Name_EN.ToLower().Contains(name_EN.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(brandCode), e => e.BrandCode.ToLower().Contains(brandCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(unit), e => e.Unit.ToLower().Contains(unit.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(itemBaseType), e => e.ItemBaseType.ToLower().Contains(itemBaseType.ToLower()))
                    .WhereIf(packSizeMin.HasValue, e => e.PackSize >= packSizeMin!.Value)
                    .WhereIf(packSizeMax.HasValue, e => e.PackSize <= packSizeMax!.Value)
                    .WhereIf(packQuantityMin.HasValue, e => e.PackQuantity >= packQuantityMin!.Value)
                    .WhereIf(packQuantityMax.HasValue, e => e.PackQuantity <= packQuantityMax!.Value)
                    .WhereIf(weightMin.HasValue, e => e.Weight >= weightMin!.Value)
                    .WhereIf(weightMax.HasValue, e => e.Weight <= weightMax!.Value)
                    .WhereIf(expiryDateMin.HasValue, e => e.ExpiryDate >= expiryDateMin!.Value)
                    .WhereIf(expiryDateMax.HasValue, e => e.ExpiryDate <= expiryDateMax!.Value)
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value);
        }
    }
}