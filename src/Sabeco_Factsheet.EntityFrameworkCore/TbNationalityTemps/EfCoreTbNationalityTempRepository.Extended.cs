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

namespace Sabeco_Factsheet.TbNationalityTemps
{
    public class EfCoreTbNationalityTempRepository : EfCoreTbNationalityTempRepositoryBase, ITbNationalityTempRepository
    {
        public EfCoreTbNationalityTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbNationalityTemp>> GetListNoPagedAsync(
            string? filterText = null,
            string? code = null,
            string? code2 = null,
            string? name_en = null,
            string? name_vn = null,
            bool? isActive = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, code2, name_en, name_vn, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbNationalityTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}