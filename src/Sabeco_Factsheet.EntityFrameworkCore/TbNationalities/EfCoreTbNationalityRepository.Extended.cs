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

namespace Sabeco_Factsheet.TbNationalities
{
    public class EfCoreTbNationalityRepository : EfCoreTbNationalityRepositoryBase, ITbNationalityRepository
    {
        public EfCoreTbNationalityRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbNationality>> GetListNoPagedAsync(
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
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbNationalityConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}