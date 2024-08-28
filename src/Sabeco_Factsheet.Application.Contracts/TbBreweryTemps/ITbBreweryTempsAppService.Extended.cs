using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBreweryTemps
{
    public partial interface ITbBreweryTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBreweryTempDto>> GetListNoPagedAsync(GetTbBreweryTempsInput input);

        //Write your custom code here...

    }
}