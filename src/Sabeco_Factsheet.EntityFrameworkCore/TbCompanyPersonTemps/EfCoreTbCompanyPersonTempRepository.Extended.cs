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

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public class EfCoreTbCompanyPersonTempRepository : EfCoreTbCompanyPersonTempRepositoryBase, ITbCompanyPersonTempRepository
    {
        public EfCoreTbCompanyPersonTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyPersonTemp>> GetListNoPagedAsync(
            string? filterText = null,
            int? idCompanyPersonMin = null,
            int? idCompanyPersonMax = null,
            string? branchCode = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? personIdMin = null,
            int? personIdMax = null,
            int? positionIdMin = null,
            int? positionIdMax = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
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
            bool? isDeleted = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, idCompanyPersonMin, idCompanyPersonMax, branchCode, companyIdMin, companyIdMax, personIdMin, personIdMax, positionIdMin, positionIdMax, fromDateMin, fromDateMax, toDateMin, toDateMax, positionTypeMin, positionTypeMax, positionCode, personalValueMin, personalValueMax, personalSharePercentageMin, personalSharePercentageMax, ownerValueMin, ownerValueMax, representativePercentageMin, representativePercentageMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyPersonTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}