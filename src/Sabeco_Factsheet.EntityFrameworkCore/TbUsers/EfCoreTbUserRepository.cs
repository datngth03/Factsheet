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

namespace Sabeco_Factsheet.TbUsers
{
    public abstract class EfCoreTbUserRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbUser, int>
    {
        public EfCoreTbUserRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
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
            Guid? abpUserId = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, userPrincipalName, userName, fullName, email, companyIdMin, companyIdMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, abpUserId);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbUser>> GetListAsync(
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
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
            Guid? abpUserId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userPrincipalName, userName, fullName, email, companyIdMin, companyIdMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, abpUserId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
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
            Guid? abpUserId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userPrincipalName, userName, fullName, email, companyIdMin, companyIdMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, abpUserId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbUser> ApplyFilter(
            IQueryable<TbUser> query,
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
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
            Guid? abpUserId = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserPrincipalName.ToLower().Contains(filterText.ToLower()) || e.UserName.ToLower().Contains(filterText.ToLower()) || e.FullName.ToLower().Contains(filterText.ToLower()) || e.Email.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(userPrincipalName), e => e.UserPrincipalName.ToLower().Contains(userPrincipalName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.ToLower().Contains(userName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(fullName), e => e.FullName.ToLower().Contains(fullName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.ToLower().Contains(email.ToLower()))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)

                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_dateMin.HasValue, e => e.crt_date >= crt_dateMin!.Value)
                    .WhereIf(crt_dateMax.HasValue, e => e.crt_date <= crt_dateMax!.Value)
                    .WhereIf(crt_userMin.HasValue, e => e.crt_user >= crt_userMin!.Value)
                    .WhereIf(crt_userMax.HasValue, e => e.crt_user <= crt_userMax!.Value)
                    .WhereIf(mod_dateMin.HasValue, e => e.mod_date >= mod_dateMin!.Value)
                    .WhereIf(mod_dateMax.HasValue, e => e.mod_date <= mod_dateMax!.Value)
                    .WhereIf(mod_userMin.HasValue, e => e.mod_user >= mod_userMin!.Value)
                    .WhereIf(mod_userMax.HasValue, e => e.mod_user <= mod_userMax!.Value)
                    .WhereIf(abpUserId.HasValue, e => e.AbpUserId == abpUserId);
        }
    }
}