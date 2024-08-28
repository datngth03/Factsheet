using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbStockPrices
{
    public partial interface ITbStockPricesAppService
    {
        //HQSOFT's generated code:
        Task<List<TbStockPriceDto>> GetListNoPagedAsync(GetTbStockPricesInput input);

        //Write your custom code here...

    }
}