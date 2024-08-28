using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public partial interface ITbBreweryDeliveryVolumeTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBreweryDeliveryVolumeTempDto>> GetListNoPagedAsync(GetTbBreweryDeliveryVolumeTempsInput input);

        //Write your custom code here...

    }
}