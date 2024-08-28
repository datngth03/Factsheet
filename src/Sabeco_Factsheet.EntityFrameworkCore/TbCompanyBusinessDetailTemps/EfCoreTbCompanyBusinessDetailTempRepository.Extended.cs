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

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{
    public class EfCoreTbCompanyBusinessDetailTempRepository : EfCoreTbCompanyBusinessDetailTempRepositoryBase, ITbCompanyBusinessDetailTempRepository
    {
        public EfCoreTbCompanyBusinessDetailTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyBusinessDetailTemp>> GetListNoPagedAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            string? registrationCode = null,
            string? registrationName = null,
            string? registrationName_EN = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentIdMin, parentIdMax, registrationCode, registrationName, registrationName_EN, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyBusinessDetailTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}