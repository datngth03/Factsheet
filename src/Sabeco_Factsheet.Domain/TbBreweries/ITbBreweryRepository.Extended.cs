using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbBreweries
{
    public partial interface ITbBreweryRepository
    {
        //HQSOFT's generated code:
        Task<List<TbBrewery>> GetListNoPagedAsync(
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
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}