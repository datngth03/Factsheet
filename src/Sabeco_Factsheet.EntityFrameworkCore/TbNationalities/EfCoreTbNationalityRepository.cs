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

namespace Sabeco_Factsheet.TbNationalities
{
    public abstract class EfCoreTbNationalityRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbNationality, int>
    {
        public EfCoreTbNationalityRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, code, code2, name_en, name_vn, isActive);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbNationality>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, code2, name_en, name_vn, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbNationalityConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, code2, name_en, name_vn, isActive);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbNationality> ApplyFilter(
            IQueryable<TbNationality> query,
            string? filterText = null,
            string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code.ToLower().Contains(filterText.ToLower()) || e.Code2.ToLower().Contains(filterText.ToLower()) || e.Name_en.ToLower().Contains(filterText.ToLower()) || e.Name_vn.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.ToLower().Contains(code.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(code2), e => e.Code2.ToLower().Contains(code2.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name_en), e => e.Name_en.ToLower().Contains(name_en.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(name_vn), e => e.Name_vn.ToLower().Contains(name_vn.ToLower()))
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }
    }
}