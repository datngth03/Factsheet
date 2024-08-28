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

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public class EfCoreTbCompanyStockRepository : EfCoreTbCompanyStockRepositoryBase, ITbCompanyStockRepository
    {
        public EfCoreTbCompanyStockRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyStock>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyCode = null,
            bool? isPublicCompany = null,
            string? stockExchange = null,
            DateTime? registrationDateMin = null,
            DateTime? registrationDateMax = null,
            decimal? charteredCapitalMin = null,
            decimal? charteredCapitalMax = null,
            decimal? parValueMin = null,
            decimal? parValueMax = null,
            int? totalShareMin = null,
            int? totalShareMax = null,
            int? listedShareMin = null,
            int? listedShareMax = null,
            string? description = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            string? sorting = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, companyCode, isPublicCompany, stockExchange, registrationDateMin, registrationDateMax, charteredCapitalMin, charteredCapitalMax, parValueMin, parValueMax, totalShareMin, totalShareMax, listedShareMin, listedShareMax, description, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyStockConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}