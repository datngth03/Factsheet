using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public partial interface ITbHisBreweriesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisBreweryDto>> GetListNoPagedAsync(GetTbHisBreweriesInput input);

        //Write your custom code here...

    }
}