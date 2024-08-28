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

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public class EfCoreTbAdditionInfoTempRepository : EfCoreTbAdditionInfoTempRepositoryBase, ITbAdditionInfoTempRepository
    {
        public EfCoreTbAdditionInfoTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbAdditionInfoTemp>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            string? typeOfGroup = null,
            string? typeOfEvent = null,
            string? description = null,
            string? noOfDocument = null,
            string? remark = null,
            bool? isActive = null,
            int? create_userMin = null,
            int? create_userMax = null,
            DateTime? create_dateMin = null,
            DateTime? create_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, docDateMin, docDateMax, typeOfGroup, typeOfEvent, description, noOfDocument, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbAdditionInfoTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}