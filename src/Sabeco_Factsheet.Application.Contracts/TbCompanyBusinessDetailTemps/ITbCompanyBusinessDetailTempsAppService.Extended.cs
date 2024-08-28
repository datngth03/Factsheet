using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{
    public partial interface ITbCompanyBusinessDetailTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBusinessDetailTempDto>> GetListNoPagedAsync(GetTbCompanyBusinessDetailTempsInput input);

        //Write your custom code here...

    }
}