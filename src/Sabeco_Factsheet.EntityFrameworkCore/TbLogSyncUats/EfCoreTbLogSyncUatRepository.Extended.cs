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

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public class EfCoreTbLogSyncUatRepository : EfCoreTbLogSyncUatRepositoryBase, ITbLogSyncUatRepository
    {
        public EfCoreTbLogSyncUatRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogSyncUat>> GetListNoPagedAsync(
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? reasonExportFailed = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeExportMin, timeExportMax, isSuccess, userExportMin, userExportMax, reasonExportFailed);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogSyncUatConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}