using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public partial interface ITbBreweryDeliveryVolumeTempRepository : IRepository<TbBreweryDeliveryVolumeTemp, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? idBreweryDeliveryVolumeMin = null,
            int? idBreweryDeliveryVolumeMax = null,
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
            CancellationToken cancellationToken = default);
        Task<List<TbBreweryDeliveryVolumeTemp>> GetListAsync(
                    string? filterText = null,
                    int? idBreweryDeliveryVolumeMin = null,
                    int? idBreweryDeliveryVolumeMax = null,
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
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? idBreweryDeliveryVolumeMin = null,
            int? idBreweryDeliveryVolumeMax = null,
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
            CancellationToken cancellationToken = default);
    }
}