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
using Sabeco_Factsheet.TbCompanyPersons;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public class EfCoreTbCompanyMappingRepository : EfCoreTbCompanyMappingRepositoryBase, ITbCompanyMappingRepository
    {
        public EfCoreTbCompanyMappingRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyMapping>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            string? sorting = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, companyTypeShareholdingCode, companyTypesCode, note, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, idCompanyTypeShareholdingCodeMin, idCompanyTypeShareholdingCodeMax, idCompanyTypesCodeMin, idCompanyTypesCodeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyMappingConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...

        public virtual async Task<List<TbCompanyMapping>> GetListByCompanyId(
            int? id,
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            string? sorting = null,
            CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.CompanyId == id);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyMappingConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }

    }
}