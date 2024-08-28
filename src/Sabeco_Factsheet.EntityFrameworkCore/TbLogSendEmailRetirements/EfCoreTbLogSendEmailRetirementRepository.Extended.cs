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

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public class EfCoreTbLogSendEmailRetirementRepository : EfCoreTbLogSendEmailRetirementRepositoryBase, ITbLogSendEmailRetirementRepository
    {
        public EfCoreTbLogSendEmailRetirementRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLogSendEmailRetirement>> GetListNoPagedAsync(
            string? filterText = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, idCompanyMin, idCompanyMax, idPersonMin, idPersonMax, isSendEmail, dateSendEmailMin, dateSendEmailMax, typeMin, typeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLogSendEmailRetirementConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}