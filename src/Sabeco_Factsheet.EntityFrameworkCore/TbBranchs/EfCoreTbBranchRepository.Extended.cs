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

namespace Sabeco_Factsheet.TbBranchs
{
    public class EfCoreTbBranchRepository : EfCoreTbBranchRepositoryBase, ITbBranchRepository
    {
        public EfCoreTbBranchRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBranch>> GetListNoPagedAsync(
            string? filterText = null,
            string? code = null,
            string? briefName = null,
            string? name = null,
            string? name_EN = null,
            string? companyCode = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_DateMin = null,
            DateTime? crt_DateMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, briefName, name, name_EN, companyCode, description, isActive, crt_DateMin, crt_DateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbBranchConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}