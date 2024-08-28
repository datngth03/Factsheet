using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbHisBreweries
{
    public partial interface ITbHisBreweryRepository
    {
        //HQSOFT's generated code:
        Task<List<TbHisBrewery>> GetListNoPagedAsync(
                    string? filterText = null,
                    bool? isSendMail = null,
                    DateTime? dateSendMailMin = null,
                    DateTime? dateSendMailMax = null,
                    DateTime? insertDateMin = null,
                    DateTime? insertDateMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    int? idBreweryMin = null,
                    int? idBreweryMax = null,
                    string? breweryName = null,
                    string? breweryName_EN = null,
                    string? breweryAdress = null,
                    string? briefName = null,
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