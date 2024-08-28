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

namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public class EfCoreTbHisCompanyPersonRepository : EfCoreTbHisCompanyPersonRepositoryBase, ITbHisCompanyPersonRepository
    {
        public EfCoreTbHisCompanyPersonRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbHisCompanyPerson>> GetListNoPagedAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            int? typeMin = null,
            int? typeMax = null,
            string? branchCode = null,
            int? idCompanyPersonMin = null,
            int? idCompanyPersonMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            int? positionIdMin = null,
            int? positionIdMax = null,
            string? positionCode = null,
            decimal? personalValueMin = null,
            decimal? personalValueMax = null,
            decimal? personalSharePercentageMin = null,
            decimal? personalSharePercentageMax = null,
            decimal? ownerValueMin = null,
            decimal? ownerValueMax = null,
            decimal? representativePercentageMin = null,
            decimal? representativePercentageMax = null,
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
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, insertDateMin, insertDateMax, typeMin, typeMax, branchCode, idCompanyPersonMin, idCompanyPersonMax, companyIdMin, companyIdMax, personIdMin, personIdMax, fromDateMin, fromDateMax, toDateMin, toDateMax, positionIdMin, positionIdMax, positionCode, personalValueMin, personalValueMax, personalSharePercentageMin, personalSharePercentageMax, ownerValueMin, ownerValueMax, representativePercentageMin, representativePercentageMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisCompanyPersonConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}