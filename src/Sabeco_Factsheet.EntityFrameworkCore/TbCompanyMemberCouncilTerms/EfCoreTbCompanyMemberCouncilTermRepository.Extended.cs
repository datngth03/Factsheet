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

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public class EfCoreTbCompanyMemberCouncilTermRepository : EfCoreTbCompanyMemberCouncilTermRepositoryBase, ITbCompanyMemberCouncilTermRepository
    {
        public EfCoreTbCompanyMemberCouncilTermRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbCompanyMemberCouncilTerm>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            int? termFromMin = null,
            int? termFromMax = null,
            int? termEndMin = null,
            int? termEndMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, termFromMin, termFromMax, termEndMin, termEndMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbCompanyMemberCouncilTermConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}