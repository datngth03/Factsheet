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

namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public class EfCoreTbLandInfoTempRepository : EfCoreTbLandInfoTempRepositoryBase, ITbLandInfoTempRepository
    {
        public EfCoreTbLandInfoTempRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbLandInfoTemp>> GetListNoPagedAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? description = null,
            string? address = null,
            string? typeOfLand = null,
            decimal? areaMin = null,
            decimal? areaMax = null,
            string? supportingDocument = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            string? payment = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyIdMin, companyIdMax, description, address, typeOfLand, areaMin, areaMax, supportingDocument, issueDateMin, issueDateMax, expiryDateMin, expiryDateMax, payment, remark, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbLandInfoTempConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}