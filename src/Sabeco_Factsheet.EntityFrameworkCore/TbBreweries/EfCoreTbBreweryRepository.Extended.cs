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

namespace Sabeco_Factsheet.TbBreweries
{
    public class EfCoreTbBreweryRepository : EfCoreTbBreweryRepositoryBase, ITbBreweryRepository
    {
        public EfCoreTbBreweryRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBrewery>> GetListNoPagedAsync(
            string? filterText = null,
            string? breweryCode = null,
            string? breweryName = null,
            string? breweryName_EN = null,
            string? briefName = null,
            string? breweryAdress = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            decimal? capacityVolumeMin = null,
            decimal? capacityVolumeMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, breweryCode, breweryName, breweryName_EN, briefName, breweryAdress, companyIdMin, companyIdMax, capacityVolumeMin, capacityVolumeMax, deliveryVolumeMin, deliveryVolumeMax, note, docStatusMin, docStatusMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbBreweryConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...
    }
}