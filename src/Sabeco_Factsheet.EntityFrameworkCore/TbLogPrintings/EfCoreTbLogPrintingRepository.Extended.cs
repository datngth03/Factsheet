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

namespace Sabeco_Factsheet.TbLogPrintings
{
    public class EfCoreTbLogPrintingRepository : EfCoreTbLogPrintingRepositoryBase, ITbLogPrintingRepository
    {
        public EfCoreTbLogPrintingRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogPrinting>> GetListNoPagedAsync(
            string? filterText = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null,
            string? sorting = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userName, companyCode, fileLanguage, isPrinting, printTimeMin, printTimeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogPrintingConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}