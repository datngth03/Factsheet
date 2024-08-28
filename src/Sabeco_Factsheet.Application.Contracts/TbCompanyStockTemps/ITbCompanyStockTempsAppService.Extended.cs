using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public partial interface ITbCompanyStockTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyStockTempDto>> GetListNoPagedAsync(GetTbCompanyStockTempsInput input);

        //Write your custom code here...

    }
}