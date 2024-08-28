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

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public class EfCoreTbLogRefeshAccountRepository : EfCoreTbLogRefeshAccountRepositoryBase, ITbLogRefeshAccountRepository
    {
        public EfCoreTbLogRefeshAccountRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogRefeshAccount>> GetListNoPagedAsync(
            string? filterText = null,
            string? accessToken = null,
            DateTime? timeRefeshMin = null,
            DateTime? timeRefeshMax = null,
            bool? isSuccess = null,
            string? useRefesh = null,
            string? failedReason = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, accessToken, timeRefeshMin, timeRefeshMax, isSuccess, useRefesh, failedReason);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogRefeshAccountConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}