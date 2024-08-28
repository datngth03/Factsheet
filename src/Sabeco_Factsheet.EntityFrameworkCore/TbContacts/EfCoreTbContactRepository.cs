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

namespace Sabeco_Factsheet.TbContacts
{
    public abstract class EfCoreTbContactRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbContact, int>
    {
        public EfCoreTbContactRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, companyidMin, companyidMax, contactName, contactDept, contactPosition, contactEmail, contactPhone, note, docStatusMin, docStatusMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, isDeleted);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbContact>> GetListAsync(
            string? filterText = null,
            int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyidMin, companyidMax, contactName, contactDept, contactPosition, contactEmail, contactPhone, note, docStatusMin, docStatusMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbContactConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyidMin, companyidMax, contactName, contactDept, contactPosition, contactEmail, contactPhone, note, docStatusMin, docStatusMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, isDeleted);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbContact> ApplyFilter(
            IQueryable<TbContact> query,
            string? filterText = null,
            int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ContactName.ToLower().Contains(filterText.ToLower()) || e.ContactDept.ToLower().Contains(filterText.ToLower()) || e.ContactPosition.ToLower().Contains(filterText.ToLower()) || e.ContactEmail.ToLower().Contains(filterText.ToLower()) || e.ContactPhone.ToLower().Contains(filterText.ToLower()) || e.Note.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyidMin.HasValue, e => e.companyid >= companyidMin!.Value)
                    .WhereIf(companyidMax.HasValue, e => e.companyid <= companyidMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName), e => e.ContactName.ToLower().Contains(contactName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactDept), e => e.ContactDept.ToLower().Contains(contactDept.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPosition), e => e.ContactPosition.ToLower().Contains(contactPosition.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactEmail), e => e.ContactEmail.ToLower().Contains(contactEmail.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPhone), e => e.ContactPhone.ToLower().Contains(contactPhone.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.ToLower().Contains(note.ToLower()))

                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(isDeleted.HasValue, e => e.IsDeleted == isDeleted);
        }
    }
}