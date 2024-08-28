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

namespace Sabeco_Factsheet.TbPositions
{
    public class EfCoreTbPositionRepository : EfCoreTbPositionRepositoryBase, ITbPositionRepository
    {
        public EfCoreTbPositionRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbPosition>> GetListNoPagedAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            byte? positionTypeMin = null,
            byte? positionTypeMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? ctr_dateMin = null,
            DateTime? ctr_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? orderNumbMin = null,
            int? orderNumbMax = null,
            bool? isDeleted = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, name_EN, positionTypeMin, positionTypeMax, isActive, crt_userMin, crt_userMax, ctr_dateMin, ctr_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, orderNumbMin, orderNumbMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbPositionConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}