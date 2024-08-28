using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public partial interface ITbCompanyStocksAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyStockDto>> GetListNoPagedAsync(GetTbCompanyStocksInput input);

        //Write your custom code here...

    }
}