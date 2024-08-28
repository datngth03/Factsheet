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

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public class EfCoreTbBreweryDeliveryVolumeRepository : EfCoreTbBreweryDeliveryVolumeRepositoryBase, ITbBreweryDeliveryVolumeRepository
    {
        public EfCoreTbBreweryDeliveryVolumeRepository(IDbContextProvider<Sabeco_FactsheetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //HQSOFT's generated code:
        public virtual async Task<List<TbBreweryDeliveryVolume>> GetListNoPagedAsync(
            string? filterText = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            string? breweryCode = null,
            int? yearMin = null,
            int? yearMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, breweryIdMin, breweryIdMax, breweryCode, yearMin, yearMax, deliveryVolumeMin, deliveryVolumeMax, isActive, create_userMin, create_userMax, create_dateMin, create_dateMax, mod_userMin, mod_userMax, mod_dateMin, mod_dateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbBreweryDeliveryVolumeConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
        //Write your custom code here...

        public virtual async Task<List<TbBreweryDeliveryVolume>> GetListByBreweryId(
            int? id,
            string? filterText = null,
            int? breweryIdMin = null,
            int? breweryIdMax = null,
            string? breweryCode = null,
            int? yearMin = null,
            int? yearMax = null,
            decimal? deliveryVolumeMin = null,
            decimal? deliveryVolumeMax = null,
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
            var query = (await GetQueryableAsync()).Where(x => x.BreweryId == id);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TbBreweryDeliveryVolumeConsts.GetDefaultSorting(false) : sorting);
            return await query.ToListAsync(cancellationToken);
        }
    }
}