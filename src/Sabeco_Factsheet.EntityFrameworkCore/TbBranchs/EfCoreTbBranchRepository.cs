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

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class EfCoreTbBranchRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbBranch, int>
    {
        public EfCoreTbBranchRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, code, briefName, name, name_EN, companyCode, description, isActive, crt_DateMin, crt_DateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbBranch>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, briefName, name, name_EN, companyCode, description, isActive, crt_DateMin, crt_DateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbBranchConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, briefName, name, name_EN, companyCode, description, isActive, crt_DateMin, crt_DateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbBranch> ApplyFilter(
            IQueryable<TbBranch> query,
            string? filterText = null,
            string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.BriefName.ToLower().Contains(filterText.ToLower()) || e.Name.ToLower().Contains(filterText.ToLower()) || e.Name_EN.ToLower().Contains(filterText.ToLower()) || e.CompanyCode.ToLower().Contains(filterText.ToLower()) || e.Description.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(briefName), e => e.BriefName.ToLower().Contains(briefName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.ToLower().Contains(name.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name_EN), e => e.Name_EN.ToLower().Contains(name_EN.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.CompanyCode.ToLower().Contains(companyCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.ToLower().Contains(description.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                    .WhereIf(crt_DateMin.HasValue, e => e.Crt_Date >= crt_DateMin!.Value)
                    .WhereIf(crt_DateMax.HasValue, e => e.Crt_Date <= crt_DateMax!.Value);
        }
    }
}