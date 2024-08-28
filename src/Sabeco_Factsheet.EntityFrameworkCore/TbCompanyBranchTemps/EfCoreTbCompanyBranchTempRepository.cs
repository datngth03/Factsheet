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

namespace Sabeco_Factsheet.TbCompanyBranchTemps
{
    public abstract class EfCoreTbCompanyBranchTempRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbCompanyBranchTemp, int>
    {
        public EfCoreTbCompanyBranchTempRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? companyIdMin = null,
            int? companyIdMax = null,
            string? branchName = null,
            string? branchAddress = null,
            string? branchCode = null,
            string? contactPerson = null,
            string? contactPhone = null,
            string? email = null,
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

            query = ApplyFilter(query, filterText, companyIdMin, companyIdMax, branchName, branchAddress, branchCode, contactPerson, contactPhone, email, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbCompanyBranchTemp>> GetListAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? branchName = null,
            string? branchAddress = null,
            string? branchCode = null,
            string? contactPerson = null,
            string? contactPhone = null,
            string? email = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, branchName, branchAddress, branchCode, contactPerson, contactPhone, email, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyBranchTempConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? branchName = null,
            string? branchAddress = null,
            string? branchCode = null,
            string? contactPerson = null,
            string? contactPhone = null,
            string? email = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyIdMin, companyIdMax, branchName, branchAddress, branchCode, contactPerson, contactPhone, email, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbCompanyBranchTemp> ApplyFilter(
            IQueryable<TbCompanyBranchTemp> query,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? branchName = null,
            string? branchAddress = null,
            string? branchCode = null,
            string? contactPerson = null,
            string? contactPhone = null,
            string? email = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BranchName.ToLower().Contains(filterText.ToLower()) || e.BranchAddress.ToLower().Contains(filterText.ToLower()) || e.BranchCode.ToLower().Contains(filterText.ToLower()) || e.ContactPerson.ToLower().Contains(filterText.ToLower()) || e.ContactPhone.ToLower().Contains(filterText.ToLower()) || e.Email.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(branchName), e => e.BranchName.ToLower().Contains(branchName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(branchAddress), e => e.BranchAddress.ToLower().Contains(branchAddress.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(branchCode), e => e.BranchCode.ToLower().Contains(branchCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPerson), e => e.ContactPerson.ToLower().Contains(contactPerson.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPhone), e => e.ContactPhone.ToLower().Contains(contactPhone.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.ToLower().Contains(email.ToLower()))
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