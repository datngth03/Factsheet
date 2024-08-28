using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sabeco_Factsheet.TbCompanyTemps
{
    public partial interface ITbCompanyTempsAppService
    {
        //HQSOFT's generated code:
        Task<List<TbCompanyTempDto>> GetListNoPagedAsync(GetTbCompanyTempsInput input);

        //Write your custom code here...

    }
}