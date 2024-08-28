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

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public abstract class EfCoreTbBreweryDeliveryVolumeRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbBreweryDeliveryVolume, int>
    {
        public EfCoreTbBreweryDeliveryVolumeRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? breweryIdMin = null,
            int? breweryIdMax = null,
            string? breweryCode = null,
            int? yearMin = null,
            int? yearMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
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

            query = ApplyFilter(query, filterText, breweryIdMin, breweryIdMax, breweryCode, yearMin, yearMax, deliveryVolumeMin, deliveryVolumeMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbBreweryDeliveryVolume>> GetListAsync(
            string? filterText = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            string? breweryCode = null,
            int? yearMin = null,
            int? yearMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, breweryIdMin, breweryIdMax, breweryCode, yearMin, yearMax, deliveryVolumeMin, deliveryVolumeMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbBreweryDeliveryVolumeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            string? breweryCode = null,
            int? yearMin = null,
            int? yearMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, breweryIdMin, breweryIdMax, breweryCode, yearMin, yearMax, deliveryVolumeMin, deliveryVolumeMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbBreweryDeliveryVolume> ApplyFilter(
            IQueryable<TbBreweryDeliveryVolume> query,
            string? filterText = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            string? breweryCode = null,
            int? yearMin = null,
            int? yearMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BreweryCode.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(breweryIdMin.HasValue, e => e.BreweryId >= breweryIdMin!.Value)
                    .WhereIf(breweryIdMax.HasValue, e => e.BreweryId <= breweryIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(breweryCode), e => e.BreweryCode.ToLower().Contains(breweryCode.ToLower()))
                    .WhereIf(yearMin.HasValue, e => e.Year >= yearMin!.Value)
                    .WhereIf(yearMax.HasValue, e => e.Year <= yearMax!.Value)
                    .WhereIf(deliveryVolumeMin.HasValue, e => e.DeliveryVolume >= deliveryVolumeMin!.Value)
                    .WhereIf(deliveryVolumeMax.HasValue, e => e.DeliveryVolume <= deliveryVolumeMax!.Value)
                    .WhereIf(isActive.HasValue, e => e.isActive == isActive)
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