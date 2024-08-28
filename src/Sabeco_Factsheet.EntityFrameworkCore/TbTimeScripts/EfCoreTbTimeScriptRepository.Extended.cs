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

namespace Sabeco_Factsheet.TbTimeScripts
{
    public class EfCoreTbTimeScriptRepository : EfCoreTbTimeScriptRepositoryBase, ITbTimeScriptRepository
    {
        public EfCoreTbTimeScriptRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbTimeScript>> GetListNoPagedAsync(
            string? filterText = null,
            string? code = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
            int? dayMin = null,
            int? dayMax = null,
            int? hourMin = null,
            int? hourMax = null,
            int? minuteMin = null,
            int? minuteMax = null,
            int? secondMin = null,
            int? secondMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, yearMin, yearMax, monthMin, monthMax, dayMin, dayMax, hourMin, hourMax, minuteMin, minuteMax, secondMin, secondMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbTimeScriptConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}