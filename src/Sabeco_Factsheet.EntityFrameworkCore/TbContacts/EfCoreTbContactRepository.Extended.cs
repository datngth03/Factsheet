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

namespace Sabeco_Factsheet.TbContacts
{
    public class EfCoreTbContactRepository : EfCoreTbContactRepositoryBase, ITbContactRepository
    {
        public EfCoreTbContactRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbContact>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyidMin, companyidMax, contactName, contactDept, contactPosition, contactEmail, contactPhone, note, docStatusMin, docStatusMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax, isDeleted);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbContactConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}