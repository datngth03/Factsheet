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

namespace Sabeco_Factsheet.TbInvestPersons
{
    public abstract class EfCoreTbInvestPersonRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbInvestPerson, int>
    {
        public EfCoreTbInvestPersonRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? parentIdMin = null,
            int? parentIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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

            query = ApplyFilter(query, filterText, parentIdMin, parentIdMax, personIdMin, personIdMax, fromDateMin, fromDateMax, personalValueMin, personalValueMax, ownerValueMin, ownerValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbInvestPerson>> GetListAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentIdMin, parentIdMax, personIdMin, personIdMax, fromDateMin, fromDateMax, personalValueMin, personalValueMax, ownerValueMin, ownerValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbInvestPersonConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, parentIdMin, parentIdMax, personIdMin, personIdMax, fromDateMin, fromDateMax, personalValueMin, personalValueMax, ownerValueMin, ownerValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbInvestPerson> ApplyFilter(
            IQueryable<TbInvestPerson> query,
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            int? personalValueMin = null,
            int? personalValueMax = null,
            int? ownerValueMin = null,
            int? ownerValueMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(parentIdMin.HasValue, e => e.ParentId >= parentIdMin!.Value)
                    .WhereIf(parentIdMax.HasValue, e => e.ParentId <= parentIdMax!.Value)
                    .WhereIf(personIdMin.HasValue, e => e.PersonId >= personIdMin!.Value)
                    .WhereIf(personIdMax.HasValue, e => e.PersonId <= personIdMax!.Value)
                    .WhereIf(fromDateMin.HasValue, e => e.FromDate >= fromDateMin!.Value)
                    .WhereIf(fromDateMax.HasValue, e => e.FromDate <= fromDateMax!.Value)
                    .WhereIf(personalValueMin.HasValue, e => e.PersonalValue >= personalValueMin!.Value)
                    .WhereIf(personalValueMax.HasValue, e => e.PersonalValue <= personalValueMax!.Value)
                    .WhereIf(ownerValueMin.HasValue, e => e.OwnerValue >= ownerValueMin!.Value)
                    .WhereIf(ownerValueMax.HasValue, e => e.OwnerValue <= ownerValueMax!.Value)
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