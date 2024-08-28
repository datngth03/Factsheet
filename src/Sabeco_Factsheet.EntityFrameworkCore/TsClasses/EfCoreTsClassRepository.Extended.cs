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

namespace Sabeco_Factsheet.TsClasses
{
    public class EfCoreTsClassRepository : EfCoreTsClassRepositoryBase, ITsClassRepository
    {
        public EfCoreTsClassRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TsClass>> GetListNoPagedAsync(
            string? filterText = null,
            string? parentCode = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? code_Type = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, parentCode, code, name, name_EN, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, code_Type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TsClassConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...

        public virtual async Task<List<TsClass>> GetListByParentCode(
            string? parentCode,
            string? filterText = null, 
            string? code = null,
            string? name = null,
            string? name_EN = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? code_Type = null,
            string? sorting = null,
         CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.ParentCode == parentCode);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TsClassConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
    }
}