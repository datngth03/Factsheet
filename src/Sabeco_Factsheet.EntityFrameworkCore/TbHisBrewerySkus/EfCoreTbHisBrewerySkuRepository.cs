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

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public abstract class EfCoreTbHisBrewerySkuRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbHisBrewerySku, int>
    {
        public EfCoreTbHisBrewerySkuRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idBrewerySKUMin = null,
            int? idBrewerySKUMax = null,
            int? yearMin = null,
            int? yearMax = null,
            string? breweryCode = null,
            string? sKUCode = null,
            decimal? productionVolumeMin = null,
            decimal? productionVolumeMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            int? sKUIdMin = null,
            int? sKUIdMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idBrewerySKUMin, idBrewerySKUMax, yearMin, yearMax, breweryCode, sKUCode, productionVolumeMin, productionVolumeMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, breweryIdMin, breweryIdMax, sKUIdMin, sKUIdMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbHisBrewerySku>> GetListAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idBrewerySKUMin = null,
            int? idBrewerySKUMax = null,
            int? yearMin = null,
            int? yearMax = null,
            string? breweryCode = null,
            string? sKUCode = null,
            decimal? productionVolumeMin = null,
            decimal? productionVolumeMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            int? sKUIdMin = null,
            int? sKUIdMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idBrewerySKUMin, idBrewerySKUMax, yearMin, yearMax, breweryCode, sKUCode, productionVolumeMin, productionVolumeMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, breweryIdMin, breweryIdMax, sKUIdMin, sKUIdMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisBrewerySkuConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idBrewerySKUMin = null,
            int? idBrewerySKUMax = null,
            int? yearMin = null,
            int? yearMax = null,
            string? breweryCode = null,
            string? sKUCode = null,
            decimal? productionVolumeMin = null,
            decimal? productionVolumeMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            int? sKUIdMin = null,
            int? sKUIdMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idBrewerySKUMin, idBrewerySKUMax, yearMin, yearMax, breweryCode, sKUCode, productionVolumeMin, productionVolumeMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, breweryIdMin, breweryIdMax, sKUIdMin, sKUIdMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbHisBrewerySku> ApplyFilter(
            IQueryable<TbHisBrewerySku> query,
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idBrewerySKUMin = null,
            int? idBrewerySKUMax = null,
            int? yearMin = null,
            int? yearMax = null,
            string? breweryCode = null,
            string? sKUCode = null,
            decimal? productionVolumeMin = null,
            decimal? productionVolumeMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            int? sKUIdMin = null,
            int? sKUIdMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BreweryCode.ToLower().Contains(filterText.ToLower()) || e.SKUCode.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(isSendMail.HasValue, e => e.IsSendMail == isSendMail)
                    .WhereIf(dateSendMailMin.HasValue, e => e.DateSendMail >= dateSendMailMin!.Value)
                    .WhereIf(dateSendMailMax.HasValue, e => e.DateSendMail <= dateSendMailMax!.Value)
                    .WhereIf(insertDateMin.HasValue, e => e.InsertDate >= insertDateMin!.Value)
                    .WhereIf(insertDateMax.HasValue, e => e.InsertDate <= insertDateMax!.Value)
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value)
                    .WhereIf(idBrewerySKUMin.HasValue, e => e.IdBrewerySKU >= idBrewerySKUMin!.Value)
                    .WhereIf(idBrewerySKUMax.HasValue, e => e.IdBrewerySKU <= idBrewerySKUMax!.Value)
                    .WhereIf(yearMin.HasValue, e => e.Year >= yearMin!.Value)
                    .WhereIf(yearMax.HasValue, e => e.Year <= yearMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(breweryCode), e => e.BreweryCode.ToLower().Contains(breweryCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(sKUCode), e => e.SKUCode.ToLower().Contains(sKUCode.ToLower()))
                    .WhereIf(productionVolumeMin.HasValue, e => e.ProductionVolume >= productionVolumeMin!.Value)
                    .WhereIf(productionVolumeMax.HasValue, e => e.ProductionVolume <= productionVolumeMax!.Value)

                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(breweryIdMin.HasValue, e => e.BreweryId >= breweryIdMin!.Value)
                    .WhereIf(breweryIdMax.HasValue, e => e.BreweryId <= breweryIdMax!.Value)
                    .WhereIf(sKUIdMin.HasValue, e => e.SKUId >= sKUIdMin!.Value)
                    .WhereIf(sKUIdMax.HasValue, e => e.SKUId <= sKUIdMax!.Value);
        }
    }
}