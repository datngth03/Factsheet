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

namespace Sabeco_Factsheet.TbAssets
{
    public class EfCoreTbAssetRepository : EfCoreTbAssetRepositoryBase, ITbAssetRepository
    {
        public EfCoreTbAssetRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbAsset>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? assetType = null,
            string? assetItem = null,
            string? assetAddress = null,
            decimal? quantityMin = null,
            decimal? quantityMax = null,
            string? docNo = null,
            DateTime? docDateMin = null,
            DateTime? docDateMax = null,
            DateTime? expireDateMin = null,
            DateTime? expireDateMax = null,
            string? description = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            bool? isDeleted = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, assetType, assetItem, assetAddress, quantityMin, quantityMax, docNo, docDateMin, docDateMax, expireDateMin, expireDateMax, description, docStatusMin, docStatusMax, isActive, isDeleted, crt_dateMin, crt_dateMax, crt_userMin, crt_userMax, mod_dateMin, mod_dateMax, mod_userMin, mod_userMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbAssetConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}