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

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public class EfCoreTbUserMappingPersonRepository : EfCoreTbUserMappingPersonRepositoryBase, ITbUserMappingPersonRepository
    {
        public EfCoreTbUserMappingPersonRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbUserMappingPerson>> GetListNoPagedAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? personidMin = null,
            int? personidMax = null,
            bool? isActive = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, useridMin, useridMax, personidMin, personidMax, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserMappingPersonConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}