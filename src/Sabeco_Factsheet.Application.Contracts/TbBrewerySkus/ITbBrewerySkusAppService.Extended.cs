using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public partial interface ITbBrewerySkusAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBrewerySkuDto>> GetListNoPagedAsync(GetTbBrewerySkusInput input);

        //Write your custom code here...

        Task<List<TbBrewerySkuDto>> GetListByBreweryId(int id);
    }
}