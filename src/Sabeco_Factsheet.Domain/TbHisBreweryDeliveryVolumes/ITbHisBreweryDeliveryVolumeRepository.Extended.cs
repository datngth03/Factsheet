using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public partial interface ITbHisBreweryDeliveryVolumeRepository
    {
        //HQSOFT's generated code:
        Task<List<TbHisBreweryDeliveryVolume>> GetListNoPagedAsync(
                    string? filterText = null,
                    bool? isSendMail = null,
                    DateTime? dateSendMailMin = null,
                    DateTime? dateSendMailMax = null,
                    DateTime? insertDateMin = null,
                    DateTime? insertDateMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
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
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}