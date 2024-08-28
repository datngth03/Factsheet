using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public partial interface ITbBrewerySkuTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBrewerySkuTempDto>> GetListNoPagedAsync(GetTbBrewerySkuTempsInput input);

        //Write your custom code here...

    }
}