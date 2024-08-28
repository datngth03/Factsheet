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

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public abstract class EfCoreTbAdditionInfoRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbAdditionInfo, int>
    {
        public EfCoreTbAdditionInfoRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
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

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, docDateMin, docDateMax, typeOfGroup, typeOfEvent, description, noOfDocument, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbAdditionInfo>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, docDateMin, docDateMax, typeOfGroup, typeOfEvent, description, noOfDocument, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbAdditionInfoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, docDateMin, docDateMax, typeOfGroup, typeOfEvent, description, noOfDocument, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbAdditionInfo> ApplyFilter(
            IQueryable<TbAdditionInfo> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.TypeOfGroup.ToLower().Contains(filterText.ToLower()) || e.TypeOfEvent.ToLower().Contains(filterText.ToLower()) || e.Description.ToLower().Contains(filterText.ToLower()) || e.NoOfDocument.ToLower().Contains(filterText.ToLower()) || e.Remark.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(docDateMin.HasValue, e => e.DocDate >= docDateMin!.Value)
                    .WhereIf(docDateMax.HasValue, e => e.DocDate <= docDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(typeOfGroup), e => e.TypeOfGroup.ToLower().Contains(typeOfGroup.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(typeOfEvent), e => e.TypeOfEvent.ToLower().Contains(typeOfEvent.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.ToLower().Contains(description.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(noOfDocument), e => e.NoOfDocument.ToLower().Contains(noOfDocument.ToLower()))
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