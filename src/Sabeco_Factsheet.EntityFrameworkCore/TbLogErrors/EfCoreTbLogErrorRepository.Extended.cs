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

namespace Sabeco_Factsheet.TbLogErrors
{
    public class EfCoreTbLogErrorRepository : EfCoreTbLogErrorRepositoryBase, ITbLogErrorRepository
    {
        public EfCoreTbLogErrorRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogError>> GetListNoPagedAsync(
            string? filterText = null,
            DateTime? timeLogMin = null,
            DateTime? timeLogMax = null,
            int? userLogMin = null,
            int? userLogMax = null,
            string? iPAddress = null,
            string? classLog = null,
            string? functionLog = null,
            string? reasonFailed = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeLogMin, timeLogMax, userLogMin, userLogMax, iPAddress, classLog, functionLog, reasonFailed);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogErrorConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}