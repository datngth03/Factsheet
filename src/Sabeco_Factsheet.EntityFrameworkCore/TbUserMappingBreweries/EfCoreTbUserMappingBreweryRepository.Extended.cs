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

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public class EfCoreTbUserMappingBreweryRepository : EfCoreTbUserMappingBreweryRepositoryBase, ITbUserMappingBreweryRepository
    {
        public EfCoreTbUserMappingBreweryRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbUserMappingBrewery>> GetListNoPagedAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? breweryidMin = null,
            int? breweryidMax = null,
            bool? isActive = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, useridMin, useridMax, breweryidMin, breweryidMax, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserMappingBreweryConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}