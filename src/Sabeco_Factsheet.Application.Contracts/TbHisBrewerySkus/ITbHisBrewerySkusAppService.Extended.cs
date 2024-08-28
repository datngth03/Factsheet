using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public partial interface ITbHisBrewerySkusAppService
    {
        //HQSOFT's generated code:
        Task<List<TbHisBrewerySkuDto>> GetListNoPagedAsync(GetTbHisBrewerySkusInput input);

        //Write your custom code here...

    }
}