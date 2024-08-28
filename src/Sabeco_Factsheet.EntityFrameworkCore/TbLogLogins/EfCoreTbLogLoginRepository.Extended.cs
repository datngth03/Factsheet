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

namespace Sabeco_Factsheet.TbLogLogins
{
    public class EfCoreTbLogLoginRepository : EfCoreTbLogLoginRepositoryBase, ITbLogLoginRepository
    {
        public EfCoreTbLogLoginRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogLogin>> GetListNoPagedAsync(
            string? filterText = null,
            string? userName = null,
            DateTime? loginDateMin = null,
            DateTime? loginDateMax = null,
            string? iPTracking = null,
            bool? statusLogin = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userName, loginDateMin, loginDateMax, iPTracking, statusLogin);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogLoginConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}