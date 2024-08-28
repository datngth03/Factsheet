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

namespace Sabeco_Factsheet.TbInvests
{
    public class EfCoreTbInvestRepository : EfCoreTbInvestRepositoryBase, ITbInvestRepository
    {
        public EfCoreTbInvestRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbInvest>> GetListNoPagedAsync(
            string? filterText = null,
            string? branchCode = null,
            int? branchIdMin = null,
            int? branchIdMax = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            int? shareNumTotalMin = null,
            int? shareNumTotalMax = null,
            decimal? shareValueTotalMin = null,
            decimal? shareValueTotalMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? investGroup = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, branchCode, branchIdMin, branchIdMax, companyIdMin, companyIdMax, companyCode, shareNumTotalMin, shareNumTotalMax, shareValueTotalMin, shareValueTotalMax, note, docStatusMin, docStatusMax, investGroup, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbInvestConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}