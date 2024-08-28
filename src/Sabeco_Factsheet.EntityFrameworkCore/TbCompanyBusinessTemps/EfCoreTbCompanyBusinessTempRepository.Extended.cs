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

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public class EfCoreTbCompanyBusinessTempRepository : EfCoreTbCompanyBusinessTempRepositoryBase, ITbCompanyBusinessTempRepository
    {
        public EfCoreTbCompanyBusinessTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyBusinessTemp>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? license = null,
            byte? registrationNoMin = null,
            byte? registrationNoMax = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            string? companyName = null,
            string? companyAddress = null,
            string? legalRepresent = null,
            string? companyType = null,
            string? majorBusiness = null,
            string? otherActivity = null,
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
            DateTime? latestAmendmentMin = null,
            DateTime? latestAmendmentMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, license, registrationNoMin, registrationNoMax, registrationDateMin, registrationDateMax, companyName, companyAddress, legalRepresent, companyType, majorBusiness, otherActivity, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, latestAmendmentMin, latestAmendmentMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyBusinessTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}