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

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public class EfCoreTbInfoUpdateRepository : EfCoreTbInfoUpdateRepositoryBase, ITbInfoUpdateRepository
    {
        public EfCoreTbInfoUpdateRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbInfoUpdate>> GetListNoPagedAsync(
            string? filterText = null,
            string? tableName = null,
            string? columnName = null,
            string? screenName = null,
            int? screenIdMin = null,
            int? screenIdMax = null,
            int? rowIdMin = null,
            int? rowIdMax = null,
            string? command = null,
            string? groupName = null,
            string? lastValue = null,
            string? newValue = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            string? comment = null,
            int? isActiveMin = null,
            int? isActiveMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            Guid? changeSetId = null,
            DateTime? timeAssessmentMin = null,
            DateTime? timeAssessmentMax = null,
            bool? isVisible = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, tableName, columnName, screenName, screenIdMin, screenIdMax, rowIdMin, rowIdMax, command, groupName, lastValue, newValue, docStatusMin, docStatusMax, comment, isActiveMin, isActiveMax, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, changeSetId, timeAssessmentMin, timeAssessmentMax, isVisible);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbInfoUpdateConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}