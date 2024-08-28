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
using Sabeco_Factsheet.TbCompanyPersons;

namespace Sabeco_Factsheet.TbUsers
{
    public class EfCoreTbUserRepository : EfCoreTbUserRepositoryBase, ITbUserRepository
    {
        public EfCoreTbUserRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbUser>> GetListNoPagedAsync(
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            Guid? abpUserId = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userPrincipalName, userName, fullName, email, companyIdMin, companyIdMax, docStatusMin, docStatusMax, isActive, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax, abpUserId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }

        //Write your custom code here...

        public virtual async Task<TbUser?> GetByAbpUserIdAsync(
            Guid? abpUserId,
            CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync())
                .Where(x => x.AbpUserId == abpUserId)
                .OrderBy(x => x.UserName);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<List<TbUser>> GetListByAbpUserId(
            Guid? abpUserId = null,
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            string? sorting = null,
         CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.AbpUserId == abpUserId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbUserConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
    }
}