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

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public abstract class EfCoreTbHisLogPrintingRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbHisLogPrinting, int>
    {
        public EfCoreTbHisLogPrintingRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, isSendMail, dateSendMailMin, dateSendMailMax, typeMin, typeMax, insertDateMin, insertDateMax, userName, companyCode, fileLanguage, isPrinting);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbHisLogPrinting>> GetListAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, typeMin, typeMax, insertDateMin, insertDateMax, userName, companyCode, fileLanguage, isPrinting);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisLogPrintingConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, typeMin, typeMax, insertDateMin, insertDateMax, userName, companyCode, fileLanguage, isPrinting);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbHisLogPrinting> ApplyFilter(
            IQueryable<TbHisLogPrinting> query,
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserName.ToLower().Contains(filterText.ToLower()) || e.CompanyCode.ToLower().Contains(filterText.ToLower()) || e.FileLanguage.ToLower().Contains(filterText.ToLower()))
                    .WhereIf(isSendMail.HasValue, e => e.IsSendMail == isSendMail)
                    .WhereIf(dateSendMailMin.HasValue, e => e.DateSendMail >= dateSendMailMin!.Value)
                    .WhereIf(dateSendMailMax.HasValue, e => e.DateSendMail <= dateSendMailMax!.Value)
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value)
                    .WhereIf(insertDateMin.HasValue, e => e.InsertDate >= insertDateMin!.Value)
                    .WhereIf(insertDateMax.HasValue, e => e.InsertDate <= insertDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.ToLower().Contains(userName.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.CompanyCode.ToLower().Contains(companyCode.ToLower()))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileLanguage), e => e.FileLanguage.ToLower().Contains(fileLanguage.ToLower()))
                    .WhereIf(isPrinting.HasValue, e => e.IsPrinting == isPrinting);
        }
    }
}