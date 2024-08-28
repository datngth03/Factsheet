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

namespace Sabeco_Factsheet.TbInvestDetails
{
    public class EfCoreTbInvestDetailRepository : EfCoreTbInvestDetailRepositoryBase, ITbInvestDetailRepository
    {
        public EfCoreTbInvestDetailRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbInvestDetail>> GetListNoPagedAsync(
            string? filterText = null,
            int? parentIdMin = null,
            int? parentIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? docNo = null,
            int? investTypeMin = null,
            int? investTypeMax = null,
            int? shareNumMin = null,
            int? shareNumMax = null,
            decimal? shareValueMin = null,
            decimal? shareValueMax = null,
            string? note = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            bool? isDeleted = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentIdMin, parentIdMax, docDateMin, docDateMax, docNo, investTypeMin, investTypeMax, shareNumMin, shareNumMax, shareValueMin, shareValueMax, note, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbInvestDetailConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}