using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public partial interface ITbCompanyBusinessTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyBusinessTempDto>> GetListNoPagedAsync(GetTbCompanyBusinessTempsInput input);

        //Write your custom code here...

    }
}