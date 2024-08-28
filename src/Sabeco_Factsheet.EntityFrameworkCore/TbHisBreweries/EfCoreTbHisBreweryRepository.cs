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

namespace Sabeco_Factsheet.TbHisBreweries
{
    public abstract class EfCoreTbHisBreweryRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbHisBrewery, int>
    {
        public EfCoreTbHisBreweryRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
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
            int? idBreweryMin = null,
            int? idBreweryMax = null,
            string? breweryName = null,
            string? breweryName_EN = null,
            string? breweryAdress = null,
            string? briefName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            decimal? capacityVolumeMin = null,
            decimal? capacityVolumeMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
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

            query = ApplyFilter(query, filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idBreweryMin, idBreweryMax, breweryName, breweryName_EN, breweryAdress, briefName, companyIdMin, companyIdMax, capacityVolumeMin, capacityVolumeMax, deliveryVolumeMin, deliveryVolumeMax, note, docStatusMin, docStatusMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbHisBrewery>> GetListAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idBreweryMin = null,
            int? idBreweryMax = null,
            string? breweryName = null,
            string? breweryName_EN = null,
            string? breweryAdress = null,
            string? briefName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            decimal? capacityVolumeMin = null,
            decimal? capacityVolumeMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idBreweryMin, idBreweryMax, breweryName, breweryName_EN, breweryAdress, briefName, companyIdMin, companyIdMax, capacityVolumeMin, capacityVolumeMax, deliveryVolumeMin, deliveryVolumeMax, note, docStatusMin, docStatusMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisBreweryConsts.GetDefaultSorting(false) : sorting);
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
            int? idBreweryMin = null,
            int? idBreweryMax = null,
            string? breweryName = null,
            string? breweryName_EN = null,
            string? breweryAdress = null,
            string? briefName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            decimal? capacityVolumeMin = null,
            decimal? capacityVolumeMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, idBreweryMin, idBreweryMax, breweryName, breweryName_EN, breweryAdress, briefName, companyIdMin, companyIdMax, capacityVolumeMin, capacityVolumeMax, deliveryVolumeMin, deliveryVolumeMax, note, docStatusMin, docStatusMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbHisBrewery> ApplyFilter(
            IQueryable<TbHisBrewery> query,
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            int? idBreweryMin = null,
            int? idBreweryMax = null,
            string? breweryName = null,
            string? breweryName_EN = null,
            string? breweryAdress = null,
            string? briefName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            decimal? capacityVolumeMin = null,
            decimal? capacityVolumeMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BreweryName.ToLower().Contains(filterText.ToLower()) || e.BreweryName_EN.ToLower().Contains(filterText.ToLower()) || e.BreweryAdress.ToLower().Contains(filterText.ToLower()) || e.BriefName.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(isSendMail.HasValue, e => e.IsSendMail == isSendMail)
                    .WhereIf(dateSendMailMin.HasValue, e => e.DateSendMail >= dateSendMailMin!.Value)
                    .WhereIf(dateSendMailMax.HasValue, e => e.DateSendMail <= dateSendMailMax!.Value)
                    .WhereIf(insertDateMin.HasValue, e => e.InsertDate >= insertDateMin!.Value)
                    .WhereIf(insertDateMax.HasValue, e => e.InsertDate <= insertDateMax!.Value)
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value)
                    .WhereIf(idBreweryMin.HasValue, e => e.IdBrewery >= idBreweryMin!.Value)
                    .WhereIf(idBreweryMax.HasValue, e => e.IdBrewery <= idBreweryMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(breweryName), e => e.BreweryName.ToLower().Contains(breweryName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(breweryName_EN), e => e.BreweryName_EN.ToLower().Contains(breweryName_EN.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(breweryAdress), e => e.BreweryAdress.ToLower().Contains(breweryAdress.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(briefName), e => e.BriefName.ToLower().Contains(briefName.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(capacityVolumeMin.HasValue, e => e.CapacityVolume >= capacityVolumeMin!.Value)
                    .WhereIf(capacityVolumeMax.HasValue, e => e.CapacityVolume <= capacityVolumeMax!.Value)
                    .WhereIf(deliveryVolumeMin.HasValue, e => e.DeliveryVolume >= deliveryVolumeMin!.Value)
                    .WhereIf(deliveryVolumeMax.HasValue, e => e.DeliveryVolume <= deliveryVolumeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))

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