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

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public class EfCoreTbLogSendEmailRepository : EfCoreTbLogSendEmailRepositoryBase, ITbLogSendEmailRepository
    {
        public EfCoreTbLogSendEmailRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogSendEmail>> GetListNoPagedAsync(
            string? filterText = null,
            DateTime? timeSendMin = null,
            DateTime? timeSendMax = null,
            bool? isSuccess = null,
            string? userSend = null,
            string? typeEmail = null,
            string? failedReason = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, timeSendMin, timeSendMax, isSuccess, userSend, typeEmail, failedReason);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogSendEmailConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}