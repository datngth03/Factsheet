using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public partial interface ITbHisBreweryDeliveryVolumesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisBreweryDeliveryVolumeDto>> GetListNoPagedAsync(GetTbHisBreweryDeliveryVolumesInput input);

        //Write your custom code here...

    }
}