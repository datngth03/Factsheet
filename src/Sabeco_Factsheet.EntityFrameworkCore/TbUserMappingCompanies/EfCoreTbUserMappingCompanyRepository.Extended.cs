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

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public class EfCoreTbUserMappingCompanyRepository : EfCoreTbUserMappingCompanyRepositoryBase, ITbUserMappingCompanyRepository
    {
        public EfCoreTbUserMappingCompanyRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbUserMappingCompany>> GetListNoPagedAsync(
            string? filterText = null,
            int? useridMin = null,
            int? useridMax = null,
            int? companyidMin = null,
            int? companyidMax = null,
            bool? isActive = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, useridMin, useridMax, companyidMin, companyidMax, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserMappingCompanyConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}