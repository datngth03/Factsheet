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

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public class EfCoreTbLogExportDataRepository : EfCoreTbLogExportDataRepositoryBase, ITbLogExportDataRepository
    {
        public EfCoreTbLogExportDataRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogExportData>> GetListNoPagedAsync(
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeExportMin, timeExportMax, isSuccess, userExportMin, userExportMax, tableName, reasonExportFailed);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogExportDataConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}