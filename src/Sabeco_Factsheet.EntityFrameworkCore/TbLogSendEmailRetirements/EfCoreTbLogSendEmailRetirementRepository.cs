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

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public abstract class EfCoreTbLogSendEmailRetirementRepositoryBase : EfCoreRepository<Sabeco_FactsheetDbContext, TbLogSendEmailRetirement, int>
    {
        public EfCoreTbLogSendEmailRetirementRepositoryBase(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, idCompanyMin, idCompanyMax, idPersonMin, idPersonMax, isSendEmail, dateSendEmailMin, dateSendEmailMax, typeMin, typeMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TbLogSendEmailRetirement>> GetListAsync(
            string? filterText = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, idCompanyMin, idCompanyMax, idPersonMin, idPersonMax, isSendEmail, dateSendEmailMin, dateSendEmailMax, typeMin, typeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogSendEmailRetirementConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, idCompanyMin, idCompanyMax, idPersonMin, idPersonMax, isSendEmail, dateSendEmailMin, dateSendEmailMax, typeMin, typeMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TbLogSendEmailRetirement> ApplyFilter(
            IQueryable<TbLogSendEmailRetirement> query,
            string? filterText = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(idCompanyMin.HasValue, e => e.idCompany >= idCompanyMin!.Value)
                    .WhereIf(idCompanyMax.HasValue, e => e.idCompany <= idCompanyMax!.Value)
                    .WhereIf(idPersonMin.HasValue, e => e.idPerson >= idPersonMin!.Value)
                    .WhereIf(idPersonMax.HasValue, e => e.idPerson <= idPersonMax!.Value)
                    .WhereIf(isSendEmail.HasValue, e => e.IsSendEmail == isSendEmail)
                    .WhereIf(dateSendEmailMin.HasValue, e => e.DateSendEmail >= dateSendEmailMin!.Value)
                    .WhereIf(dateSendEmailMax.HasValue, e => e.DateSendEmail <= dateSendEmailMax!.Value)
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value);
        }
    }
}