using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public partial interface ITbUserMappingBreweriesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbUserMappingBreweryDto>> GetListNoPagedAsync(GetTbUserMappingBreweriesInput input);

        //Write your custom code here...

    }
}