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

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public class EfCoreTbConfigRetirementTimeRepository : EfCoreTbConfigRetirementTimeRepositoryBase, ITbConfigRetirementTimeRepository
    {
        public EfCoreTbConfigRetirementTimeRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbConfigRetirementTime>> GetListNoPagedAsync(
            string? filterText = null,
            string? code = null,
            int? yearNumbMin = null,
            int? yearNumbMax = null,
            int? monthNumbMin = null,
            int? monthNumbMax = null,
            int? dayNumbMin = null,
            int? dayNumbMax = null,
            string? note = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, yearNumbMin, yearNumbMax, monthNumbMin, monthNumbMax, dayNumbMin, dayNumbMax, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbConfigRetirementTimeConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}