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

namespace Sabeco_Factsheet.TbTerms
{
    public class EfCoreTbTermRepository : EfCoreTbTermRepositoryBase, ITbTermRepository
    {
        public EfCoreTbTermRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbTerm>> GetListNoPagedAsync(
            string? filterText = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            string? termCode = null,
            int? fromYearMin = null,
            int? fromYearMax = null,
            int? toYearMin = null,
            int? toYearMax = null,
            string? description = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, branchIdMin, branchIdMax, termCode, fromYearMin, fromYearMax, toYearMin, toYearMax, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbTermConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}