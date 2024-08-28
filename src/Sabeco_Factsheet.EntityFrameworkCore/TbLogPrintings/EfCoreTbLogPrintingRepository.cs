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

namespace Sabeco_Factsheet.TbLogPrintings
{
    public abstract class EfCoreTbLogPrintingRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogPrinting, int>
    {
        public EfCoreTbLogPrintingRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, userName, companyCode, fileLanguage, isPrinting, printTimeMin, printTimeMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogPrinting>> GetListAsync(
            string? filterText = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userName, companyCode, fileLanguage, isPrinting, printTimeMin, printTimeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogPrintingConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userName, companyCode, fileLanguage, isPrinting, printTimeMin, printTimeMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogPrinting> ApplyFilter(
            IQueryable<TbLogPrinting> query,
            string? filterText = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.userName.ToLower().Contains(filterText.ToLower()) || e.companyCode.ToLower().Contains(filterText.ToLower()) || e.fileLanguage.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.userName.ToLower().Contains(userName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.companyCode.ToLower().Contains(companyCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileLanguage), e => e.fileLanguage.ToLower().Contains(fileLanguage.ToLower()))
                    .WhereIf(isPrinting.HasValue, e => e.isPrinting == isPrinting)
                    .WhereIf(printTimeMin.HasValue, e => e.printTime >= printTimeMin!.Value)
                    .WhereIf(printTimeMax.HasValue, e => e.printTime <= printTimeMax!.Value);
        }
    }
}