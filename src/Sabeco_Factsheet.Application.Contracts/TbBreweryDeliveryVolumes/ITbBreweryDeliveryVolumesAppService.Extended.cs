using System.Collections.Generic;
using System.Threading.Tasks;
using static Sabeco_Factsheet.Permissions.Sabeco_FactsheetPermissions;
using Volo.Abp.ObjectMapping;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public partial interface ITbBreweryDeliveryVolumesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBreweryDeliveryVolumeDto>> GetListNoPagedAsync(GetTbBreweryDeliveryVolumesInput input);

        //Write your custom code here...
        Task<List<TbBreweryDeliveryVolumeDto>> GetListByBreweryId(int id);
    }
}