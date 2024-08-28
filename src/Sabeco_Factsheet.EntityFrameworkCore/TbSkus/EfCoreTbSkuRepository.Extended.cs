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

namespace Sabeco_Factsheet.TbSkus
{
    public class EfCoreTbSkuRepository : EfCoreTbSkuRepositoryBase, ITbSkuRepository
    {
        public EfCoreTbSkuRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbSku>> GetListNoPagedAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? name_EN = null,
            string? brandCode = null,
            string? unit = null,
            string? itemBaseType = null,
            decimal? packSizeMin = null,
            decimal? packSizeMax = null,
            int? packQuantityMin = null,
            int? packQuantityMax = null,
            decimal? weightMin = null,
            decimal? weightMax = null,
            int? expiryDateMin = null,
            int? expiryDateMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            string? sorting = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, name_EN, brandCode, unit, itemBaseType, packSizeMin, packSizeMax, packQuantityMin, packQuantityMax, weightMin, weightMax, expiryDateMin, expiryDateMax, isActive, crt_userMin, crt_userMax, crt_dateMin, crt_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbSkuConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}