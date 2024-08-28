using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbSkus
{
    public partial interface ITbSkusAppService
    {
        //HQSOFT's generated code:
        Task<List<TbSkuDto>> GetListNoPagedAsync(GetTbSkusInput input);

        //Write your custom code here...

    }
}