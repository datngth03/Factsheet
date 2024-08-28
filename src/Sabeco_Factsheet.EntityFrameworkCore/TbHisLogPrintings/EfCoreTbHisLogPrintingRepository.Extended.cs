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

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public class EfCoreTbHisLogPrintingRepository : EfCoreTbHisLogPrintingRepositoryBase, ITbHisLogPrintingRepository
    {
        public EfCoreTbHisLogPrintingRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbHisLogPrinting>> GetListNoPagedAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, isSendMail, dateSendMailMin, dateSendMailMax, typeMin, typeMax, insertDateMin, insertDateMax, userName, companyCode, fileLanguage, isPrinting);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbHisLogPrintingConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}