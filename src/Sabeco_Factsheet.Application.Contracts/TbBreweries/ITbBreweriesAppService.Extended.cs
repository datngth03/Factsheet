using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbBreweries
{
    public partial interface ITbBreweriesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbBreweryDto>> GetListNoPagedAsync(GetTbBreweriesInput input);

        //Write your custom code here...

    }
}